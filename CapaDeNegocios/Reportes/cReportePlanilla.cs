using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Data;
using CapaDeDatos;
using CapaDeNegocios.PlanillaNueva;


namespace CapaDeNegocios.Reportes
{
    public class cReportePlanilla
    {
        private cDatosGenerales oDatosGenerales = new cDatosGenerales();
        private cImprimirReportePDF Impresion = new cImprimirReportePDF();
        public void ImprimirPLanilla(cnPlanilla miPLanilla, string rutaArchivo, int tamañoLetra)
        {
            cReportePDF oReporte = new cReportePDF();
            oReporte.TamañoDefectoLetra = tamañoLetra;
            oReporte.RutaArchivo = rutaArchivo;

            cHojaPDF oHojaAuxiliar = new cHojaPDF();

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
            TituloEmpresa.Contenido = oDatosGenerales.Nombre;
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
            TituloPrincipal.Contenido = oDatosGenerales.NombreOficina;
            TituloPrincipal.QuitarBordes();
            TituloPrincipal.AltoColumna = 12;
            TituloPrincipal.TamañoLetra = oReporte.TamañoDefectoLetra;
            TituloPrincipal.ImagenTranasparente = true;
            filaTitulos.ListaCeldas.Add(TituloPrincipal);

            cCeldaPDF tituloRegimen = new cCeldaPDF();
            tituloRegimen.Contenido = miPLanilla.Descripcion + " de " + miPLanilla.Mes + " del " + miPLanilla.Año; 
            //switch (miPLanilla.RegimenLaboral.IdTRegimenLaboral)
            //{
            //    case 1:
            //        tituloRegimen.Contenido = "D.L. 1057 CAS";
            //        break;
            //    case 2:
            //        tituloRegimen.Contenido = "D.L. 726";
            //        break;
            //    case 3:
            //        tituloRegimen.Contenido = "D.L. 728";
            //        break;
            //    case 4:
            //        tituloRegimen.Contenido = "D.L. 30057";
            //        break;
            //    default:
            //        break;
            //}
            tituloRegimen.QuitarBordes();
            tituloRegimen.ImagenTranasparente = true;
            tituloRegimen.TamañoLetra = oReporte.TamañoDefectoLetra;
            filaTitulos.ListaCeldas.Add(tituloRegimen);

            TablaTitulos.ListaFilas.Add(filaTitulos);

            cCeldaPDF celdaTitulos = new cCeldaPDF();
            celdaTitulos.TablaPDF = TablaTitulos;
            celdaTitulos.QuitarBordes();

            FilaLogo.ListaCeldas.Add(celdaTitulos);
            FilaLogo.ListaCeldas.Add(celdaVacia2);

            TablaLogo.ListaFilas.Add(FilaLogo);

            cFilasPDF FilaMeta = new cFilasPDF();

            cCeldaPDF NombreMeta = new cCeldaPDF();
            NombreMeta.Contenido = "Meta: " + miPLanilla.Meta.Numero + " " + miPLanilla.Meta.Nombre;
            NombreMeta.QuitarBordes();
            NombreMeta.AltoColumna = 12;
            NombreMeta.Alineamiento = enumAlineamiento.izquierda;
            NombreMeta.TamañoLetra = oReporte.TamañoDefectoLetra;
            FilaMeta.ListaCeldas.Add(NombreMeta);
            TablaTituloPrincipal.ListaFilas.Add(FilaMeta);


            cTablaPDF TablaDetalle = new cTablaPDF();
            TablaDetalle.columnas = 12;
            TablaDetalle.anchoColumnas = new float[] { 50f, 100f, 100f, 100f, 100f, 100f, 100f, 100f, 100f, 100f, 100f, 100f };

            cFilasPDF FilaEncabezado1 = new cFilasPDF();

            cCeldaPDF celdaNro = new cCeldaPDF();
            celdaNro.Contenido = "Nº";
            FilaEncabezado1.ListaCeldas.Add(celdaNro);

            cCeldaPDF celdaNombres = new cCeldaPDF();

            

            cTablaPDF TablaNombres = new cTablaPDF();
            TablaNombres.columnas = 1;
            TablaNombres.anchoColumnas = new float[] { 100f };

            cFilasPDF filaNombres = new cFilasPDF();

            cCeldaPDF celdaTituloNombre = new cCeldaPDF();
            celdaTituloNombre.Contenido = "Nombres y Apellidos";
            filaNombres.ListaCeldas.Add(celdaTituloNombre);

            cCeldaPDF celdaTituloDNI = new cCeldaPDF();
            celdaTituloDNI.Contenido = "DNI";
            filaNombres.ListaCeldas.Add(celdaTituloDNI);

            cCeldaPDF celdaTituloFechaInicio = new cCeldaPDF();
            celdaTituloFechaInicio.Contenido = "Fecha Inicio";
            filaNombres.ListaCeldas.Add(celdaTituloFechaInicio);

            cCeldaPDF celdaTituloCargo = new cCeldaPDF();
            celdaTituloCargo.Contenido = "CARGO";
            filaNombres.ListaCeldas.Add(celdaTituloCargo);

            TablaNombres.ListaFilas.Add(filaNombres);

            celdaNombres.TablaPDF = TablaNombres;
            FilaEncabezado1.ListaCeldas.Add(celdaNombres);


    

            cTablaPDF tablaTituloIngresos = new cTablaPDF();
            tablaTituloIngresos.columnas = 1;
            tablaTituloIngresos.anchoColumnas = new float[] { 100f };

            cFilasPDF filaTituloIngresos = new cFilasPDF();


            cCeldaPDF celdaTituloTodosIngresos = new cCeldaPDF();
            celdaTituloTodosIngresos.Contenido = "Ingresos";
            filaTituloIngresos.ListaCeldas.Add(celdaTituloTodosIngresos);

            cCeldaPDF celdaContieneTodosIngresos = new cCeldaPDF();


            cTablaPDF tablaIngresos = new cTablaPDF();
            int numeroColumnas = miPLanilla.ListaDetalle[0].ListaDetalleIngresos.Count;

            tablaIngresos.columnas = numeroColumnas;
            tablaIngresos.anchoColumnas = TraerArregloSegunTamaño(numeroColumnas);

            cFilasPDF filaIngresos = new cFilasPDF();

            foreach (cnDetallePlanillaIngresos item in miPLanilla.ListaDetalle[0].ListaDetalleIngresos)
            {
                cCeldaPDF celdaTituloIngresos = new cCeldaPDF();
                celdaTituloIngresos.Contenido = item.MaestroIngresos.Abreviacion;
                filaIngresos.ListaCeldas.Add(celdaTituloIngresos);
            }

            tablaIngresos.ListaFilas.Add(filaIngresos);
            celdaContieneTodosIngresos.TablaPDF = tablaIngresos;

            filaTituloIngresos.ListaCeldas.Add(celdaContieneTodosIngresos);

            tablaTituloIngresos.ListaFilas.Add(filaTituloIngresos);

            cCeldaPDF celdaIngresos = new cCeldaPDF();
            celdaIngresos.TablaPDF = tablaTituloIngresos;

            FilaEncabezado1.ListaCeldas.Add(celdaIngresos);


            cCeldaPDF celdaTotalIngresos = new cCeldaPDF();
            celdaTotalIngresos.Contenido = "Total Ingresos";
            FilaEncabezado1.ListaCeldas.Add(celdaTotalIngresos);

            cCeldaPDF celdaRetenciones = new cCeldaPDF();
            celdaRetenciones.Contenido = "Retenciones";
            FilaEncabezado1.ListaCeldas.Add(celdaRetenciones);

            cCeldaPDF celdaTotalRetencion = new cCeldaPDF();
            celdaTotalRetencion.Contenido = "Total Descuentos";
            FilaEncabezado1.ListaCeldas.Add(celdaTotalRetencion);


            cCeldaPDF celdaAportaciones = new cCeldaPDF();
            celdaAportaciones.Contenido = "Aportaciones";
            FilaEncabezado1.ListaCeldas.Add(celdaAportaciones);

            cCeldaPDF celdaTotalAportaciones = new cCeldaPDF();
            celdaTotalAportaciones.Contenido = "Total Aportaciones";
            FilaEncabezado1.ListaCeldas.Add(celdaTotalAportaciones);

            cCeldaPDF celdaSueldoNeto = new cCeldaPDF();
            celdaSueldoNeto.Contenido = "Sueldo Neto";
            FilaEncabezado1.ListaCeldas.Add(celdaSueldoNeto);

            cCeldaPDF celdaDias = new cCeldaPDF();
            celdaDias.Contenido = "Dias Laborados";
            FilaEncabezado1.ListaCeldas.Add(celdaDias);

            cCeldaPDF celdaCuentaBamcaria = new cCeldaPDF();
            celdaCuentaBamcaria.Contenido = "Cuenta Bancaria";
            FilaEncabezado1.ListaCeldas.Add(celdaCuentaBamcaria);

            cCeldaPDF celdaObservaciones = new cCeldaPDF();
            celdaObservaciones.Contenido = "Observaciones";
            FilaEncabezado1.ListaCeldas.Add(celdaObservaciones);

            TablaDetalle.ListaFilas.Add(FilaEncabezado1);

            foreach (cnDetallePlanilla item in miPLanilla.ListaDetalle)
            {
                cFilasPDF FilaDetalle = new cFilasPDF();

            }

            oHojaAuxiliar.ListaDeTablas.Add(TablaLogo);
            oHojaAuxiliar.ListaDeTablas.Add(TablaTituloPrincipal);
            oHojaAuxiliar.ListaDeTablas.Add(TablaDetalle);

            oReporte.ListaHojasPDF.Add(oHojaAuxiliar);
            Impresion.ImprimirReportePDF(oReporte);
        }

        public float[] TraerArregloSegunTamaño(int numero)
        {
            float[] arreglo = new float[] { };

            Array.Resize(ref arreglo, numero);

            for (int i = 0; i < numero; i++)
            {
                arreglo[i] = 100f;
            }

            return arreglo;
        }
    }

    
}
