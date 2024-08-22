using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios.DatosLaborales
{
    public class cCategoriaOcupacional
    {
        int sidtcategoriaocupacional;
        string scodigo;
        string sdescripcion;

        public int IdTCategoriaOcupacional
        {
            get { return sidtcategoriaocupacional; }
            set { sidtcategoriaocupacional = value; }
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

        public DataTable ListarCategoriaOcupacional()
        {
            return Conexion.GDatos.TraerDataTable("spListarCategoriaOcupacional");
        }

        public Boolean CrearCategoriaOcupacional(cCategoriaOcupacional miCategoriaOcupacional)
        {
            Conexion.GDatos.Ejecutar("spCrearCategoriaOcupacional", miCategoriaOcupacional.Codigo, miCategoriaOcupacional.Descripcion);
            return true;
        }

        public Boolean ModificarCategoriaOcupacional(cCategoriaOcupacional miCategoriaOcupacional)
        {
            Conexion.GDatos.Ejecutar("spModificarCategoriaOcupacional", miCategoriaOcupacional.IdTCategoriaOcupacional, miCategoriaOcupacional.Codigo, miCategoriaOcupacional.Descripcion);
            return true;
        }

        public Boolean EliminarCategoriaOcupacional(int IdTCategoriaOcupacional)
        {
            Conexion.GDatos.Ejecutar("spELiminarCategoriaOcupacional", IdTCategoriaOcupacional);
            return true;
        }

        public cCategoriaOcupacional TraerCategoriaOcupacional(int idtcategoria)
        {
            cCategoriaOcupacional cat = new cCategoriaOcupacional();
            DataTable tablaCategoria = Conexion.GDatos.TraerDataTable("spTraerCategoriaOcupacional", idtcategoria);
            if (tablaCategoria.Rows.Count > 0)
            {
                cat.IdTCategoriaOcupacional = Convert.ToInt32(tablaCategoria.Rows[0][0].ToString());
                cat.Codigo = tablaCategoria.Rows[0][1].ToString();
                cat.Descripcion = tablaCategoria.Rows[0][2].ToString();
            }

            return cat;
        }
    }
}
