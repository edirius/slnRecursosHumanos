using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using System.Data;

namespace CapaDeNegociosTramite.Operacion
{
    public class cOperacion
    {
        int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        
        string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        
        public DataTable TramiteNuevaOperacion()
        {
            return Conexion.GDatos.TraerDataTable("spTramiteNuevaOperacion");
        }

        public DataTable TramiteInsertarOperacion(string pDescripcion)
        {
            return Conexion.GDatos.TraerDataTable("spTramiteInsertarOperacion", pDescripcion ) ;
        }

        public DataTable TramiteListarOperacion()
        {
            return Conexion.GDatos.TraerDataTable("spTramiteListarOperacion" );
        }

        public DataTable TramiteEliminarOperacion(int pCodigo, string pDescripcion)
        {
            return Conexion.GDatos.TraerDataTable("spTramiteEliminarOperacion", pCodigo,pDescripcion);
        }

        public DataTable TramiteModificarOperacion(int pCodigo, string pDescripcion)
        {
            return Conexion.GDatos.TraerDataTable("spTramiteModificarOperacion", pCodigo,pDescripcion);
        }

    }
}
