using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using zkemkeeper;

namespace CapaDeNegocios.Reloj
{
    public class cServidorReloj
    {
        DeviceManipulator manipulator = new DeviceManipulator();
        public ZkemClient objZkeeper;
        private bool isDeviceConnected = false;

        public cReloj ObtenerDatosReloj()
        {
            try
            {
                cReloj nuevoReloj = new cReloj();

                return nuevoReloj;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al obtener datos del reloj: " + ex.Message);
            }
        }
    }
}
