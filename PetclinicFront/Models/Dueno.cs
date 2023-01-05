using Newtonsoft.Json;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace petclinicFront.Models
{
    public partial class Dueno
    {

        [JsonProperty("Dueno_Id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long DuenoId { get; set; }

        [JsonProperty("Nombre", Required = Required.Always)]
        public string Nombre { get; set; }

        [JsonProperty("Apellido", Required = Required.Always)]
        public string Apellido { get; set; }

        [JsonProperty("Direccion", Required = Required.Always)]
        public string Direccion { get; set; }

        [JsonProperty("Ciudad", Required = Required.Always)]
        public string Ciudad { get; set; }

        [JsonProperty("Telefono", Required = Required.Always)]
        public string Telefono { get; set; }
    }
}
