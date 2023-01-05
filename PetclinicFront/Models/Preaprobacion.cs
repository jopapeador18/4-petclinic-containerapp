using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace petclinicFront.Models
{

    //Solicitud de Preaprobacion
    public partial class PreaprobacionRequest
    {
        [JsonProperty("Genero", Required = Required.Always)]
        public bool Genero { get; set; }

        [JsonProperty("Es_Casado", Required = Required.Always)]
        public bool EsCasado { get; set; }

        [JsonProperty("Numero_Dependientes", Required = Required.Always)]
        public long NumeroDependientes { get; set; }

        [JsonProperty("Universidad_Finalizada", Required = Required.Always)]
        public bool UniversidadFinalizada { get; set; }

        [JsonProperty("Es_Independiente", Required = Required.Always)]
        public bool EsIndependiente { get; set; }

        [JsonProperty("Ingresos_Directos", Required = Required.Always)]
        public long IngresosDirectos { get; set; }

        [JsonProperty("Ingresos_Indirectos", Required = Required.Always)]
        public long IngresosIndirectos { get; set; }

        [JsonProperty("Monto_Solicitado", Required = Required.Always)]
        public long MontoSolicitado { get; set; }

        [JsonProperty("Tiempo_Dias_Credito", Required = Required.Always)]
        public long TiempoDiasCredito { get; set; }

        [JsonProperty("Posee_Historial_Crediticio", Required = Required.Always)]
        public bool PoseeHistorialCrediticio { get; set; }

        [JsonProperty("Tipo_Area_Vivienda", Required = Required.Always)]
        public string TipoAreaVivienda { get; set; }

        public static PreaprobacionRequest FromJson(string json) => JsonConvert.DeserializeObject<PreaprobacionRequest>(json, Models.Converter.Settings);
    }

    //Respuesta de preaprobacion
    public partial class PreaprobacionResponse
    {
        public double Prediction { get; set; }
        public static PreaprobacionResponse FromJson(string json) => JsonConvert.DeserializeObject<PreaprobacionResponse>(json, petclinicFront.Models.Converter.Settings);
    }
}