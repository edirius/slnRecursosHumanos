using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeNegocios.Planillas;
using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios.Reportes
{
    public class cReporteBoletasXTrabajador
    {
        private cTrabajador trabajador;
        private List<cDetalleReporteBoletaXTrabajador> listaBoletasXAño;

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

        public List<cDetalleReporteBoletaXTrabajador> ListaBoletasXAño
        {
            get
            {
                return listaBoletasXAño;
            }

            set
            {
                listaBoletasXAño = value;
            }
        }

        public cReporteBoletasXTrabajador(cTrabajador miTrabajador)
        {
            this.Trabajador = miTrabajador;
            this.ListaBoletasXAño = new List<cDetalleReporteBoletaXTrabajador>();
        }


        /// <summary>
        /// Metodo que devuelde una lista de detalles de boleta conteniendo la planilla y detalle de planilla
        /// </summary>
        /// <param name="miTrabajador"></param>
        /// <param name="año"></param>
        /// <returns></returns>
        public List<cDetalleReporteBoletaXTrabajador> TraerListaPLanillas(cTrabajador miTrabajador, int año)
        {
            try
            {
                List<cDetalleReporteBoletaXTrabajador> detallesBoleta = new List<cDetalleReporteBoletaXTrabajador>();

                DataTable listaDetalles = Conexion.GDatos.TraerDataTable("spTraerPLanillasXDNI", miTrabajador.IdTrabajador, año);
                if (listaDetalles.Rows.Count > 0)
                {
                    foreach (DataRow item in listaDetalles.Rows)
                    {
                        
                        cDetalleReporteBoletaXTrabajador detalle = new cDetalleReporteBoletaXTrabajador();
                        detalle.Planilla = new cPlanilla();
                        detalle.Planilla.IdtPlanilla = Convert.ToInt32(item[0].ToString());
                        detalle.Planilla.Numero = item[1].ToString();
                        detalle.Planilla.Mes = item[2].ToString();
                        detalle.Planilla.Año = item[3].ToString();
                        detalle.Planilla.Fecha = Convert.ToDateTime(item[4].ToString());
                        detalle.Planilla.IdtMeta = Convert.ToInt32(item[5].ToString());
                        detalle.Planilla.IdtFuenteFinanciamiento = Convert.ToInt32(item[6].ToString());
                        detalle.Planilla.IdtRegimenLaboral = Convert.ToInt32(item[7].ToString());
                        detalle.Planilla.Descripcion = item[8].ToString();
                        detalle.Planilla.Plantilla = item[9].ToString();
                        detalle.Planilla.Observaciones = item[10].ToString();

                        detalle.DetallePlanilla = new cDetallePlanilla();
                        detalle.DetallePlanilla.IdtDetallePlanilla = Convert.ToInt32(item[11].ToString());
                        detalle.DetallePlanilla.Cargo = item[12].ToString();
                        detalle.DetallePlanilla.FechaInicio = Convert.ToDateTime(item[13].ToString());
                        detalle.DetallePlanilla.DiasLaborados = Convert.ToInt16(item[14].ToString());
                        detalle.DetallePlanilla.TotalIngresos = Convert.ToDecimal(item[15].ToString());
                        detalle.DetallePlanilla.TotalATrabajador = Convert.ToDecimal(item[16].ToString());
                        detalle.DetallePlanilla.TotalDescuentos = Convert.ToDecimal(item[17].ToString());
                        detalle.DetallePlanilla.TotalAEmpleador = Convert.ToDecimal(item[18].ToString());
                        detalle.DetallePlanilla.NetoaCobrar = Convert.ToDecimal(item[19].ToString());

                        detallesBoleta.Add(detalle);
                    }
                }
                return detallesBoleta;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo TraerListaPLanillasXDNI: " + ex.Message);
            }
            
        }
    }
}
