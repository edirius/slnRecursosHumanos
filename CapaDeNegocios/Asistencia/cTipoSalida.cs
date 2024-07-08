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

        /// <summary>
        /// Metodo para ingresar un nuevo tipo de salida
        /// </summary>
        /// <param name="NuevoTipoSalida">El nuevo Tipo de Salida</param>
        public void IngresarTipoSalida(cTipoSalida NuevoTipoSalida)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spCrearTiposalida", NuevoTipoSalida.descripcion);
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo IngresarTipoSalida: " + ex);
            }
        }

        public void ModificarTipoSalida(cTipoSalida TipoSalidaAModificar)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spModificarTiposalida", TipoSalidaAModificar.codigo, TipoSalidaAModificar.descripcion);
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo ModificarTipoSalida: " + ex);
            }
        }

        public void EliminarTipoSalida(cTipoSalida TipoSalidaAEliminar)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spEliminarTiposalida", TipoSalidaAEliminar.codigo);
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo EliminarTipoSalida: " + ex);
            }
        }
    }
}
