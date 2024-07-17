using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace CapaDeNegocios.VerificadorDNI
{
    public class trabajadorValidado
    {
        public class data
        {

            public string numero { get; set; }
            public string nombre_completo { get; set; }
            public string nombres { get; set; }
            public string apellido_paterno { get; set; }
            public string apellido_materno { get; set; }
            public string fecha_nacimiento { get; set; }
            public string sexo { get; set; }
            public string estado_civil { get; set; }
            public string codigo_verificacion { get; set; }
            public string direccion { get; set; }
            public string direccion_completa { get; set; }
            public string departamento { get; set; }
            public string provincia { get; set; }
            public string distrito { get; set; }
            public string ubigeo_sunat { get; set; }
            public string ubigeo_reniec { get; set; }
            public string[] ubigeo { get; set; }
        }

        [JsonProperty("data")]
        public data Data { get; set; }
    }
}
