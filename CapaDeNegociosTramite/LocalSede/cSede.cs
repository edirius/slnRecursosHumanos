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

        public DataTable AgregarSede()
        {
            return Conexion.GDatos.TraerDataTable("spTramiteInsertarLocalSede", Descripcion);
        }
        public DataTable ModificarSede()
        {
            return Conexion.GDatos.TraerDataTable("spTramiteModificarLocalSede", CodigoSede, Descripcion);
        }
        public DataTable EliminarSede()
        {
            return Conexion.GDatos.TraerDataTable("spTramiteEliminarLocalSede", CodigoSede, Descripcion);
        }
        public DataTable ListarSede()
        {
            return Conexion.GDatos.TraerDataTable("spTramiteListarLocalSede");
        }
    }
}
