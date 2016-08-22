using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios.Planillas
{
    public class cDetallePlanillaATrabajador
    {
        int sidtdetalleplanillaatrabajador;
        decimal smonto;
        int sidtmaestroaportacionestrabajador;
        int sidtdetalleplanilla;

        public int IdtDetallePlanillaATrabajador
        {
            get { return sidtdetalleplanillaatrabajador; }
            set { sidtdetalleplanillaatrabajador = value; }
        }
        public decimal Monto
        {
            get { return smonto; }
            set { smonto = value; }
        }
        public int IdtMaestroATrabajador
        {
            get { return sidtmaestroaportacionestrabajador; }
            set { sidtmaestroaportacionestrabajador = value; }
        }
        public int IdtDetallePlanilla
        {
            get { return sidtdetalleplanilla; }
            set { sidtdetalleplanilla = value; }
        }

        public DataTable ListarPlanillaATrabajador(string paño,string pmes, int pidRegimenLaboral, int pidTrabajador)
        {
            return Conexion.GDatos.TraerDataTable("spListarPlanillaATrabajador",paño, pmes, pidRegimenLaboral, pidTrabajador);
        }

        public DataTable ListarDetallePlanillaATrabajador(int IdtDetallePlanilla)
        {
            return Conexion.GDatos.TraerDataTable("spListarDetallePlanillaATrabajador", IdtDetallePlanilla);
        }

        public Boolean CrearDetallePlanillaATrabajador(cDetallePlanillaATrabajador miDetallePlanillaATrabajador)
        {
            Conexion.GDatos.Ejecutar("spCrearDetallePlanillaATrabajador", miDetallePlanillaATrabajador.Monto, miDetallePlanillaATrabajador.IdtMaestroATrabajador, miDetallePlanillaATrabajador.IdtDetallePlanilla);
            return true;
        }

        public Boolean ModificarDetallePlanillaATrabajador(cDetallePlanillaATrabajador miDetallePlanillaATrabajador)
        {
            Conexion.GDatos.Ejecutar("spModificarDetallePlanillaATrabajador", miDetallePlanillaATrabajador.IdtDetallePlanillaATrabajador, miDetallePlanillaATrabajador.Monto, miDetallePlanillaATrabajador.IdtMaestroATrabajador, miDetallePlanillaATrabajador.IdtDetallePlanilla);
            return true;
        }

        public Boolean EliminarDetallePlanillaATrabajador(int IdtDetallePlanillaATrabajador)
        {
            Conexion.GDatos.Ejecutar("spELiminarDetallePlanillaATrabajador", IdtDetallePlanillaATrabajador);
            return true;
        }
    }
}
