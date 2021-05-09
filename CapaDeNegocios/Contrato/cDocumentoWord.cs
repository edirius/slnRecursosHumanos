using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using System.IO;

namespace CapaDeNegocios.Contrato
{
    public class cDocumentoWord
    {
        private Microsoft.Office.Interop.Word.Application miWord;
        private object oMissing;
        private Microsoft.Office.Interop.Word.Document oDocumento;

        public string numero;
        public string trabajador;
        public string dni;
        public string direccion;
        public string distrito;
        public string provincia;
        public string departamento;
        public string monto;
        public string fecharegistro;
        public string fechainicio;
        public string fechafin;
        public string cargo;
        public string meta;
        public string rutaarchivo;

        public void Iniciar()
        {
            if (File.Exists (@rutaarchivo))
            {
                miWord = new Microsoft.Office.Interop.Word.Application();
                oMissing = System.Reflection.Missing.Value;
                oDocumento = miWord.Documents.Add(@rutaarchivo);
                miWord.Visible = true;
            }
            else
            {
                throw new Exception("La plantilla CAS.dotx no se encuentra en la ruta");
            }

            //oParrafo = oDocumento.Content.Paragraphs.Add(oMissing);
            //oParrafo.Range.Text = "CONTRATO ADMINISTRATIVO DE SERVICIOS N° {0} -2015-MDCc.";
            //oParrafo.Range.Font.Bold = 1;
            //oParrafo.Range.Font.Underline = WdUnderline.wdUnderlineSingle;
            //oParrafo.Format.BaseLineAlignment = WdBaselineAlignment.wdBaselineAlignCenter;
            //oParrafo.Format.SpaceAfter = 24;
            //oParrafo.Range.InsertParagraphAfter();
            //miWord.Documents.Open()

            BuscarReemplazar("@Numero", numero);
            BuscarReemplazar("@Trabajador", trabajador);
            BuscarReemplazar("@DNI", dni);
            BuscarReemplazar("@Direccion", direccion);
            BuscarReemplazar("@Distrito", distrito);
            BuscarReemplazar("@Provincia", provincia);
            BuscarReemplazar("@Departamento", departamento);
            BuscarReemplazar("@Monto", monto);
            BuscarReemplazar("@Cargo", cargo);
            BuscarReemplazar("@Fecha", fecharegistro);
            BuscarReemplazar("@iniciofecha", fechainicio);
            BuscarReemplazar("@finfecha", fechafin);
        }

        private void BuscarReemplazar(string variable, string valor)
        {
            Find findObject = miWord.Selection.Find;
            findObject.ClearFormatting();
            findObject.Text = variable;
            findObject.Replacement.ClearFormatting();
            findObject.Replacement.Text = valor;

            object replaceAll = WdReplace.wdReplaceAll;
            findObject.Execute(ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref replaceAll, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
        }
    }
}
