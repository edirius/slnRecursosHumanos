using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using System.Data;

namespace CapaDeNegocios.PlanillaNueva
{
    public class blPlanilla
    {
        public cnPlanilla TraerPlanilla (int codigoPlanilla)
        {
            try
            {
                cnPlanilla oPlanilla = new cnPlanilla();
                DataTable tAuxiliar = Conexion.GDatos.TraerDataTable("spTraerPlanillaxID", codigoPlanilla);
                if (tAuxiliar.Rows.Count > 0)
                {
                    oPlanilla.codigo = Convert.ToInt16 ( tAuxiliar.Rows[0][0]);
                    oPlanilla.numeroPlanilla = Convert.ToString(tAuxiliar.Rows[0][1]);
                    oPlanilla.Mes = Convert.ToString(tAuxiliar.Rows[0][2]);
                    oPlanilla.Año = Convert.ToString(tAuxiliar.Rows[0][3]);
                    oPlanilla.Fecha = Convert.ToDateTime(tAuxiliar.Rows[0][4]);
                    oPlanilla.Meta.Codigo = Convert.ToInt16(tAuxiliar.Rows[0][5]);
                    oPlanilla.FuenteFinanciamiento.IdTFuenteFinanciamiento = Convert.ToInt16(tAuxiliar.Rows[0][6]);
                    oPlanilla.RegimenLaboral.IdTRegimenLaboral = Convert.ToInt16(tAuxiliar.Rows[0][7]);
                    oPlanilla.Descripcion = Convert.ToString(tAuxiliar.Rows[0][8]);
                    tAuxiliar.Dispose();
                    oPlanilla.Meta = TraerMeta(oPlanilla.Meta.Codigo);
                    oPlanilla.FuenteFinanciamiento = TraerFuenteFinanciamiento(oPlanilla.FuenteFinanciamiento.IdTFuenteFinanciamiento);
                    oPlanilla.RegimenLaboral = TraerRegimenLaboral(oPlanilla.RegimenLaboral.IdTRegimenLaboral);

                }

                else
                {
                    throw new cReglaNegociosException("No existe alguna planilla para el codigo. blPlanilla" );
                }
                return oPlanilla;
            }
            catch (Exception e)
            {
                throw new cReglaNegociosException ("blPLanilla : " + e.Message);
            }
            
        }

        public Obras.cMeta TraerMeta(int codigo)
        {
            try
            {
                Obras.cMeta miMeta = new Obras.cMeta();
                DataTable metaAuxiliar = Conexion.GDatos.TraerDataTable("spTraerMetaxID", codigo);
                if (metaAuxiliar.Rows.Count > 0)
                {
                    miMeta.Codigo = Convert.ToInt16(metaAuxiliar.Rows[0][0]);
                    miMeta.Año = Convert.ToInt16(metaAuxiliar.Rows [0][1]);
                    miMeta.Nombre = Convert.ToString(metaAuxiliar.Rows [0][2]);
                    return miMeta;
                }
                else

                {
                    throw new cReglaNegociosException("No existe Meta para el codigo ingresado. blPLanilla");
                }
            }
            catch (Exception e)
            {
               throw new cReglaNegociosException ("blPLanilla: " + e.Message);
            }
        }

        public cFuenteFinanciamiento TraerFuenteFinanciamiento (int codigo)
        {
            try
            {
                cFuenteFinanciamiento miFuenteFinanciamiento = new cFuenteFinanciamiento();
                DataTable FuenteAuxiliar = Conexion.GDatos.TraerDataTable("spTraerFuentexID", codigo);
                if (FuenteAuxiliar.Rows.Count > 0)
                {
                    miFuenteFinanciamiento.IdTFuenteFinanciamiento = Convert.ToInt16(FuenteAuxiliar.Rows[0][0]);
                    miFuenteFinanciamiento.Codigo = Convert.ToString(FuenteAuxiliar.Rows[0][1]);
                    miFuenteFinanciamiento.Descripcion = Convert.ToString(FuenteAuxiliar.Rows[0][2]);
                    FuenteAuxiliar.Dispose(); 
                }
                return miFuenteFinanciamiento;
            }
            catch (Exception e)
            {
                throw new cReglaNegociosException("blPlanilla: " + e.Message);
            }
        }

