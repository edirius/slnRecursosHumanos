using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeNegocios;

namespace CapaUsuario.ExportarSunat.Tregistro
{
    public class cCatalogoAltaTRegistro
    {
        List<cListaTrabajadores> ListaTrabajadores;

        public List<cListaTrabajadores> TraerListaTrabajadores(DateTime Mes)
        {
            try
            {
                List<cListaTrabajadores> Lista = new List<cListaTrabajadores>();
                return Lista;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo TraerListaTrabajadores: " + ex.Message);
            }
        }
    }
}
