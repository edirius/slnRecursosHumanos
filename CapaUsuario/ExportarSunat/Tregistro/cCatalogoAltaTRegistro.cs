using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeNegocios;
using CapaDeDatos;
using System.Data;

namespace CapaUsuario.ExportarSunat.Tregistro
{
    public class cCatalogoAltaTRegistro
    {
        public cTrabajador miTrabajador = new cTrabajador();

        public List<cTrabajadorAltaTRegistro> TraerListaTrabajadoresTRegistro(string mes, string año)
        {
            try
            {
                List<cTrabajadorAltaTRegistro> Lista = new List<cTrabajadorAltaTRegistro>();
                DataTable tLista = Conexion.GDatos.TraerDataTable("spAltaTRegistro", mes, año);
                for (int i = 0; i < tLista.Rows.Count; i++)
                {
                    cTrabajadorAltaTRegistro Trabajador = new cTrabajadorAltaTRegistro();
                    Trabajador.Numero = i + 1;
                    Trabajador.Id_trabajador = Convert.ToInt32(tLista.Rows[i][0].ToString());
                    Trabajador.DNI = tLista.Rows[i][1].ToString();
                    Trabajador.Nombres = tLista.Rows[i][2].ToString();
                    Trabajador.ApellidoPaterno = tLista.Rows[i][3].ToString();
                    Trabajador.ApellidoMaterno = tLista.Rows[i][4].ToString();
                    Trabajador.FechaNacimiento = Convert.ToDateTime(tLista.Rows[i][5]);
                    Trabajador.FechaInicio = Convert.ToDateTime(tLista.Rows[i][6]);
                    Trabajador.Planilla = tLista.Rows[i][7].ToString();

                    miTrabajador = miTrabajador.traerTrabajador(Trabajador.Id_trabajador);
                    Trabajador.DatosPersonales = TraerDatosPersonales(miTrabajador);
                    //Trabajador.DatosPersonales.NumeroDocumento = Trabajador.DNI;
                    //Trabajador.DatosPersonales.Nombres = Trabajador.Nombres;
                    //Trabajador.DatosPersonales.ApellidoPaterno = Trabajador.ApellidoPaterno;
                    //Trabajador.DatosPersonales.ApellidoMaterno = Trabajador.ApellidoMaterno;
                    //Trabajador.DatosPersonales.FechaNacimiento = Trabajador.FechaNacimiento;
                    //Trabajador.DatosPersonales.Sexo = 
                    Lista.Add(Trabajador);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo TraerListaTrabajadoresTRegistro: " + ex.Message);
            }
        }

        private cDatosPersonales TraerDatosPersonales(cTrabajador oTrabajador)
        {
            cDatosPersonales datos = new cDatosPersonales();
            datos.TipoDocumento.Numero = "01";
            datos.TipoDocumento.Descripcion = "DOCUMENTO NACIONAL DE IDENTIDAD";
            datos.TipoDocumento.DescripcionAbreviadad = "DNI";
            datos.NumeroDocumento = oTrabajador.Dni;
            datos.Nombres = oTrabajador.Nombres;
            datos.ApellidoPaterno = oTrabajador.ApellidoPaterno;
            datos.ApellidoMaterno = oTrabajador.ApellidoMaterno;
            datos.FechaNacimiento = oTrabajador.FechaNacimiento;
            datos.Sexo = TraerSexo(oTrabajador.Sexo);
            datos.Nacionalidad = TraerNacionalidad(oTrabajador.MiNacionalidad);
            datos.TelefonoCodigoLargaDistancia = "";
            datos.Telefono = oTrabajador.CelularPersonal;
            datos.CorreoElectronico = oTrabajador.CorreoElectronico;
            datos.Direccion01 = TraerDireccion(oTrabajador);
            datos.Direccion02 = TraerDireccion2();
            datos.IndicadorEssalud = "";

            return datos;
        }

        private TablasParametricas.cSexo TraerSexo(EnumSexo sexo)
        {
            TablasParametricas.cSexo se = new TablasParametricas.cSexo();
            switch (sexo)
            {
                case EnumSexo.Masculino:
                    se.Codigo = "1";
                    se.Sexo = "Masculino";
                    break;
                case EnumSexo.Femenino:
                    se.Codigo = "2";
                    se.Sexo = "Femenino";
                    break;
                default:
                    break;
            }

            return se;
        }

        private TablasParametricas.cNacionalidad TraerNacionalidad(cNacionalidad nacionalidad)
        {
            TablasParametricas.cNacionalidad Nacio = new TablasParametricas.cNacionalidad();
            Nacio.Descripcion = nacionalidad.Descripcion;
            Nacio.Numero = nacionalidad.CodigoSunat;
            return Nacio;
        }

        private cDireccion TraerDireccion(cTrabajador oTrabajador)
        {
            cDireccion oDireccion = new cDireccion();
            oDireccion.TipoVia = TraerTipoVia(oTrabajador);
            oDireccion.NombreVia = oTrabajador.NombreVia;
            oDireccion.NumeroVia = oTrabajador.NumeroVia;
            oDireccion.Departamento = "";
            oDireccion.Interior = oTrabajador.DepartamentoInterior;
            oDireccion.Manzana = "";
            oDireccion.Lote = "";
            oDireccion.Kilometro = "";
            oDireccion.Bloque = "";
            oDireccion.Etapa = "";
            oDireccion.TipoZona = TraerTipoZona(oTrabajador);
            oDireccion.NombreZona = oTrabajador.NombreZona;
            oDireccion.Referencia = oTrabajador.Referencia;
            oDireccion.Distrito = oTrabajador.MiDistrito;
            return oDireccion;
        }

        private cDireccion TraerDireccion2()
        {
            cDireccion oDireccion = new cDireccion();
            oDireccion.TipoVia = new TablasParametricas.cTipoVia();
            oDireccion.TipoVia.Numero = "";
            oDireccion.NombreVia = "";
            oDireccion.NumeroVia = "";
            oDireccion.Departamento = "";
            oDireccion.Interior = "";
            oDireccion.Manzana = "";
            oDireccion.Lote = "";
            oDireccion.Kilometro = "";
            oDireccion.Bloque = "";
            oDireccion.Etapa = "";
            oDireccion.TipoZona = new TablasParametricas.cTipoZona();
            oDireccion.TipoZona.Numero = "";
            oDireccion.NombreZona = "";
            oDireccion.Referencia = "";
            oDireccion.Distrito = new cDistrito();
            oDireccion.Distrito.CodigoUbigeo = "";
            return oDireccion;
        }

        private TablasParametricas.cTipoVia TraerTipoVia(cTrabajador oTrabajador)
        {
            TablasParametricas.cTipoVia oTipoVia = new TablasParametricas.cTipoVia();
            oTipoVia.Descripcion = oTrabajador.MiTipoVia.Descripcion;
            oTipoVia.Numero = oTrabajador.MiTipoVia.CodigoSunat;
            return oTipoVia;
        }

        private TablasParametricas.cTipoZona TraerTipoZona(cTrabajador oTrabajador)
        {
            TablasParametricas.cTipoZona oTipoZOna = new TablasParametricas.cTipoZona();
            oTipoZOna.Descripcion = oTrabajador.MiTipoZOna.Descripcion;
            oTipoZOna.Numero = oTrabajador.MiTipoZOna.CodigoSunat;
            return oTipoZOna;
        }

        public List<Tregistro.cFilarDatosJor> TraerArchivoJOR(List<cTrabajadorAltaTRegistro> ListaTrabajadores)
        {
            try
            {
                List<Tregistro.cFilarDatosJor> Lista = new List<cFilarDatosJor>();
                int contador = 0;
                foreach (cTrabajadorAltaTRegistro item in ListaTrabajadores)
                {
                    Tregistro.cFilarDatosJor tra = new cFilarDatosJor();
                    contador++;
                    tra.Numero = contador;
                    tra.TipoDocumento = item.DatosPersonales.TipoDocumento.DescripcionAbreviadad + Environment.NewLine + item.DatosPersonales.TipoDocumento.Numero;
                    tra.NumeroDocumento = item.DatosPersonales.NumeroDocumento;
                    tra.Nombres = item.DatosPersonales.Nombres;
                    tra.ApellidoPaterno = item.DatosPersonales.ApellidoPaterno;
                    tra.ApellidoMaterno = item.DatosPersonales.ApellidoMaterno;
                    tra.FechaNacimiento = item.DatosPersonales.FechaNacimiento.ToShortDateString();
                    tra.Sexo = item.DatosPersonales.Sexo.Sexo;
                    tra.Nacionalidad = item.DatosPersonales.Nacionalidad.Descripcion + Environment.NewLine + item.DatosPersonales.Nacionalidad.Numero;
                    tra.TelefonoCodigoLargaDistancia = item.DatosPersonales.TelefonoCodigoLargaDistancia;
                    tra.Telefono = item.DatosPersonales.Telefono;
                    tra.CorreoElectronico = item.DatosPersonales.CorreoElectronico;
                    tra.Direccion01_Tipovia = item.DatosPersonales.Direccion01.TipoVia.Descripcion + Environment.NewLine + item.DatosPersonales.Direccion01.TipoVia.Numero;
                    tra.Direccion01_Nombrevia = item.DatosPersonales.Direccion01.NombreVia;
                    tra.Direccion01_Numerovia = item.DatosPersonales.Direccion01.NumeroVia;
                    tra.Direccion01_Departamento = item.DatosPersonales.Direccion01.Departamento;
                    tra.Direccion01_Interior = item.DatosPersonales.Direccion01.Interior;
                    tra.Direccion01_Manzana = item.DatosPersonales.Direccion01.Manzana;
                    tra.Direccion01_Lote = item.DatosPersonales.Direccion01.Lote;
                    tra.Direccion01_Kilometro = item.DatosPersonales.Direccion01.Kilometro;
                    tra.Direccion01_Bloque = item.DatosPersonales.Direccion01.Bloque;
                    tra.Direccion01_Etapa = item.DatosPersonales.Direccion01.Etapa;
                    tra.Direccion01_Tipozona = item.DatosPersonales.Direccion01.TipoZona.Descripcion + Environment.NewLine + item.DatosPersonales.Direccion01.TipoZona.Numero;
                    tra.Direccion01_Nombrezona = item.DatosPersonales.Direccion01.NombreZona;
                    tra.Direccion01_Referencia = item.DatosPersonales.Direccion01.Referencia;
                    tra.Direccion01_Ubigeo = item.DatosPersonales.Direccion01.Distrito.Descripcion + Environment.NewLine + item.DatosPersonales.Direccion01.Distrito.CodigoUbigeo;
                    tra.Direccion02_Tipovia = item.DatosPersonales.Direccion02.TipoVia.Descripcion + Environment.NewLine + item.DatosPersonales.Direccion02.TipoVia.Numero;
                    tra.Direccion02_Nombrevia = item.DatosPersonales.Direccion02.NombreVia;
                    tra.Direccion02_Numerovia = item.DatosPersonales.Direccion02.NumeroVia;
                    tra.Direccion02_Departamento = item.DatosPersonales.Direccion02.Departamento;
                    tra.Direccion02_Interior = item.DatosPersonales.Direccion02.Interior;
                    tra.Direccion02_Manzana = item.DatosPersonales.Direccion02.Manzana;
                    tra.Direccion02_Lote = item.DatosPersonales.Direccion02.Lote;
                    tra.Direccion02_Kilometro = item.DatosPersonales.Direccion02.Kilometro;
                    tra.Direccion02_Bloque = item.DatosPersonales.Direccion02.Bloque;
                    tra.Direccion02_Etapa = item.DatosPersonales.Direccion02.Etapa;
                    tra.Direccion02_Tipozona = item.DatosPersonales.Direccion02.TipoZona.Descripcion + Environment.NewLine + item.DatosPersonales.Direccion02.TipoZona.Numero;
                    tra.Direccion02_Nombrezona = item.DatosPersonales.Direccion02.NombreZona;
                    tra.IndicarSalud = item.DatosPersonales.IndicadorEssalud;


                    Lista.Add(tra);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo TraerArchivoJOR: " + ex.Message);
            }
        }
    }
}
