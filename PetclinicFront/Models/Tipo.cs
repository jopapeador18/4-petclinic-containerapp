using Newtonsoft.Json;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace petclinicFront.Models
{
    public partial class Tipo
    {
        [JsonProperty("Tipo_Id", Required = Required.Always)]
        public int TipoId { get; set; }
        [JsonProperty("Tipo1", Required = Required.Always)]
        public string Tipo1 { get; set; }
    }

    public partial class Tipo
    {
        public static List<Tipo> FromJson(string json) => JsonConvert.DeserializeObject<List<Tipo>>(json, petclinicFront.Models.Converter.Settings);
    }
}
