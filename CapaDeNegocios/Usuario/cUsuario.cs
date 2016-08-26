using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using System.Data;

namespace CapaDeNegocios.Usuario
{
    public class cUsuario
    {
        int codigo;
        string nombre;
        string password;

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

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }


        public DataTable ListaDepartamentos()
        {
            return Conexion.GDatos.TraerDataTable("spListarUsuarios");
        }
    }
}
