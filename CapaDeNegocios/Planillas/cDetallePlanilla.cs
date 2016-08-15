using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios.Planillas
{
    public class cDetallePlanilla
    {
        int sidtdetalleplanilla;
        decimal ssueldo;
        DateTime sfechainicio;
        int sdiaslaborados;
        int sidtcargo;
        int sidttrabajador;
        int sidtplanilla;

        public int IdtDetallePlanilla
        {
            get { return sidtdetalleplanilla; }
            set { sidtdetalleplanilla = value; }
        }
        public decimal Sueldo
        {
            get { return ssueldo; }
            set { ssueldo = value; }
        }
        public DateTime FechaInicio
        {
            get { return sfechainicio; }
            set { sfechainicio = value; }
        }
        public int DiasLaborados
        {
            get { return sdiaslaborados; }
            set { sdiaslaborados = value; }
        }
        public int IdtCargo
        {
            get { return sidtcargo; }
            set { sidtcargo = value; }
        }
        public int IdtTrabajador
        {
            get { return sidttrabajador; }
            set { sidttrabajador = value; }
        }
        public int IdtPlanilla
        {
            get { return sidtplanilla; }
            set { sidtplanilla = value; }
        }

        public DataTable ListarPlanillaXMesYRegimenLaboral( string pmes, int pidRegimenLaboral ){
            return Conexion.GDatos.TraerDataTable("spListarPlanillaXMesYRegimenLaboral", pmes, pidRegimenLaboral);
        }

        public DataTable ListarDetallePlanilla(int IdtPlanilla)
        {
            return Conexion.GDatos.TraerDataTable("spListarDetallePlanilla", IdtPlanilla);
        }

        public Boolean CrearDetallePlanilla(cDetallePlanilla miDetallePlanilla)
        {
            Conexion.GDatos.Ejecutar("spCrearDetallePlanilla", miDetallePlanilla.Sueldo, miDetallePlanilla.FechaInicio, miDetallePlanilla.DiasLaborados, miDetallePlanilla.IdtCargo, miDetallePlanilla.IdtTrabajador, miDetallePlanilla.IdtPlanilla);
            return true;
        }

        public Boolean ModificarDetallePlanilla(cDetallePlanilla miDetallePlanilla)
        {
            Conexion.GDatos.Ejecutar("spModificarDetallePlanilla", miDetallePlanilla.IdtDetallePlanilla, miDetallePlanilla.Sueldo, miDetallePlanilla.FechaInicio, miDetallePlanilla.DiasLaborados, miDetallePlanilla.IdtCargo, miDetallePlanilla.IdtTrabajador, miDetallePlanilla.IdtPlanilla);
            return true;
        }

        public Boolean EliminarDetallePlanilla(int IdtDetallePlanilla)
        {
            Conexion.GDatos.Ejecutar("spELiminarDetallePlanilla", IdtDetallePlanilla);
            return true;
        }
    }
}
