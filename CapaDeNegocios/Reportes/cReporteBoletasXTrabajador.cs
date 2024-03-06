using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeNegocios.Planillas;
using System.Data;
using CapaDeDatos;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Globalization;

namespace CapaDeNegocios.Reportes
{
    public enum OpcionesReporteBoleta { 
    
            UnaBoletaxPagina,
            DosBoletaXPagina,
        BoletaDuplicada
    }

    public enum OpcionesPaginaReporteBoleta
    {
        Horizontal,
        Vertical
    }

    public class cReporteBoletasXTrabajador
    {
        

        private cTrabajador trabajador;
        private List<cDetalleReporteBoletaXTrabajador> listaBoletasXAño;
        private cImprimirReportePDF Impresion = new cImprimirReportePDF();
        private CapaDeNegocios.Planillas.cDetallePlanilla oDetalle = new cDetallePlanilla();
        private cDatosGenerales oDatosGenerales = new cDatosGenerales();
        CapaDeNegocios.DatosLaborales.cPeriodoTrabajador miPeriodoTrabajador = new CapaDeNegocios.DatosLaborales.cPeriodoTrabajador();
        DataTable oDataAFP = new DataTable();
        CapaDeNegocios.cListaAFP miAFP = new CapaDeNegocios.cListaAFP();

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
        public void TraerListaPLanillas(cTrabajador miTrabajador, int año)
        {
            try
            {
                this.trabajador = miTrabajador;
                List<cDetalleReporteBoletaXTrabajador> detallesBoleta = new List<cDetalleReporteBoletaXTrabajador>();
                CapaDeNegocios.Obras.cCadenaProgramaticaFuncional meta = new Obras.cCadenaProgramaticaFuncional();

                DataTable listaDetalles = Conexion.GDatos.TraerDataTable("spTraerPLanillasXDNI", miTrabajador.IdTrabajador, año);
                if (listaDetalles.Rows.Count > 0)
                {
                    
                    foreach (DataRow item in listaDetalles.Rows)
                    {
                        
                        cDetalleReporteBoletaXTrabajador detalle = new cDetalleReporteBoletaXTrabajador();
                        detalle.IdtPlanilla = Convert.ToInt32(item[0].ToString());
                        detalle.Numero = item[1].ToString();
                        detalle.Mes = item[2].ToString();
                        detalle.Año = item[3].ToString();
                        detalle.Fecha = Convert.ToDateTime(item[4].ToString());
                        detalle.IdtMeta = Convert.ToInt32(item[5].ToString());
                        detalle.IdtFuenteFinanciamiento = Convert.ToInt32(item[6].ToString());
                        detalle.IdtRegimenLaboral = Convert.ToInt32(item[7].ToString());
                        detalle.Descripcion = item[8].ToString();
                        detalle.Plantilla = item[9].ToString();
                        detalle.Observaciones = item[10].ToString();

                        detalle.IdtTrabajador = miTrabajador.IdTrabajador;

                        detalle.IdtDetallePlanilla = Convert.ToInt32(item[11].ToString());
                        detalle.Cargo = item[12].ToString();
                        detalle.FechaInicio = Convert.ToDateTime(item[13].ToString());
                        detalle.DiasLaborados = Convert.ToInt16(item[14].ToString());
                        detalle.TotalIngresos = Convert.ToDecimal(item[15].ToString());
                        detalle.TotalATrabajador = Convert.ToDecimal(item[16].ToString());
                        detalle.TotalDescuentos = Convert.ToDecimal(item[17].ToString());
                        detalle.TotalAEmpleador = Convert.ToDecimal(item[18].ToString());
                        detalle.NetoACobrar = Convert.ToDecimal(item[19].ToString());
                        detalle.Trabajador = miTrabajador;
                        detalle.Meta = meta.TraerMeta(detalle.IdtMeta);
                        detalle.DetallePlanilla = oDetalle.TraerDetallePlanillaxCodigo(detalle.IdtDetallePlanilla);
                        detallesBoleta.Add(detalle);
                    }
                }
                this.listaBoletasXAño = detallesBoleta;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo TraerListaPLanillasXDNI: " + ex.Message);
            }
            
        }

       

