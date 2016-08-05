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
    public class cDiasTareo
    {
        int sidtdiastareo;
        DateTime sfecha;
        bool sestado = false;

        public int IdTDiasTareo
        {
            get { return sidtdiastareo; }
            set { sidtdiastareo = value; }
        }

        public DateTime Fecha
        {
            get { return sfecha; }
            set { sfecha = value; }
        }

        public bool Estado
        {
            get { return sestado; }
            set { sestado = value; }
        }

        public DataTable ListarDiasTareo(cDetalleTareo miDetalleTareo)
        {
            return Conexion.GDatos.TraerDataTable("spListarDiasTareo", miDetalleTareo.IdTDetalleTareo);
        }

        public Boolean CrearDiasTareo(cDiasTareo miDiasTareo, cDetalleTareo miDetalleTareo)
        {
            Conexion.GDatos.Ejecutar("spCrearDiasTareo", miDiasTareo.Fecha, miDiasTareo.Estado, miDetalleTareo.IdTDetalleTareo);
            return true;
        }

        public Boolean ModificarDiasTareo(cDiasTareo miDiasTareo, cDetalleTareo miDetalleTareo)
        {
            Conexion.GDatos.Ejecutar("spModificarDiasTareo", miDiasTareo.IdTDiasTareo, miDiasTareo.Fecha, miDiasTareo.Estado, miDetalleTareo.IdTDetalleTareo);
            return true;
        }

        public Boolean ELiminarDiasTareo(cDiasTareo miDiasTareo)
        {
            Conexion.GDatos.Ejecutar("spEliminarDiasTareo", miDiasTareo.IdTDiasTareo);
            return true;
        }
    }
}
