﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using System.Data;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.IO;

namespace CapaDeNegocios.Usuario
{
    public class cUsuario
    {
        int codigo;
        string nombre;
        string password;
        cPrivilegio privilegio;
        cTrabajador trabajador;
        Boolean Habilitado;

        public cUsuario()
        {
            this.Privilegio = new cPrivilegio();
            this.Trabajador = new cTrabajador();
        }
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

        public cPrivilegio Privilegio
        {
            get
            {
                return privilegio;
            }

            set
            {
                privilegio = value;
            }
        }

        public cTrabajador Trabajador
        {
            get
            {
                return trabajador;
            }

            set
            {
                trabajador = value;
            }
        }

        public bool Habilitado1
        {
            get
            {
                return Habilitado;
            }

            set
            {
                Habilitado = value;
            }
        }

        public static bool Autenticar(cUsuario Usuario)
        {
            return (Convert.ToBoolean (Conexion.GDatos.TraerValorEscalar("spBuscarUsuario", Usuario.Nombre, Usuario.Password)));
        }

        public DataTable ListaUsuariosTrabajadores()
        {
            return Conexion.GDatos.TraerDataTable("spListaUsuariosTrabajadores"); 
        }

        public DataTable ListaUsuariosTrabajadoresFiltro(string filtro)
        {
            return Conexion.GDatos.TraerDataTable("spListaUsuariosTrabajadoresFiltro", filtro);
        }

        public DataTable ListaUsuarios()
        {
            return Conexion.GDatos.TraerDataTable("spListarUsuarios");
        }

        public Boolean  CrearUsuario(cUsuario UsuarioNuevo)
        {   
            return Convert.ToBoolean ( Conexion.GDatos.Ejecutar("spCrearUsuario", UsuarioNuevo.nombre, UsuarioNuevo.password, UsuarioNuevo.Privilegio.Codigo, UsuarioNuevo.trabajador.IdTrabajador, Habilitado));
        }

        public Boolean ModificarUsuario(cUsuario UsuarioAModificar)
        {
            return Convert.ToBoolean(Conexion.GDatos.Ejecutar("spModificarUsuario", UsuarioAModificar.codigo, UsuarioAModificar.nombre, UsuarioAModificar.password, UsuarioAModificar.privilegio.Codigo, Habilitado ));
        }

        public Boolean EliminarUsuario(cUsuario UsuarioAEliminar)
        {
            return Convert.ToBoolean(Conexion.GDatos.Ejecutar("spEliminarUsuario", UsuarioAEliminar.codigo));
        }

        public Boolean CambiarHabilitacionUsuario(cUsuario UsuarioADeshabilitar, Boolean habilitado)
        {
            return Convert.ToBoolean(Conexion.GDatos.Ejecutar("spDeshabilitarUsuario", UsuarioADeshabilitar.codigo, habilitado));
        }
        public int ValidarUsuarioContraseña(string usuario, string contraseña, string numero, string user)
        {
           return Conexion.GDatos.Ejecutar("spLoginUsuario", usuario, contraseña, numero, user);
        }
        public DataTable ObtenerPrivilegios(string Usuario)
        {
            return Conexion.GDatos.TraerDataTable("spObtenerPrivilegios2", Usuario);
        }
        public cUsuario BuscarUsuarioPorCodigo(int codigo)
        {
            cUsuario UsuarioParaBuscar = new cUsuario();
            DataTable tAuxiliar;
            tAuxiliar = Conexion.GDatos.TraerDataTable("spTraerUsuarioPorCodigo", codigo);
            if (tAuxiliar.Rows.Count > 0)
            {
                UsuarioParaBuscar.codigo = Convert.ToInt16(tAuxiliar.Rows[0][0].ToString());
                UsuarioParaBuscar.nombre = Convert.ToString(tAuxiliar.Rows[0][1].ToString());
                UsuarioParaBuscar.password = Convert.ToString(tAuxiliar.Rows[0][2].ToString());
                UsuarioParaBuscar.Privilegio.Codigo = Convert.ToInt16(tAuxiliar.Rows[0][3].ToString());
                UsuarioParaBuscar.trabajador.IdTrabajador = Convert.ToInt16(tAuxiliar.Rows[0][4].ToString());
                UsuarioParaBuscar.Habilitado1 = Convert.ToBoolean(tAuxiliar.Rows[0][5].ToString());

                return UsuarioParaBuscar;
            }
            else
            {
                throw new cReglaNegociosException("No se encuentra el usuario");
            }
           
        }
        public String ObtenerMD5(String contraseña)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5 = MD5CryptoServiceProvider.Create();
            byte[] dataMD5 = md5.ComputeHash(Encoding.Default.GetBytes(contraseña));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < dataMD5.Length; i++)
                sb.AppendFormat("{0:x2}", dataMD5[i]);
            return sb.ToString();
        }
        public String ObtenerSHA1(String contraseña )
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            sha1 = SHA1CryptoServiceProvider.Create();
            byte[] datasha1 = sha1.ComputeHash(
                Encoding.Default.GetBytes(contraseña));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < datasha1.Length; i++)
                sb.AppendFormat("{0:x2}", datasha1[i]);
            return sb.ToString().ToUpper();
        }
    }
}
