using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDeDatos;

namespace CapaDeNegocios.Reportes
{
    public class cResumenPlanillas
    {
        public Boolean ResumenPlanilla(string  estado, int idtplanilla)
        {
            Conexion.GDatos.Ejecutar("spPlanillaTotal", estado, idtplanilla);
            return true;
        }

        public Boolean ResumenPlanillaDetallado(string estado, int idtplanilla)
        {
            Conexion.GDatos.Ejecutar("spPlanillaDetalleTotal", estado, idtplanilla);
            return true;
        }
    }
}
