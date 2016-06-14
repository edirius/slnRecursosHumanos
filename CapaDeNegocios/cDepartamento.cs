using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using System.Data;

namespace CapaDeNegocios
{
    public class cDepartamento
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

        public DataTable ListaDepartamentos()
        {
            return Conexion.GDatos.TraerDataTable("spListarDepartamentos");
        }

        public cDepartamento TraerDepartamento(int codigoDepartamento)
        {
            cDepartamento miDepartamento = new cDepartamento();
            DataTable dt = Conexion.GDatos.TraerDataTable("spTraerDepartamento", codigoDepartamento );
            if (dt.Rows.Count > 0)
            {
                miDepartamento.codigo = Convert.ToInt16(dt.Rows[0][0]);
                miDepartamento.codigoUbigeo = Convert.ToString(dt.Rows[0][1]);
                miDepartamento.descripcion = Convert.ToString(dt.Rows[0][2]);
                return miDepartamento;
            }
            else
            {
                return null;
            }
        }
    }
}
