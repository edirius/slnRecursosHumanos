using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using System.Data;
using MySql.Data.MySqlClient;

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

        public static bool Autenticar(cUsuario Usuario)
        {
            return (Convert.ToBoolean (Conexion.GDatos.TraerValorEscalar("spBuscarUsuario", Usuario.Nombre, Usuario.Password)));
        }


        public DataTable ListaUsuarios()
        {
            return Conexion.GDatos.TraerDataTable("spListarUsuarios");
        }

        public Boolean  CrearUsuario(cUsuario UsuarioNuevo)
        {   
            return Convert.ToBoolean ( Conexion.GDatos.Ejecutar("spCrearUsuario", UsuarioNuevo.nombre, UsuarioNuevo.password));
        }

        public Boolean ModificarUsuario(cUsuario UsuarioAModificar)
        {
            return Convert.ToBoolean(Conexion.GDatos.Ejecutar("spModificarUsuario", UsuarioAModificar.codigo, UsuarioAModificar.nombre, UsuarioAModificar.password));
        }

        public Boolean EliminarUsuario(cUsuario UsuarioAEliminar)
        {
            return Convert.ToBoolean(Conexion.GDatos.Ejecutar("spEliminarUsuario", UsuarioAEliminar.codigo));
        }


    }
}
