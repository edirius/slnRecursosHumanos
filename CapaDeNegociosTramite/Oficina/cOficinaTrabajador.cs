using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using System.Data;

namespace CapaDeNegociosTramite.Oficina
{
    public class cOficinaTrabajador
    {
        public int CodigoOficinaTrabajador { get; set; }

        public int CodigoTrabajador { get; set; }

        public int CodigoOficina { get; set; }

        public int AgregarOficinaTrabajador()
        {
            return Conexion.GDatos.Ejecutar("spTramiteInsertarOficinaTrabajador", CodigoTrabajador, CodigoOficina);
        }
        public int ModificarOficinaTrabajador()
        {
            return Conexion.GDatos.Ejecutar("spTramiteModificarOficinaTrabajador", CodigoOficinaTrabajador, CodigoTrabajador, CodigoOficina);
        }
        public int EliminarOficinaTrabajador()
        {
            return Conexion.GDatos.Ejecutar("spTramiteEliminarOficinaTrabajador", CodigoOficinaTrabajador);
        }
        public DataTable ListarOficinaTrabajador()
        {
            return Conexion.GDatos.TraerDataTable("spTramiteListarOficinaTrabajador");
        }
        
        public DataTable ListarTrabajadores()
        {
            return Conexion.GDatos.TraerDataTable("spTramiteListarTrabajadores");
        }

    }
}
