using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaUsuario.Planilla.VacacionesTruncas
{
    public enum enumRegimenesLaborales
    {
        TODOS,
        CAS,
        DL276,
        DL728,
        DL30057,
        RACIONAMIENTO,
    }

    public enum enumSituacionLaboral
    {
        TODOS,
        ACTIVOS,
        INACTIVOS,
        SinSituacionLaboral
    }
    public class cOpcionesBusqueda
    {
        public enumRegimenesLaborales RegimenElegido { get; set; }

    }
}
