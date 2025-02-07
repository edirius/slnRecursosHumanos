using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios.Asistencia.GrupoAsistencia
{
    public class cCatalogoGrupoAsistencia
    {
        public List<cGrupoAsistencia> TraerGrupoAsistencia(Boolean SoloHabilitados)
        {
            try
            {
                List<cGrupoAsistencia> Lista = new List<cGrupoAsistencia>();
                DataTable oData = Conexion.GDatos.TraerDataTable("spListarGrupoAsistencia", SoloHabilitados);

                foreach (DataRow item in oData.Rows)
                {
                    cGrupoAsistencia grupo = new cGrupoAsistencia();
                    grupo.IdtGrupoAsistencia = Convert.ToInt32(item["idtgrupoasistencia"]);
                    grupo.Descripcion = item["descripcion"].ToString();
                    grupo.Habilitado = Convert.ToBoolean(item["habilitado"]);
                    Lista.Add(grupo);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo traerGrupoAsistencia: " + ex.Message);
            }
        }

        /// <summary>
        /// Funcion que devuelve una lista de detalles de grupoasistencia
        /// </summary>
        /// <param name="codigo">Id del grupoAsistencia</param>
        /// <returns>Lista de detalles</returns>
        public List<cDetalleGrupoAsistencia> TraerDetallesGrupoAsistencia(int codigo)
        {
            try
            {
                List<cDetalleGrupoAsistencia> Lista = new List<cDetalleGrupoAsistencia>();
                DataTable oData = Conexion.GDatos.TraerDataTable("spListarDetalleGrupoAsistencia", codigo);

                foreach (DataRow item in oData.Rows)
                {
                    cDetalleGrupoAsistencia grupo = new cDetalleGrupoAsistencia();
                    grupo.IdtDetalleGrupoAsistencia = Convert.ToInt32(item["idtdetallegrupoasistecia"]);
                    grupo.IdtTrabajador = Convert.ToInt32(item["id_trabajador"]);
                    grupo.Nombres = item["nombres"].ToString();
                    grupo.ApellidoPaterno = item["apellidoPaterno"].ToString();
                    grupo.ApellidoMaterno = item["apellidoMaterno"].ToString();
                    grupo.DNI = item["DNI"].ToString();
                    Lista.Add(grupo);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo TraerDetallesGrupoAsistencia: " + ex.Message);
            }
        }

        public void CrearGrupoAsistencia(cGrupoAsistencia NuevoGrupo)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spCrearGrupoasistencia", NuevoGrupo.Descripcion, NuevoGrupo.Habilitado);
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo CrearGrupoAsistencia: " + ex.Message);
            }
        }

        public void ModificarGrupoAsistencia(cGrupoAsistencia GrupoAModificar)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spModificarGrupoasistencia", GrupoAModificar.IdtGrupoAsistencia, GrupoAModificar.Descripcion, GrupoAModificar.Habilitado);
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo ModificarGrupoAsistencia: " + ex.Message);
            }
        }

        public void EliminarGrupoAsistencia(cGrupoAsistencia GrupoAModificar)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spEliminarGrupoasistencia", GrupoAModificar.IdtGrupoAsistencia);
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo EliminarGrupoAsistencia: " + ex.Message);
            }
        }

        public void CrearDetalleGrupoAsistencia(cDetalleGrupoAsistencia NuevoDetalle)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spCrearDetalleGrupoAsistencia", NuevoDetalle.IdtTrabajador, NuevoDetalle.GrupoAsistencia.IdtGrupoAsistencia);
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo CrearDetalleGrupoAsistencia: " + ex.Message);
            }
        }

        public void ModificarDetalleGrupoAsistencia(cDetalleGrupoAsistencia DetalleAModificar)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spModificarDetalleGrupoAsistencia", DetalleAModificar.IdtDetalleGrupoAsistencia, DetalleAModificar.IdtTrabajador, DetalleAModificar.GrupoAsistencia.IdtGrupoAsistencia);
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo ModificarDetalleGrupoAsistencia: " + ex.Message);
            }
        }

        public void EliminarDetalleGrupoAsistencia(cDetalleGrupoAsistencia DetalleAEliminar)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spEliminarDetalleGrupoAsistencia", DetalleAEliminar.IdtDetalleGrupoAsistencia);
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo EliminarDetalleGrupoAsistencia: " + ex.Message);
            }
        }
    }
}
