using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios.Asistencia
{
    public class cTipoSalida
    {
        int codigo;
        string descripcion;

        public int Codigo
        {
            get
            {
                return codigo;
            }

            set
            {
                codigo = value;
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

        public List<cTipoSalida> TraerTiposSalida()
        {
            try
            {
                List<cTipoSalida> ListaTiposSalida = new List<cTipoSalida>();

                DataTable ttipossalida = Conexion.GDatos.TraerDataTable("spTraerTiposSalidas");
                if (ttipossalida.Rows.Count > 0)
                {
                    foreach (DataRow item in ttipossalida.Rows)
                    {
                        cTipoSalida nuevo = new cTipoSalida();
                        nuevo.Codigo = Convert.ToInt32(item[0]);
                        nuevo.Descripcion = item[1].ToString();
                        ListaTiposSalida.Add(nuevo);
                    }
                }

                return ListaTiposSalida;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo TraerTiposSalida: " + ex);
            }
        }
    }
}
