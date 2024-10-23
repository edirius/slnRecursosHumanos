using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Tareos
{
    public class cExcelHojaInformativa
    {
        int inicioFila;
        int finFila;
        string columnaDNI;
        string nombreHoja;
        string columnaCuentaBancaria;
        List<cDetalleHojaInformativa> detalles;


        public cExcelHojaInformativa()
        {
            detalles = new List<cDetalleHojaInformativa>();
            NombreHoja = "H. INF. TECNICO";
            InicioFila = 11;
            FinFila = 11;
            ColumnaDNI = "H";
            ColumnaCuentaBancaria = "L";
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

        public string ColumnaCuentaBancaria
        {
            get
            {
                return columnaCuentaBancaria;
            }

            set
            {
                columnaCuentaBancaria = value;
            }
        }

        public List<cDetalleHojaInformativa> Detalles
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
    }
}