        public DatosLaborales.cRegimenLaboral TraerRegimenLaboral(int codigo)
        {
            try
            {
                DatosLaborales.cRegimenLaboral miRegimenLaboral = new DatosLaborales.cRegimenLaboral();
                DataTable RegimenAuxiliar = Conexion.GDatos.TraerDataTable("spTraerRegimenLaboral", codigo);
                if (RegimenAuxiliar.Rows.Count > 0)
                {
                    miRegimenLaboral.IdTRegimenLaboral = Convert.ToInt16(RegimenAuxiliar.Rows[0][0]);
                    miRegimenLaboral.Codigo = Convert.ToString(RegimenAuxiliar.Rows[0][1]);
                    miRegimenLaboral.Descripcion = Convert.ToString(RegimenAuxiliar.Rows[0][2]);
                    RegimenAuxiliar.Dispose();  
                }
                return miRegimenLaboral;
            }
            catch (Exception e)
            {
                throw new cReglaNegociosException("blPlanilla: " + e.Message);
            }
        }

        public List<cnDetallePlanilla> TraerDetallesPlanilla(int codigoPlanilla)
        {
            try
            {
                List<cnDetallePlanilla> ListaDetalles = new List<cnDetallePlanilla>();
                DataTable ListaDetallesAuxiliar = Conexion.GDatos.TraerDataTable("spTraerDetallePlanilla", codigoPlanilla);
                if (ListaDetallesAuxiliar.Rows.Count > 0 )
                {
                    for (int i = 0; i < ListaDetallesAuxiliar.Rows.Count; i++)
                    {
                        cnDetallePlanilla detalleAuxiliar = new cnDetallePlanilla();
                        detalleAuxiliar.numero = i + 1;
                        detalleAuxiliar.miTrabajador.IdTrabajador = Convert.ToInt16(ListaDetallesAuxiliar.Rows[0][9]);

                    }
                    return ListaDetalles; 
                }     
                else
                {
                    throw new cReglaNegociosException("blPlanilla: No existe detalles de planilla");
                }
            }
            catch (Exception e)
            {

                throw new cReglaNegociosException("blPlanilla: " + e.Message );
            }
        }

        public List<cnDetallePlanillaIngresos> TraerListaIngresos(cnDetallePlanilla  miDetallePlanilla)
        {
            try
            {
                List<cnDetallePlanillaIngresos> miListaDetalleIngresos = new List<cnDetallePlanillaIngresos>();
                DataTable ListaAuxiliarIngresos = Conexion.GDatos.TraerDataTable("spTraerDetalleIngresos", miDetallePlanilla.codigo);
                if (ListaAuxiliarIngresos.Rows.Count > 0)
                {
                    for (int i = 0; i < ListaAuxiliarIngresos.Rows.Count; i++)
                    {
                        cnDetallePlanillaIngresos ingresoAuxiliar = new cnDetallePlanillaIngresos();
                        ingresoAuxiliar.Codigo = Convert.ToInt16(ListaAuxiliarIngresos.Rows[0][0]);
                        ingresoAuxiliar.Monto = Convert.ToDouble(ListaAuxiliarIngresos.Rows[0][1]);
                        ingresoAuxiliar.MaestroIngresos.Codigo = Convert.ToString(ListaAuxiliarIngresos.Rows[0][2]);
                        miListaDetalleIngresos.Add(ingresoAuxiliar);
                    }
                }
                return miListaDetalleIngresos;    
            }
            catch (Exception e)
            {

                throw new cReglaNegociosException("blPLanilla: " + e.Message) ;
            }
        }
    }
}
