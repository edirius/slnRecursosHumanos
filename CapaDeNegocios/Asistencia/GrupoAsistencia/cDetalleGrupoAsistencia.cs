using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Asistencia.GrupoAsistencia
{
    public class cDetalleGrupoAsistencia
    {
        public int IdtDetalleGrupoAsistencia { get; set; }
        public string DNI { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int Id_Trabajador { get; set; }
        public int Idtreloj { get; set; }
        public string NombreHorario { get; set; }
        public cGrupoAsistencia GrupoAsistencia { get; set; }

        public cDetalleGrupoAsistencia()
        {
            GrupoAsistencia = new cGrupoAsistencia();
        }
    }
}
