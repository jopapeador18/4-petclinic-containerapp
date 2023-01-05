using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace petclinicFront.Helpers
{
    public class RestHelper
    {
        public RestHelper()
        {

        }


        public async Task<RestResponse> ExecuteHTTPRequest(string RequestUri, Method method, string jsonRequestBody)
        {
            var client = new RestClient(RequestUri);
            var request = new RestRequest();
            request.AddHeader("Accept", "application/json");
            request.Method = method;
            request.AddStringBody(jsonRequestBody, DataFormat.Json);

            return await client.ExecuteAsync(request);
        }
    }
}
