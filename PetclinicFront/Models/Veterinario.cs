using Newtonsoft.Json;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace petclinicFront.Models
{
    public partial class Veterinario
    {
        public Veterinario()
        {
            VeterinarioEspecialidad = new List<VeterinarioEspecialidad>();
        }

        [JsonProperty("Veterinario_Id", Required = Required.Always)]
        public int VeterinarioId { get; set; }

        [JsonProperty("Nombre", Required = Required.Always)]
        public string Nombre { get; set; }

        [JsonProperty("Apellido", Required = Required.Always)]
        public string Apellido { get; set; }

        [JsonProperty("Veterinario_Especialidad", Required = Required.Always)]
        public List<VeterinarioEspecialidad> VeterinarioEspecialidad { get; set; }
    }

    public partial class Veterinario
    {
        public static List<Veterinario> FromJson(string json) => JsonConvert.DeserializeObject<List<Veterinario>>(json, petclinicFront.Models.Converter.Settings);
    }
}