        public void ImprimirReporteBoleta(string RutaArchivo, OpcionesReporteBoleta opciones, Single tamañoLetra)
        {
            try
            {
                

                if (this.listaBoletasXAño.Count > 0)
                {
                    cReportePDF oReporte = new cReportePDF();
                    oReporte.TamañoDefectoLetra = tamañoLetra;
                    oReporte.RutaArchivo = RutaArchivo;
                    int numeroBoletasImpresas = 0;

                    cHojaPDF oHojaAuxiliar = new cHojaPDF();

                    foreach (cDetalleReporteBoletaXTrabajador item in listaBoletasXAño)
                    {

                        numeroBoletasImpresas++;

                        CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador AFPElegido = traerAFPTrabajador(Convert.ToInt32(trabajador.IdTrabajador), new DateTime(Convert.ToInt16(item.Año), Convert.ToInt16(Mes(item.Mes)), 1));

                        


                        cTablaPDF TablaTituloPrincipal = new cTablaPDF();
                        TablaTituloPrincipal.columnas = 1;
                        
                        TablaTituloPrincipal.anchoColumnas = new float[] { 500f };
                        cFilasPDF FilaTituloPrincipal = new cFilasPDF();


                        cCeldaPDF celdaVacia2 = new cCeldaPDF();
                        celdaVacia2.AltoColumna = 12;
                        celdaVacia2.QuitarBordes();
                        celdaVacia2.ImagenTranasparente = true;
                        
                        FilaTituloPrincipal.ListaCeldas.Add(celdaVacia2);

                        cTablaPDF TablaLogo = new cTablaPDF();
                        TablaLogo.columnas = 3;
                        TablaLogo.anchoColumnas = new float[] { 50f, 100f, 50f };

                        cFilasPDF FilaLogo = new cFilasPDF();

                        cCeldaPDF Logo = new cCeldaPDF();
                        Logo.esImagen = true;
                        Logo.QuitarBordes();
                        Logo.ImagenTranasparente = true;
                        Logo.Alineamiento = enumAlineamiento.izquierda;
                        Logo.ALineamientoVertical = enumAlineamientoVertical.abajo;
                        
                        FilaLogo.ListaCeldas.Add(Logo);

                        cTablaPDF TablaTitulos = new cTablaPDF();
                        TablaTitulos.columnas = 1;
                        TablaTitulos.anchoColumnas = new float[] { 500f };

                        cFilasPDF filaTitulos = new cFilasPDF();

                        cCeldaPDF TituloEmpresa = new cCeldaPDF();
                        TituloEmpresa.Contenido = oDatosGenerales.Nombre + " RUC: " + oDatosGenerales.Ruc;
                        TituloEmpresa.QuitarBordes();
                        TituloEmpresa.AltoColumna = 24;
                        TituloEmpresa.Alineamiento = enumAlineamiento.abajo;
                        TituloEmpresa.ALineamientoVertical = enumAlineamientoVertical.abajo;
                        TituloEmpresa.TamañoLetra = oReporte.TamañoDefectoLetra;
                        TituloEmpresa.ImagenTranasparente = true;
                        filaTitulos.ListaCeldas.Add(TituloEmpresa);

                        cCeldaPDF celdaVacia = new cCeldaPDF();
                        celdaVacia.AltoColumna = 12;
                        celdaVacia.QuitarBordes();
                        celdaVacia.BordeAnchos.AnchoArriba = 1;
                        celdaVacia.BordeAnchos.AnchoAbajo = 1;

                        cCeldaPDF celdaVaciaFinal = new cCeldaPDF();
                        celdaVaciaFinal.AltoColumna = 12;
                        celdaVaciaFinal.QuitarBordes();
                        celdaVaciaFinal.BordeAnchos.AnchoArriba = 1;
                        celdaVaciaFinal.BordeAnchos.AnchoAbajo = 1;
                        celdaVaciaFinal.BordeAnchos.AnchoDerecha = 1;

                        cCeldaPDF TituloPrincipal = new cCeldaPDF();
                        if (item.IdtRegimenLaboral == 3)
                        {
                            TituloPrincipal.Contenido = "BOLETA DE PAGO DE TRABAJADOR EVENTUAL";
                        }
                        else
                        {
                            TituloPrincipal.Contenido = "BOLETA DE PAGO";
                        }
                        
                        TituloPrincipal.QuitarBordes();
                        TituloPrincipal.AltoColumna = 12;
                        TituloPrincipal.TamañoLetra = oReporte.TamañoDefectoLetra;
                        TituloPrincipal.ImagenTranasparente = true;
                        filaTitulos.ListaCeldas.Add(TituloPrincipal);

                        cCeldaPDF tituloRegimen = new cCeldaPDF();
                        switch (item.IdtRegimenLaboral)
                        {
                            case 1:
                                tituloRegimen.Contenido = "D.L. 1057 CAS";
                                break;
                            case 2:
                                tituloRegimen.Contenido = "D.L. 726";
                                break;
                            case 3:
                                tituloRegimen.Contenido = "D.L. 728";
                                break;
                            case 4:
                                tituloRegimen.Contenido = "D.L. 30057";
                                break;
                            default:
                                break;
                        }
                        tituloRegimen.QuitarBordes();
                        tituloRegimen.ImagenTranasparente = true;
                        tituloRegimen.TamañoLetra = oReporte.TamañoDefectoLetra;
                        filaTitulos.ListaCeldas.Add(tituloRegimen);

                        cCeldaPDF tituloMes = new cCeldaPDF();
                        tituloMes.Contenido = item.Mes + " " + item.Año;
                        tituloMes.AltoColumna = 12;
                        tituloMes.QuitarBordes();
                        tituloMes.ImagenTranasparente = true;
                        tituloMes.TamañoLetra = oReporte.TamañoDefectoLetra;
                        filaTitulos.ListaCeldas.Add(tituloMes);

                        TablaTitulos.ListaFilas.Add(filaTitulos);

                        cCeldaPDF celdaTitulos = new cCeldaPDF();
                        celdaTitulos.TablaPDF = TablaTitulos;
                        celdaTitulos.QuitarBordes();

                        FilaLogo.ListaCeldas.Add(celdaTitulos);
                        FilaLogo.ListaCeldas.Add(celdaVacia2);

                        TablaLogo.ListaFilas.Add(FilaLogo);

                        cFilasPDF FilaMeta = new cFilasPDF();

                        cCeldaPDF NombreMeta = new cCeldaPDF();
                        NombreMeta.Contenido = "Meta: " + item.Meta.Numero + " " + item.Meta.Nombre;
                        NombreMeta.QuitarBordes();
                        NombreMeta.AltoColumna = 12;
                        NombreMeta.Alineamiento = enumAlineamiento.izquierda;
                        NombreMeta.TamañoLetra = oReporte.TamañoDefectoLetra;
                        FilaMeta.ListaCeldas.Add(NombreMeta);
                        TablaTituloPrincipal.ListaFilas.Add(FilaMeta);

                        cFilasPDF filaNombre = new cFilasPDF();

                        cCeldaPDF celdaNombre = new cCeldaPDF();
                        celdaNombre.Contenido = "Nombre: " + item.Trabajador.Nombres + " " + item.Trabajador.ApellidoPaterno + " " + item.Trabajador.ApellidoMaterno + "                        DNI: " + item.Trabajador.Dni  +  "                Nro. Planilla: "  + item.Numero + "      DIAS LABORADOS:  " + item.DiasLaborados;
                        celdaNombre.QuitarBordes();
                        celdaNombre.AltoColumna = 12;
                        celdaNombre.Alineamiento = enumAlineamiento.izquierda;
                        celdaNombre.TamañoLetra = oReporte.TamañoDefectoLetra;
                        filaNombre.ListaCeldas.Add(celdaNombre);
                        TablaTituloPrincipal.ListaFilas.Add(filaNombre);

                        cFilasPDF filaCargo = new cFilasPDF();

                        cCeldaPDF celdaCargo = new cCeldaPDF();
                        if (AFPElegido != null)
                        {
                            if (AFPElegido.IdtAFP == 5)
                            {
                                celdaCargo.Contenido = "Cargo: " + item.Cargo + "                           REGIMEN PENSIONARIO: " + AFPElegido.Afp.Nombre;
                            }
                            else
                            {
                                celdaCargo.Contenido = "Cargo: " + item.Cargo + "                           REGIMEN PENSIONARIO: " + AFPElegido.Afp.Nombre + "                  CUSPP: " + AFPElegido.CUSPP;
                            }
                            
                        }
                        else
                        {
                            celdaCargo.Contenido = "Cargo: " + item.Cargo;
                        }
                        
                        celdaCargo.QuitarBordes();
                        celdaCargo.AltoColumna = 12;
                        celdaCargo.Alineamiento = enumAlineamiento.izquierda;
                        celdaCargo.TamañoLetra = oReporte.TamañoDefectoLetra;
                        filaCargo.ListaCeldas.Add(celdaCargo);
                        TablaTituloPrincipal.ListaFilas.Add(filaCargo);

                        cTablaPDF TablaDetalle = new cTablaPDF();
                        TablaDetalle.columnas = 3;
                        TablaDetalle.anchoColumnas = new float[] { 50f, 50f , 50f};

                        cFilasPDF filaDetalle = new cFilasPDF();

                        

                        cTablaPDF TablaTituloIngreso = new cTablaPDF();
                        TablaTituloIngreso.columnas = 2;
                        TablaTituloIngreso.anchoColumnas = new float[] { 50f, 50f};

                        cFilasPDF FilaTituloIngreso = new cFilasPDF();

                       

                        cCeldaPDF TituloIngreso = new cCeldaPDF();
                        TituloIngreso.Contenido = "INGRESOS";
                        TituloIngreso.QuitarBordes();
                        TituloIngreso.BordeAnchos.AnchoIzquierda = 1;
                        TituloIngreso.BordeAnchos.AnchoArriba = 1;
                        TituloIngreso.AltoColumna = 12;
                        TituloIngreso.BordeAnchos.AnchoAbajo = 1;
                        TituloIngreso.TamañoLetra = oReporte.TamañoDefectoLetra;
                        FilaTituloIngreso.ListaCeldas.Add(TituloIngreso);
                        FilaTituloIngreso.ListaCeldas.Add(celdaVacia);
                        TablaTituloIngreso.ListaFilas.Add(FilaTituloIngreso);


                        cFilasPDF FilaTituloConcepto = new cFilasPDF();
                        cCeldaPDF TituloConcepto = new cCeldaPDF();
                        TituloConcepto.Contenido = "Concepto";
                        TituloConcepto.QuitarBordes();
                        TituloConcepto.BordeAnchos.AnchoIzquierda = 1;
                        TituloConcepto.AltoColumna = 12;
                        TituloConcepto.TamañoLetra = oReporte.TamañoDefectoLetra;
                        FilaTituloConcepto.ListaCeldas.Add(TituloConcepto);

                        cCeldaPDF TituloMonto = new cCeldaPDF();
                        TituloMonto.Contenido = "Monto";
                        TituloMonto.QuitarBordes();
                        TituloMonto.TamañoLetra = oReporte.TamañoDefectoLetra;
                        TituloMonto.AltoColumna = 12;

                        FilaTituloConcepto.ListaCeldas.Add(TituloMonto);
                        TablaTituloIngreso.ListaFilas.Add(FilaTituloConcepto);


                        foreach (cDetallePlanillaIngresos item2 in item.DetallePlanilla.ListaIngresos)
                        {
                            cFilasPDF FilaIngresos = new cFilasPDF();
                            cCeldaPDF NombreIngreso = new cCeldaPDF();
                            NombreIngreso.Contenido = item2.MaestroIngresos.Abreviacion;
                            NombreIngreso.QuitarBordes();
                            NombreIngreso.BordeAnchos.AnchoIzquierda = 1;
                            NombreIngreso.AltoColumna = 10;
                            NombreIngreso.TamañoLetra = oReporte.TamañoDefectoLetra;
                            FilaIngresos.ListaCeldas.Add(NombreIngreso);

                            cCeldaPDF MontoIngreso = new cCeldaPDF();
                            MontoIngreso.Contenido = item2.Monto.ToString();
                            MontoIngreso.QuitarBordes();
                            MontoIngreso.AltoColumna = 10;
                            MontoIngreso.TamañoLetra = oReporte.TamañoDefectoLetra;
                            FilaIngresos.ListaCeldas.Add(MontoIngreso);

                            TablaTituloIngreso.ListaFilas.Add(FilaIngresos);
                        }

                        cCeldaPDF CeldaIngresos = new cCeldaPDF();
                        CeldaIngresos.TablaPDF = TablaTituloIngreso;

                        filaDetalle.ListaCeldas.Add(CeldaIngresos);

                        //Tabla descuentos

                        cTablaPDF TablaDescuento = new cTablaPDF();
                        TablaDescuento.columnas = 2;
                        TablaDescuento.anchoColumnas = new float[] { 50f, 50f };

                        cFilasPDF FilaTituloDescuento = new cFilasPDF();

                        cCeldaPDF TituloDescuento = new cCeldaPDF();
                        TituloDescuento.Contenido = "DESCUENTOS";
                        TituloDescuento.AltoColumna = 12;
                        TituloDescuento.QuitarBordes();
                        TituloDescuento.BordeAnchos.AnchoIzquierda = 1;
                        TituloDescuento.BordeAnchos.AnchoAbajo = 1;
                        TituloDescuento.BordeAnchos.AnchoArriba = 1;
                        TituloDescuento.TamañoLetra = oReporte.TamañoDefectoLetra;
                        FilaTituloDescuento.ListaCeldas.Add(TituloDescuento);
                        FilaTituloDescuento.ListaCeldas.Add(celdaVacia);
                        TablaDescuento.ListaFilas.Add(FilaTituloDescuento);
                        TablaDescuento.ListaFilas.Add(FilaTituloConcepto);

                        foreach  (cDetallePlanillaDescuentos item3 in item.DetallePlanilla.ListaDescuentos)
                        {
                            cFilasPDF FilaDescuentos = new cFilasPDF();
                            cCeldaPDF NombreDescuento = new cCeldaPDF();
                            NombreDescuento.Contenido = item3.MaestroDescuento.Abreviacion;
                            NombreDescuento.QuitarBordes();
                            NombreDescuento.BordeAnchos.AnchoIzquierda = 1;
                            NombreDescuento.AltoColumna = 10;
                            NombreDescuento.TamañoLetra = oReporte.TamañoDefectoLetra;
                            FilaDescuentos.ListaCeldas.Add(NombreDescuento);

                            cCeldaPDF MontoDescuento = new cCeldaPDF();
                            MontoDescuento.Contenido = item3.Monto.ToString();
                            MontoDescuento.AltoColumna = 10;
                            MontoDescuento.QuitarBordes(); 
                            FilaDescuentos.ListaCeldas.Add(MontoDescuento);

                            TablaDescuento.ListaFilas.Add(FilaDescuentos);
                        }

                        

                        //Tabla Aportaciones
                        foreach (cDetallePlanillaATrabajador  item4 in item.DetallePlanilla.ListaAportacionesTrabajador)
                        {
                            cFilasPDF FilaAportacionTrabajador = new cFilasPDF();
                            cCeldaPDF NombreAportacion = new cCeldaPDF();
                            NombreAportacion.Contenido = item4.MaestroAportacionTrabajador.Abreviacion;
                            NombreAportacion.QuitarBordes();
                            NombreAportacion.BordeAnchos.AnchoIzquierda = 1;
                            NombreAportacion.AltoColumna = 10;
                            NombreAportacion.TamañoLetra = oReporte.TamañoDefectoLetra;
                            FilaAportacionTrabajador.ListaCeldas.Add(NombreAportacion);

                            cCeldaPDF MontoAportacionTrabajador = new cCeldaPDF();
                            MontoAportacionTrabajador.Contenido = item4.Monto.ToString();
                            MontoAportacionTrabajador.QuitarBordes();
                            MontoAportacionTrabajador.AltoColumna = 10;
                            MontoAportacionTrabajador.TamañoLetra = oReporte.TamañoDefectoLetra;
                            FilaAportacionTrabajador.ListaCeldas.Add(MontoAportacionTrabajador);

                            TablaDescuento.ListaFilas.Add(FilaAportacionTrabajador);
                        }

                        cCeldaPDF celdaDescuento = new cCeldaPDF();
                        celdaDescuento.TablaPDF = TablaDescuento;

                        filaDetalle.ListaCeldas.Add(celdaDescuento);

                        //tabla aportaciones empleador
                        cTablaPDF TablaAportacionesEmpleador = new cTablaPDF();
                        TablaAportacionesEmpleador.columnas = 2;
                        TablaAportacionesEmpleador.anchoColumnas = new float[] { 50f, 50f };

                        cFilasPDF FilaTituloAportacionesEmpleador = new cFilasPDF();

                        cCeldaPDF TituloAportacionesEmpleador = new cCeldaPDF();
                        TituloAportacionesEmpleador.Contenido = "APORTACIONES EMPL.";
                        TituloAportacionesEmpleador.QuitarBordes();
                        TituloAportacionesEmpleador.AltoColumna = 12;
                        TituloAportacionesEmpleador.BordeAnchos.AnchoAbajo = 1;
                        TituloAportacionesEmpleador.BordeAnchos.AnchoArriba = 1;
                        TituloAportacionesEmpleador.BordeAnchos.AnchoIzquierda = 1;
                        TituloAportacionesEmpleador.TamañoLetra = oReporte.TamañoDefectoLetra;
                        FilaTituloAportacionesEmpleador.ListaCeldas.Add(TituloAportacionesEmpleador);
                        FilaTituloAportacionesEmpleador.ListaCeldas.Add(celdaVaciaFinal);
                        TablaAportacionesEmpleador.ListaFilas.Add(FilaTituloAportacionesEmpleador);

                        cFilasPDF FilaTituloConcepto2 = new cFilasPDF();
                        cCeldaPDF TituloConcepto2 = new cCeldaPDF();
                        TituloConcepto2.Contenido = "Concepto";
                        TituloConcepto2.QuitarBordes();
                        TituloConcepto2.BordeAnchos.AnchoIzquierda = 1;
                        TituloConcepto2.AltoColumna = 12;
                        TituloConcepto2.TamañoLetra = oReporte.TamañoDefectoLetra;
                        FilaTituloConcepto2.ListaCeldas.Add(TituloConcepto2);

                        cCeldaPDF TituloMonto2 = new cCeldaPDF();
                        TituloMonto2.Contenido = "Monto";
                        TituloMonto2.QuitarBordes();
                        TituloMonto2.BordeAnchos.AnchoDerecha = 1;
                        TituloMonto2.TamañoLetra = oReporte.TamañoDefectoLetra;
                        TituloMonto2.AltoColumna = 12;

                        
                        FilaTituloConcepto2.ListaCeldas.Add(TituloMonto2);

                        TablaAportacionesEmpleador.ListaFilas.Add(FilaTituloConcepto2);
                        foreach (cDetallePlanillaAEmpleador item5 in item.DetallePlanilla.ListaAportacionesEmpleador)
                        {
                            cFilasPDF FilaAportacionEmpleador = new cFilasPDF();
                            cCeldaPDF NombreAportacionE = new cCeldaPDF();
                            NombreAportacionE.Contenido = item5.MaestroAportacionE.Abreviacion;
                            NombreAportacionE.QuitarBordes();
                            NombreAportacionE.BordeAnchos.AnchoIzquierda = 1;
                            NombreAportacionE.AltoColumna = 10;
                            NombreAportacionE.TamañoLetra = oReporte.TamañoDefectoLetra;
                            FilaAportacionEmpleador.ListaCeldas.Add(NombreAportacionE);

                            cCeldaPDF MontoAportacionEmpleador = new cCeldaPDF();
                            MontoAportacionEmpleador.Contenido = item5.Monto.ToString();
                            MontoAportacionEmpleador.QuitarBordes();
                            MontoAportacionEmpleador.BordeAnchos.AnchoDerecha = 1;
                            MontoAportacionEmpleador.AltoColumna = 10;
                            MontoAportacionEmpleador.TamañoLetra = oReporte.TamañoDefectoLetra;
                            FilaAportacionEmpleador.ListaCeldas.Add(MontoAportacionEmpleador);

                            TablaAportacionesEmpleador.ListaFilas.Add(FilaAportacionEmpleador);
                        }

                        cCeldaPDF celdaAportacionEmpleador = new cCeldaPDF();
                        celdaAportacionEmpleador.TablaPDF = TablaAportacionesEmpleador;

                        filaDetalle.ListaCeldas.Add(celdaAportacionEmpleador);

                        TablaDetalle.ListaFilas.Add(filaDetalle);

                        cFilasPDF FilaSubtotal = new cFilasPDF();

                        cTablaPDF tablaSubtotal = new cTablaPDF();
                        tablaSubtotal.columnas = 1;
                        tablaSubtotal.anchoColumnas = new float[] { 500f };

                        cFilasPDF filaSub = new cFilasPDF();
                        cCeldaPDF celdaSubtotal = new cCeldaPDF();
                        if (oReporte.TamañoDefectoLetra == 7)
                        {
                            celdaSubtotal.Contenido = "TOTAL INGRESOS:   " + item.TotalIngresos.ToString("c", new CultureInfo("es-PE")) + "                TOTAL DESCUENTOS:   " + (item.TotalDescuentos + item.TotalATrabajador).ToString("c", new CultureInfo("es-PE")) + "            TOTAL APORTAC. EMPLEADOR: " + item.TotalAEmpleador.ToString("c", new CultureInfo("es-PE")) + "             NETO A COBRAR: " + item.NetoACobrar.ToString("c", new CultureInfo("es-PE"));
                        }
                        else
                        {
                            celdaSubtotal.Contenido = "TOTAL INGRESOS:   " + item.TotalIngresos.ToString("c", new CultureInfo("es-PE")) + "          TOTAL DESCUENTOS:   " + (item.TotalDescuentos + item.TotalATrabajador).ToString("c", new CultureInfo("es-PE")) + "       TOTAL APORTAC. EMPLEADOR:  " + item.TotalAEmpleador.ToString("c", new CultureInfo("es-PE")) + "             NETO A COBRAR: " + item.NetoACobrar.ToString("c", new CultureInfo("es-PE"));
                        }
                        celdaSubtotal.TamañoLetra = oReporte.TamañoDefectoLetra;
                        celdaSubtotal.Alineamiento = enumAlineamiento.izquierda;

                        filaSub.ListaCeldas.Add(celdaSubtotal);

                        tablaSubtotal.ListaFilas.Add(filaSub);


                        cTablaPDF tablaFirmas = new cTablaPDF();
                        tablaFirmas.columnas = 2;
                        tablaFirmas.anchoColumnas = new float[] { 50f, 50f };

                        cFilasPDF filaFirmas = new cFilasPDF();
                        cCeldaPDF FirmaTrabajador = new cCeldaPDF();
                        FirmaTrabajador.QuitarBordes();
                        FirmaTrabajador.Contenido = "TRABAJADOR";
                        FirmaTrabajador.AltoColumna = 60;
                        FirmaTrabajador.Alineamiento = enumAlineamiento.abajo;
                        FirmaTrabajador.ALineamientoVertical = enumAlineamientoVertical.abajo;
                        filaFirmas.ListaCeldas.Add(FirmaTrabajador);

                        cCeldaPDF FirmaEmpleador = new cCeldaPDF();
                        FirmaEmpleador.QuitarBordes();
                        FirmaEmpleador.Contenido = "EMPLEADOR";
                        FirmaEmpleador.AltoColumna = 60;
                        FirmaEmpleador.Alineamiento = enumAlineamiento.abajo;
                        FirmaEmpleador.ALineamientoVertical = enumAlineamientoVertical.abajo;
                        filaFirmas.ListaCeldas.Add(FirmaEmpleador);

                        tablaFirmas.ListaFilas.Add(filaFirmas);



                        TablaDetalle.ListaFilas.Add(FilaSubtotal);

                        
                        if (opciones == OpcionesReporteBoleta.UnaBoletaxPagina)
                        {
                            cHojaPDF oHojaPDF = new cHojaPDF();
                            oHojaPDF.ListaDeTablas.Add(TablaLogo);
                            oHojaPDF.ListaDeTablas.Add(TablaTituloPrincipal);
                            oHojaPDF.ListaDeTablas.Add(TablaDetalle);
                            oHojaPDF.ListaDeTablas.Add(tablaSubtotal);
                            oHojaPDF.ListaDeTablas.Add(tablaFirmas);
                            oReporte.ListaHojasPDF.Add(oHojaPDF);
                        }

                        if (opciones == OpcionesReporteBoleta.BoletaDuplicada)
                        {
                            cHojaPDF oHojaPDF = new cHojaPDF();
                            oHojaPDF.ListaDeTablas.Add(TablaLogo);
                            oHojaPDF.ListaDeTablas.Add(TablaTituloPrincipal);
                            oHojaPDF.ListaDeTablas.Add(TablaDetalle);
                            oHojaPDF.ListaDeTablas.Add(tablaSubtotal);
                            oHojaPDF.ListaDeTablas.Add(tablaFirmas);

                            oHojaPDF.ListaDeTablas.Add(TablaLogo);
                            oHojaPDF.ListaDeTablas.Add(TablaTituloPrincipal);
                            oHojaPDF.ListaDeTablas.Add(TablaDetalle);
                            oHojaPDF.ListaDeTablas.Add(tablaSubtotal);
                            oHojaPDF.ListaDeTablas.Add(tablaFirmas);
                            oReporte.ListaHojasPDF.Add(oHojaPDF);
                        }

                        if (opciones == OpcionesReporteBoleta.DosBoletaXPagina)
                        {
                            if ((numeroBoletasImpresas%2) != 0)
                            {
                                oHojaAuxiliar.ListaDeTablas.Add(TablaLogo);
                                oHojaAuxiliar.ListaDeTablas.Add(TablaTituloPrincipal);
                                oHojaAuxiliar.ListaDeTablas.Add(TablaDetalle);
                                oHojaAuxiliar.ListaDeTablas.Add(tablaSubtotal);
                                oHojaAuxiliar.ListaDeTablas.Add(tablaFirmas);
                                if (numeroBoletasImpresas == listaBoletasXAño.Count)
                                {
                                    cHojaPDF oHojaPDF = new cHojaPDF();
                                    oHojaPDF.ListaDeTablas.Add(TablaLogo);
                                    oHojaPDF.ListaDeTablas.Add(TablaTituloPrincipal);
                                    oHojaPDF.ListaDeTablas.Add(TablaDetalle);
                                    oHojaPDF.ListaDeTablas.Add(tablaSubtotal);
                                    oHojaPDF.ListaDeTablas.Add(tablaFirmas);
                                    oReporte.ListaHojasPDF.Add(oHojaPDF);
                                }
                            }
                            else
                            {
                                cHojaPDF oHojaPDF = new cHojaPDF();
                                foreach (cTablaPDF item0 in oHojaAuxiliar.ListaDeTablas)
                                {
                                    oHojaPDF.ListaDeTablas.Add(item0);

                                }

                                //foreach (cTablaPDF item0 in oHojaAuxiliar.ListaDeTablas)
                                //{
                                //    oHojaAuxiliar.ListaDeTablas.Remove(item0);
                                //}
                                oHojaPDF.ListaDeTablas.Add(TablaLogo);
                                oHojaPDF.ListaDeTablas.Add(TablaTituloPrincipal);
                                oHojaPDF.ListaDeTablas.Add(TablaDetalle);
                                oHojaPDF.ListaDeTablas.Add(tablaSubtotal);
                                oHojaPDF.ListaDeTablas.Add(tablaFirmas);
                                oReporte.ListaHojasPDF.Add(oHojaPDF);

                                oHojaAuxiliar = new cHojaPDF();
                                
                            }
                        }
                    }

                    Impresion.ImprimirReportePDFBOLETA(oReporte);

                }
                else
                {
                    throw new cReglaNegociosException("Error en el metodo ImprimirReporteBoleta: El reporte esta vacio. ");
                }
            }
            catch (Exception ex) 
            {
                throw new cReglaNegociosException("Error en el metodo ImprimirReporteBoleta: " + ex.Message);
            }
        }

