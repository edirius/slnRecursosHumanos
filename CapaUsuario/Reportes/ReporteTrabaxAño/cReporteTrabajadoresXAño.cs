using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaUsuario.Reportes.ReporteTrabaxAño
{
    public class cReporteTrabajadoresXAño
    {
        public List<cDetallesReporteTrabajadores> Detalles { get; set; }

        public cReporteTrabajadoresXAño()
        {
            Detalles = new List<cDetallesReporteTrabajadores>();
        }
    }
}
