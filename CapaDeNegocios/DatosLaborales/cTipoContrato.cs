using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using System.Data;

namespace CapaDeNegocios.DatosLaborales
{
    public class cTipoContrato
    {
        private int idtTipocontrato;
        private string descripcion;
        private string codigoSunat;

        public int IdtTipocontrato
        {
            get
            {
                return idtTipocontrato;
            }

            set
            {
                idtTipocontrato = value;
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

        public cTipoContrato TraerTipoContrato(int idtTipoContrato)
        {
            try
            {
                cTipoContrato tipo = new cTipoContrato();
                DataTable tabla = Conexion.GDatos.TraerDataTable("spTraerTipoContrato", idtTipocontrato);
                if (tabla.Rows.Count > 0)
                {
                    tipo.IdtTipocontrato = Convert.ToInt32(tabla.Rows[0][0].ToString());
                    tipo.Descripcion = tabla.Rows[0][1].ToString();
                    tipo.CodigoSunat = tabla.Rows[0][2].ToString();
                    return tipo;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo TraerTipoContrato: " + ex.Message);
            }
        }
    }
}
