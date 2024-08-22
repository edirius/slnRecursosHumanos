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

        public cOcupacion TraerOcupacion(int idtOcupacion)
        {
            try
            {
                cOcupacion ocu = new cOcupacion();
                DataTable tabla = Conexion.GDatos.TraerDataTable("spTraerOcupacion", idtOcupacion);
                if (tabla.Rows.Count > 0)
                {
                    ocu.IdTOcupacion = Convert.ToInt32(tabla.Rows[0][0].ToString());
                    ocu.Codigo = tabla.Rows[0][1].ToString();
                    ocu.Descripcion = tabla.Rows[0][2].ToString();
                    return ocu;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo TraerOcupacion: " + ex.Message);
            }
        }
    }
}
