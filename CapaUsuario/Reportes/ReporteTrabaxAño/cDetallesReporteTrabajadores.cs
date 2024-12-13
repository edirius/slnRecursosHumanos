using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaUsuario.Reportes.ReporteTrabaxAño
{
    public class cDetallesReporteTrabajadores
    {
        public Int32 Codigo { get; set; }
        public int NumeroOrden { get; set; }
        public string DNI { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public List<cDetalleMeses> Meses { get; set; }

        public cDetallesReporteTrabajadores()
        {
            Meses = new List<cDetalleMeses>();
        }
    }
}
