using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios
{
    public class cNacionalidad
    {
        int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        string codigoSunat;

        public string CodigoSunat
        {
            get { return codigoSunat; }
            set { codigoSunat = value; }
        }
        string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public DataTable listaNacionalidades()
        {
            return Conexion.GDatos.TraerDataTable("spListarNacionalidades");
        }

        public cNacionalidad TraerNacionalidad(int codigoNacionalidad)
        {
            cNacionalidad miNacionalidad = new cNacionalidad();
            DataTable dt = Conexion.GDatos.TraerDataTable("spTraerNacionalidad", codigoNacionalidad );
            if (dt.Rows.Count > 0)
            {
                miNacionalidad.codigo =Convert.ToInt16( dt.Rows[0][0]);
                miNacionalidad.codigoSunat = Convert.ToString( dt.Rows[0][1]);
                miNacionalidad.descripcion = Convert.ToString( dt.Rows[0][2]);
                return miNacionalidad;
            }
            else
            {
                return null;
            }
        }
    }
}
