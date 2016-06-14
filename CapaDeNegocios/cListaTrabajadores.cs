using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios
{
    public class cListaTrabajadores
    {
        public Boolean AgregarTrabajador(cTrabajador trabajador)
        {
            string sexo = "";

            switch (trabajador.Sexo )
            {
                case EnumSexo.Masculino:
                    sexo = "M";
                    break;
                case EnumSexo.Femenino:
                    sexo = "F";
                    break;
                default:
                   
                    break;
            }
            Conexion.GDatos.Ejecutar("spCrearTrabajador",trabajador.Nombres,  trabajador.ApellidoPaterno, trabajador.ApellidoMaterno,  sexo, trabajador.EstadoCivil.ToString(), trabajador.Direccion,trabajador.Dni, trabajador.CelularPersonal, trabajador.CelularTrabajo, trabajador.FechaNacimiento, trabajador.Foto, trabajador.CorreoElectronico, trabajador.MiTipoVia.Codigo, trabajador.NombreVia, trabajador.NumeroVia, trabajador.DepartamentoInterior, trabajador.MiTipoZOna.Codigo, trabajador.NombreZona, trabajador.Referencia, trabajador.MiDistrito.Codigo , trabajador.MiNacionalidad.Codigo );                                                                                                                                                                                                                                                                                                    
     
            return true;
        }

        public Boolean ModificarTrabajador(cTrabajador trabajador)
        {
            string sexo = "";

            switch (trabajador.Sexo)
            {
                case EnumSexo.Masculino:
                    sexo = "M";
                    break;
                case EnumSexo.Femenino:
                    sexo = "F";
                    break;
                default:

                    break;
            }

            Conexion.GDatos.Ejecutar("spModificarTrabajador", trabajador.IdTrabajador, trabajador.Nombres, trabajador.ApellidoPaterno, trabajador.ApellidoMaterno, sexo, trabajador.EstadoCivil.ToString(),trabajador.Direccion , trabajador.Dni, trabajador.CelularPersonal, trabajador.CelularTrabajo, trabajador.FechaNacimiento, trabajador.Foto, trabajador.CorreoElectronico, trabajador.MiTipoVia.Codigo, trabajador.NombreVia, trabajador.NumeroVia, trabajador.DepartamentoInterior, trabajador.MiTipoZOna.Codigo, trabajador.NombreZona, trabajador.Referencia, trabajador.MiDistrito.Codigo, trabajador.MiNacionalidad.Codigo);
            return true;
        }

        public Boolean EliminarTrabajador(cTrabajador trabajador)
        {
            Conexion.GDatos.Ejecutar("spEliminarTrabajador", trabajador.IdTrabajador);
            return true;
        }

        public DataTable ObtenerListaTrabajadores(Boolean Activo)
        {
            return Conexion.GDatos.TraerDataTable("spListarTrabajadores", Activo);
        }
    }
}
