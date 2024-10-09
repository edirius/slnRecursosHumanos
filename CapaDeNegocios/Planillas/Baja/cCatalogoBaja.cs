using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using System.Data;

namespace CapaDeNegocios.Planillas.Baja
{
    public class cCatalogoBaja
    {
        public List<cTrabajadorParaDarBaja> TraerListaTrabajadoresParaDarBaja(string mes, int año)
        {
            try
            {
                CapaDeNegocios.Utilidades.cUtilidades oUtilidades = new Utilidades.cUtilidades();

                List<cTrabajadorParaDarBaja> Lista = new List<cTrabajadorParaDarBaja>();
                DataTable TablaTrabajadores = Conexion.GDatos.TraerDataTable("spTrabajadoresParaDarDeBaja", mes, año);
                foreach (DataRow item in TablaTrabajadores.Rows)
                {
                    cTrabajadorParaDarBaja Tra = new cTrabajadorParaDarBaja();
                    Tra.NumeroDocumento = item[7].ToString();
                    Tra.Nombres = item[1].ToString();
                    Tra.ApellidoPaterno = item[2].ToString();
                    Tra.ApellidoMaterno = item[3].ToString();
                    Tra.FechaInicio = Convert.ToDateTime(item[27].ToString());
                    Tra.PeriodoTrabajador = Tra.PeriodoTrabajador.TraerPeriodoTrabajadorXID(Convert.ToInt32(item[26].ToString()));
                    if (!(Tra.FechaInicio.Month == oUtilidades.ConvertirMesANumero(mes) && Tra.FechaInicio.Year == año))
                    {
                        Lista.Add(Tra);
                    }
                }

                return Lista;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo ListaTrabajadoresParaDarBaja: " + ex.Message);
            }
        }
    }
}
