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
                    oPlanilla.ListaDetalle = TraerDetallesPlanilla(oPlanilla.codigo);
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
                    miMeta.Numero = Convert.ToInt16(metaAuxiliar.Rows[0][3]);
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

        public cTrabajador TraerTrabajador (int codigo)
        {
            try
            {
                cTrabajador miTrabajador = new cTrabajador();
                DataTable TablaTrabajador = Conexion.GDatos.TraerDataTable("spTraerTrabajadorxID", codigo);
                if (TablaTrabajador.Rows.Count > 0)
                {
                    miTrabajador.IdTrabajador = Convert.ToInt16(TablaTrabajador.Rows[0][0]);
                    miTrabajador.Nombres = Convert.ToString(TablaTrabajador.Rows[0][1]);
                    miTrabajador.ApellidoPaterno = Convert.ToString(TablaTrabajador.Rows[0][2]);
                    miTrabajador.ApellidoMaterno = Convert.ToString(TablaTrabajador.Rows[0][3]);
                    miTrabajador.ListaRegimenPensionario = TraerRegimenPensionario(miTrabajador.IdTrabajador);
                    TablaTrabajador.Dispose();
                }
                return miTrabajador;
            }
            catch (Exception e)
            {
                throw new cReglaNegociosException("blPlanilla: " + e.Message);
            }
        }

        public List<cPeriodoRegimenPensionario> TraerRegimenPensionario (int codigoTrabajador)
        {
            try
            {
                List<cPeriodoRegimenPensionario> listaRegimenPensionario = new List<cPeriodoRegimenPensionario>();

                DataTable TablaPeriodoRegimenPensionario = Conexion.GDatos.TraerDataTable("spTraerPeriodosRegimenPensionario", codigoTrabajador);
                if (TablaPeriodoRegimenPensionario.Rows.Count > 0 )
                {
                    for (int i = 0; i < TablaPeriodoRegimenPensionario.Rows.Count; i++)
                    {
                        cPeriodoRegimenPensionario miPeriodoRegimenPensionario = new cPeriodoRegimenPensionario();

                        miPeriodoRegimenPensionario.IdRegimenPensionario = Convert.ToInt16(TablaPeriodoRegimenPensionario.Rows[i][0]);
                        miPeriodoRegimenPensionario.FechaInicio = Convert.ToDateTime(TablaPeriodoRegimenPensionario.Rows[i][1]);
                        if (string.IsNullOrEmpty(Convert.ToString(TablaPeriodoRegimenPensionario.Rows[i][2])))
                        {
                            miPeriodoRegimenPensionario.FechaFin = new DateTime(2999, 12, 31);
                        }
                        else
                        { 
                            miPeriodoRegimenPensionario.FechaFin = Convert.ToDateTime(TablaPeriodoRegimenPensionario.Rows[i][2]);
                        }
                       
                        miPeriodoRegimenPensionario.Cuspp = Convert.ToString(TablaPeriodoRegimenPensionario.Rows[i][3]);
                        miPeriodoRegimenPensionario.TipoComision = Convert.ToString(TablaPeriodoRegimenPensionario.Rows[i][4]);
                        miPeriodoRegimenPensionario.MiAFP = TraerAFP(Convert.ToInt16(TablaPeriodoRegimenPensionario.Rows[i][5]));
                        listaRegimenPensionario.Add(miPeriodoRegimenPensionario);
                    }
                    return listaRegimenPensionario;
                }
                else
                {
                    throw new cReglaNegociosException("blPlanilla: No existe regimen pensionarios para el trabajador.");
                }
            }
            catch (Exception e)
            {

                throw new cReglaNegociosException("blplanilla: " + e.Message );
            }
        }

        public cAFP TraerAFP(int codigoAFP)
        {
            try
            {
                cAFP miAFp = new cAFP();
                DataTable TablaAFP = Conexion.GDatos.TraerDataTable("spTraerAFP", codigoAFP);
                if (TablaAFP.Rows.Count > 0)
                {
                    miAFp.CodigoAFP = Convert.ToInt16(TablaAFP.Rows[0][0]);
                    miAFp.Nombre = Convert.ToString(TablaAFP.Rows[0][1]);
                    return miAFp;
                }
                else
                {
                    throw new cReglaNegociosException("blPlanilla: No existe ninguna AFP para el codigo");
                }
            }
            catch (Exception d)
            {

                throw new cReglaNegociosException("blPlanilla: " + d.Message);
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
                        detalleAuxiliar.codigo = Convert.ToInt32(ListaDetallesAuxiliar.Rows[i][0]); 
                        detalleAuxiliar.numero = i + 1;
                        detalleAuxiliar.cargo = Convert.ToString(ListaDetallesAuxiliar.Rows[i][1]);
                        detalleAuxiliar.fechaInicio = Convert.ToDateTime(ListaDetallesAuxiliar.Rows[i][2]);
                        detalleAuxiliar.diasLaborados = Convert.ToInt16(ListaDetallesAuxiliar.Rows[i][3]);
                        detalleAuxiliar.totalIngreso = Convert.ToDouble(ListaDetallesAuxiliar.Rows[i][4]);
                        detalleAuxiliar.totalAportacionesTrabajador = Convert.ToDouble(ListaDetallesAuxiliar.Rows[i][5]);
                        detalleAuxiliar.totalDescuentos = Convert.ToDouble(ListaDetallesAuxiliar.Rows[i][6]);
                        detalleAuxiliar.totalAportacionesEmpleador = Convert.ToDouble(ListaDetallesAuxiliar.Rows[i][7]);
                        detalleAuxiliar.netoACobrar = Convert.ToDouble(ListaDetallesAuxiliar.Rows[i][8]);
                        detalleAuxiliar.miTrabajador = TraerTrabajador (Convert.ToInt32(ListaDetallesAuxiliar.Rows[i][9]));
                        detalleAuxiliar.ListaDetalleIngresos = TraerListaIngresos(detalleAuxiliar);
                        detalleAuxiliar.ListaDetalleEgresos = TraerListaDescuentos(detalleAuxiliar);
                        detalleAuxiliar.ListaDetalleAportacionesTrabajador = TraerListaAportacionesTrabajador(detalleAuxiliar);
                        detalleAuxiliar.ListaDetalleAportacionesEmpleador = TraerListaAportacionesEmpleador(detalleAuxiliar);
                        ListaDetalles.Add(detalleAuxiliar);
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
                        ingresoAuxiliar.Codigo = Convert.ToInt32(ListaAuxiliarIngresos.Rows[i][0]);
                        ingresoAuxiliar.Monto = Convert.ToDouble(ListaAuxiliarIngresos.Rows[i][1]);
                        ingresoAuxiliar.MaestroIngresos = TraerMaestroIngresos(Convert.ToInt16(ListaAuxiliarIngresos.Rows[i][2]));
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

        public Sunat.cMaestroIngresos TraerMaestroIngresos(int codigo)
        {
            try
            {
                DataTable AuxiliarMaestroIngresos = Conexion.GDatos.TraerDataTable("spTraerMaestroIngresos", codigo);
                Sunat.cMaestroIngresos MIngresoAuxiliar = new Sunat.cMaestroIngresos();
                if (AuxiliarMaestroIngresos.Rows.Count > 0)
                {
                    
                    MIngresoAuxiliar.IdtMaestroIngresos = Convert.ToInt16(AuxiliarMaestroIngresos.Rows[0][0]);
                    MIngresoAuxiliar.Codigo = Convert.ToString(AuxiliarMaestroIngresos.Rows[0][1]);
                    MIngresoAuxiliar.Descripcion = Convert.ToString(AuxiliarMaestroIngresos.Rows[0][2]);
                    MIngresoAuxiliar.Essalud_trabajador = Convert.ToBoolean(AuxiliarMaestroIngresos.Rows[0][3]);
                    MIngresoAuxiliar.Essalud_cbssp = Convert.ToBoolean(AuxiliarMaestroIngresos.Rows[0][4]);
                    MIngresoAuxiliar.Essalud_agrario = Convert.ToBoolean(AuxiliarMaestroIngresos.Rows[0][5]);
                    MIngresoAuxiliar.Essalud_sctr = Convert.ToBoolean(AuxiliarMaestroIngresos.Rows[0][6]);
                    MIngresoAuxiliar.Impuesto_extraord = Convert.ToBoolean(AuxiliarMaestroIngresos.Rows[0][7]);
                    MIngresoAuxiliar.Derechos_sociales = Convert.ToBoolean(AuxiliarMaestroIngresos.Rows[0][8]);
                    MIngresoAuxiliar.Senati = Convert.ToBoolean(AuxiliarMaestroIngresos.Rows[0][9]);
                    MIngresoAuxiliar.Snp = Convert.ToBoolean(AuxiliarMaestroIngresos.Rows[0][10]);
                    MIngresoAuxiliar.Spp = Convert.ToBoolean(AuxiliarMaestroIngresos.Rows[0][11]);
                    MIngresoAuxiliar.Renta_5ta = Convert.ToBoolean(AuxiliarMaestroIngresos.Rows[0][12]);
                    MIngresoAuxiliar.Essalud_pensionista = Convert.ToBoolean(AuxiliarMaestroIngresos.Rows[0][13]);
                    MIngresoAuxiliar.Contrib_solidaria = Convert.ToBoolean(AuxiliarMaestroIngresos.Rows[0][14]);
                    MIngresoAuxiliar.Calculo = Convert.ToString(AuxiliarMaestroIngresos.Rows[0][15]);
                    MIngresoAuxiliar.Abreviacion = Convert.ToString(AuxiliarMaestroIngresos.Rows[0][16]);
                    MIngresoAuxiliar.Informativa = Convert.ToBoolean(AuxiliarMaestroIngresos.Rows[0][17]);
                    MIngresoAuxiliar.Tipo = Convert.ToString(AuxiliarMaestroIngresos.Rows[0][18]);

                }
                else
                {
                    throw new cReglaNegociosException("blPlanilla: No existe datos para Maestro INgresos");
                }
                return MIngresoAuxiliar;
            }
            catch (Exception e)
            {
                throw new cReglaNegociosException("blPlanilla: " + e.Message);
            }
        }

        public List<cnDetallePlanillaEgresos> TraerListaDescuentos(cnDetallePlanilla miDetallePlanilla)
        {
            try
            {
                List<cnDetallePlanillaEgresos> miListaDetalleDescuentos = new List<cnDetallePlanillaEgresos>();
                DataTable ListaAuxiliarEgresos = Conexion.GDatos.TraerDataTable("spTraerDetalleDescuentos", miDetallePlanilla.codigo);
                if (ListaAuxiliarEgresos.Rows.Count > 0)
                {
                    for (int i = 0; i < ListaAuxiliarEgresos.Rows.Count; i++)
                    {
                        cnDetallePlanillaEgresos descuentoAuxiliar = new  cnDetallePlanillaEgresos();
                        descuentoAuxiliar.Codigo = Convert.ToInt32(ListaAuxiliarEgresos.Rows[0][0]);
                        descuentoAuxiliar.Monto = Convert.ToDouble(ListaAuxiliarEgresos.Rows[0][1]);
                        descuentoAuxiliar.MaestroDescuentos = TraerMaestroDescuento(Convert.ToInt16(ListaAuxiliarEgresos.Rows[0][2]));  
                        miListaDetalleDescuentos.Add(descuentoAuxiliar);
                    }
                }
                return miListaDetalleDescuentos;
            }
            catch (Exception e)
            {

                throw new cReglaNegociosException("blPLanilla: " + e.Message);
            }
        }

        public Sunat.cMaestroDescuentos TraerMaestroDescuento (int codigo)
        {
            try
            {
                DataTable AuxiliarMaestroEgresos = Conexion.GDatos.TraerDataTable("spTraerMaestroDescuento", codigo);
                Sunat.cMaestroDescuentos MDescuentoAuxiliar = new Sunat.cMaestroDescuentos();
                if (AuxiliarMaestroEgresos.Rows.Count > 0)
                {

                    MDescuentoAuxiliar.IdtMaestroDescuentos = Convert.ToInt16(AuxiliarMaestroEgresos.Rows[0][0]);
                    MDescuentoAuxiliar.Codigo = Convert.ToString(AuxiliarMaestroEgresos.Rows[0][1]);
                    MDescuentoAuxiliar.Descripcion = Convert.ToString(AuxiliarMaestroEgresos.Rows[0][2]);
                    MDescuentoAuxiliar.Calculo = Convert.ToString(AuxiliarMaestroEgresos.Rows[0][3]);
                    MDescuentoAuxiliar.Abreviacion = Convert.ToString(AuxiliarMaestroEgresos.Rows[0][4]);
                 }
                else
                {
                    throw new cReglaNegociosException("blPlanilla: No existe datos para Maestro Descuentos");
                }
                return MDescuentoAuxiliar;
            }
            catch (Exception e)
            {
                throw new cReglaNegociosException("blPlanilla: " + e.Message);
            }
        }

        public List<cnDetallePlanillaAportacionesTrabajador> TraerListaAportacionesTrabajador(cnDetallePlanilla miDetallePlanilla)
        {
            try
            {
                List<cnDetallePlanillaAportacionesTrabajador> miListaAportacionesTrabajador =  new List<cnDetallePlanillaAportacionesTrabajador>();
                DataTable ListaAuxiliarAportacionesTrabajador = Conexion.GDatos.TraerDataTable("spTraerDetalleAportacionesTrabajador", miDetallePlanilla.codigo);
                if (ListaAuxiliarAportacionesTrabajador.Rows.Count > 0)
                {
                    for (int i = 0; i < ListaAuxiliarAportacionesTrabajador.Rows.Count; i++)
                    {
                        cnDetallePlanillaAportacionesTrabajador aportacionAuxiliar = new cnDetallePlanillaAportacionesTrabajador();
                        aportacionAuxiliar.Codigo = Convert.ToInt32(ListaAuxiliarAportacionesTrabajador.Rows[i][0]);
                        aportacionAuxiliar.Monto = Convert.ToDouble(ListaAuxiliarAportacionesTrabajador.Rows[i][1]);
                        aportacionAuxiliar.MaestroAportacionTrabajador = TraerMaestroAportacionesTrabajador(Convert.ToInt16(ListaAuxiliarAportacionesTrabajador.Rows[i][2]));
                        miListaAportacionesTrabajador.Add(aportacionAuxiliar);
                    }
                }
                return miListaAportacionesTrabajador;
            }
            catch (Exception e)
            {

                throw new cReglaNegociosException("blPLanilla: " + e.Message);
            }
        }

        public Sunat.cMaestroAportacionesTrabajador TraerMaestroAportacionesTrabajador(int codigo)
        {
            try
            {
                DataTable AuxiliarMaestroAportacionTrabajador = Conexion.GDatos.TraerDataTable("spTraerMaestroAportacionTrabajador", codigo);
                Sunat.cMaestroAportacionesTrabajador MAportacionTrabajador = new Sunat.cMaestroAportacionesTrabajador();
                if (AuxiliarMaestroAportacionTrabajador.Rows.Count > 0)
                {

                    MAportacionTrabajador.IdtMaestroAportacionesTrabajador  = Convert.ToInt16(AuxiliarMaestroAportacionTrabajador.Rows[0][0]);
                    MAportacionTrabajador.Codigo = Convert.ToString(AuxiliarMaestroAportacionTrabajador.Rows[0][1]);
                    MAportacionTrabajador.Descripcion = Convert.ToString(AuxiliarMaestroAportacionTrabajador.Rows[0][2]);
                    MAportacionTrabajador.Calculo = Convert.ToString(AuxiliarMaestroAportacionTrabajador.Rows[0][3]);
                    MAportacionTrabajador.Abreviacion = Convert.ToString(AuxiliarMaestroAportacionTrabajador.Rows[0][4]);
                }
                else
                {
                    throw new cReglaNegociosException("blPlanilla: No existe datos para Maestro Aportacion Trabajador");
                }
                return MAportacionTrabajador;
            }
            catch (Exception e)
            {
                throw new cReglaNegociosException("blPlanilla: " + e.Message);
            }
        }


        public List<cnDetallePlanillaAportacionesEmpleador> TraerListaAportacionesEmpleador(cnDetallePlanilla miDetallePlanilla)
        {
            try
            {
                List<cnDetallePlanillaAportacionesEmpleador> miListaAportacionesEmpleador = new List<cnDetallePlanillaAportacionesEmpleador>();
                DataTable ListaAuxiliarAportacionesEmpleador = Conexion.GDatos.TraerDataTable("spTraerDetalleAportacionesEmpleador", miDetallePlanilla.codigo);
                if (ListaAuxiliarAportacionesEmpleador.Rows.Count > 0)
                {
                    for (int i = 0; i < ListaAuxiliarAportacionesEmpleador.Rows.Count; i++)
                    {
                        cnDetallePlanillaAportacionesEmpleador aportacionAuxiliar = new cnDetallePlanillaAportacionesEmpleador();
                        aportacionAuxiliar.Codigo = Convert.ToInt32(ListaAuxiliarAportacionesEmpleador.Rows[i][0]);
                        aportacionAuxiliar.Monto = Convert.ToDouble(ListaAuxiliarAportacionesEmpleador.Rows[i][1]);
                        aportacionAuxiliar.MaestroAportacionesEmpleador = TraerMaestroAportacionesEmpleador(Convert.ToInt16(ListaAuxiliarAportacionesEmpleador.Rows[i][2]));
                        miListaAportacionesEmpleador.Add(aportacionAuxiliar);
                    }
                }
                return miListaAportacionesEmpleador;
            }
            catch (Exception e)
            {

                throw new cReglaNegociosException("blPLanilla: " + e.Message);
            }
        }

        public Sunat.cMaestroAportacionesEmpleador TraerMaestroAportacionesEmpleador (int codigo)
        {
            try
            {
                DataTable AuxiliarMaestroAportacionEmpleador = Conexion.GDatos.TraerDataTable("spTraerMaestroAportacionEmpleador", codigo);
                Sunat.cMaestroAportacionesEmpleador MAportacionEmpleador = new Sunat.cMaestroAportacionesEmpleador();
                if (AuxiliarMaestroAportacionEmpleador.Rows.Count > 0)
                {

                    MAportacionEmpleador.IdtMaestroAportacionesEmpleador = Convert.ToInt16(AuxiliarMaestroAportacionEmpleador.Rows[0][0]);
                    MAportacionEmpleador.Codigo = Convert.ToString(AuxiliarMaestroAportacionEmpleador.Rows[0][1]);
                    MAportacionEmpleador.Descripcion = Convert.ToString(AuxiliarMaestroAportacionEmpleador.Rows[0][2]);
                    MAportacionEmpleador.Calculo = Convert.ToString(AuxiliarMaestroAportacionEmpleador.Rows[0][3]);
                    MAportacionEmpleador.Abreviacion = Convert.ToString(AuxiliarMaestroAportacionEmpleador.Rows[0][4]);
                }
                else
                {
                    throw new cReglaNegociosException("blPlanilla: No existe datos para Maestro Aportacion Empleador");
                }
                return MAportacionEmpleador;
            }
            catch (Exception e)
            {
                throw new cReglaNegociosException("blPlanilla: " + e.Message);
            }
        }

        public cnDetallePlanilla ListaTotales(cnPlanilla miPlanilla)
        {
            cnDetallePlanilla auxiliarDetalle = new cnDetallePlanilla();
             

            for (int i = 0; i < miPlanilla.ListaDetalle[0].ListaDetalleIngresos.Count ; i++)
            {
                cnDetallePlanillaIngresos auxiliarIngresos = new cnDetallePlanillaIngresos();
                auxiliarIngresos.MaestroIngresos = miPlanilla.ListaDetalle[0].ListaDetalleIngresos[i].MaestroIngresos;
                auxiliarDetalle.ListaDetalleIngresos.Add(auxiliarIngresos); 
                
            }

            for (int i = 0; i < miPlanilla.ListaDetalle[0].ListaDetalleEgresos.Count  ; i++)
            {
                cnDetallePlanillaEgresos auxiliarEgresos = new cnDetallePlanillaEgresos();
                auxiliarEgresos.MaestroDescuentos = miPlanilla.ListaDetalle[0].ListaDetalleEgresos[i].MaestroDescuentos;
                auxiliarDetalle.ListaDetalleEgresos.Add(auxiliarEgresos);
            }

            for (int i = 0; i < miPlanilla.ListaDetalle[0].ListaDetalleAportacionesEmpleador.Count ; i++)
            {
                cnDetallePlanillaAportacionesEmpleador aportacionEmpleador = new cnDetallePlanillaAportacionesEmpleador();
                aportacionEmpleador.MaestroAportacionesEmpleador = miPlanilla.ListaDetalle[0].ListaDetalleAportacionesEmpleador[i].MaestroAportacionesEmpleador;
                auxiliarDetalle.ListaDetalleAportacionesEmpleador.Add(aportacionEmpleador);
                 
            }

            for (int i = 0; i < miPlanilla.ListaDetalle[0].ListaDetalleAportacionesTrabajador.Count  ; i++)
            {
                cnDetallePlanillaAportacionesTrabajador aportacionTrabajador = new cnDetallePlanillaAportacionesTrabajador();
                aportacionTrabajador.MaestroAportacionTrabajador = miPlanilla.ListaDetalle[0].ListaDetalleAportacionesTrabajador[i].MaestroAportacionTrabajador;  
                auxiliarDetalle.ListaDetalleAportacionesTrabajador.Add(aportacionTrabajador); 
            }

            for (int i = 0; i < miPlanilla.ListaDetalle.Count; i++)
            {
                for (int j = 0; j < miPlanilla.ListaDetalle[i].ListaDetalleIngresos.Count ; j++)
                {
                    auxiliarDetalle.ListaDetalleIngresos[j].Monto = auxiliarDetalle.ListaDetalleIngresos[j].Monto + miPlanilla.ListaDetalle[i].ListaDetalleIngresos[j].Monto;

                }

                for (int k = 0; k < miPlanilla.ListaDetalle[i].ListaDetalleEgresos.Count  ; k++)
                {
                    auxiliarDetalle.ListaDetalleEgresos[k].Monto = auxiliarDetalle.ListaDetalleEgresos[k].Monto + miPlanilla.ListaDetalle[i].ListaDetalleEgresos[k].Monto; 
                }

                for (int l = 0; l < miPlanilla.ListaDetalle[i].ListaDetalleAportacionesTrabajador.Count  ; l++)
                {
                    auxiliarDetalle.ListaDetalleAportacionesTrabajador[l].Monto += miPlanilla.ListaDetalle[i].ListaDetalleAportacionesTrabajador[l].Monto;  
                }
                for (int n = 0; n < miPlanilla.ListaDetalle[i].ListaDetalleAportacionesEmpleador.Count  ; n++)
                {
                    auxiliarDetalle.ListaDetalleAportacionesEmpleador[n].Monto += miPlanilla.ListaDetalle[i].ListaDetalleAportacionesEmpleador[n].Monto;   
                }
            }

         
            return auxiliarDetalle;
        }

        
    }
}