        public void ImprimirReporteBoleta(string RutaArchivo, OpcionesReporteBoleta opciones, Single tamañoLetra, OpcionesPaginaReporteBoleta OpcionBoleta)
        {
            try
            {
                if (this.listaBoletasXAño.Count > 0)
                {
                    cReportePDF oReporte = new cReportePDF();
                    oReporte.TamañoDefectoLetra = tamañoLetra;
                    oReporte.RutaArchivo = RutaArchivo;
                    int numeroBoletasImpresas = 0;

                    cHojaPDF oHojaAuxiliar = new cHojaPDF();

                    foreach (cDetalleReporteBoletaXTrabajador item in listaBoletasXAño)
                    {

                        numeroBoletasImpresas++;

                        CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador AFPElegido = traerAFPTrabajador(Convert.ToInt32(trabajador.IdTrabajador), new DateTime(Convert.ToInt16(item.Año), Convert.ToInt16(Mes(item.Mes)), 1));

                        cTablaPDF TablaTituloPrincipal = new cTablaPDF();
                        TablaTituloPrincipal.columnas = 1;

                        TablaTituloPrincipal.anchoColumnas = new float[] { 1000f };
                        cFilasPDF FilaTituloPrincipal = new cFilasPDF();


                        cCeldaPDF celdaVacia2 = new cCeldaPDF();
                        celdaVacia2.AltoColumna = 12;
                        celdaVacia2.QuitarBordes();
                        celdaVacia2.ImagenTranasparente = true;

                        FilaTituloPrincipal.ListaCeldas.Add(celdaVacia2);

                        cTablaPDF TablaLogo = new cTablaPDF();
                        TablaLogo.columnas = 3;
                        TablaLogo.anchoColumnas = new float[] { 100f, 200f, 100f };

                        cFilasPDF FilaLogo = new cFilasPDF();

                        cCeldaPDF Logo = new cCeldaPDF();
                        Logo.esImagen = true;
                        Logo.QuitarBordes();
                        Logo.ImagenTranasparente = true;
                        Logo.Alineamiento = enumAlineamiento.izquierda;
                        Logo.ALineamientoVertical = enumAlineamientoVertical.arriba;

                        FilaLogo.ListaCeldas.Add(Logo);

                        cTablaPDF TablaTitulos = new cTablaPDF();
                        TablaTitulos.columnas = 1;
                        TablaTitulos.anchoColumnas = new float[] { 1000f };

                        cFilasPDF filaTitulos = new cFilasPDF();

                        cCeldaPDF TituloEmpresa = new cCeldaPDF();
                        TituloEmpresa.Contenido = oDatosGenerales.Nombre + " RUC: " + oDatosGenerales.Ruc;
                        TituloEmpresa.QuitarBordes();
                        TituloEmpresa.AltoColumna = 24;
                        TituloEmpresa.Alineamiento = enumAlineamiento.abajo;
                        TituloEmpresa.ALineamientoVertical = enumAlineamientoVertical.abajo;
                        TituloEmpresa.TamañoLetra = oReporte.TamañoDefectoLetra;
                        TituloEmpresa.ImagenTranasparente = true;
                        filaTitulos.ListaCeldas.Add(TituloEmpresa);

                        cCeldaPDF celdaVacia = new cCeldaPDF();
                        celdaVacia.AltoColumna = 12;
                        celdaVacia.QuitarBordes();
                        celdaVacia.BordeAnchos.AnchoArriba = 1;
                        celdaVacia.BordeAnchos.AnchoAbajo = 1;

                        cCeldaPDF celdaVaciaFinal = new cCeldaPDF();
                        celdaVaciaFinal.AltoColumna = 12;
                        celdaVaciaFinal.QuitarBordes();
                        celdaVaciaFinal.BordeAnchos.AnchoArriba = 1;
                        celdaVaciaFinal.BordeAnchos.AnchoAbajo = 1;
                        celdaVaciaFinal.BordeAnchos.AnchoDerecha = 1;

                        cCeldaPDF TituloPrincipal = new cCeldaPDF();
                        if (item.IdtRegimenLaboral == 3)
                        {
                            TituloPrincipal.Contenido = "BOLETA DE PAGO DE TRABAJADOR EVENTUAL";
                        }
                        else
                        {
                            TituloPrincipal.Contenido = "BOLETA DE PAGO";
                        }

                        TituloPrincipal.QuitarBordes();
                        TituloPrincipal.AltoColumna = 12;
                        TituloPrincipal.TamañoLetra = oReporte.TamañoDefectoLetra;
                        TituloPrincipal.ImagenTranasparente = true;
                        filaTitulos.ListaCeldas.Add(TituloPrincipal);

                        cCeldaPDF tituloRegimen = new cCeldaPDF();
                        switch (item.IdtRegimenLaboral)
                        {
                            case 1:
                                tituloRegimen.Contenido = "D.L. 1057 CAS";
                                break;
                            case 2:
                                tituloRegimen.Contenido = "D.L. 726";
                                break;
                            case 3:
                                tituloRegimen.Contenido = "D.L. 728";
                                break;
                            case 4:
                                tituloRegimen.Contenido = "D.L. 30057";
                                break;
                            default:
                                break;
                        }
                        tituloRegimen.QuitarBordes();
                        tituloRegimen.ImagenTranasparente = true;
                        tituloRegimen.TamañoLetra = oReporte.TamañoDefectoLetra;
                        filaTitulos.ListaCeldas.Add(tituloRegimen);

                        cCeldaPDF tituloMes = new cCeldaPDF();
                        tituloMes.Contenido = item.Mes + " " + item.Año;
                        tituloMes.AltoColumna = 12;
                        tituloMes.QuitarBordes();
                        tituloMes.ImagenTranasparente = true;
                        tituloMes.TamañoLetra = oReporte.TamañoDefectoLetra;
                        filaTitulos.ListaCeldas.Add(tituloMes);

                        TablaTitulos.ListaFilas.Add(filaTitulos);

                        cCeldaPDF celdaTitulos = new cCeldaPDF();
                        celdaTitulos.TablaPDF = TablaTitulos;
                        celdaTitulos.QuitarBordes();

                        FilaLogo.ListaCeldas.Add(celdaTitulos);
                        FilaLogo.ListaCeldas.Add(celdaVacia2);

                        TablaLogo.ListaFilas.Add(FilaLogo);

                        cFilasPDF FilaMeta = new cFilasPDF();

                        cCeldaPDF NombreMeta = new cCeldaPDF();
                        NombreMeta.Contenido = "Meta: " + item.Meta.Numero + " " + item.Meta.Nombre;
                        NombreMeta.QuitarBordes();
                        NombreMeta.AltoColumna = 12;
                        NombreMeta.Alineamiento = enumAlineamiento.izquierda;
                        NombreMeta.TamañoLetra = oReporte.TamañoDefectoLetra;
                        FilaMeta.ListaCeldas.Add(NombreMeta);
                        TablaTituloPrincipal.ListaFilas.Add(FilaMeta);

                        cFilasPDF filaNombre = new cFilasPDF();

                        cCeldaPDF celdaNombre = new cCeldaPDF();
                        celdaNombre.Contenido = "Nombre: " + item.Trabajador.Nombres + " " + item.Trabajador.ApellidoPaterno + " " + item.Trabajador.ApellidoMaterno + "                        DNI: " + item.Trabajador.Dni + "                Nro. Planilla: " + item.Numero + "      DIAS LABORADOS:  " + item.DiasLaborados;
                        celdaNombre.QuitarBordes();
                        celdaNombre.AltoColumna = 12;
                        celdaNombre.Alineamiento = enumAlineamiento.izquierda;
                        celdaNombre.TamañoLetra = oReporte.TamañoDefectoLetra;
                        filaNombre.ListaCeldas.Add(celdaNombre);
                        TablaTituloPrincipal.ListaFilas.Add(filaNombre);

                        cFilasPDF filaCargo = new cFilasPDF();

                        cCeldaPDF celdaCargo = new cCeldaPDF();
                        if (AFPElegido != null)
                        {
                            if (AFPElegido.IdtAFP == 5)
                            {
                                celdaCargo.Contenido = "Cargo: " + item.Cargo + "                           REGIMEN PENSIONARIO: " + AFPElegido.Afp.Nombre;
                            }
                            else
                            {
                                celdaCargo.Contenido = "Cargo: " + item.Cargo + "                           REGIMEN PENSIONARIO: " + AFPElegido.Afp.Nombre + "                  CUSPP: " + AFPElegido.CUSPP;
                            }

                        }
                        else
                        {
                            celdaCargo.Contenido = "Cargo: " + item.Cargo;
                        }

                        celdaCargo.QuitarBordes();
                        celdaCargo.AltoColumna = 12;
                        celdaCargo.Alineamiento = enumAlineamiento.izquierda;
                        celdaCargo.TamañoLetra = oReporte.TamañoDefectoLetra;
                        filaCargo.ListaCeldas.Add(celdaCargo);
                        TablaTituloPrincipal.ListaFilas.Add(filaCargo);

                        cTablaPDF TablaDetalle = new cTablaPDF();
                        TablaDetalle.columnas = 3;
                        TablaDetalle.anchoColumnas = new float[] { 200f, 200f, 200f };

                        cFilasPDF filaDetalle = new cFilasPDF();



                        cTablaPDF TablaTituloIngreso = new cTablaPDF();
                        TablaTituloIngreso.columnas = 2;
                        TablaTituloIngreso.anchoColumnas = new float[] { 100f, 100f };

                        cFilasPDF FilaTituloIngreso = new cFilasPDF();



                        cCeldaPDF TituloIngreso = new cCeldaPDF();
                        TituloIngreso.Contenido = "INGRESOS";
                        TituloIngreso.QuitarBordes();
                        TituloIngreso.BordeAnchos.AnchoIzquierda = 1;
                        TituloIngreso.BordeAnchos.AnchoArriba = 1;
                        TituloIngreso.AltoColumna = 12;
                        TituloIngreso.BordeAnchos.AnchoAbajo = 1;
                        TituloIngreso.TamañoLetra = oReporte.TamañoDefectoLetra;
                        FilaTituloIngreso.ListaCeldas.Add(TituloIngreso);
                        FilaTituloIngreso.ListaCeldas.Add(celdaVacia);
                        TablaTituloIngreso.ListaFilas.Add(FilaTituloIngreso);


                        cFilasPDF FilaTituloConcepto = new cFilasPDF();
                        cCeldaPDF TituloConcepto = new cCeldaPDF();
                        TituloConcepto.Contenido = "Concepto";
                        TituloConcepto.QuitarBordes();
                        TituloConcepto.BordeAnchos.AnchoIzquierda = 1;
                        TituloConcepto.AltoColumna = 12;
                        TituloConcepto.TamañoLetra = oReporte.TamañoDefectoLetra;
                        FilaTituloConcepto.ListaCeldas.Add(TituloConcepto);

                        cCeldaPDF TituloMonto = new cCeldaPDF();
                        TituloMonto.Contenido = "Monto";
                        TituloMonto.QuitarBordes();
                        TituloMonto.TamañoLetra = oReporte.TamañoDefectoLetra;
                        TituloMonto.AltoColumna = 12;

                        FilaTituloConcepto.ListaCeldas.Add(TituloMonto);
                        TablaTituloIngreso.ListaFilas.Add(FilaTituloConcepto);


                        foreach (cDetallePlanillaIngresos item2 in item.DetallePlanilla.ListaIngresos)
                        {
                            cFilasPDF FilaIngresos = new cFilasPDF();
                            cCeldaPDF NombreIngreso = new cCeldaPDF();
                            NombreIngreso.Contenido = item2.MaestroIngresos.Abreviacion;
                            NombreIngreso.QuitarBordes();
                            NombreIngreso.BordeAnchos.AnchoIzquierda = 1;
                            NombreIngreso.AltoColumna = 10;
                            NombreIngreso.TamañoLetra = oReporte.TamañoDefectoLetra;
                            FilaIngresos.ListaCeldas.Add(NombreIngreso);

                            cCeldaPDF MontoIngreso = new cCeldaPDF();
                            MontoIngreso.Contenido = item2.Monto.ToString();
                            MontoIngreso.QuitarBordes();
                            MontoIngreso.AltoColumna = 10;
                            MontoIngreso.TamañoLetra = oReporte.TamañoDefectoLetra;
                            FilaIngresos.ListaCeldas.Add(MontoIngreso);

                            TablaTituloIngreso.ListaFilas.Add(FilaIngresos);
                        }

                        cCeldaPDF CeldaIngresos = new cCeldaPDF();
                        CeldaIngresos.TablaPDF = TablaTituloIngreso;

                        filaDetalle.ListaCeldas.Add(CeldaIngresos);

                        //Tabla descuentos

                        cTablaPDF TablaDescuento = new cTablaPDF();
                        TablaDescuento.columnas = 2;
                        TablaDescuento.anchoColumnas = new float[] { 100f, 100f };

                        cFilasPDF FilaTituloDescuento = new cFilasPDF();

                        cCeldaPDF TituloDescuento = new cCeldaPDF();
                        TituloDescuento.Contenido = "DESCUENTOS";
                        TituloDescuento.AltoColumna = 12;
                        TituloDescuento.QuitarBordes();
                        TituloDescuento.BordeAnchos.AnchoIzquierda = 1;
                        TituloDescuento.BordeAnchos.AnchoAbajo = 1;
                        TituloDescuento.BordeAnchos.AnchoArriba = 1;
                        TituloDescuento.TamañoLetra = oReporte.TamañoDefectoLetra;
                        FilaTituloDescuento.ListaCeldas.Add(TituloDescuento);
                        FilaTituloDescuento.ListaCeldas.Add(celdaVacia);
                        TablaDescuento.ListaFilas.Add(FilaTituloDescuento);
                        TablaDescuento.ListaFilas.Add(FilaTituloConcepto);

                        foreach (cDetallePlanillaDescuentos item3 in item.DetallePlanilla.ListaDescuentos)
                        {
                            cFilasPDF FilaDescuentos = new cFilasPDF();
                            cCeldaPDF NombreDescuento = new cCeldaPDF();
                            NombreDescuento.Contenido = item3.MaestroDescuento.Abreviacion;
                            NombreDescuento.QuitarBordes();
                            NombreDescuento.BordeAnchos.AnchoIzquierda = 1;
                            NombreDescuento.AltoColumna = 10;
                            NombreDescuento.TamañoLetra = oReporte.TamañoDefectoLetra;
                            FilaDescuentos.ListaCeldas.Add(NombreDescuento);

                            cCeldaPDF MontoDescuento = new cCeldaPDF();
                            MontoDescuento.Contenido = item3.Monto.ToString();
                            MontoDescuento.AltoColumna = 10;
                            MontoDescuento.QuitarBordes();
                            FilaDescuentos.ListaCeldas.Add(MontoDescuento);

                            TablaDescuento.ListaFilas.Add(FilaDescuentos);
                        }



                        //Tabla Aportaciones
                        foreach (cDetallePlanillaATrabajador item4 in item.DetallePlanilla.ListaAportacionesTrabajador)
                        {
                            cFilasPDF FilaAportacionTrabajador = new cFilasPDF();
                            cCeldaPDF NombreAportacion = new cCeldaPDF();
                            NombreAportacion.Contenido = item4.MaestroAportacionTrabajador.Abreviacion;
                            NombreAportacion.QuitarBordes();
                            NombreAportacion.BordeAnchos.AnchoIzquierda = 1;
                            NombreAportacion.AltoColumna = 10;
                            NombreAportacion.TamañoLetra = oReporte.TamañoDefectoLetra;
                            FilaAportacionTrabajador.ListaCeldas.Add(NombreAportacion);

                            cCeldaPDF MontoAportacionTrabajador = new cCeldaPDF();
                            MontoAportacionTrabajador.Contenido = item4.Monto.ToString();
                            MontoAportacionTrabajador.QuitarBordes();
                            MontoAportacionTrabajador.AltoColumna = 10;
                            MontoAportacionTrabajador.TamañoLetra = oReporte.TamañoDefectoLetra;
                            FilaAportacionTrabajador.ListaCeldas.Add(MontoAportacionTrabajador);

                            TablaDescuento.ListaFilas.Add(FilaAportacionTrabajador);
                        }

                        cCeldaPDF celdaDescuento = new cCeldaPDF();
                        celdaDescuento.TablaPDF = TablaDescuento;

                        filaDetalle.ListaCeldas.Add(celdaDescuento);

                        //tabla aportaciones empleador
                        cTablaPDF TablaAportacionesEmpleador = new cTablaPDF();
                        TablaAportacionesEmpleador.columnas = 2;
                        TablaAportacionesEmpleador.anchoColumnas = new float[] { 100f, 100f };

                        cFilasPDF FilaTituloAportacionesEmpleador = new cFilasPDF();

                        cCeldaPDF TituloAportacionesEmpleador = new cCeldaPDF();
                        TituloAportacionesEmpleador.Contenido = "APORTACIONES EMPL.";
                        TituloAportacionesEmpleador.QuitarBordes();
                        TituloAportacionesEmpleador.AltoColumna = 12;
                        TituloAportacionesEmpleador.BordeAnchos.AnchoAbajo = 1;
                        TituloAportacionesEmpleador.BordeAnchos.AnchoArriba = 1;
                        TituloAportacionesEmpleador.BordeAnchos.AnchoIzquierda = 1;
                        TituloAportacionesEmpleador.TamañoLetra = oReporte.TamañoDefectoLetra;
                        FilaTituloAportacionesEmpleador.ListaCeldas.Add(TituloAportacionesEmpleador);
                        FilaTituloAportacionesEmpleador.ListaCeldas.Add(celdaVaciaFinal);
                        TablaAportacionesEmpleador.ListaFilas.Add(FilaTituloAportacionesEmpleador);

                        cFilasPDF FilaTituloConcepto2 = new cFilasPDF();
                        cCeldaPDF TituloConcepto2 = new cCeldaPDF();
                        TituloConcepto2.Contenido = "Concepto";
                        TituloConcepto2.QuitarBordes();
                        TituloConcepto2.BordeAnchos.AnchoIzquierda = 1;
                        TituloConcepto2.AltoColumna = 12;
                        TituloConcepto2.TamañoLetra = oReporte.TamañoDefectoLetra;
                        FilaTituloConcepto2.ListaCeldas.Add(TituloConcepto2);

                        cCeldaPDF TituloMonto2 = new cCeldaPDF();
                        TituloMonto2.Contenido = "Monto";
                        TituloMonto2.QuitarBordes();
                        TituloMonto2.BordeAnchos.AnchoDerecha = 1;
                        TituloMonto2.TamañoLetra = oReporte.TamañoDefectoLetra;
                        TituloMonto2.AltoColumna = 12;


                        FilaTituloConcepto2.ListaCeldas.Add(TituloMonto2);

                        TablaAportacionesEmpleador.ListaFilas.Add(FilaTituloConcepto2);
                        foreach (cDetallePlanillaAEmpleador item5 in item.DetallePlanilla.ListaAportacionesEmpleador)
                        {
                            cFilasPDF FilaAportacionEmpleador = new cFilasPDF();
                            cCeldaPDF NombreAportacionE = new cCeldaPDF();
                            NombreAportacionE.Contenido = item5.MaestroAportacionE.Abreviacion;
                            NombreAportacionE.QuitarBordes();
                            NombreAportacionE.BordeAnchos.AnchoIzquierda = 1;
                            NombreAportacionE.AltoColumna = 10;
                            NombreAportacionE.TamañoLetra = oReporte.TamañoDefectoLetra;
                            FilaAportacionEmpleador.ListaCeldas.Add(NombreAportacionE);

                            cCeldaPDF MontoAportacionEmpleador = new cCeldaPDF();
                            MontoAportacionEmpleador.Contenido = item5.Monto.ToString();
                            MontoAportacionEmpleador.QuitarBordes();
                            MontoAportacionEmpleador.BordeAnchos.AnchoDerecha = 1;
                            MontoAportacionEmpleador.AltoColumna = 10;
                            MontoAportacionEmpleador.TamañoLetra = oReporte.TamañoDefectoLetra;
                            FilaAportacionEmpleador.ListaCeldas.Add(MontoAportacionEmpleador);

                            TablaAportacionesEmpleador.ListaFilas.Add(FilaAportacionEmpleador);
                        }

                        cCeldaPDF celdaAportacionEmpleador = new cCeldaPDF();
                        celdaAportacionEmpleador.TablaPDF = TablaAportacionesEmpleador;

                        filaDetalle.ListaCeldas.Add(celdaAportacionEmpleador);

                        TablaDetalle.ListaFilas.Add(filaDetalle);

                        cFilasPDF FilaSubtotal = new cFilasPDF();

                        cTablaPDF tablaSubtotal = new cTablaPDF();
                        tablaSubtotal.columnas = 1;
                        tablaSubtotal.anchoColumnas = new float[] { 500f };

                        cFilasPDF filaSub = new cFilasPDF();
                        cCeldaPDF celdaSubtotal = new cCeldaPDF();
                        if (oReporte.TamañoDefectoLetra == 7)
                        {
                            celdaSubtotal.Contenido = "TOTAL INGRESOS:   " + item.TotalIngresos.ToString("c", new CultureInfo("es-PE")) + "                TOTAL DESCUENTOS:   " + (item.TotalDescuentos + item.TotalATrabajador).ToString("c", new CultureInfo("es-PE")) + "            TOTAL APORTAC. EMPLEADOR: " + item.TotalAEmpleador.ToString("c", new CultureInfo("es-PE")) + "             NETO A COBRAR: " + item.NetoACobrar.ToString("c", new CultureInfo("es-PE"));
                        }
                        else
                        {
                            celdaSubtotal.Contenido = "TOTAL INGRESOS:   " + item.TotalIngresos.ToString("c", new CultureInfo("es-PE")) + "          TOTAL DESCUENTOS:   " + (item.TotalDescuentos + item.TotalATrabajador).ToString("c", new CultureInfo("es-PE")) + "       TOTAL APORTAC. EMPLEADOR:  " + item.TotalAEmpleador.ToString("c", new CultureInfo("es-PE")) + "             NETO A COBRAR: " + item.NetoACobrar.ToString("c", new CultureInfo("es-PE"));
                        }
                        celdaSubtotal.TamañoLetra = oReporte.TamañoDefectoLetra;
                        celdaSubtotal.Alineamiento = enumAlineamiento.izquierda;

                        filaSub.ListaCeldas.Add(celdaSubtotal);

                        tablaSubtotal.ListaFilas.Add(filaSub);


                        cTablaPDF tablaFirmas = new cTablaPDF();
                        tablaFirmas.columnas = 2;
                        tablaFirmas.anchoColumnas = new float[] { 100f, 100f };

                        cFilasPDF filaFirmas = new cFilasPDF();
                        cCeldaPDF FirmaTrabajador = new cCeldaPDF();
                        FirmaTrabajador.QuitarBordes();
                        FirmaTrabajador.Contenido = "TRABAJADOR";
                        FirmaTrabajador.AltoColumna = 60;
                        FirmaTrabajador.Alineamiento = enumAlineamiento.abajo;
                        FirmaTrabajador.ALineamientoVertical = enumAlineamientoVertical.abajo;
                        filaFirmas.ListaCeldas.Add(FirmaTrabajador);

                        cCeldaPDF FirmaEmpleador = new cCeldaPDF();
                        FirmaEmpleador.QuitarBordes();
                        FirmaEmpleador.Contenido = "EMPLEADOR";
                        FirmaEmpleador.AltoColumna = 60;
                        FirmaEmpleador.Alineamiento = enumAlineamiento.abajo;
                        FirmaEmpleador.ALineamientoVertical = enumAlineamientoVertical.abajo;
                        filaFirmas.ListaCeldas.Add(FirmaEmpleador);

                        tablaFirmas.ListaFilas.Add(filaFirmas);



                        TablaDetalle.ListaFilas.Add(FilaSubtotal);

                        cTablaPDF tablaA = new cTablaPDF();
                        tablaA.columnas = 3;
                        tablaA.anchoColumnas = new float[] { 1000f, 100f, 1000f };

                        cFilasPDF fila1 = new cFilasPDF();
                        cFilasPDF fila2 = new cFilasPDF();
                        cFilasPDF fila3 = new cFilasPDF();
                        cFilasPDF fila4 = new cFilasPDF();
                        cFilasPDF fila5 = new cFilasPDF();
                        cCeldaPDF celda1 = new cCeldaPDF();
                        celda1.TablaPDF = TablaLogo;
                        fila1.ListaCeldas.Add(celda1);
                        fila1.ListaCeldas.Add(celdaVacia2);
                        fila1.ListaCeldas.Add(celda1);
                        tablaA.ListaFilas.Add(fila1);
                        cCeldaPDF celda2 = new cCeldaPDF();
                        celda2.TablaPDF = TablaTituloPrincipal;
                        fila2.ListaCeldas.Add(celda2);
                        fila2.ListaCeldas.Add(celdaVacia2);
                        fila2.ListaCeldas.Add(celda2);
                        tablaA.ListaFilas.Add(fila2);
                        cCeldaPDF celda3 = new cCeldaPDF();
                        celda3.TablaPDF = TablaDetalle;
                        fila3.ListaCeldas.Add(celda3);
                        fila3.ListaCeldas.Add(celdaVacia2);
                        fila3.ListaCeldas.Add(celda3);
                        tablaA.ListaFilas.Add(fila3);
                        cCeldaPDF celda4 = new cCeldaPDF();
                        celda4.TablaPDF = tablaSubtotal;
                        fila4.ListaCeldas.Add(celda4);
                        fila4.ListaCeldas.Add(celdaVacia2);
                        fila4.ListaCeldas.Add(celda4);
                        tablaA.ListaFilas.Add(fila4);
                        cCeldaPDF celda5 = new cCeldaPDF();
                        celda5.TablaPDF = tablaFirmas;
                        fila5.ListaCeldas.Add(celda5);
                        fila5.ListaCeldas.Add(celdaVacia2);
                        fila5.ListaCeldas.Add(celda5);
                        tablaA.ListaFilas.Add(fila5);

                        if (opciones == OpcionesReporteBoleta.UnaBoletaxPagina)
                        {
                            cHojaPDF oHojaPDF = new cHojaPDF();
                            oHojaPDF.ListaDeTablas.Add(tablaA);
                            oReporte.ListaHojasPDF.Add(oHojaPDF);
                        }

                        if (opciones == OpcionesReporteBoleta.BoletaDuplicada)
                        {
                            cHojaPDF oHojaPDF = new cHojaPDF();
                            oHojaPDF.ListaDeTablas.Add(tablaA);
                            oReporte.ListaHojasPDF.Add(oHojaPDF);
                        }

                        if (opciones == OpcionesReporteBoleta.DosBoletaXPagina)
                        {
                            if ((numeroBoletasImpresas % 2) != 0)
                            {
                                oHojaAuxiliar.ListaDeTablas.Add(TablaLogo);
                                oHojaAuxiliar.ListaDeTablas.Add(TablaTituloPrincipal);
                                oHojaAuxiliar.ListaDeTablas.Add(TablaDetalle);
                                oHojaAuxiliar.ListaDeTablas.Add(tablaSubtotal);
                                oHojaAuxiliar.ListaDeTablas.Add(tablaFirmas);
                                if (numeroBoletasImpresas == listaBoletasXAño.Count)
                                {
                                    cHojaPDF oHojaPDF = new cHojaPDF();
                                    oHojaPDF.ListaDeTablas.Add(TablaLogo);
                                    oHojaPDF.ListaDeTablas.Add(TablaTituloPrincipal);
                                    oHojaPDF.ListaDeTablas.Add(TablaDetalle);
                                    oHojaPDF.ListaDeTablas.Add(tablaSubtotal);
                                    oHojaPDF.ListaDeTablas.Add(tablaFirmas);
                                    oReporte.ListaHojasPDF.Add(oHojaPDF);
                                }
                            }
                            else
                            {
                                cHojaPDF oHojaPDF = new cHojaPDF();
                                foreach (cTablaPDF item0 in oHojaAuxiliar.ListaDeTablas)
                                {
                                    oHojaPDF.ListaDeTablas.Add(item0);

                                }

                                //foreach (cTablaPDF item0 in oHojaAuxiliar.ListaDeTablas)
                                //{
                                //    oHojaAuxiliar.ListaDeTablas.Remove(item0);
                                //}
                                oHojaPDF.ListaDeTablas.Add(TablaLogo);
                                oHojaPDF.ListaDeTablas.Add(TablaTituloPrincipal);
                                oHojaPDF.ListaDeTablas.Add(TablaDetalle);
                                oHojaPDF.ListaDeTablas.Add(tablaSubtotal);
                                oHojaPDF.ListaDeTablas.Add(tablaFirmas);
                                oReporte.ListaHojasPDF.Add(oHojaPDF);

                                oHojaAuxiliar = new cHojaPDF();

                            }
                        }
                    }

                    Impresion.ImprimirReportePDFBOLETAVERTICAL(oReporte);

                }
                else
                {
                    throw new cReglaNegociosException("Error en el metodo ImprimirReporteBoleta: El reporte esta vacio. ");
                }
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo ImprimirReporteBoleta: " + ex.Message);
            }
        }
        string Mes(string pmes)
        {
            string x = "";
            switch (pmes)
            {
                case "ENERO":
                    x = "01";
                    break;
                case "FEBRERO":
                    x = "02";
                    break;
                case "MARZO":
                    x = "03";
                    break;
                case "ABRIL":
                    x = "04";
                    break;
                case "MAYO":
                    x = "05";
                    break;
                case "JUNIO":
                    x = "06";
                    break;
                case "JULIO":
                    x = "07";
                    break;
                case "AGOSTO":
                    x = "08";
                    break;
                case "SETIEMBRE":
                    x = "09";
                    break;
                case "OCTUBRE":
                    x = "10";
                    break;
                case "NOVIEMBRE":
                    x = "11";
                    break;
                case "DICIEMBRE":
                    x = "12";
                    break;
            }
            return x;
        }

