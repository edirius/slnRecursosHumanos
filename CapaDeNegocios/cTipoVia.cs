using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios
{
    public class cTipoVia
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

        public DataTable ListaTiposVia()
        {
            return Conexion.GDatos.TraerDataTable("spListaTiposVia");
        }

        public cTipoVia TraerTipoVia(int codigoTipoVia)
        {
            cTipoVia TipoVia = new cTipoVia();
            DataTable dt = Conexion.GDatos.TraerDataTable("spTraerTipoVia", codigoTipoVia);
            if (dt.Rows.Count > 0)
            {
                TipoVia.codigo = Convert.ToInt16(dt.Rows[0][0]);
                TipoVia.codigoSunat = Convert.ToString(dt.Rows[0][1]);
                TipoVia.descripcion = Convert.ToString(dt.Rows[0][2]);
                return TipoVia;
            }
            else
            {
                return null;
            }
        }
    }
}
