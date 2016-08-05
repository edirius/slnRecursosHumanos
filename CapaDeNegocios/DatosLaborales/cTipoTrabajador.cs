using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CapaDeDatos;


namespace CapaDeNegocios
{
    public class cTipoTrabajador
    {
        private int codigo;

        private string codigoSunat;
        private string descripcion;

        public int Codigo
        {
            get
            {
                return codigo;
            }

            set
            {
                codigo = value;
            }
        }

        public string CodigoSunat
        {
            get
            {
                return codigoSunat;
            }

            set
            {
                codigoSunat = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }

       public DataTable ListarTiposDeTrabajadores()
        {
            return Conexion.GDatos.TraerDataTable("uspListarTiposDeTrabajador" );
        }
    }
}
