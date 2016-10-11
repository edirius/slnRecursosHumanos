using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using System.Data;


namespace CapaDeNegociosTramite.LocalSede
{
    public class cSede
    {  
        public int CodigoSede { get; set; }

        public string Descripcion { get; set; }

        public int AgregarSede()
        {
            return Conexion.GDatos.Ejecutar("spTramiteInsertarLocalSede", Descripcion );
        }
        public int ModificarSede()
        {
            return Conexion.GDatos.Ejecutar("spTramiteModificarLocalSede", CodigoSede, Descripcion);
        }
        public int EliminarSede()
        {
            return Conexion.GDatos.Ejecutar("spTramiteEliminarLocalSede", CodigoSede);
        }
        public DataTable ListarSede()
        {
            return Conexion.GDatos.TraerDataTable("spTramiteListarLocalSede");
        }
    }
}
