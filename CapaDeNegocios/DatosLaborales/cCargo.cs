using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDeDatos;
namespace CapaDeNegocios.DatosLaborales
{
    public class cCargo
    {
        int idtCargo;
        string descripcion;

        public int IdtCargo
        {
            get
            {
                return idtCargo;
            }

            set
            {
                idtCargo = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }

        public cCargo TraerCargoPorXcodigo(int cod)
        {
            cCargo cat = new cCargo();
            DataTable tablaCategoria = Conexion.GDatos.TraerDataTable("spTraerCargo", cod);
            if (tablaCategoria.Rows.Count > 0)
            {
                cat.idtCargo = Convert.ToInt32(tablaCategoria.Rows[0][0].ToString());
                cat.Descripcion = tablaCategoria.Rows[0][1].ToString();
            }

            return cat;
        }
    }
}
