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
        List<cDetallePlanillaIngresos> listaIngresos;
        List<cDetallePlanillaDescuentos> listaDescuentos;
        List<cDetallePlanillaATrabajador> listaAportacionesTrabajador;
        List<cDetallePlanillaAEmpleador> listaAportacionesEmpleador;

        private CapaDeNegocios.PlanillaNueva.blPlanilla oPlanilla = new PlanillaNueva.blPlanilla();

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

        public cDetallePlanilla()
        {
            this.listaIngresos = new List<cDetallePlanillaIngresos>();
            this.listaDescuentos = new List<cDetallePlanillaDescuentos>();
            this.listaAportacionesTrabajador = new List<cDetallePlanillaATrabajador>();
            this.listaAportacionesEmpleador = new List<cDetallePlanillaAEmpleador>();
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

        public List<cDetallePlanillaIngresos> ListaIngresos
        {
            get
            {
                return listaIngresos;
            }

            set
            {
                listaIngresos = value;
            }
        }

        public List<cDetallePlanillaDescuentos> ListaDescuentos
        {
            get
            {
                return listaDescuentos;
            }

            set
            {
                listaDescuentos = value;
            }
        }

        public List<cDetallePlanillaATrabajador> ListaAportacionesTrabajador
        {
            get
            {
                return listaAportacionesTrabajador;
            }

            set
            {
                listaAportacionesTrabajador = value;
            }
        }

        public List<cDetallePlanillaAEmpleador> ListaAportacionesEmpleador
        {
            get
            {
                return listaAportacionesEmpleador;
            }

            set
            {
                listaAportacionesEmpleador = value;
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

        /// <summary>
        /// Metodo para traer el detalle de planilla x su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>objeto detalle de planilla</returns>
        public cDetallePlanilla TraerDetallePlanillaxCodigo(int id)
        {
            try
            {
                cDetallePlanilla auxiliar = new cDetallePlanilla();
                DataTable tabla = Conexion.GDatos.TraerDataTable("spTrearDetallePlanillaXID", id);
                if (tabla.Rows.Count > 0)
                {
                    foreach (DataRow item in tabla.Rows)
                    {
                        auxiliar.IdtDetallePlanilla = Convert.ToInt32(item[0].ToString());
                        auxiliar.Cargo = item[1].ToString();
                        auxiliar.FechaInicio = Convert.ToDateTime(item[2].ToString());
                        auxiliar.DiasLaborados = Convert.ToInt16(item[3].ToString());
                        auxiliar.TotalIngresos = Convert.ToDecimal(item[4].ToString());
                        auxiliar.TotalATrabajador = Convert.ToDecimal(item[5].ToString());
                        auxiliar.TotalDescuentos = Convert.ToDecimal(item[6].ToString());
                        auxiliar.TotalAEmpleador = Convert.ToDecimal(item[7].ToString());
                        auxiliar.NetoaCobrar = Convert.ToDecimal(item[8].ToString());
                        auxiliar.IdtTrabajador = Convert.ToInt32(item[9].ToString());
                        auxiliar.IdtPlanilla = Convert.ToInt32(item[10].ToString());
                    }

                    DataTable tablaIngresos = Conexion.GDatos.TraerDataTable("spTraerDetalleIngresos", id);
                    foreach (DataRow item in tablaIngresos.Rows)
                    {
                        cDetallePlanillaIngresos ingresos = new cDetallePlanillaIngresos();
                        ingresos.IdtDetallePlanillaIngresos = Convert.ToInt32(item[0].ToString());
                        ingresos.Monto = Convert.ToDecimal(item[1].ToString());
                        ingresos.IdtMaestroIngresos = Convert.ToInt32(item[2].ToString());
                        ingresos.IdtDetallePlanilla = Convert.ToInt32(item[3].ToString());
                        ingresos.MaestroIngresos = oPlanilla.TraerMaestroIngresos(ingresos.IdtMaestroIngresos);
                        auxiliar.listaIngresos.Add(ingresos);
                    }

                    DataTable tablaDescuentos = Conexion.GDatos.TraerDataTable("spTraerDetalleDescuentos", id);
                    foreach (DataRow item in tablaDescuentos.Rows)
                    {
                        cDetallePlanillaDescuentos descuentos = new cDetallePlanillaDescuentos();
                        descuentos.IdtDetallePlanillaDescuentos = Convert.ToInt32(item[0].ToString());
                        descuentos.Monto = Convert.ToDecimal(item[1].ToString());
                        descuentos.IdtMaestroDescuentos = Convert.ToInt32(item[2].ToString());
                        descuentos.IdtDetallePlanilla = Convert.ToInt32(item[3].ToString());
                        descuentos.MaestroDescuento = oPlanilla.TraerMaestroDescuento(descuentos.IdtMaestroDescuentos);
                        auxiliar.ListaDescuentos.Add(descuentos);
                    }

                    DataTable tablaAportacionesTrabajador = Conexion.GDatos.TraerDataTable("spTraerDetalleAportacionesTrabajador", id);
                    foreach (DataRow item in tablaAportacionesTrabajador.Rows)
                    {
                        cDetallePlanillaATrabajador aportacionTrabajador = new cDetallePlanillaATrabajador();
                        aportacionTrabajador.IdtDetallePlanillaATrabajador = Convert.ToInt32(item[0].ToString());
                        aportacionTrabajador.Monto = Convert.ToDecimal(item[1].ToString());
                        aportacionTrabajador.IdtMaestroATrabajador = Convert.ToInt32(item[2].ToString());
                        aportacionTrabajador.IdtDetallePlanilla = Convert.ToInt32(item[3].ToString());
                        aportacionTrabajador.MaestroAportacionTrabajador = oPlanilla.TraerMaestroAportacionesTrabajador(aportacionTrabajador.IdtMaestroATrabajador);
                        auxiliar.listaAportacionesTrabajador.Add(aportacionTrabajador);
                    }

                    DataTable tablaAportacionesEmpleador = Conexion.GDatos.TraerDataTable("spTraerDetalleAportacionesEmpleador", id);
                    foreach (DataRow item in tablaAportacionesEmpleador.Rows)
                    {
                        cDetallePlanillaAEmpleador aportacionEmpleador = new cDetallePlanillaAEmpleador();
                        aportacionEmpleador.IdtDetallePlanillaAEmpleador = Convert.ToInt32(item[0].ToString());
                        aportacionEmpleador.Monto = Convert.ToDecimal(item[1].ToString());
                        aportacionEmpleador.IdtMaestroAEmpleador = Convert.ToInt32(item[2].ToString());
                        aportacionEmpleador.IdtDetallePlanilla = Convert.ToInt32(item[3].ToString());
                        aportacionEmpleador.MaestroAportacionE = oPlanilla.TraerMaestroAportacionesEmpleador(aportacionEmpleador.IdtMaestroAEmpleador);
                        auxiliar.listaAportacionesEmpleador.Add(aportacionEmpleador);
                    }

                    return auxiliar;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo TraerDetallePlanillaxCodigo: " + ex.Message);
            }
        }
    }
}
