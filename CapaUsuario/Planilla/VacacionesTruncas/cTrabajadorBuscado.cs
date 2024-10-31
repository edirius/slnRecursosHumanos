using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaUsuario.Planilla.VacacionesTruncas
{
    public class cTrabajadorBuscado
    {
        public int CODIGOTRABAJADOR { get; set; }
        public string DNI { get; set; }
        public string NOMBRES { get; set; }
        public string APELLIDOPATERNO { get; set; }
        public string APELLIDOMATERNO { get; set; }
        public DateTime FECHANACIMIENTO { get; set; }
        public string GENERO { get; set; }
        public string CARGO { get; set; }
    }
}
