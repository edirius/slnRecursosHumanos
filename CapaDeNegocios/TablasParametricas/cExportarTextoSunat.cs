using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using CapaDeDatos;
using System.Collections;

namespace CapaDeNegocios.TablasParametricas
{
    public class cExportarTextoSunat
    {
        public string ExportarTexto(string DNI, string Codigo, double MontoDevengado, double Montopagado)
        {
            string Texto = "";
            ArrayList miLista = new ArrayList();
            miLista.Add("02" + "|" + DNI + "|" + Codigo + "|" + Convert.ToString(MontoDevengado) + Convert.ToString(Montopagado) + '\n');
            foreach (string Concatenar in miLista)
            {
                Texto = Concatenar;
            }
            return Texto;
        }
    }
}
