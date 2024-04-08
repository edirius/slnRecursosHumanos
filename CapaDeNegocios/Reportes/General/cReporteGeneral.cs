using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeNegocios.Reportes;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace CapaDeNegocios.Reportes.General
{
    public class cReporteGeneral
    {
        /// <summary>
        /// Metodo para exportar una tabla a un reporte
        /// </summary>
        /// <param name="miTabla"></param>
        public void ImprimirPDFdeunaTabla(DataTable miTabla)
        {
            for (int i = 0; i < miTabla.Rows.Count; i++)
            {

            }
        }
    }
}
