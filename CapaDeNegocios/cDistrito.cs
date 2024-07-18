using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios
{
    public class cDistrito
    {
        int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        string codigoUbigeo;

        public string CodigoUbigeo
        {
            get { return codigoUbigeo; }
            set { codigoUbigeo = value; }
        }
        string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        cProvincia miProvincia;

        public cProvincia MiProvincia
        {
            get { return miProvincia; }
            set { miProvincia = value; }
        }

        public DataTable ListarDistritos(cProvincia provincia)
        {
            return Conexion.GDatos.TraerDataTable("spListarDistritos", provincia.Codigo);
        }

        public cDistrito TraerDistrito(int codigoDistrito)
        {
            cDistrito miDistrito = new cDistrito();
            DataTable dt = Conexion.GDatos.TraerDataTable("spTraerDistrito", codigoDistrito);
            if (dt.Rows.Count > 0)
            {
                miDistrito.miProvincia = new cProvincia();
                miDistrito.codigo = Convert.ToInt16(dt.Rows[0][0]);
                miDistrito.miProvincia.Codigo  = Convert.ToInt16(dt.Rows[0][1]);
                miDistrito.codigoUbigeo = Convert.ToString(dt.Rows[0][2]);
                miDistrito.descripcion = Convert.ToString(dt.Rows[0][3]);
                return miDistrito;
            }
            else
            {
                return null;
            }
        }

        public cDistrito TraerDistritoxUbigeo(string ubigeo)
        {
            cDistrito miDistrito = new cDistrito();
            DataTable dt = Conexion.GDatos.TraerDataTable("spTraerDistritoxUbigeo", ubigeo);
            if (dt.Rows.Count > 0)
            {
                miDistrito.miProvincia = new cProvincia();
                miDistrito.codigo = Convert.ToInt16(dt.Rows[0][0]);
                miDistrito.miProvincia.Codigo = Convert.ToInt16(dt.Rows[0][1]);
                miDistrito.codigoUbigeo = Convert.ToString(dt.Rows[0][2]);
                miDistrito.descripcion = Convert.ToString(dt.Rows[0][3]);
                return miDistrito;
            }
            else
            {
                return null;
            }
        }
    }
}
