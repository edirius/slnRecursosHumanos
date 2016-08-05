using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDeDatos;
using CapaDeNegocios.Obras;

namespace CapaDeNegocios.DatosLaborales
{
    public class cOcupacion
    {
        int sidtocupacion;
        string scodigo;
        string sdescripcion;

        public int IdTOcupacion
        {
            get { return sidtocupacion; }
            set { sidtocupacion = value; }
        }

        public string Codigo
        {
            get { return scodigo; }
            set { scodigo = value; }
        }

        public string Descripcion
        {
            get { return sdescripcion; }
            set { sdescripcion = value; }
        }

        public DataTable ListarOcupacion()
        {
            return Conexion.GDatos.TraerDataTable("spListarOcupacion");
        }

        public Boolean CrearOcupacion(cOcupacion miOcupacion)
        {
            Conexion.GDatos.Ejecutar("spCrearOcupacion", miOcupacion.Codigo, miOcupacion.Descripcion);
            return true;
        }

        public Boolean ModificarOcupacion(cOcupacion miOcupacion)
        {
            Conexion.GDatos.Ejecutar("spModificarOcupacion", miOcupacion.IdTOcupacion, miOcupacion.Codigo, miOcupacion.Descripcion);
            return true;
        }

        public Boolean EliminarOcupacion(cOcupacion miOcupacion)
        {
            Conexion.GDatos.Ejecutar("spELiminarOcupacion", miOcupacion.IdTOcupacion);
            return true;
        }
    }
}
