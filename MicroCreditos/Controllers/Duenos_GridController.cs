using MicroCreditos.Helpers;
using MicroCreditos.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MicroCreditos.Controllers
{
    public class CreditosController : ApiController
    {
        private static string scoringEndpoint = Environment.GetEnvironmentVariable("SCORING_ENDPOINT");
        private static string apiKey = Environment.GetEnvironmentVariable("API_KEY");
        private PreaprobacionResponse responsePreaprobacion;
        private HttpStatusCode httpStatusCode;

        //HttpResponseMessage response;
        // POST: api/Duenos_Grid
        [Route("api/PostCreditos")]
        [ResponseType(typeof(PreaprobacionResponse))]
        public async Task<HttpResponseMessage> PostCreditos(PreaprobacionRequest request)
        {
            InvokeRequestResponseService(request).Wait();            
            HttpResponseMessage responseHttp = Request.CreateResponse(httpStatusCode, responsePreaprobacion);
            return responseHttp;            
        }


        async Task InvokeRequestResponseService(PreaprobacionRequest request)
        {                       
            var handler = new HttpClientHandler()
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback =
                    (httpRequestMessage, cert, cetChain, policyErrors) => { return true; }
            };

            using (var client = new HttpClient(handler))
            {
                // Request data goes here

                List<PreaprobacionRequest> CreditRows = new List<PreaprobacionRequest>() { request };                
                JArray creditosRowsArray = JArray.FromObject(CreditRows);
                JObject PreaprobacionRequestJson =
                    new JObject(
                        new JProperty("Inputs", new JObject(
                            new JProperty("CreditRows", creditosRowsArray)
                            )
                        ),
                        new JProperty("GlobalParameters", new JObject())
                    );

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                client.BaseAddress = new Uri(scoringEndpoint);

                    

                //var requestString = JsonConvert.SerializeObject(scoreRequest);
                var content = new StringContent(PreaprobacionRequestJson.ToString());

                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                
                HttpResponseMessage response = await client.PostAsync("", content).ConfigureAwait(false);                                

                if (response.IsSuccessStatusCode)
                {
                    JObject responseContent = null;
                    string result = await response.Content.ReadAsStringAsync();
                    responseContent = JObject.Parse(result);
                    double scoreLabel = Convert.ToDouble(responseContent["Results"]["Results"][0]["Scored Labels"]);
                    httpStatusCode = response.StatusCode;
                    responsePreaprobacion = new PreaprobacionResponse(scoreLabel);                    
                }
                else
                {
                    httpStatusCode = response.StatusCode;
                    responsePreaprobacion = new PreaprobacionResponse(0);
                    /*Console.WriteLine(string.Format("The request failed with status code: {0}", response.StatusCode));

                    // Print the headers - they include the requert ID and the timestamp,
                    // which are useful for debugging the failure
                    Console.WriteLine(response.Headers.ToString());

                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseContent);*/
                }
            }            
        }


    }
}