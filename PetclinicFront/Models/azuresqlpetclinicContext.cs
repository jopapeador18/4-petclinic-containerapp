using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using petclinicFront.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace petclinicFront.Models
{
    public partial class azuresqlpetclinicContext
    {

        RestHelper restHelper;
        string baseUrl = "";
        string baseUrlVets = "";
        string baseUrlCredits = "";


        public azuresqlpetclinicContext()
        {
            restHelper = new RestHelper();
            DuenosGrid = new List<DuenosGrid>();
            Dueno = new List<Dueno>();
            Mascota = new List<Mascota>();
            baseUrl = Environment.GetEnvironmentVariable("CLIENTES_BACKEND");
            baseUrlVets = Environment.GetEnvironmentVariable("VETS_BACKEND");
            baseUrlCredits = Environment.GetEnvironmentVariable("CREDITS_BACKEND");
        }

        public List<DuenosGrid> GetDuenosGrid(int? Id)
        {
            string idToSearch = Id == 0 ? "" : $"/{Id}";
            var task = Task.Run(async () => await restHelper.ExecuteHTTPRequest($"{baseUrl}/api/Duenos_Grid{idToSearch}", RestSharp.Method.Get, "{}"));
            var result = task.Result.Content;
            if (!result.StartsWith('['))
            {
                result = "["+result+"]";
            }

            return Models.DuenosGrid.FromJson(result);   
        }
        public List<Mascota> GetMascotasPorDueno(int? DuenoId)
        {
            var task = Task.Run(async () => await restHelper.ExecuteHTTPRequest($"{baseUrl}/api/Mascotas/Dueno/{DuenoId}", RestSharp.Method.Get, "{}"));
            var result = task.Result.Content;
            if (!result.StartsWith('['))
            {
                result = "["+result+"]";
            }
            return Models.Mascota.FromJson(result);   
        }
        public bool AddDueno(Dueno dueno)
        {
            dueno.DuenoId = 0;
            var task = Task.Run(async () => await restHelper.ExecuteHTTPRequest($"{baseUrl}/api/Duenos_Grid", RestSharp.Method.Post, dueno.ToJson()));
            var result = task.Result.Content;
            if (!result.StartsWith('['))
            {
                result = "[" + result + "]";
            }

            return true;
        }
        public bool EditDueno(int id, Dueno dueno)
        {
            var task = Task.Run(async () => await restHelper.ExecuteHTTPRequest($"{baseUrl}/api/Duenos_Grid/{id}", RestSharp.Method.Put, dueno.ToJson()));
            var result = task.Result.Content;
            if (!result.StartsWith('['))
            {
                result = "[" + result + "]";
            }

            return true;
        }
        public bool DeleteDueno(int? id)
        {
            var task = Task.Run(async () => await restHelper.ExecuteHTTPRequest($"{baseUrl}/api/Duenos_Grid/{id}", RestSharp.Method.Delete,"{}"));
            var result = task.Result.Content;
            if (!result.StartsWith('['))
            {
                result = "[" + result + "]";
            }

            return true;
        }

        public List<Mascota> GetMascotas(int? Id)
        {
            string idToSearch = Id == 0 ? "" : $"/{Id}";
            var task = Task.Run(async () => await restHelper.ExecuteHTTPRequest($"{baseUrl}/api/Mascotas{idToSearch}", RestSharp.Method.Get, "{}"));
            var result = task.Result.Content;
            if (!result.StartsWith('['))
            {
                result = "[" + result + "]";
            }
            return Models.Mascota.FromJson(result);
        }
        public bool AddMascota(Mascota mascota)
        {
            mascota.MascotaId = 0;
            var task = Task.Run(async () => await restHelper.ExecuteHTTPRequest($"{baseUrl}/api/Mascotas", RestSharp.Method.Post, mascota.ToJson()));
            var result = task.Result.Content;
            if (!result.StartsWith('['))
            {
                result = "[" + result + "]";
            }

            return true;
        }

        public List<Tipo> GetTipos(int? Id)
        {
            string idToSearch = Id == 0 ? "" : $"/{Id}";
            var task = Task.Run(async () => await restHelper.ExecuteHTTPRequest($"{baseUrl}/api/Tipos{idToSearch}", RestSharp.Method.Get, "{}"));
            var result = task.Result.Content;
            if (!result.StartsWith('['))
            {
                result = "[" + result + "]";
            }
            return Models.Tipo.FromJson(result);
        }
        public List<Veterinario> GetVets(int? Id)
        {
            string idToSearch = Id == 0 ? "" : $"/{Id}";
            var task = Task.Run(async () => await restHelper.ExecuteHTTPRequest($"{baseUrlVets}/api/Veterinarios{idToSearch}", RestSharp.Method.Get, "{}"));
            var result = task.Result.Content;
            if (!result.StartsWith('['))
            {
                result = "[" + result + "]";
            }
            return Models.Veterinario.FromJson(result);
        }
        public bool AddVet(Veterinario veterinario)
        {
            veterinario.VeterinarioId = 0;
            var task = Task.Run(async () => await restHelper.ExecuteHTTPRequest($"{baseUrlVets}/api/Veterinarios", RestSharp.Method.Post, veterinario.ToJson()));
            var result = task.Result.Content;
            if (!result.StartsWith('['))
            {
                result = "[" + result + "]";
            }

            return true;
        }
        public bool DeleteVet(int? id)
        {
            var task = Task.Run(async () => await restHelper.ExecuteHTTPRequest($"{baseUrlVets}/api/Veterinarios/{id}", RestSharp.Method.Delete, "{}"));
            var result = task.Result.Content;
            if (!result.StartsWith('['))
            {
                result = "[" + result + "]";
            }

            return true;
        }
        public bool EditVet(int id, Veterinario veterinario)
        {
            var task = Task.Run(async () => await restHelper.ExecuteHTTPRequest($"{baseUrlVets}/api/Veterinarios/{id}", RestSharp.Method.Put, veterinario.ToJson()));
            var result = task.Result.Content;   
            if (!result.StartsWith('['))
            {
                result = "[" + result + "]";
            }

            return true;
        }

        public double GetCreditPrediction(PreaprobacionRequest solicitud)
        {
            var task = Task.Run(async () => await restHelper.ExecuteHTTPRequest($"{baseUrlCredits}/api/PostCreditos", RestSharp.Method.Post, solicitud.ToJson()));
            var result = task.Result.Content;

            if (task.Result.IsSuccessful)
            {
                var response = PreaprobacionResponse.FromJson(result);
                return response.Prediction;
            }
            else
            {
                return -10;
            }
            //return Double.Parse("0." + new Random().Next(0, 100));
        }

        public virtual List<Dueno> Dueno { get; set; }
        public virtual List<DuenosGrid> DuenosGrid { get; set; }
        public virtual List<Mascota> Mascota { get; set; }
        public virtual DbSet<Especialidad> Especialidad { get; set; }
        public virtual DbSet<Tipo> Tipo { get; set; }
        public virtual DbSet<Veterinario> Veterinario { get; set; }
        public virtual DbSet<VeterinarioEspecialidad> VeterinarioEspecialidad { get; set; }
        public virtual DbSet<Visita> Visita { get; set; }

    }
}
