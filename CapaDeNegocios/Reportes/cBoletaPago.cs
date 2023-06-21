using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDeDatos;
using CapaDeNegocios.Obras;
using CapaDeNegocios.Planillas;

namespace CapaDeNegocios.Reportes
{
    public class cBoletaPago
    {
        private cTrabajador trabajador;
        private cMeta meta;
        private cDetallePlanilla detallePlanilla;
        private DateTime mes;

        public cTrabajador Trabajador
        {
            get
            {
                return trabajador;
            }

            set
            {
                trabajador = value;
            }
        }

        public cMeta Meta
        {
            get
            {
                return meta;
            }

            set
            {
                meta = value;
            }
        }

        public cDetallePlanilla DetallePlanilla
        {
            get
            {
                return detallePlanilla;
            }

            set
            {
                detallePlanilla = value;
            }
        }

        public DateTime Mes
        {
            get
            {
                return mes;
            }

            set
            {
                mes = value;
            }
        }

        

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
