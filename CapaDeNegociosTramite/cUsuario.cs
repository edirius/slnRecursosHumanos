using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using CapaDeDatos;


namespace CapaDeNegociosTramite
{
    public class cUsuario
    {

        public int ValidarUsuarioContraseña(string usuario, string contraseña, string numero, string user)
        {
            return Conexion.GDatos.Ejecutar("spLoginUsuario", usuario, contraseña, numero, user);
        }


        public String ObtenerSHA1(String contraseña)
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
