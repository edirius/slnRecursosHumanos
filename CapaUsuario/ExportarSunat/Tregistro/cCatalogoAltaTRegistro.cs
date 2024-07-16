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
    }
}
