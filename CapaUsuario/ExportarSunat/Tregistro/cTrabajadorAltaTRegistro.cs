using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeNegocios.ExportarSunat;

namespace CapaUsuario.ExportarSunat.Tregistro
{
    public class cTrabajadorAltaTRegistro
    {
        public int Numero { get; set; }
        public int Id_trabajador { get; set; }
        public DateTime FechaInicio { get; set; }
        public string DNI { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Planilla { get; set; }
        public cDatosIdentificacion DatosIdentificacion { get; set; }
    }
}
