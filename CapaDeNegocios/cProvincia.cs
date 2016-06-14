using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios
{
    public class cProvincia
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
        cDepartamento miDepartamento;

        public cDepartamento MiDepartamento
        {
            get { return miDepartamento; }
            set { miDepartamento = value; }
        }

        public DataTable ListarProvincias(cDepartamento departamento)
        {
            return Conexion.GDatos.TraerDataTable("spListarProvincias", departamento.Codigo);
        }

        public cProvincia TraerProvincia(int codigoProvincia)
        {
            cProvincia miProvincia = new cProvincia();
            DataTable dt = Conexion.GDatos.TraerDataTable("spTraerProvincia", codigoProvincia);
            if (dt.Rows.Count > 0)
	        {
		        miProvincia.codigo = Convert.ToInt16(dt.Rows[0][0]);
                miProvincia.miDepartamento = new cDepartamento();
                miProvincia.miDepartamento.Codigo  = Convert.ToInt16(dt.Rows[0][1]);
                miProvincia.codigoUbigeo = Convert.ToString(dt.Rows[0][2]);
                miProvincia.descripcion = Convert.ToString(dt.Rows[0][3]);
                return miProvincia;
	        }
            else
            {
                return null;
            }    
        }
    }
}
