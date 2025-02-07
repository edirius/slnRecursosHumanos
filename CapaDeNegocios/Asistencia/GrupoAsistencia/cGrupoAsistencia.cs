using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Asistencia.GrupoAsistencia
{
    public class cGrupoAsistencia
    {
        public int IdtGrupoAsistencia { get; set; }
        public string Descripcion { get; set; }
        public Boolean Habilitado { get; set; }
        public List<cDetalleGrupoAsistencia> Detalles { get; set; }
    }
}
