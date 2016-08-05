using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeNegocios.Contrato;
using CapaDeNegocios.DatosLaborales;
using CapaDeDatos;
using System.Data;


namespace CapaDeNegocios.Trabajadores
{
    public class cTrabajadorServidorPersonal:cTrabajador 
    {
        public cTrabajadorServidorPersonal()
        {
            //MiListaPeriodos = new List<cPeriodo>();
            miListaPeriodosSistemaPension = new List<cPeriodoSistemaPension>();
        }

      

        //List<cPeriodo> miListaPeriodos;
        List<cPeriodoSistemaPension> miListaPeriodosSistemaPension;

        //public List<cPeriodo> MiListaPeriodos
        //{
        //    get
        //    {
        //        return miListaPeriodos;
        //    }

        //    set
        //    {
        //        miListaPeriodos = value;
        //    }
        //}

        public List<cPeriodoSistemaPension> MiListaPeriodosSistemaPension
        {
            get
            {
                return miListaPeriodosSistemaPension;
            }

            set
            {
                miListaPeriodosSistemaPension = value;
            }
        }



        //public void AgregarPeriodo(cPeriodo miNuevoPeriodo)
        //{
        //    miNuevoPeriodo.Trabajador = this;

        //    miListaPeriodos.Add(miNuevoPeriodo);

        //}

        //public void ModificarPeriodo(cPeriodo miPeriodo)
        //{

        //}

        //public void EliminarPeriodo(cPeriodo miPeriodo)
        //{
        //    miListaPeriodos.Remove(miPeriodo);
        //}


        public new cTrabajadorServidorPersonal traerTrabajador(int codigoTrabajador)
        {
            cTrabajadorServidorPersonal miTrabajador = new cTrabajadorServidorPersonal();
            DataTable dt = Conexion.GDatos.TraerDataTable("spTraerTrabajador", codigoTrabajador);
            if (dt.Rows.Count > 0)
            {

                miTrabajador.IdTrabajador = Convert.ToInt16(dt.Rows[0][0]);
                miTrabajador.Nombres = Convert.ToString(dt.Rows[0][1]);
                miTrabajador.ApellidoPaterno = Convert.ToString(dt.Rows[0][2]);
                miTrabajador.ApellidoMaterno = Convert.ToString(dt.Rows[0][3]);
                switch (Convert.ToString(dt.Rows[0][4]))
                {
                    case "M":
                        miTrabajador.Sexo = EnumSexo.Masculino;
                        break;
                    case "F":
                        miTrabajador.Sexo = EnumSexo.Femenino;
                        break;
                    default:
                        break;
                }
                switch (Convert.ToString(dt.Rows[0][5]))
                {
                    case "Casado":
                        miTrabajador.EstadoCivil = enumEstadoCivil.Casado;
                        break;
                    case "Soltero":
                        miTrabajador.EstadoCivil = enumEstadoCivil.Soltero;
                        break;
                    case "Divorciado":
                        miTrabajador.EstadoCivil = enumEstadoCivil.Divorciado;
                        break;
                    case "Viudo":
                        miTrabajador.EstadoCivil = enumEstadoCivil.Viudo;
                        break;
                    default:
                        break;
                }

                miTrabajador.Direccion = Convert.ToString(dt.Rows[0][6]);
                miTrabajador.Dni = Convert.ToString(dt.Rows[0][7]);
                miTrabajador.CelularPersonal = Convert.ToString(dt.Rows[0][8]);
                miTrabajador.CelularTrabajo = Convert.ToString(dt.Rows[0][9]);
                miTrabajador.FechaNacimiento = Convert.ToDateTime(dt.Rows[0][10]);
                if (dt.Rows[0][11] != DBNull.Value)
                {
                    miTrabajador.Foto = (Byte[])(dt.Rows[0][11]);
                }
                else
                {
                    miTrabajador.Foto = null;
                }
                miTrabajador.CorreoElectronico = Convert.ToString(dt.Rows[0][12]);
                miTrabajador.MiTipoVia = new cTipoVia();
                miTrabajador.MiTipoVia.Codigo = Convert.ToInt16(dt.Rows[0][13]);
                miTrabajador.NombreVia = Convert.ToString(dt.Rows[0][14]);
                miTrabajador.NumeroVia = Convert.ToString(dt.Rows[0][15]);
                miTrabajador.DepartamentoInterior = Convert.ToString(dt.Rows[0][16]);
                miTrabajador.MiTipoZOna = new cTipoZona();
                miTrabajador.MiTipoZOna.Codigo = Convert.ToInt16(dt.Rows[0][17]);
                miTrabajador.NombreZona = Convert.ToString(dt.Rows[0][18]);
                miTrabajador.Referencia = Convert.ToString(dt.Rows[0][19]);
                miTrabajador.MiDistrito = new cDistrito();
                miTrabajador.MiDistrito.Codigo = Convert.ToInt16(dt.Rows[0][20]);
                miTrabajador.MiNacionalidad = new cNacionalidad();
                miTrabajador.MiNacionalidad.Codigo = Convert.ToInt16(dt.Rows[0][21]);

                miTrabajador.MiTipoVia = miTrabajador.MiTipoVia.TraerTipoVia(miTrabajador.MiTipoVia.Codigo);
                miTrabajador.MiTipoZOna = miTrabajador.MiTipoZOna.TraerTipoZona(miTrabajador.MiTipoZOna.Codigo);
                miTrabajador.MiNacionalidad = miTrabajador.MiNacionalidad.TraerNacionalidad(miTrabajador.MiNacionalidad.Codigo);
                miTrabajador.MiDistrito = miTrabajador.MiDistrito.TraerDistrito(miTrabajador.MiDistrito.Codigo);
                miTrabajador.MiProvincia = new cProvincia();
                miTrabajador.MiProvincia = miTrabajador.MiProvincia.TraerProvincia(miTrabajador.MiDistrito.MiProvincia.Codigo);
                miTrabajador.MiDepartamento = new cDepartamento();
                miTrabajador.MiDepartamento = miTrabajador.MiDepartamento.TraerDepartamento(miTrabajador.MiProvincia.MiDepartamento.Codigo);

                return miTrabajador;
            }
            else
            {
                return null;
            }
        }

    }
}
