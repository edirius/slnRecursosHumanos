using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Reportes
{
    public class cReporteTareo
    {
        public void ImprimirTareo(CapaDeNegocios.Tareos.cTareo oTareo, string ruta)
        {
            try
            {
                cReportePDF oReporte = new cReportePDF();
                oReporte.RutaArchivo = ruta;

                cHojaPDF oHojaPDF = new cHojaPDF();

                cTablaPDF oTablaTitulo = new cTablaPDF();
                oTablaTitulo.columnas = 1;
                oTablaTitulo.anchoColumnas = new float[] { 100 };
                cFilasPDF filaTitulo = new cFilasPDF();
                cCeldaPDF TituloCelda = new cCeldaPDF("HOJA DE INFORMACIÓN DE ASISTENCIA DE " + oTareo.Descripcion);
                filaTitulo.ListaCeldas.Add(TituloCelda);
                oTablaTitulo.ListaFilas.Add(filaTitulo);

                cTablaPDF TablaSubtitulos = new cTablaPDF();
                TablaSubtitulos.columnas = 5;
                TablaSubtitulos.anchoColumnas = new float[] { 10, 30, 10, 30, 10 };

                cFilasPDF FilaSubtitulos = new cFilasPDF();
                
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al imprimir en PDF el tareo: " + ex.Message);
            }

        }
    }
}
