using Newtonsoft.Json;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace petclinicFront.Models
{
    public partial class VeterinarioEspecialidad
    {
        [JsonProperty("Veterinario_Especialidad_Id", Required = Required.Always)]
        public int VeterinarioEspecialidadId { get; set; }
        
        [JsonProperty("Veterinario_Id", Required = Required.Always)]
        public int VeterinarioId { get; set; }
        
        [JsonProperty("Especialidad_Id", Required = Required.Always)]
        public int EspecialidadId { get; set; }

        [JsonProperty("Especialidad", Required = Required.Always)]
        public Especialidad Especialidad { get; set; }

        [JsonProperty("Veterinario", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public virtual Veterinario Veterinario { get; set; }
    }
}
