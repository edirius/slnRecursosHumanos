using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios.Reloj
{
    public class cCatalogoMaquinaReloj
    {
        public List<cMaquinaReloj> ListaRelojes(Boolean activo)
        {
            try
            {
                DataTable Relojes = Conexion.GDatos.TraerDataTable("spListarReloj", activo);
                List<cMaquinaReloj> ListaRelojes = new List<cMaquinaReloj>();
                for (int i = 0; i < Relojes.Rows.Count; i++)
                {
                    cMaquinaReloj Reloj = new cMaquinaReloj();
                    Reloj.IdtReloj = Convert.ToInt32(Relojes.Rows[i][0].ToString());
                    Reloj.Descripcion = Relojes.Rows[i][1].ToString();
                    Reloj.Ip = Relojes.Rows[i][2].ToString();
                    Reloj.Activo = Convert.ToBoolean(Relojes.Rows[i][3]);
                    Reloj.Puerto = Relojes.Rows[i][4].ToString();
                    ListaRelojes.Add(Reloj);
                }

                return ListaRelojes;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo ListaRelojes: " + ex.Message);
            }
            
        }

        public void CrearMaquinaReloj(cMaquinaReloj reloj)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spCrearReloj", reloj.Descripcion, reloj.Ip, reloj.Activo, reloj.Puerto);
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo CrearMaquinaReloj: " + ex.Message);
            }
        }

        public void ModificarMaquinaReloj(cMaquinaReloj reloj)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spModificarReloj", reloj.IdtReloj, reloj.Descripcion, reloj.Ip, reloj.Activo, reloj.Puerto);
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo ModificarMaquinaReloj: " + ex.Message);
            }
        }

        public void EliminarMaquinaReloj(cMaquinaReloj reloj)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spEliminarReloj", reloj.IdtReloj);
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo EliminarMaquinaReloj: " + ex.Message);
            }
        }
    }
}
