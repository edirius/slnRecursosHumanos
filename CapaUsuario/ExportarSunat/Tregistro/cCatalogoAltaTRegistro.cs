using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeNegocios;
using CapaDeDatos;
using System.Data;
using CapaDeNegocios.DatosLaborales;
using System.Collections;

namespace CapaUsuario.ExportarSunat.Tregistro
{
    public class cCatalogoAltaTRegistro
    {
        public cTrabajador miTrabajador = new cTrabajador();
        public string RUC;
        CapaDeNegocios.Utilidades.cUtilidades miUtilidades = new CapaDeNegocios.Utilidades.cUtilidades();

        public cCatalogoAltaTRegistro(string ruc)
        {
            RUC = ruc;
        }

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
                    Trabajador.PeriodoTrabajador.IdtPeriodoTrabajador = Convert.ToInt32(tLista.Rows[i][8].ToString());
                    miTrabajador = miTrabajador.traerTrabajador(Trabajador.Id_trabajador);
                    Trabajador.DatosPersonales = TraerDatosPersonales(miTrabajador);
                    cRegimenPensionarioTrabajador regimen = new cRegimenPensionarioTrabajador();
                    regimen.IdtRegimenPensionarioTrabajador = Convert.ToInt32(tLista.Rows[i][9].ToString());
                    regimen.CUSPP = tLista.Rows[i][10].ToString();
                    regimen.Afp = new cAFP();
                    regimen.Afp.CodigoAFP = Convert.ToInt32(tLista.Rows[i][11].ToString());
                    regimen.Afp.Nombre = tLista.Rows[i][12].ToString();
                    regimen.Afp.Codigosunat = tLista.Rows[i][13].ToString();
                    Trabajador.PeriodosRegimenPensionario.Add(regimen);
                    Trabajador.DatosTrabajador = TraerDatosTrabajador(Trabajador, new DateTime(Convert.ToInt32(año), miUtilidades.ConvertirMesANumero(mes), 1));
                    Trabajador.RegimenTrabajador.IdtRegimenTrabajador = Convert.ToInt32( tLista.Rows[i][14].ToString());
                    if (Trabajador.DatosTrabajador.Count == 0)
                    {
                        throw new cReglaNegociosException("Error al traer los datos del trabajador del trabajador: " + Trabajador.DNI + " " + Trabajador.Nombres + " " + Trabajador.ApellidoPaterno + " " + Trabajador.ApellidoMaterno + " y el mes " + mes);
                    }
                    Trabajador.DatosPeriodo = TraerDatosPeriodo(Trabajador, new DateTime(Convert.ToInt32(año), miUtilidades.ConvertirMesANumero(mes),1));
                    //Trabajador.DatosPersonales.NumeroDocumento = Trabajador.DNI;
                    //Trabajador.DatosPersonales.Nombres = Trabajador.Nombres;
                    //Trabajador.DatosPersonales.ApellidoPaterno = Trabajador.ApellidoPaterno;
                    //Trabajador.DatosPersonales.ApellidoMaterno = Trabajador.ApellidoMaterno;
                    //Trabajador.DatosPersonales.FechaNacimiento = Trabajador.FechaNacimiento;
                    //Trabajador.DatosPersonales.Sexo = 
                    Trabajador.Observaciones = VerificarObservaciones(Trabajador);
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
            datos.PaisEmisor.Codigo = "604";
            datos.PaisEmisor.Descripcion = "Peru";
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
            datos.IndicadorEssalud = "1";

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
            if (oTrabajador.NumeroVia == "")
            {
                oDireccion.NumeroVia = "0";
            }
            
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
                    tra.TipoDocumento = item.DatosPersonales.TipoDocumento.Numero + " - " + item.DatosPersonales.TipoDocumento.DescripcionAbreviadad;
                    tra.NumeroDocumento = item.DatosPersonales.NumeroDocumento;
                    tra.Nombres = item.DatosPersonales.Nombres;
                    tra.ApellidoPaterno = item.DatosPersonales.ApellidoPaterno;
                    tra.ApellidoMaterno = item.DatosPersonales.ApellidoMaterno;
                    tra.FechaNacimiento = item.DatosPersonales.FechaNacimiento.ToShortDateString();
                    tra.Sexo = item.DatosPersonales.Sexo.Sexo;
                    tra.Nacionalidad = item.DatosPersonales.Nacionalidad.Numero + " - " + item.DatosPersonales.Nacionalidad.Descripcion;
                    tra.TelefonoCodigoLargaDistancia = item.DatosPersonales.TelefonoCodigoLargaDistancia;
                    tra.Telefono = item.DatosPersonales.Telefono;
                    tra.CorreoElectronico = item.DatosPersonales.CorreoElectronico;
                    tra.Direccion01_Tipovia = item.DatosPersonales.Direccion01.TipoVia.Numero + " - " + item.DatosPersonales.Direccion01.TipoVia.Descripcion;
                    tra.Direccion01_Nombrevia = item.DatosPersonales.Direccion01.NombreVia;
                    tra.Direccion01_Numerovia = item.DatosPersonales.Direccion01.NumeroVia;
                    tra.Direccion01_Departamento = item.DatosPersonales.Direccion01.Departamento;
                    tra.Direccion01_Interior = item.DatosPersonales.Direccion01.Interior;
                    tra.Direccion01_Manzana = item.DatosPersonales.Direccion01.Manzana;
                    tra.Direccion01_Lote = item.DatosPersonales.Direccion01.Lote;
                    tra.Direccion01_Kilometro = item.DatosPersonales.Direccion01.Kilometro;
                    tra.Direccion01_Bloque = item.DatosPersonales.Direccion01.Bloque;
                    tra.Direccion01_Etapa = item.DatosPersonales.Direccion01.Etapa;
                    tra.Direccion01_Tipozona = item.DatosPersonales.Direccion01.TipoZona.Numero + " - " + item.DatosPersonales.Direccion01.TipoZona.Descripcion;
                    tra.Direccion01_Nombrezona = item.DatosPersonales.Direccion01.NombreZona;
                    tra.Direccion01_Referencia = item.DatosPersonales.Direccion01.Referencia;
                    tra.Direccion01_Ubigeo = item.DatosPersonales.Direccion01.Distrito.CodigoUbigeo + " - " + item.DatosPersonales.Direccion01.Distrito.Descripcion;
                    tra.Direccion02_Tipovia = item.DatosPersonales.Direccion02.TipoVia.Numero + " - " + item.DatosPersonales.Direccion02.TipoVia.Descripcion;
                    tra.Direccion02_Nombrevia = item.DatosPersonales.Direccion02.NombreVia;
                    tra.Direccion02_Numerovia = item.DatosPersonales.Direccion02.NumeroVia;
                    tra.Direccion02_Departamento = item.DatosPersonales.Direccion02.Departamento;
                    tra.Direccion02_Interior = item.DatosPersonales.Direccion02.Interior;
                    tra.Direccion02_Manzana = item.DatosPersonales.Direccion02.Manzana;
                    tra.Direccion02_Lote = item.DatosPersonales.Direccion02.Lote;
                    tra.Direccion02_Kilometro = item.DatosPersonales.Direccion02.Kilometro;
                    tra.Direccion02_Bloque = item.DatosPersonales.Direccion02.Bloque;
                    tra.Direccion02_Etapa = item.DatosPersonales.Direccion02.Etapa;
                    tra.Direccion02_Tipozona = item.DatosPersonales.Direccion02.TipoZona.Numero + " - " + item.DatosPersonales.Direccion02.TipoZona.Descripcion;
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

