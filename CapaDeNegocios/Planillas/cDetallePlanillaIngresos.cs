using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios.Planillas
{
    public class cDetallePlanillaIngresos
    {
        int sidtdetalleplanillaingresos;
        decimal smonto;
        int sidtmaestroingresos;
        int sidtdetalleplanilla;

        public int IdtDetallePlanillaIngresos
        {
            get { return sidtdetalleplanillaingresos; }
            set { sidtdetalleplanillaingresos = value; }
        }
        public decimal Monto
        {
            get { return smonto; }
            set { smonto = value; }
        }
        public int IdtMaestroIngresos
        {
            get { return sidtmaestroingresos; }
            set { sidtmaestroingresos = value; }
        }
        public int IdtDetallePlanilla
        {
            get { return sidtdetalleplanilla; }
            set { sidtdetalleplanilla = value; }
        }

        public DataTable ListarPlanillaXIngresosXBoletaPago(int pidPlanilla, int idRegimenLaboral, int idTrabajador)
        {
            return Conexion.GDatos.TraerDataTable("spListarPlanillaXIngresosXBoletaPago", pidPlanilla, idRegimenLaboral, idTrabajador);
        }

        public DataTable ListarPlanillaXIngresos(int pidPlanilla, int idRegimenLaboral, int idTrabajador)
        {
            return Conexion.GDatos.TraerDataTable("spListarPlanillaXIngresos", pidPlanilla, idRegimenLaboral, idTrabajador);
        }

        public DataTable ListarDetallePlanillaIngresos(int IdtDetallePlanilla)
        {
            return Conexion.GDatos.TraerDataTable("spListarDetallePlanillaIngresos", IdtDetallePlanilla);
        }

        public Boolean CrearDetallePlanillaIngresos(cDetallePlanillaIngresos miDetallePlanillaIngresos)
        {
            Conexion.GDatos.Ejecutar("spCrearDetallePlanillaIngresos", miDetallePlanillaIngresos.Monto, miDetallePlanillaIngresos.IdtMaestroIngresos, miDetallePlanillaIngresos.IdtDetallePlanilla);
            return true;
        }

        public Boolean ModificarDetallePlanillaIngresos(cDetallePlanillaIngresos miDetallePlanillaIngresos)
        {
            Conexion.GDatos.Ejecutar("spModificarDetallePlanillaIngresos", miDetallePlanillaIngresos.IdtDetallePlanillaIngresos, miDetallePlanillaIngresos.Monto, miDetallePlanillaIngresos.IdtMaestroIngresos, miDetallePlanillaIngresos.IdtDetallePlanilla);
            return true;
        }

        public Boolean EliminarDetallePlanillaIngresos(int IdtDetallePlanillaIngresos)
        {
            Conexion.GDatos.Ejecutar("spELiminarDetallePlanillaIngresos", IdtDetallePlanillaIngresos);
            return true;
        }
    }
}
