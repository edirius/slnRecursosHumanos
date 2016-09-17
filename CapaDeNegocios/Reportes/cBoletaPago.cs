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
        public DataTable ListarPlanillaXMesYRegimenLaboralYTrabajadorA(int pidPlanilla , int pidtregimenlaboral, int pid_trabajador, string pmes, string pmes_nro, string paño)
        {
            return Conexion.GDatos.TraerDataTable("spListarPlanillaXMesYRegimenLaboralYTrabajadorA", pidPlanilla, pidtregimenlaboral, pid_trabajador, pmes, pmes_nro, paño);
        }

        public DataTable ListarPlanillaXMesYRegimenLaboralYTrabajadorB(int pidPlanilla, int pidtregimenlaboral, int pid_trabajador, string pmes, string pmes_nro, string paño)
        {
            return Conexion.GDatos.TraerDataTable("spListarPlanillaXMesYRegimenLaboralYTrabajadorB", pidPlanilla, pidtregimenlaboral,pid_trabajador,  pmes, pmes_nro , paño);
        }

        public DataTable ListarPlanillaXMesYRegimenLaboralYTrabajadorC(int pidPlanilla, int pidtregimenlaboral, int pid_trabajador,  string pmes, string pmes_nro, string paño)
        {
            return Conexion.GDatos.TraerDataTable("spListarPlanillaXMesYRegimenLaboralYTrabajadorC", pidPlanilla,pidtregimenlaboral,pid_trabajador, pmes,pmes_nro, paño);
        }
    }
}