        public List<cDatosTrabajador> TraerDatosTrabajador(cTrabajadorAltaTRegistro Trabajador, DateTime mes)
        {
            try
            {
                List<cDatosTrabajador> Lista = new List<cDatosTrabajador>();
                cRegimenTrabajador oRegimen = new cRegimenTrabajador();
                List<cRegimenTrabajador> RegimenesTrabajador = oRegimen.TraerRegimenTrabajadorMes(Trabajador.PeriodoTrabajador.IdtPeriodoTrabajador, mes);
                foreach (cRegimenTrabajador item in RegimenesTrabajador)
                {
                    cDatosTrabajador DatosRegimen = new cDatosTrabajador();
                    DatosRegimen.TipoDocumento = Trabajador.DatosPersonales.TipoDocumento;
                    DatosRegimen.NumeroDocumento = Trabajador.DatosPersonales.NumeroDocumento;
                    DatosRegimen.PaisEmisor = Trabajador.DatosPersonales.PaisEmisor;
                    DatosRegimen.RegimenLaboral = TraerRegimenLaboral(item.IdtRegimenLaboral);
                    DatosRegimen.SituacionEducativa = TraerSituacionEducativa("07");
                    DatosRegimen.Ocupacion = TraerOcupacion(item.IdtOcupacion);
                    DatosRegimen.Discapacidad = "0";
                    DatosRegimen.CUSPP = "";
                    //1 PARA ONP, 2 PARA PRIVADA PENSION, VACIO PARA NINGUNO
                    DatosRegimen.SCRTPension = "";
                    DatosRegimen.TipoContrato = TraerTipoContrato(item.IdtTipoContrato);
                    DatosRegimen.SujetoARegimenAlternativo = "0";
                    DatosRegimen.SujetoAJornadaMaxima = "0";
                    DatosRegimen.SujetoAHorarioNocturno = "0";
                    DatosRegimen.EsSindicalizado = "0";
                    DatosRegimen.PeriodicidadIngreso = TraerPeriocidadIngreso(item.Periodicidad);
                    DatosRegimen.MontoBasico = 0;
                    DatosRegimen.Situacion = TraerSituacion("1");
                    DatosRegimen.TipoTrabajador = TraerTipoTrabajador(item.IdtTipoTrabajador);
                    //Para los TT: 23, 66, 67 y 71 es vacio.
                    if (DatosRegimen.TipoTrabajador.Numero == "23" || DatosRegimen.TipoTrabajador.Numero == "66" || DatosRegimen.TipoTrabajador.Numero == "67" || DatosRegimen.TipoTrabajador.Numero == "71")
                    {
                        DatosRegimen.RentaQuintaExonerada = "";
                    }
                    else
                    {
                        DatosRegimen.RentaQuintaExonerada = "0";
                    }
                    DatosRegimen.SituacionEspecialTrabajador = TraerSituacionEspecialTrabajador("0");
                    DatosRegimen.TipoPago = TraerTipoPago(item.TipoPago);
                    //Para el TT: 20 OBRERO, se debe colocar vacio la categoria ocupacional
                    if (DatosRegimen.TipoTrabajador.Numero == "20")
                    {
                        DatosRegimen.CategoriaOcupacionalTrabajador = new TablasParametricas.cCategoriaOcupacionalTrabajador();
                        DatosRegimen.CategoriaOcupacionalTrabajador.Codigo = "";
                    }
                    else
                    {
                        DatosRegimen.CategoriaOcupacionalTrabajador = TraerCategoriaOcupacional(item.IdtCategoriaOcupacional);
                    }
                    
                    // PARA LOS TIPOS 19, 20, 21, 23, 66 71, 88, 89, 90, 91 y 98. ES VACIO
                    if (DatosRegimen.TipoTrabajador.Numero == "23" || DatosRegimen.TipoTrabajador.Numero == "66" || DatosRegimen.TipoTrabajador.Numero == "67" || DatosRegimen.TipoTrabajador.Numero == "71")
                    {
                        DatosRegimen.ConvenioParaEvitarDobleTri = "";
                    }
                    else
                    {
                        DatosRegimen.ConvenioParaEvitarDobleTri = "0";
                    }
                    
                    //Dato interno del programa
                    DatosRegimen.Cargo = TraerCargo(item.IdtCargo);
                    if (DatosRegimen.RegimenLaboral.Codigo == "15" )
                    {
                        DatosRegimen.RUC = item.RUC;
                    }
                    else
                    {
                        DatosRegimen.RUC = "";
                    }
                    
                    
                    Lista.Add(DatosRegimen);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo TraerDatosTrabajador: " + ex.Message);
            }
        }

        private string VerificarObservaciones(cTrabajadorAltaTRegistro tra)
        {
            string obs="";
            //CODIGO 15 = CAS
            if (tra.DatosTrabajador[0].RegimenLaboral.Codigo == "15")
            {
                if (tra.DatosTrabajador[0].TipoContrato.Numero != "14")
                {
                    obs = obs + " - Error en el tipo de contrato para CAS" + Environment.NewLine;
                }

                if (tra.DatosTrabajador[0].TipoTrabajador.Numero != "67")
                {
                    obs = obs + " - Para el regimen Cas  el tipo de trabajador no corresponde " + Environment.NewLine;
                }
                if (tra.DatosTrabajador[0].RUC == "")
                {
                    obs = obs + " - Para el regimen Cas se necesita ingresar RUC" + Environment.NewLine;
                }
            }

            if (tra.DatosTrabajador[0].TipoTrabajador.Numero == "87")
            {
                if (tra.DatosTrabajador[0].CategoriaOcupacionalTrabajador.Codigo == "02")
                {
                    obs = obs + " - Hay inconsistencia entre el tipo de trabajador y la categoria ocupacional" + Environment.NewLine;
                }
            }

            return obs;
        }

        public TablasParametricas.cRegimenLaboral TraerRegimenLaboral(int idtRegimenLaboral)
        {
            CapaDeNegocios.DatosLaborales.cRegimenLaboral oRegimen = new cRegimenLaboral();
            TablasParametricas.cRegimenLaboral TablaRegimenLaboral = new TablasParametricas.cRegimenLaboral();
            oRegimen=  oRegimen.TraerRegimenLaboral(idtRegimenLaboral);
            TablaRegimenLaboral.Codigo = oRegimen.Codigo;
            TablaRegimenLaboral.Descripcion = oRegimen.Descripcion;
            TablaRegimenLaboral.DescripcionAbreviada = oRegimen.Descripcion;
            return TablaRegimenLaboral;
        }

        public TablasParametricas.cOcupacion TraerOcupacion(int idtocupacion)
        {
            CapaDeNegocios.DatosLaborales.cOcupacion oOcupacion = new cOcupacion();
            oOcupacion = oOcupacion.TraerOcupacion(idtocupacion);
            TablasParametricas.cOcupacion ocu = new TablasParametricas.cOcupacion();
            ocu.Codigo = oOcupacion.Codigo;
            ocu.Nombre = oOcupacion.Descripcion;
            return ocu;
        }

        public TablasParametricas.cSituacionEducativa TraerSituacionEducativa(string codigo)
        {
            TablasParametricas.cSituacionEducativa edu = new TablasParametricas.cSituacionEducativa();
            switch (codigo)
            {
                case "07":
                    edu.Descripcion = "EDUCACIÓN SECUNDARIA COMPLETA";
                    edu.DescripcionAbreviada = "SECUNDARIA COMPLETA";
                    edu.Numero = "07";
                    break;
                default:
                    break;
            }

            return edu;
        }

        public TablasParametricas.cTipoContrato TraerTipoContrato(int idtTipoContrato)
        {
            CapaDeNegocios.DatosLaborales.cTipoContrato oTipoContrato = new cTipoContrato();
            oTipoContrato = oTipoContrato.TraerTipoContrato(idtTipoContrato);
            TablasParametricas.cTipoContrato tipo = new TablasParametricas.cTipoContrato();
            tipo.Numero = oTipoContrato.CodigoSunat;
            tipo.Descripcion = oTipoContrato.Descripcion;

            return tipo;
        }

        public TablasParametricas.cPeriodicidadIngreso TraerPeriocidadIngreso(string periodicidad)
        {
            TablasParametricas.cPeriodicidadIngreso per = new TablasParametricas.cPeriodicidadIngreso();
            switch (periodicidad)
            {
                case "MENSUAL":
                    {
                        per.Descripcion = "MENSUAL";
                        per.Numero = "1";
                        break;
                    }
                case "QUINCENAL":
                    {
                        per.Descripcion = "QUINCENAL";
                        per.Numero = "2";
                        break;
                    }
                case "SEMANAL":
                    {
                        per.Descripcion = "SEMANAL";
                        per.Numero = "3";
                        break;
                    }
                case "DIARIA":
                    {
                        per.Descripcion = "DIARIA";
                        per.Numero = "4";
                        break;
                    }
                case "OTROS":
                    {
                        per.Descripcion = "OTROS";
                        per.Numero = "5";
                        break;
                    }
            }

            return per;
        }

        public TablasParametricas.cSituacion TraerSituacion(string idSituacion)
        {
            TablasParametricas.cSituacion sit = new TablasParametricas.cSituacion();
            switch (idSituacion)
            {
                case "0":
                    sit.Descripcion = "BAJA";
                    sit.DescripcionAbreviada = "BAJA";
                    sit.Numero = "0";
                    break;
                case "1":
                    sit.Descripcion = "ACTIVO O SUBSIDIADO";
                    sit.DescripcionAbreviada = "ACTIVO O SUBSIDIADO";
                    sit.Numero = "1";
                    break;
                case "2":
                    sit.Descripcion = "SIN VÍNCULO LABORAL CON CONCEPTOS PENDIENTE DE LIQUIDAR";
                    sit.DescripcionAbreviada = "SIN VINC. LAB. CON CONC PEND POR LIQUIDAR";
                    sit.Numero = "2";
                    break;
                case "3":
                    sit.Descripcion = "SUSPENSIÓN PERFECTA DE LABORES";
                    sit.DescripcionAbreviada = "SUSPENSIÓN PERFECTA DE LABORES";
                    sit.Numero = "3";
                    break;
                default:
                    break;
            }
            return sit; 
        }

        public TablasParametricas.cSituacionEspecialTrabajador TraerSituacionEspecialTrabajador(string idtSituacionEspecialTrabajador)
        {
            TablasParametricas.cSituacionEspecialTrabajador esp = new TablasParametricas.cSituacionEspecialTrabajador();
            switch (idtSituacionEspecialTrabajador)
            {
                case "0":
                    esp.Descripcion = "NINGUNA";
                    esp.DescripcionAbreviada = "NINGUNA";
                    esp.Numero = "0";
                    break;
                case "1":
                    esp.Descripcion = "TRABAJADOR DE DIRECCIÓN – PRESENCIAL";
                    esp.DescripcionAbreviada = "DIRECCIÓN – PRESENCIAL";
                    esp.Numero = "1";
                    break;
                case "2":
                    esp.Descripcion = "TRABAJADOR DE CONFIANZA - PRESENCIAL";
                    esp.DescripcionAbreviada = "CONFIANZA - PRESENCIAL";
                    esp.Numero = "2";
                    break;
                case "3":
                    esp.Descripcion = "TRABAJADOR DE DIRECCIÓN - TELETRABAJO MIXTO";
                    esp.DescripcionAbreviada = "DIRECCIÓN - TELETRABAJO MIXTO";
                    esp.Numero = "3";
                    break;
                case "4":
                    esp.Descripcion = "TRABAJADOR DE CONFIANZA - TELETRABAJO MIXTO";
                    esp.DescripcionAbreviada = "CONFIANZA - TELETRABAJO MIXTO";
                    esp.Numero = "4";
                    break;
                case "5":
                    esp.Descripcion = "TRABAJADOR DE DIRECCIÓN - TELETRABAJO COMPLETO";
                    esp.DescripcionAbreviada = "DIRECCIÓN - TELETRABAJO COMPLETO";
                    esp.Numero = "5";
                    break;
                case "6":
                    esp.Descripcion = "TRABAJADOR DE CONFIANZA - TELETRABAJO COMPLETO";
                    esp.DescripcionAbreviada = "CONFIANZA - TELETRABAJO COMPLETO";
                    esp.Numero = "6";
                    break;
                case "7":
                    esp.Descripcion = "TELETRABAJO MIXTO";
                    esp.DescripcionAbreviada = "TELETRABAJO MIXTO";
                    esp.Numero = "7";
                    break;
                case "8":
                    esp.Descripcion = "TELETRABAJO COMPLETO";
                    esp.DescripcionAbreviada = "TELETRABAJO COMPLETO";
                    esp.Numero = "8";
                    break;
                default:
                    break;
            }

            return esp;
        }

        public TablasParametricas.cTipoPago TraerTipoPago(string TipoPago)
        {
            TablasParametricas.cTipoPago tipo = new TablasParametricas.cTipoPago();
            switch (TipoPago)
            {
                case "EFECTIVO":
                    {
                        tipo.Descripcion = "EFECTIVO";
                        tipo.Numero = "1";
                        break;
                    }
                case "DEPOSITO":
                    {
                        tipo.Descripcion = "DEPOSITO EN CUENTA";
                        tipo.Numero = "2";
                        break;
                    }
                case "OTROS":
                    {
                        tipo.Descripcion = "OTROS";
                        tipo.Numero = "3";
                        break;
                    }
                default:
                    break;
            }
            return tipo;
        }

        public TablasParametricas.cCategoriaOcupacionalTrabajador TraerCategoriaOcupacional(int idtCategoria)
        {
            TablasParametricas.cCategoriaOcupacionalTrabajador cat = new TablasParametricas.cCategoriaOcupacionalTrabajador();
            CapaDeNegocios.DatosLaborales.cCategoriaOcupacional oCategoriaOcupacional = new cCategoriaOcupacional();
            oCategoriaOcupacional = oCategoriaOcupacional.TraerCategoriaOcupacional(idtCategoria);

            cat.Codigo = oCategoriaOcupacional.Codigo;
            cat.Descripcion = oCategoriaOcupacional.Descripcion;
            return cat;
        }
        public TablasParametricas.cCargo TraerCargo(int idtcargo)
        {
            TablasParametricas.cCargo car = new TablasParametricas.cCargo();
            CapaDeNegocios.DatosLaborales.cCargo cargo = new cCargo();
            cargo = cargo.TraerCargoPorXcodigo(idtcargo);

            car.IdtCargo = cargo.IdtCargo;
            car.Descripcion = cargo.Descripcion;

            return car;
        }

        public List<Tregistro.cFilaDatosTra> TraerArchivoTRA(List<cTrabajadorAltaTRegistro> ListaTrabajadores, DateTime Mes)
        {
            cCatalogoAltaTRegistro oCatalogo = new cCatalogoAltaTRegistro(RUC);
            try
            {
                List<Tregistro.cFilaDatosTra> Lista = new List<cFilaDatosTra>();
                int contador = 0;
                foreach (cTrabajadorAltaTRegistro item in ListaTrabajadores)
                {
                    //item.DatosTrabajador = oCatalogo.TraerDatosTrabajador(item, Mes);
                    foreach (cDatosTrabajador item2 in item.DatosTrabajador)
                    {
                        cFilaDatosTra tra = new cFilaDatosTra();
                        contador++;
                        tra.Numero = contador;
                        tra.TipoDocumento = item2.TipoDocumento.Numero + " - " + item2.TipoDocumento.DescripcionAbreviadad;
                        tra.NumeroDocumento = item2.NumeroDocumento;
                        tra.PaisEmisorDocumento = item2.PaisEmisor.Codigo + " - " + item2.PaisEmisor.Descripcion;
                        tra.RegimenLaboral = item2.RegimenLaboral.Codigo + " - " + item2.RegimenLaboral.DescripcionAbreviada;
                        tra.SituacionEducativa = item2.SituacionEducativa.Numero + " - " + item2.SituacionEducativa.DescripcionAbreviada;
                        tra.Ocupacion = item2.Ocupacion.Codigo + " - " + item2.Ocupacion.Nombre;
                        tra.Discapacidad = item2.Discapacidad;
                        tra.CUSPP = item2.CUSPP;
                        tra.SCRTPension = item2.SCRTPension;
                        tra.TipoContrato = item2.TipoContrato.Numero + " - " + item2.TipoContrato.DescripcionAbreviada;
                        tra.SujetoARegimenAcumulativo = item2.SujetoARegimenAlternativo;
                        tra.SujetoAjornadaMaxima = item2.SujetoAJornadaMaxima;
                        tra.SujetoAHorarioNocturno = item2.SujetoAHorarioNocturno;
                        tra.EsSindicalizado = item2.EsSindicalizado;
                        tra.PeriocidadRemuneracion = item2.PeriodicidadIngreso.Numero + " - " + item2.PeriodicidadIngreso.Descripcion; ;
                        tra.MontoBasicoRemuneracion = item2.MontoBasico.ToString();
                        tra.Situacion = item2.Situacion.Numero + " - " + item2.Situacion.DescripcionAbreviada; ;
                        tra.RentaQuintaExoneradas = item2.RentaQuintaExonerada;
                        tra.SituacionEspecialTrabajador = item2.SituacionEspecialTrabajador.Numero + " - " + item2.SituacionEspecialTrabajador.DescripcionAbreviada;
                        tra.TipoPago = item2.TipoPago.Numero + " - " + item2.TipoPago.Descripcion;
                        tra.CategoriaOcupacionalTrabajador = item2.CategoriaOcupacionalTrabajador.Codigo + " - " + item2.CategoriaOcupacionalTrabajador.Descripcion;
                        tra.ConvenioEvitarDobleTributacion = item2.ConvenioParaEvitarDobleTri;
                        tra.RUC = item2.RUC;
                        Lista.Add(tra);
                    }
                    
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo TraerArchivoTRA: " + ex.Message);
            }
        }

        public List<cDatosPeriodo> TraerDatosPeriodo(cTrabajadorAltaTRegistro Trabajador, DateTime mes)
        {
            List<cDatosPeriodo> ListaPeriodos = new List<cDatosPeriodo>();

            cDatosPeriodo Periodo1 = new cDatosPeriodo();
            Periodo1.TipoDocumento = Trabajador.DatosPersonales.TipoDocumento;
            Periodo1.NumeroDocumento = Trabajador.DatosPersonales.NumeroDocumento;
            Periodo1.PaisEmisor = Trabajador.DatosPersonales.PaisEmisor;
            Periodo1.Categoria = enumCategoria.Trabajador;
            Periodo1.TipoRegistro = enumTipoRegistro.Periodo;
            Periodo1.FechaInicio = Trabajador.FechaInicio.ToShortDateString();
            Periodo1.FechaFin = "";
            Periodo1.MotivoFinPeriodo = new TablasParametricas.cMotivoBaja();
            Periodo1.MotivoFinPeriodo.Numero = "";
            Periodo1.EntidadesPrestadorasSalud = new TablasParametricas.cEntidadesPrestadorasSalud();
            Periodo1.EntidadesPrestadorasSalud.Numero = "";
            ListaPeriodos.Add(Periodo1);

            cDatosPeriodo Periodo2 = new cDatosPeriodo();
            Periodo2.TipoDocumento = Trabajador.DatosPersonales.TipoDocumento;
            Periodo2.NumeroDocumento = Trabajador.DatosPersonales.NumeroDocumento;
            Periodo2.PaisEmisor = Trabajador.DatosPersonales.PaisEmisor;
            Periodo2.Categoria = enumCategoria.Trabajador;
            Periodo2.TipoRegistro = enumTipoRegistro.TipoTrabajador;
            Periodo2.FechaInicio = Trabajador.FechaInicio.ToShortDateString();
            Periodo2.FechaFin = "";
            Periodo2.TipoTrabajador = Trabajador.DatosTrabajador[0].TipoTrabajador;
            Periodo2.EntidadesPrestadorasSalud = new TablasParametricas.cEntidadesPrestadorasSalud();
            Periodo2.EntidadesPrestadorasSalud.Numero = "";
            ListaPeriodos.Add(Periodo2);

            cDatosPeriodo Periodo3 = new cDatosPeriodo();
            Periodo3.TipoDocumento = Trabajador.DatosPersonales.TipoDocumento;
            Periodo3.NumeroDocumento = Trabajador.DatosPersonales.NumeroDocumento;
            Periodo3.PaisEmisor = Trabajador.DatosPersonales.PaisEmisor;
            Periodo3.Categoria = enumCategoria.Trabajador;
            Periodo3.TipoRegistro = enumTipoRegistro.RegimenSalud;
            Periodo3.FechaInicio = Trabajador.FechaInicio.ToShortDateString();
            Periodo3.FechaFin = "";
            Periodo3.RegimenSalud = TraerRegimenSalud();
            Periodo3.EntidadesPrestadorasSalud = new TablasParametricas.cEntidadesPrestadorasSalud();
            Periodo3.EntidadesPrestadorasSalud.Numero = "";
            ListaPeriodos.Add(Periodo3);

            cDatosPeriodo Periodo4 = new cDatosPeriodo();
            Periodo4.TipoDocumento = Trabajador.DatosPersonales.TipoDocumento;
            Periodo4.NumeroDocumento = Trabajador.DatosPersonales.NumeroDocumento;
            Periodo4.PaisEmisor = Trabajador.DatosPersonales.PaisEmisor;
            Periodo4.Categoria = enumCategoria.Trabajador;
            Periodo4.TipoRegistro = enumTipoRegistro.RegimenPensionario;
            Periodo4.FechaInicio = Trabajador.FechaInicio.ToShortDateString();
            Periodo4.FechaFin = "";
            Periodo4.RegimenPensionario = TraerRegimenPensionario(Trabajador);
            Periodo4.EntidadesPrestadorasSalud = new TablasParametricas.cEntidadesPrestadorasSalud();
            Periodo4.EntidadesPrestadorasSalud.Numero = "";
            ListaPeriodos.Add(Periodo4);

            if (Trabajador.TieneScrt)
            {
                cDatosPeriodo Periodo5 = new cDatosPeriodo();
                Periodo5.TipoDocumento = Trabajador.DatosPersonales.TipoDocumento;
                Periodo5.NumeroDocumento = Trabajador.DatosPersonales.NumeroDocumento;
                Periodo5.PaisEmisor = Trabajador.DatosPersonales.PaisEmisor;
                Periodo5.Categoria = enumCategoria.Trabajador;
                Periodo5.TipoRegistro = enumTipoRegistro.SCRTSalud;
                Periodo5.FechaInicio = Trabajador.FechaInicio.ToShortDateString();
                Periodo5.FechaFin = "";
                switch (Trabajador.TipoSCRTSalud)
                {
                    case enumTipoSCRTSalud.Essalud:
                        Periodo5.SCRTSalud = enumSCRTSalud.Essalud;
                        break;
                    case enumTipoSCRTSalud.EPS:
                        Periodo5.SCRTSalud = enumSCRTSalud.EPS;
                        break;
                    default:
                        break;
                }
                Periodo5.EntidadesPrestadorasSalud = new TablasParametricas.cEntidadesPrestadorasSalud();
                Periodo5.EntidadesPrestadorasSalud.Numero = "";
                ListaPeriodos.Add(Periodo5);
            }

            return ListaPeriodos;

        }

        public TablasParametricas.cTipoTrabajador TraerTipoTrabajador(int idtTipoTrabajador)
        {
            cTipoTrabajador tipo = new cTipoTrabajador();
            tipo = tipo.TraerTipoTrabajador(idtTipoTrabajador);

            TablasParametricas.cTipoTrabajador tra = new TablasParametricas.cTipoTrabajador();
            tra.Numero = tipo.CodigoSunat;
            tra.Descripcion = tipo.Descripcion;
            tra.DescripcionAbreviada = tipo.Descripcion;

            return tra;
        }

        public TablasParametricas.cRegimenSalud TraerRegimenSalud()
        {
            TablasParametricas.cRegimenSalud Regimen = new TablasParametricas.cRegimenSalud();
            Regimen.Numero = "00";
            Regimen.Descripcion = "ESSALUD REGULAR (Exclusivamente)";
            Regimen.DescripcionAbreviada = "ESSALUD REGULAR ";
            return Regimen;
        }

        public TablasParametricas.cRegimenPensionario TraerRegimenPensionario(cTrabajadorAltaTRegistro tra)
        {
            TablasParametricas.cRegimenPensionario reg = new TablasParametricas.cRegimenPensionario();
            reg.Numero = tra.PeriodosRegimenPensionario[0].Afp.Codigosunat;
            reg.Descripcion = tra.PeriodosRegimenPensionario[0].Afp.Nombre;
            reg.DescripcionAbreviada = tra.PeriodosRegimenPensionario[0].Afp.Nombre;
            return reg;
        }

        public List<Tregistro.cFilaDatosPer> TraerArchivoPER(List<cTrabajadorAltaTRegistro> ListaTrabajadores, DateTime Mes)
        {
            List<Tregistro.cFilaDatosPer> Lista = new List<cFilaDatosPer>();
            int contador = 0;
            foreach (cTrabajadorAltaTRegistro item in ListaTrabajadores)
            {
                foreach (cDatosPeriodo item2 in item.DatosPeriodo)
                {
                    cFilaDatosPer per = new cFilaDatosPer();
                    contador++;
                    per.Numero = contador;
                    per.TipoDocumento = item2.TipoDocumento.Numero + " - " + item2.TipoDocumento.DescripcionAbreviadad;
                    per.NumeroDocumento = item2.NumeroDocumento;
                    per.PaisEmisorDocumento = item2.PaisEmisor.Codigo + " - " + item2.PaisEmisor.Descripcion;
                    per.Categoría = ((int)item2.Categoria).ToString() + " - " + item2.Categoria.ToString();
                    per.TipoDeRegistro = ((int)item2.TipoRegistro).ToString() + " - " + item2.TipoRegistro.ToString();
                    per.FechaInicio = item2.FechaInicio.ToString();
                    per.FechaFin = item2.FechaFin.ToString();
                    switch (item2.TipoRegistro)
                    {
                        case enumTipoRegistro.Periodo:
                            per.IndicadorTipoRegistro = item2.MotivoFinPeriodo.Numero + " - " + item2.MotivoFinPeriodo.DescripcionAbreviada;
                            break;
                        case enumTipoRegistro.TipoTrabajador:
                            per.IndicadorTipoRegistro = item2.TipoTrabajador.Numero + " - " + item2.TipoTrabajador.DescripcionAbreviada;
                            break;
                        case enumTipoRegistro.RegimenSalud:
                            per.IndicadorTipoRegistro = item2.RegimenSalud.Numero + " - " + item2.RegimenSalud.DescripcionAbreviada;
                            break;
                        case enumTipoRegistro.RegimenPensionario:
                            per.IndicadorTipoRegistro = item2.RegimenPensionario.Numero + " - " + item2.RegimenPensionario.DescripcionAbreviada;
                            break;
                        case enumTipoRegistro.SCRTSalud:
                            per.IndicadorTipoRegistro = ((int)item2.SCRTSalud).ToString();
                            break;
                        default:
                            break;
                    }
                    Lista.Add(per);
                }
            }

            return Lista;
        }

        public ArrayList GenerarListaIDE(List<cTrabajadorAltaTRegistro> ListaTrabajadoresSeleccionados)
        {
            string Palo = "|";

            try
            {
                ArrayList ListaIDE = new ArrayList();
                foreach (cTrabajadorAltaTRegistro item in ListaTrabajadoresSeleccionados)
                {
                    if (item.Marcado)
                    {
                        //Compatibilidad para versiones anteriores
                        if (item.DatosPersonales.Telefono == "")
                        {
                            item.DatosPersonales.Telefono = "999999999";
                        }
                        string ContenidoIDE = "";
                        ContenidoIDE = item.DatosPersonales.TipoDocumento.Numero + Palo +
                            item.DatosPersonales.NumeroDocumento + Palo +
                            item.DatosPersonales.PaisEmisor.Codigo + Palo +
                            item.DatosPersonales.FechaNacimiento.ToShortDateString() + Palo +
                            item.ApellidoPaterno + Palo +
                            item.ApellidoMaterno + Palo +
                            item.Nombres + Palo +
                            item.DatosPersonales.Sexo.Codigo + Palo +
                            item.DatosPersonales.Nacionalidad.Numero + Palo +
                            item.DatosPersonales.TelefonoCodigoLargaDistancia + Palo +
                            item.DatosPersonales.Telefono + Palo +
                            item.DatosPersonales.CorreoElectronico + Palo +
                            item.DatosPersonales.Direccion01.TipoVia.Numero + Palo +
                            item.DatosPersonales.Direccion01.NombreVia + Palo +
                            item.DatosPersonales.Direccion01.NumeroVia + Palo +
                            item.DatosPersonales.Direccion01.Departamento + Palo +
                            item.DatosPersonales.Direccion01.Interior + Palo +
                            item.DatosPersonales.Direccion01.Manzana + Palo +
                            item.DatosPersonales.Direccion01.Lote + Palo +
                            item.DatosPersonales.Direccion01.Kilometro + Palo +
                            item.DatosPersonales.Direccion01.Bloque + Palo +
                            item.DatosPersonales.Direccion01.Etapa + Palo +
                            item.DatosPersonales.Direccion01.TipoZona.Numero + Palo +
                            item.DatosPersonales.Direccion01.NombreZona + Palo +
                            item.DatosPersonales.Direccion01.Referencia + Palo +
                            item.DatosPersonales.Direccion01.Distrito.CodigoUbigeo + Palo +
                            item.DatosPersonales.Direccion02.TipoVia.Numero + Palo +
                            item.DatosPersonales.Direccion02.NombreVia + Palo +
                            item.DatosPersonales.Direccion02.NumeroVia + Palo +
                            item.DatosPersonales.Direccion02.Departamento + Palo +
                            item.DatosPersonales.Direccion02.Interior + Palo +
                            item.DatosPersonales.Direccion02.Manzana + Palo +
                            item.DatosPersonales.Direccion02.Lote + Palo +
                            item.DatosPersonales.Direccion02.Kilometro + Palo +
                            item.DatosPersonales.Direccion02.Bloque + Palo +
                            item.DatosPersonales.Direccion02.Etapa + Palo +
                            item.DatosPersonales.Direccion02.TipoZona.Numero + Palo +
                            item.DatosPersonales.Direccion02.NombreZona + Palo +
                            item.DatosPersonales.Direccion02.Referencia + Palo +
                            item.DatosPersonales.Direccion02.Distrito.CodigoUbigeo + Palo +
                            item.DatosPersonales.IndicadorEssalud + Palo;
                        ListaIDE.Add(ContenidoIDE);
                    }
                }
                return ListaIDE;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en GenerarListaIDE: " + ex.Message);
            }
        }

        public ArrayList GenerarListaTRA(List<cTrabajadorAltaTRegistro> ListaTrabajadoresSeleccionados)
        {
            string Palo = "|";
            try
            {
                ArrayList ListaTRA = new ArrayList();
                foreach (cTrabajadorAltaTRegistro item in ListaTrabajadoresSeleccionados)
                {
                    if (item.Marcado)
                    {
                        string ContenidoTRA = "";
                        ContenidoTRA = item.DatosPersonales.TipoDocumento.Numero + Palo +
                            item.DatosPersonales.NumeroDocumento + Palo +
                            item.DatosPersonales.PaisEmisor.Codigo + Palo +
                            item.DatosTrabajador[0].RegimenLaboral.Codigo + Palo +
                            item.DatosTrabajador[0].SituacionEducativa.Numero + Palo +
                            item.DatosTrabajador[0].Ocupacion.Codigo + Palo +
                            item.DatosTrabajador[0].Discapacidad + Palo +
                            item.DatosTrabajador[0].CUSPP + Palo +
                            item.DatosTrabajador[0].SCRTPension + Palo +
                            item.DatosTrabajador[0].TipoContrato.Numero + Palo +
                            item.DatosTrabajador[0].SujetoARegimenAlternativo + Palo +
                            item.DatosTrabajador[0].SujetoAJornadaMaxima + Palo +
                            item.DatosTrabajador[0].SujetoAHorarioNocturno + Palo +
                            item.DatosTrabajador[0].EsSindicalizado + Palo +
                            item.DatosTrabajador[0].PeriodicidadIngreso.Numero + Palo +
                            item.DatosTrabajador[0].MontoBasico + Palo +
                            item.DatosTrabajador[0].Situacion.Numero + Palo +
                            item.DatosTrabajador[0].RentaQuintaExonerada + Palo +
                            item.DatosTrabajador[0].SituacionEspecialTrabajador.Numero + Palo +
                            item.DatosTrabajador[0].TipoPago.Numero + Palo +
                            item.DatosTrabajador[0].CategoriaOcupacionalTrabajador.Codigo + Palo +
                            item.DatosTrabajador[0].ConvenioParaEvitarDobleTri + Palo +
                            item.DatosTrabajador[0].RUC + Palo;
                        ListaTRA.Add(ContenidoTRA);
                    }
                }
                return ListaTRA;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en GenerarListaTRA: " + ex.Message);
            }
        }

        public ArrayList GenerarListaPER(List<cTrabajadorAltaTRegistro> ListaTrabajadoresSeleccionados)
        {
            string Palo = "|";
            try
            {
                ArrayList ListaPER = new ArrayList();
                foreach (cTrabajadorAltaTRegistro item in ListaTrabajadoresSeleccionados)
                {
                    if (item.Marcado)
                    {
                        foreach (cDatosPeriodo item2 in item.DatosPeriodo)
                        {
                            switch (item2.TipoRegistro)
                            {
                                case enumTipoRegistro.Periodo:
                                    string ContenidoPER = "";
                                    ContenidoPER = item.DatosPersonales.TipoDocumento.Numero + Palo +
                                        item.DatosPersonales.NumeroDocumento + Palo +
                                        item.DatosPersonales.PaisEmisor.Codigo + Palo +
                                        (int)item2.Categoria + Palo +
                                        (int)item2.TipoRegistro + Palo +
                                        item2.FechaInicio + Palo +
                                        item2.FechaFin + Palo +
                                        item2.MotivoFinPeriodo.Numero + Palo +
                                        Palo;
                                    ListaPER.Add(ContenidoPER);
                                    break;
                                case enumTipoRegistro.TipoTrabajador:
                                    ContenidoPER = "";
                                    ContenidoPER = item.DatosPersonales.TipoDocumento.Numero + Palo +
                                        item.DatosPersonales.NumeroDocumento + Palo +
                                        item.DatosPersonales.PaisEmisor.Codigo + Palo +
                                        (int)item2.Categoria + Palo +
                                        (int)item2.TipoRegistro + Palo +
                                        item2.FechaInicio + Palo +
                                        item2.FechaFin + Palo +
                                        item2.TipoTrabajador.Numero + Palo +
                                        Palo;
                                    ListaPER.Add(ContenidoPER);
                                    break;
                                case enumTipoRegistro.RegimenSalud:
                                    ContenidoPER = "";
                                    ContenidoPER = item.DatosPersonales.TipoDocumento.Numero + Palo +
                                        item.DatosPersonales.NumeroDocumento + Palo +
                                        item.DatosPersonales.PaisEmisor.Codigo + Palo +
                                        (int)item2.Categoria + Palo +
                                        (int)item2.TipoRegistro + Palo +
                                        item2.FechaInicio + Palo +
                                        item2.FechaFin + Palo +
                                        item2.RegimenSalud.Numero + Palo +
                                        item2.EntidadesPrestadorasSalud.Numero + Palo;
                                    ListaPER.Add(ContenidoPER);
                                    break;
                                case enumTipoRegistro.RegimenPensionario:
                                    ContenidoPER = "";
                                    ContenidoPER = item.DatosPersonales.TipoDocumento.Numero + Palo +
                                        item.DatosPersonales.NumeroDocumento + Palo +
                                        item.DatosPersonales.PaisEmisor.Codigo + Palo +
                                        (int)item2.Categoria + Palo +
                                        (int)item2.TipoRegistro + Palo +
                                        item2.FechaInicio + Palo +
                                        item2.FechaFin + Palo +
                                        item2.RegimenPensionario.Numero + Palo +
                                        Palo;
                                    ListaPER.Add(ContenidoPER);
                                    break;
                                case enumTipoRegistro.SCRTSalud:
                                    ContenidoPER = "";
                                    ContenidoPER = item.DatosPersonales.TipoDocumento.Numero + Palo +
                                        item.DatosPersonales.NumeroDocumento + Palo +
                                        item.DatosPersonales.PaisEmisor.Codigo + Palo +
                                        (int)item2.Categoria + Palo +
                                        (int)item2.TipoRegistro + Palo +
                                        item2.FechaInicio + Palo +
                                        item2.FechaFin + Palo +
                                        item2.SCRTSalud + Palo +
                                        Palo;
                                    ListaPER.Add(ContenidoPER);
                                    break;
                                default:
                                    break;
                            }
                        }
                        
                    }
                }
                return ListaPER;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en GenerarListaPER: " + ex.Message);
            }
        }

        public ArrayList GenerarListaEST(List<cTrabajadorAltaTRegistro> ListaTrabajadoresSeleccionados)
        {
            string Palo = "|";
            try
            {
                ArrayList ListaEST = new ArrayList();
                foreach (cTrabajadorAltaTRegistro item in ListaTrabajadoresSeleccionados)
                {
                    if (item.Marcado)
                    {
                        string ContenidoEST = "";
                        ContenidoEST = item.DatosPersonales.TipoDocumento.Numero + Palo +
                            item.DatosPersonales.NumeroDocumento + Palo +
                            item.DatosPersonales.PaisEmisor.Codigo + Palo +
                            RUC + Palo +
                            "0000" + Palo;
                        ListaEST.Add(ContenidoEST);
                    }
                }
                return ListaEST;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en GenerarListaEST: " + ex.Message);
            }
        }
    }

    
}
