using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaUsuario.Planilla.VacacionesTruncas
{
    public class cPeriodoTrabajador
    {
        public Boolean Check { get; set; }
        public int IdtTrabajador { get; set; }
        public int IdtPeriodo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Regimen { get; set; }
        public double Sueldo { get; set; }
    }
}
