using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios.DatosLaborales
{
    public class cSistemaPension
    {
        int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        /// <summary>
        /// Retorna la lista de los sistemas de pension
        /// </summary>
        /// <returns>Un datatable con la informacion de los sistemas de pensión</returns>
        public DataTable ListarSistemasPension()
        {
            return Conexion.GDatos.TraerDataTable("spListarSistemasPension", "Todo");
        }

    }
}
