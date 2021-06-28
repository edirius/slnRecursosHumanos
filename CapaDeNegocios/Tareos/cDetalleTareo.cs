using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDeDatos;
using CapaDeNegocios.Obras;

namespace CapaDeNegocios.Tareos
{
    public class cDetalleTareo
    {
        int sidtdetalletareo;
        string scategoria;
        string sdiastareo;
        int stotaldias;
        int sidttrabajador;
        int sidttareo;

        public int IdTDetalleTareo
        {
            get { return sidtdetalletareo; }
            set { sidtdetalletareo = value; }
        }
        public string Categoria
        {
            get { return scategoria; }
            set { scategoria = value; }
        }
        public string DiasTareo
        {
            get { return sdiastareo; }
            set { sdiastareo = value; }
        }
        public int TotalDias
        {
            get { return stotaldias; }
            set { stotaldias = value; }
        }
        public int IdtTrabajador
        {
            get { return sidttrabajador; }
            set { sidttrabajador = value; }
        }
        public int IdtTareo
        {
            get { return sidttareo; }
            set { sidttareo = value; }
        }

        private DataTable OrdenarPorCategoria(DataTable odata)
        {
            DataTable AUXILIAR = odata.Clone();
            foreach (DataRow item in odata.Rows)
            {
                if (item[1].ToString() == "MAESTRO DE OBRA")
                {
                    AUXILIAR.ImportRow(item);
                }
            }

            foreach (DataRow item in odata.Rows)
            {
                if (item[1].ToString() == "ALMACENERO")
                {
                    AUXILIAR.ImportRow(item);
                }
            }

            foreach (DataRow item in odata.Rows)
            {
                DataRow nueva;
                nueva = item;
                if (item[1].ToString() == "OPERARIO")
                {
                    AUXILIAR.ImportRow(item);
                }
            }

            foreach (DataRow item in odata.Rows)
            {
                if (item[1].ToString() == "OFICIAL")
                {
                    AUXILIAR.ImportRow(item);
                }
            }

            foreach (DataRow item in odata.Rows)
            {
                if (item[1].ToString() != "MAESTRO DE OBRA" && item[1].ToString() != "ALMACENERO" && item[1].ToString() != "OPERARIO" && item[1].ToString() != "OFICIAL")
                {
                    AUXILIAR.ImportRow(item);
                }
            }

            return AUXILIAR;
        }

        public DataTable ListarDetalleTareo(int IdTTareo)
        {
            return OrdenarPorCategoria(Conexion.GDatos.TraerDataTable("spListarDetalleTareo", IdTTareo));
        }

        public Boolean CrearDetalleTareo(cDetalleTareo miDetalleTareo)
        {
            Conexion.GDatos.Ejecutar("spCrearDetalleTareo", miDetalleTareo.Categoria, miDetalleTareo.DiasTareo, miDetalleTareo.TotalDias, miDetalleTareo.IdtTrabajador, miDetalleTareo.IdtTareo);
            return true;

        }

        public Boolean ModificarDetalleTareo(cDetalleTareo miDetalleTareo)
        {
            Conexion.GDatos.Ejecutar("spModificarDetalleTareo", miDetalleTareo.IdTDetalleTareo, miDetalleTareo.Categoria, miDetalleTareo.DiasTareo, miDetalleTareo.TotalDias, miDetalleTareo.IdtTrabajador, miDetalleTareo.IdtTareo);
            return true;
        }

        public Boolean EliminarDetalleTareo(int IdTDetalleTareo)
        {
            Conexion.GDatos.Ejecutar("spEliminarDetalleTareo", IdTDetalleTareo);
            return true;
        }


    }
}
