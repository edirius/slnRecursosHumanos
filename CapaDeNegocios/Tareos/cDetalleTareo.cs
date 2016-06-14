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

        public DataTable ListarDetalleTareo(cTareo miTareo)
        {
            return Conexion.GDatos.TraerDataTable("spListarDetalleTareo", miTareo.IdTTareo);
        }

        public Boolean CrearDetalleTareo(cDetalleTareo miDetalleTareo, cOcupacion miOcupacion, cTrabajador miTrabajador, cTareo miTareo)
        {
            Conexion.GDatos.Ejecutar("spCrearDetalleTareo", miDetalleTareo.Categoria, miOcupacion.IdTOcupacion, miTrabajador.IdTrabajador, miTareo.IdTTareo);
            return true;
        }

        public Boolean ModificarDetalleTareo(cDetalleTareo miDetalleTareo, cOcupacion miOcupacion, cTrabajador miTrabajador, cTareo miTareo)
        {
            Conexion.GDatos.Ejecutar("spModificarDetalleTareo", miDetalleTareo.IdTDetalleTareo, miDetalleTareo.Categoria, miOcupacion.IdTOcupacion, miTrabajador.IdTrabajador, miTareo.IdTTareo);
            return true;
        }

        public Boolean EliminarDetalleTareo(cDetalleTareo miDetalleTareo)
        {
            Conexion.GDatos.Ejecutar("spEliminarDetalleTareo", miDetalleTareo.IdTDetalleTareo);
            return true;
        }


    }
}
