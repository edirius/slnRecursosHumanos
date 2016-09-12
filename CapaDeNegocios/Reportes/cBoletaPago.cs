using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios.Reportes
{
    public class cBoletaPago
    {



        public DataTable ListarPlanillaXMesYRegimenLaboralYTrabajadorA(int pidPlanilla, int pidRegimenLaboral, int pidtrabajador)
        {
            return Conexion.GDatos.TraerDataTable("spListarPlanillaXMesYRegimenLaboralYTrabajadorA", pidPlanilla, pidRegimenLaboral,pidtrabajador);
        }

        public DataTable ListarPlanillaXMesYRegimenLaboralYTrabajadorB(int pidPlanilla, int pidRegimenLaboral, int pidtrabajador)
        {
            return Conexion.GDatos.TraerDataTable("spListarPlanillaXMesYRegimenLaboralYTrabajadorB", pidPlanilla, pidRegimenLaboral, pidtrabajador);
        }

        public DataTable ListarPlanillaXMesYRegimenLaboralYTrabajadorC(int pidPlanilla, int pidRegimenLaboral, int pidtrabajador)
        {
            return Conexion.GDatos.TraerDataTable("spListarPlanillaXMesYRegimenLaboralYTrabajadorC", pidPlanilla, pidRegimenLaboral, pidtrabajador);
        }
    }
}
