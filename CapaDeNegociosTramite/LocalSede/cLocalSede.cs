using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using System.Data;

namespace CapaDeNegociosTramite.LocalSede
{
    public class cLocalSede
    {

        public DataTable TramiteNuevoLocalSede()
        {
            return Conexion.GDatos.TraerDataTable("spTramiteNuevoLocalSede");
        }
        public DataTable  TramiteInsertarLocalSede(string pdescripcion)
        {
            return Conexion.GDatos.TraerDataTable("spTramiteInsertarLocalSede", pdescripcion);
        }
        public DataTable  TramiteListarLocalSede()
        {
            return Conexion.GDatos.TraerDataTable("spTramiteListarLocalSede");
        }
        public DataTable TramiteEliminarLocalSede(int pid_local_sede, string pdescripcion)
        {
            return Conexion.GDatos.TraerDataTable("spTramiteEliminarLocalSede", pid_local_sede, pdescripcion);
        }
        public DataTable  TramiteModificarLocalSede(int pid_local_sede, string pdescripcion)
        {
            return Conexion.GDatos.TraerDataTable("spTramiteModificarLocalSede",pid_local_sede,pdescripcion);
        }
    }
}
