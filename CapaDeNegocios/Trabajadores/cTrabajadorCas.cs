using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios.Trabajadores
{
    public class cTrabajadorCas:cTrabajador
    {

        string ruc;

        public string Ruc
        {
            get
            {
                return ruc;
            }

            set
            {
                ruc = value;
            }
        }



        public DataTable ListarAlcalde()
        {
            return Conexion.GDatos.TraerDataTable("spListarAlcalde");
        }

        public DataTable ListarTrabajadoresParaDeclaracionJurada(string paño)
        {
            return Conexion.GDatos.TraerDataTable("spListarTrabajadoresParaDeclaracionJurada", paño);
        }

    }
}