        private CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador traerAFPTrabajador(int idttrabajador, DateTime fecha)
        {
            oDataAFP = miAFP.ObtenerListaAFP();

            List<CapaDeNegocios.DatosLaborales.cPeriodoTrabajador> AuxiliarPeriodoTrabajador = miPeriodoTrabajador.traerPeriodosMesTrabajador(idttrabajador, fecha);
            List<CapaDeNegocios.DatosLaborales.cRegimenTrabajador> ListaRegimenTrabajador = new List<CapaDeNegocios.DatosLaborales.cRegimenTrabajador>();
            List<CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador> ListaPeriodoAFP = new List<CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador>();

            CapaDeNegocios.DatosLaborales.cPeriodoTrabajador PeriodoElegido = new CapaDeNegocios.DatosLaborales.cPeriodoTrabajador();
            CapaDeNegocios.DatosLaborales.cRegimenTrabajador RegimenElegido = new CapaDeNegocios.DatosLaborales.cRegimenTrabajador();
            CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador AFPElegido = new CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador();

            if (AuxiliarPeriodoTrabajador.Count > 0)
            {
                foreach (CapaDeNegocios.DatosLaborales.cPeriodoTrabajador item in AuxiliarPeriodoTrabajador)
                {
                    CapaDeNegocios.DatosLaborales.cRegimenTrabajador auxiliarRegimenTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenTrabajador();

                    ListaRegimenTrabajador = auxiliarRegimenTrabajador.TraerRegimenTrabajadorMes(item.IdtPeriodoTrabajador, fecha);
                    ListaPeriodoAFP = AFPElegido.TraerRegimenPensionarioxMes(item.IdtPeriodoTrabajador, fecha);

                    if (ListaPeriodoAFP.Count > 0)
                    {
                        AFPElegido = ListaPeriodoAFP[ListaPeriodoAFP.Count - 1];
                        AFPElegido.Afp = new CapaDeNegocios.cAFP();

                        foreach (DataRow rowAFP in oDataAFP.Select("idtafp = '" + AFPElegido.IdtAFP.ToString() + "'"))
                        {
                            AFPElegido.Afp.CodigoAFP = AFPElegido.IdtAFP;
                            AFPElegido.Afp.Nombre = rowAFP[1].ToString();
                        }

                        return AFPElegido;
                    }
                    else
                    {
                        return null;
                    }
                }
                return null;
            }
            else
            {
                return null;
            }
        }
    }
}
