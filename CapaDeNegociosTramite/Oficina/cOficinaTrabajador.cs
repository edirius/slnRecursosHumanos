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

        public DataTable AgregarOficinaTrabajador()
        {
            return Conexion.GDatos.TraerDataTable("spTramiteInsertarOficinaTrabajador", CodigoTrabajador, CodigoOficina);
        }
        public DataTable ModificarOficinaTrabajador()
        {
            return Conexion.GDatos.TraerDataTable("spTramiteModificarOficinaTrabajador", CodigoOficinaTrabajador, CodigoTrabajador, CodigoOficina);
        }
        public DataTable EliminarOficinaTrabajador()
        {
            return Conexion.GDatos.TraerDataTable("spTramiteEliminarOficinaTrabajador", CodigoOficinaTrabajador);
        }
        public DataTable ListarOficinaTrabajador()
        {
            return Conexion.GDatos.TraerDataTable("spTramiteListarOficinaTrabajador");
        }
        
        public DataTable ListarTrabajadores()
        {
            return Conexion.GDatos.TraerDataTable("spTramiteListarTrabajadores");
        }
        public DataTable DatosUsuario(string nombre)
        {
            return Conexion.GDatos.TraerDataTable("spTramiteRecuperarDatosUsuario", nombre);
        }

    }
}
