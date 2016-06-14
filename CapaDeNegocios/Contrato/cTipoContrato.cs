using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios.Contrato
{
    public class cTipoContrato
    {
        int codigo;

        private string descripcion;
        private string codigoSunat;

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

        public Boolean AgregarContrato(cTipoContrato miContrato)
        {
            Conexion.GDatos.Ejecutar("spCrearTipoContrato", miContrato.descripcion, miContrato.codigoSunat);
            return true;
        }

        public DataTable ListaTipoContratos()
        {
            return Conexion.GDatos.TraerDataTable("spListarTipoContrato");
        }
    }
}
