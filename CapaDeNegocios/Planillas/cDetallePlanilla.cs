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
        DateTime sfechainicio;
        int sdiaslaborados;
        decimal stotalingresos;
        decimal stotalatrabajador;
        decimal stotaldescuentos;
        decimal stotalaempleador;
        decimal snetoacobrar;
        int sidttrabajador;
        int sidtplanilla;
        cTrabajador sTrabajador;

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

        public cTrabajador STrabajador
        {
            get
            {
                return sTrabajador;
            }

            set
            {
                sTrabajador = value;
            }
        }

        public DataTable ListarPlanillaXMesYRegimenLaboral(int pidPlanilla, int pidRegimenLaboral, string pmes, string paño)
        {
            return Conexion.GDatos.TraerDataTable("spListarPlanillaXMesYRegimenLaboral", pidPlanilla, pidRegimenLaboral, pmes,  paño);
        }

        public DataTable ListarPlanillaXMesYRegimenLaboralBancaria(int pidPlanilla, int pidRegimenLaboral, string pmes, string paño)
        {
            return Conexion.GDatos.TraerDataTable("spListarPlanillaXMesYRegimenLaboralBancaria", pidPlanilla, pidRegimenLaboral, pmes, paño);
        }

        public DataTable ListarPlanillaXMesYRegimenLaboralRacionamiento(int pidPlanilla, int pidRegimenLaboral, string pmes, string paño)
        {
            return Conexion.GDatos.TraerDataTable("spListarPlanillaXMesYRegimenLaboralRacionamiento", pidPlanilla, pidRegimenLaboral, pmes, paño);
        }

        public DataTable ListarPlanillaXMesYRegimenLaboralRacionamientoBancaria(int pidPlanilla, int pidRegimenLaboral, string pmes, string paño)
        {
            return Conexion.GDatos.TraerDataTable("spListarPlanillaXMesYRegimenLaboralRacionamientoBancaria", pidPlanilla, pidRegimenLaboral, pmes, paño);
        }

        public DataTable ListarDetallePlanilla(int IdtPlanilla)
        {
            return Conexion.GDatos.TraerDataTable("spListarDetallePlanilla", IdtPlanilla);
        }

        public DataTable ListarDetallePlanillaParaAFP(int IdtPlanilla, string mes, string año)
        {
            DateTime miNuevoFecha = new DateTime();
            int numeromes = 0;
            switch (mes)
            {
                case "ENERO":
                    numeromes = 1;
                    break;
                case "FEBRERO":
                    numeromes = 2;
                    break;
                case "MARZO":
                    numeromes = 3;
                    break;
                case "ABRIL":
                    numeromes = 4;
                    break;
                case "MAYO":
                    numeromes = 5;
                    break;
                case "JUNIO":
                    numeromes = 6;
                    break;
                case "JULIO":
                    numeromes = 7;
                    break;
                case "AGOSTO":
                    numeromes = 8;
                    break;
                case "SETIEMBRE":
                    numeromes = 9;
                    break;
                case "OCTUBRE":
                    numeromes = 10;
                    break;
                case "NOVIEMBRE":
                    numeromes = 11;
                    break;
                case "DICIEMBRE":
                    numeromes = 12;
                    break;
                
                default:
                    break;
            }
            miNuevoFecha = new DateTime(Convert.ToInt32(año), numeromes, 1);
            
            return Conexion.GDatos.TraerDataTable("spListarDetallePlanillaParaAFP", IdtPlanilla, miNuevoFecha);
        }

        public Boolean CrearDetallePlanilla(cDetallePlanilla miDetallePlanilla)
        {
            Conexion.GDatos.Ejecutar("spCrearDetallePlanilla", miDetallePlanilla.Cargo, miDetallePlanilla.FechaInicio, miDetallePlanilla.DiasLaborados, miDetallePlanilla.TotalIngresos, miDetallePlanilla.TotalATrabajador, miDetallePlanilla.TotalDescuentos, miDetallePlanilla.TotalAEmpleador, miDetallePlanilla.NetoaCobrar, miDetallePlanilla.IdtTrabajador, miDetallePlanilla.IdtPlanilla);
            return true;
        }

        public Boolean ModificarDetallePlanilla(cDetallePlanilla miDetallePlanilla)
        {
            Conexion.GDatos.Ejecutar("spModificarDetallePlanilla", miDetallePlanilla.IdtDetallePlanilla, miDetallePlanilla.Cargo, miDetallePlanilla.FechaInicio, miDetallePlanilla.DiasLaborados, miDetallePlanilla.TotalIngresos, miDetallePlanilla.TotalATrabajador, miDetallePlanilla.TotalDescuentos, miDetallePlanilla.TotalAEmpleador, miDetallePlanilla.NetoaCobrar, miDetallePlanilla.IdtTrabajador, miDetallePlanilla.IdtPlanilla);
            return true;
        }

        public Boolean EliminarDetallePlanilla(int IdtDetallePlanilla)
        {
            Conexion.GDatos.Ejecutar("spELiminarDetallePlanilla", IdtDetallePlanilla);
            return true;
        }

        /// <summary>
        /// Funcion que devuelve una tabla con los detalles de planilla que encontro posteriores a la fecha tentativa de baja
        /// </summary>
        /// <param name="fechaTentativaBaja"></param>
        /// <param name="idtTrabajadorBaja"></param>
        /// <returns></returns>
        public DataTable EncontrarDetallesPosteriorFecha(DateTime fechaTentativaBaja, int idtTrabajadorBaja)
        {
            DataTable auxiliar = Conexion.GDatos.TraerDataTable("spTraerDetallesPosterioresFecha", fechaTentativaBaja, idtTrabajadorBaja);
            return auxiliar;
        }
    }
}
