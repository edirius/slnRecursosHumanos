using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDeNegocios;
using CapaDeDatos;

namespace CapaUsuario.Planilla.VacacionesTruncas
{
    public class cCatalogoBusqueda
    {
        /// <summary>
        /// Metodo que devuelve una lista de trabajadores segun el tipo de busqueda y el filtro
        /// </summary>
        /// <param name="tipoBusqueda">Puede ser 0 para dni, 1 para nombres, 2 para cargos</param>
        /// <param name="filtro">Filtro a buscar</param>
        /// <returns></returns>
        public List<cTrabajadorBuscado> TraerTrabajadoresSegunFiltro(enumTipoBusqueda tipoBusqueda, string filtro)
        {
            try
            {
                DataTable oTabla = Conexion.GDatos.TraerDataTable("spBuscarTrabajadorxNombresxDNIxCargo", (int)tipoBusqueda, filtro);

                List<cTrabajadorBuscado> Lista = new List<cTrabajadorBuscado>();
                for (int i = 0; i < oTabla.Rows.Count; i++)
                {
                    cTrabajadorBuscado tra = new cTrabajadorBuscado();
                    tra.CODIGOTRABAJADOR = Convert.ToInt32(oTabla.Rows[i][0]);
                    tra.DNI = oTabla.Rows[i][1].ToString();
                    tra.NOMBRES = oTabla.Rows[i][2].ToString();
                    tra.APELLIDOPATERNO = oTabla.Rows[i][3].ToString();
                    tra.APELLIDOMATERNO = oTabla.Rows[i][4].ToString();
                    tra.FECHANACIMIENTO = Convert.ToDateTime(oTabla.Rows[i][5].ToString());
                    tra.GENERO = oTabla.Rows[i][6].ToString();
                    if (tipoBusqueda == enumTipoBusqueda.CARGO)
                    {
                        tra.CARGO = oTabla.Rows[i][7].ToString();
                    }
                    Lista.Add(tra);
                }

                return Lista;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el método TraerTrabajadoresSegunFiltro: " + ex.Message);
            }
        }
    }
}
