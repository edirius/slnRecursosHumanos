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

        public DataTable ListarDetalleTareo(int IdTTareo)
        {
            return Conexion.GDatos.TraerDataTable("spListarDetalleTareo", IdTTareo);
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
