using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios
{
    public class cTipoZona
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

        public DataTable ListarTiposZona()
        {
            return Conexion.GDatos.TraerDataTable("spListarTiposZona");
        }

        public cTipoZona TraerTipoZona(int codigoZona)
        {
            cTipoZona miZOna = new cTipoZona();
            DataTable dt = Conexion.GDatos.TraerDataTable("spTraerTipoZona", codigoZona );
            if (dt.Rows.Count > 0)
            {
                miZOna.codigo = Convert.ToInt16(dt.Rows[0][0]);
                miZOna.codigoSunat = Convert.ToString(dt.Rows[0][1]);
                miZOna.descripcion = Convert.ToString(dt.Rows[0][2]);
                return miZOna;
            }
            else
            {
                return null;
            }
        }
    }
}
