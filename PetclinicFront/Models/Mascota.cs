using Newtonsoft.Json;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace petclinicFront.Models
{
    public partial class Mascota
    {
        [JsonProperty("Mascota_Id", Required = Required.Always)]
        public int MascotaId { get; set; }

        [JsonProperty("Mascota1", Required = Required.Always)]
        public string Mascota1 { get; set; }

        [JsonProperty("Fecha_Nacimiento", Required = Required.Always)]
        public DateTime? FechaNacimiento { get; set; }

        [JsonProperty("Tipo_Id", Required = Required.Always)]
        public int TipoId { get; set; }

        [JsonProperty("Dueno_Id", Required = Required.Always)]
        public int DuenoId { get; set; }

        [JsonProperty("Dueno", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public virtual Dueno Dueno { get; set; }

        [JsonProperty("Tipo", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public virtual Tipo Tipo { get; set; }
        
    }
    public partial class Mascota
    {
        public static List<Mascota> FromJson(string json) => JsonConvert.DeserializeObject<List<Mascota>>(json, petclinicFront.Models.Converter.Settings);
    }
}
