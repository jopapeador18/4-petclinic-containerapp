using Newtonsoft.Json;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace petclinicFront.Models
{
    public partial class Especialidad
    {
        [JsonProperty("Especialidad_Id", Required = Required.Always)]
        public long EspecialidadId { get; set; }

        [JsonProperty("Especialidad1", Required = Required.Always)]
        public string Especialidad1 { get; set; }
    }
}
