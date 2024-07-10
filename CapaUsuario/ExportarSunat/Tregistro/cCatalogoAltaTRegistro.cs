using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeNegocios;
using CapaDeDatos;
using System.Data;

namespace CapaUsuario.ExportarSunat.Tregistro
{
    public class cCatalogoAltaTRegistro
    {
        public List<cTrabajadorAltaTRegistro> TraerListaTrabajadoresTRegistro(string mes, string año)
        {
            try
            {
                List<cTrabajadorAltaTRegistro> Lista = new List<cTrabajadorAltaTRegistro>();
                DataTable tLista = Conexion.GDatos.TraerDataTable("spAltaTRegistro", mes, año);
                for (int i = 0; i < tLista.Rows.Count; i++)
                {
                    cTrabajadorAltaTRegistro Trabajador = new cTrabajadorAltaTRegistro();
                    Trabajador.Numero = i + 1;
                    Trabajador.DNI = tLista.Rows[i][0].ToString();
                    Trabajador.Nombres = tLista.Rows[i][1].ToString();
                    Trabajador.ApellidoPaterno = tLista.Rows[i][2].ToString();
                    Trabajador.ApellidoMaterno = tLista.Rows[i][3].ToString();
                    Trabajador.FechaInicio = Convert.ToDateTime(tLista.Rows[i][4]);
                    Trabajador.Planilla = tLista.Rows[i][5].ToString();
                    Lista.Add(Trabajador);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo TraerListaTrabajadoresTRegistro: " + ex.Message);
            }
        }
    }
}
