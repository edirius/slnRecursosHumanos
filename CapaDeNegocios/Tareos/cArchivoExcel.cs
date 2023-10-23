using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Tareos
{
    public enum enumTipoNombres
    {
        primeroNombres,
        primeroApellidos
    }

    public class cArchivoExcel
    {
        int inicioFila;
        int finFila;
        string columnaNombres;
        string columnaCargo;
        string columnaDias;
        string columnaDNI;
        string nombreHoja;
        enumTipoNombres tipoNombres;

        List<cDetalleArchivoExcel> detalles;
         
        public cArchivoExcel()
        {
            Detalles = new List<cDetalleArchivoExcel>();

        }

        public int InicioFila
        {
            get
            {
                return inicioFila;
            }

            set
            {
                inicioFila = value;
            }
        }

        public int FinFila
        {
            get
            {
                return finFila;
            }

            set
            {
                finFila = value;
            }
        }

        public string ColumnaNombres
        {
            get
            {
                return columnaNombres;
            }

            set
            {
                columnaNombres = value;
            }
        }

        public string ColumnaCargo
        {
            get
            {
                return columnaCargo;
            }

            set
            {
                columnaCargo = value;
            }
        }

        public string ColumnaDias
        {
            get
            {
                return columnaDias;
            }

            set
            {
                columnaDias = value;
            }
        }

        public string ColumnaDNI
        {
            get
            {
                return columnaDNI;
            }

            set
            {
                columnaDNI = value;
            }
        }

        public string NombreHoja
        {
            get
            {
                return nombreHoja;
            }

            set
            {
                nombreHoja = value;
            }
        }

        public List<cDetalleArchivoExcel> Detalles
        {
            get
            {
                return detalles;
            }

            set
            {
                detalles = value;
            }
        }

        public enumTipoNombres TipoNombres
        {
            get
            {
                return tipoNombres;
            }

            set
            {
                tipoNombres = value;
            }
        }
    }
}
