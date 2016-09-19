using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios.Planillas
{
    public class cDetallePlanillaAEmpleador
    {
        int sidtdetalleplanillaaempleador;
        decimal smonto;
        int sidtmaestroaportacionesempleador;
        int sidtdetalleplanilla;

        public int IdtDetallePlanillaAEmpleador
        {
            get { return sidtdetalleplanillaaempleador; }
            set { sidtdetalleplanillaaempleador = value; }
        }
        public decimal Monto
        {
            get { return smonto; }
            set { smonto = value; }
        }
        public int IdtMaestroAEmpleador
        {
            get { return sidtmaestroaportacionesempleador; }
            set { sidtmaestroaportacionesempleador = value; }
        }
        public int IdtDetallePlanilla
        {
            get { return sidtdetalleplanilla; }
            set { sidtdetalleplanilla = value; }
        }

        public DataTable ListarPlanillaAEmpleadorXBoletaPago(int pidPlanilla,int pidtregimenlaboral, int pid_trabajador)
        {
            return Conexion.GDatos.TraerDataTable("spListarPlanillaAEmpleadorXBoletaPago", pidPlanilla, pidtregimenlaboral, pid_trabajador );
        }

        public DataTable ListarPlanillaAEmpleador(int pidPlanilla, int pidRegimenLaboral, int pidTrabajador)
        {
            return Conexion.GDatos.TraerDataTable("spListarPlanillaAEmpleador", pidPlanilla, pidRegimenLaboral, pidTrabajador);
        }

        public DataTable ListarDetallePlanillaAEmpleador(int IdtDetallePlanilla)
        {
            return Conexion.GDatos.TraerDataTable("spListarDetallePlanillaAEmpleador", IdtDetallePlanilla);
        }

        public Boolean CrearDetallePlanillaAEmpleador(cDetallePlanillaAEmpleador miDetallePlanillaAEmpleador)
        {
            Conexion.GDatos.Ejecutar("spCrearDetallePlanillaAEmpleador", miDetallePlanillaAEmpleador.Monto, miDetallePlanillaAEmpleador.IdtMaestroAEmpleador, miDetallePlanillaAEmpleador.IdtDetallePlanilla);
            return true;
        }

        public Boolean ModificarDetallePlanillaAEmpleador(cDetallePlanillaAEmpleador miDetallePlanillaAEmpleador)
        {
            Conexion.GDatos.Ejecutar("spModificarDetallePlanillaAEmpleador", miDetallePlanillaAEmpleador.IdtDetallePlanillaAEmpleador, miDetallePlanillaAEmpleador.Monto, miDetallePlanillaAEmpleador.IdtMaestroAEmpleador, miDetallePlanillaAEmpleador.IdtDetallePlanilla);
            return true;
        }

        public Boolean EliminarDetallePlanillaAEmpleador(int IdtDetallePlanillaAEmpleador)
        {
            Conexion.GDatos.Ejecutar("spELiminarDetallePlanillaAEmpleador", IdtDetallePlanillaAEmpleador);
            return true;
        }
    }
}
