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
        string scargo;
        decimal sremuneracion;
        DateTime sfechainicio;
        int sdiaslaborados;
        decimal sremuneraciontotal;
        decimal stotalingresos;
        decimal stotalatrabajador;
        decimal stotaldescuentos;
        decimal stotalaempleador;
        decimal snetoacobrar;
        int sidttrabajador;
        int sidtplanilla;

        public int IdtDetallePlanilla
        {
            get { return sidtdetalleplanilla; }
            set { sidtdetalleplanilla = value; }
        }
        public string Cargo
        {
            get { return scargo; }
            set { scargo = value; }
        }
        public decimal Remuneracion
        {
            get { return sremuneracion; }
            set { sremuneracion = value; }
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
        public decimal RemuneracionTotal
        {
            get { return sremuneraciontotal; }
            set { sremuneraciontotal = value; }
        }
        public decimal TotalIngresos
        {
            get { return stotalingresos; }
            set { stotalingresos = value; }
        }
        public decimal TotalATrabajador
        {
            get { return stotalatrabajador; }
            set { stotalatrabajador = value; }
        }
        public decimal TotalDescuentos
        {
            get { return stotaldescuentos; }
            set { stotaldescuentos = value; }
        }
        public decimal TotalAEmpleador
        {
            get { return stotalaempleador; }
            set { stotalaempleador = value; }
        }
        public decimal NetoaCobrar
        {
            get { return snetoacobrar; }
            set { snetoacobrar = value; }
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

        public DataTable ListarPlanillaXMesYRegimenLaboral( string paño, string pmes, int pidRegimenLaboral ){
            return Conexion.GDatos.TraerDataTable("spListarPlanillaXMesYRegimenLaboral",paño, pmes, pidRegimenLaboral);
        }

        public DataTable ListarDetallePlanilla(int IdtPlanilla)
        {
            return Conexion.GDatos.TraerDataTable("spListarDetallePlanilla", IdtPlanilla);
        }

        public Boolean CrearDetallePlanilla(cDetallePlanilla miDetallePlanilla)
        {
            Conexion.GDatos.Ejecutar("spCrearDetallePlanilla", miDetallePlanilla.Cargo, miDetallePlanilla.Remuneracion, miDetallePlanilla.FechaInicio, miDetallePlanilla.DiasLaborados, miDetallePlanilla.RemuneracionTotal, miDetallePlanilla.TotalIngresos, miDetallePlanilla.TotalATrabajador, miDetallePlanilla.TotalDescuentos, miDetallePlanilla.TotalAEmpleador, miDetallePlanilla.NetoaCobrar, miDetallePlanilla.IdtTrabajador, miDetallePlanilla.IdtPlanilla);
            return true;
        }

        public Boolean ModificarDetallePlanilla(cDetallePlanilla miDetallePlanilla)
        {
            Conexion.GDatos.Ejecutar("spModificarDetallePlanilla", miDetallePlanilla.IdtDetallePlanilla, miDetallePlanilla.Cargo, miDetallePlanilla.Remuneracion, miDetallePlanilla.FechaInicio, miDetallePlanilla.DiasLaborados, miDetallePlanilla.RemuneracionTotal, miDetallePlanilla.TotalIngresos, miDetallePlanilla.TotalATrabajador, miDetallePlanilla.TotalDescuentos, miDetallePlanilla.TotalAEmpleador, miDetallePlanilla.NetoaCobrar, miDetallePlanilla.IdtTrabajador, miDetallePlanilla.IdtPlanilla);
            return true;
        }

        public Boolean EliminarDetallePlanilla(int IdtDetallePlanilla)
        {
            Conexion.GDatos.Ejecutar("spELiminarDetallePlanilla", IdtDetallePlanilla);
            return true;
        }
    }
}
