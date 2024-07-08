using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaUsuario.ExportarSunat.Tregistro
{
    public class cListaTrabajadores
    {
        public int Numero { get; set; }
        public DateTime FechaInicio { get; set; }
        public string DNI { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Planilla { get; set; }
    }
}
