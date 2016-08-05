using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios.DatosLaborales
{
    public class cMotivoFinPeriodo
    {
        int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        string descripcion;

        private string codigosunat;

        public string Codigosunat
        {
            get { return codigosunat; }
            set { codigosunat = value; }
        }


        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public cMotivoFinPeriodo TraerMotivoFinPeriodo(int codigoFinPeriodo)
        {
            cMotivoFinPeriodo miMotivoFinPeriodo = new cMotivoFinPeriodo();
            DataTable dt = Conexion.GDatos.TraerDataTable("spTraerMotivoFinPeriodo", codigoFinPeriodo);
            if (dt.Rows.Count > 0)
            {
                miMotivoFinPeriodo.codigo = Convert.ToInt16(dt.Rows[0][0]);
                miMotivoFinPeriodo.codigosunat = Convert.ToString(dt.Rows[0][1]);
                miMotivoFinPeriodo.descripcion = Convert.ToString(dt.Rows[0][2]);
                return miMotivoFinPeriodo;
            }
            else
            {
                return null;
            }
        }

        public DataTable ListaMotivosFinPeriodos()
        {
            return Conexion.GDatos.TraerDataTable("spListaMotivosFinPeriodos"); 
        }
    }
}
