﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios.DatosLaborales
{
    public class cRegimenPensionarioTrabajador
    {
        int sidtregimenpensionariotrabajador;
        string sfechainicio;
        string sfechafin;
        string scuspp;
        string stipocomision;
        int sidtafp;
        int sidtperiodotrabajor;
        private cAFP afp;

        public int IdtRegimenPensionarioTrabajador
        {
            get { return sidtregimenpensionariotrabajador; }
            set { sidtregimenpensionariotrabajador = value; }
        }
        public string FechaInicio
        {
            get { return sfechainicio; }
            set { sfechainicio = value; }
        }
        public string FechaFin
        {
            get { return sfechafin; }
            set { sfechafin = value; }
        }
        public string CUSPP
        {
            get { return scuspp; }
            set { scuspp = value; }
        }
        public string TipoComision
        {
            get { return stipocomision; }
            set { stipocomision = value; }
        }
        public int IdtAFP
        {
            get { return sidtafp; }
            set { sidtafp = value; }
        }
        public int IdtPeriodoTrabajador
        {
            get { return sidtperiodotrabajor; }
            set { sidtperiodotrabajor = value; }
        }

        public cAFP Afp
        {
            get
            {
                return afp;
            }

            set
            {
                afp = value;
            }
        }

        public DataTable ListarRegimenPensionarioTrabajador(int IdtPeriodoTrabajador)
        {
            return Conexion.GDatos.TraerDataTable("spListarRegimenPensionarioTrabajador", IdtPeriodoTrabajador);
        }

        public Boolean CrearRegimenPensionarioTrabajador(cRegimenPensionarioTrabajador miRegimenPensionarioTrabajador)
        {
            Conexion.GDatos.Ejecutar("spCrearRegimenPensionarioTrabajador", miRegimenPensionarioTrabajador.FechaInicio, miRegimenPensionarioTrabajador.FechaFin, miRegimenPensionarioTrabajador.CUSPP, miRegimenPensionarioTrabajador.TipoComision, miRegimenPensionarioTrabajador.IdtAFP, miRegimenPensionarioTrabajador.IdtPeriodoTrabajador);
            return true;
        }

        public Boolean ModificarRegimenPensionarioTrabajador(cRegimenPensionarioTrabajador miRegimenPensionarioTrabajador)
        {
            Conexion.GDatos.Ejecutar("spModificarRegimenPensionarioTrabajador", miRegimenPensionarioTrabajador.IdtRegimenPensionarioTrabajador, miRegimenPensionarioTrabajador.FechaInicio, miRegimenPensionarioTrabajador.FechaFin, miRegimenPensionarioTrabajador.CUSPP, miRegimenPensionarioTrabajador.TipoComision, miRegimenPensionarioTrabajador.IdtAFP, miRegimenPensionarioTrabajador.IdtPeriodoTrabajador);
            return true;
        }

        public Boolean EliminarRegimenPensionarioTrabajador(int IdtRegimenPensionarioTrabajador)
        {
            Conexion.GDatos.Ejecutar("spELiminarRegimenPensionarioTrabajador", IdtRegimenPensionarioTrabajador);
            return true;
        }

        public Boolean BajaRegimenPensionarioTrabajador(string fechafin, int IdtPeriodoTrabajador)
        {
            Conexion.GDatos.Ejecutar("spBajaRegimenPensionarioTrabajador", fechafin, IdtPeriodoTrabajador);
            return true;
        }


        /// <summary>
        /// Metodo para traer el ultimo regimen pensionario del trabajador.
        /// idtregimenpensionariotrabajador, fechainicio, fechafin, CUSPP, tipocomision, idtafp, idtperiodotrabajador
        /// </summary>
        /// <param name="idtPeriodoTrabajador"></param>
        /// <returns></returns>
        public cRegimenPensionarioTrabajador TraerUltimoRegimenPensionario(int idtPeriodoTrabajador)
        {
         
            try
            {
                

                DataTable listaPeriodos;
                listaPeriodos = Conexion.GDatos.TraerDataTable("spListarRegimenPensionarioTrabajador", idtPeriodoTrabajador);

                if (listaPeriodos.Rows.Count == 0)
                {
                    return null;
                    //throw new cReglaNegociosException("Error, el trabajador no esta activo ");
                }

                cRegimenPensionarioTrabajador nuevoPeriodoTrabajador = new cRegimenPensionarioTrabajador();
                        nuevoPeriodoTrabajador.IdtRegimenPensionarioTrabajador = Convert.ToInt16(listaPeriodos.Rows[listaPeriodos.Rows.Count -1][0].ToString());
                        nuevoPeriodoTrabajador.sfechainicio = listaPeriodos.Rows[listaPeriodos.Rows.Count - 1][1].ToString();
                        nuevoPeriodoTrabajador.sfechafin = "";
                        nuevoPeriodoTrabajador.CUSPP = listaPeriodos.Rows[listaPeriodos.Rows.Count - 1][3].ToString();
                        nuevoPeriodoTrabajador.TipoComision = listaPeriodos.Rows[listaPeriodos.Rows.Count - 1][4].ToString();
                        nuevoPeriodoTrabajador.IdtAFP = Convert.ToInt16(listaPeriodos.Rows[listaPeriodos.Rows.Count - 1][5].ToString());
                        nuevoPeriodoTrabajador.IdtPeriodoTrabajador = Convert.ToInt16(listaPeriodos.Rows[listaPeriodos.Rows.Count - 1][6].ToString());



                return nuevoPeriodoTrabajador;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en traer el periodo del trabajador: " + ex.Message);
            }
        }

        public cRegimenPensionarioTrabajador TraerRegimenPensionario(int idtRegimenTrabajador)
        {

            try
            {


                DataTable listaPeriodos;
                listaPeriodos = Conexion.GDatos.TraerDataTable("spTraerRegimenPensionarioTrabajador", idtRegimenTrabajador);

                if (listaPeriodos.Rows.Count == 0)
                {
                    throw new cReglaNegociosException("Error, el regimen no esta activo ");
                }

                cRegimenPensionarioTrabajador nuevoPeriodoTrabajador = new cRegimenPensionarioTrabajador();
                nuevoPeriodoTrabajador.IdtRegimenPensionarioTrabajador = Convert.ToInt16(listaPeriodos.Rows[0][0].ToString());
                nuevoPeriodoTrabajador.sfechainicio = listaPeriodos.Rows[0][1].ToString();
                nuevoPeriodoTrabajador.sfechafin = listaPeriodos.Rows[0][2].ToString(); ;
                nuevoPeriodoTrabajador.CUSPP = listaPeriodos.Rows[0][3].ToString();
                nuevoPeriodoTrabajador.TipoComision = listaPeriodos.Rows[0][4].ToString();
                nuevoPeriodoTrabajador.IdtAFP = Convert.ToInt16(listaPeriodos.Rows[0][5].ToString());
                nuevoPeriodoTrabajador.IdtPeriodoTrabajador = Convert.ToInt16(listaPeriodos.Rows[0][6].ToString());



                return nuevoPeriodoTrabajador;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en traer el periodo del trabajador: " + ex.Message);
            }
        }


        /// <summary>
        /// Metodo para traer los regimen pensionarios dentro de un mes por el periodo de un trabajador
        /// </summary>
        /// <param name="pidtPeriodoTrabajador"></param>
        /// <param name="MesBuscado"></param>
        /// <returns></returns>
        public List<cRegimenPensionarioTrabajador> TraerRegimenPensionarioxMes(int pidtPeriodoTrabajador, DateTime MesBuscado)
        {

            try
            {
                List<cRegimenPensionarioTrabajador> ListaRegimePensionario = new List<cRegimenPensionarioTrabajador>();

                MesBuscado = new DateTime(MesBuscado.Year, MesBuscado.Month, 1);

                DataTable listaPeriodos;
                listaPeriodos = Conexion.GDatos.TraerDataTable("spTraerPeriodosAFPxPeriodo", pidtPeriodoTrabajador);

                foreach (DataRow item in listaPeriodos.Rows)
                {
                    DateTime fechaRegimenInicio = convertirFecha(item[1].ToString(), true);
                    fechaRegimenInicio = new DateTime(fechaRegimenInicio.Year, fechaRegimenInicio.Month, 1);
                    DateTime fechaRegimenFin;
                    if ((item[2] == null) || (item[2].ToString() == ""))
                    {
                        fechaRegimenFin = new DateTime(3000, 12, 31);
                    }
                    else
                    {
                        fechaRegimenFin = convertirFecha(item[2].ToString(), false);
                    }

                    if (MesBuscado.Date >= fechaRegimenInicio && MesBuscado.Date <= fechaRegimenFin)
                    {
                        cRegimenPensionarioTrabajador nuevoPeriodoTrabajador = new cRegimenPensionarioTrabajador();
                        nuevoPeriodoTrabajador.IdtRegimenPensionarioTrabajador = Convert.ToInt16(listaPeriodos.Rows[0][0].ToString());
                        nuevoPeriodoTrabajador.sfechainicio = listaPeriodos.Rows[0][1].ToString();
                        nuevoPeriodoTrabajador.sfechafin = listaPeriodos.Rows[0][2].ToString(); ;
                        nuevoPeriodoTrabajador.CUSPP = listaPeriodos.Rows[0][3].ToString();
                        nuevoPeriodoTrabajador.TipoComision = listaPeriodos.Rows[0][4].ToString();
                        nuevoPeriodoTrabajador.IdtAFP = Convert.ToInt16(listaPeriodos.Rows[0][5].ToString());
                        nuevoPeriodoTrabajador.IdtPeriodoTrabajador = Convert.ToInt16(listaPeriodos.Rows[0][6].ToString());
                        ListaRegimePensionario.Add(nuevoPeriodoTrabajador);
                    }
                }
                return ListaRegimePensionario;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en traer el periodo del trabajador: " + ex.Message);
            }
        }


        public CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador traerAFPTrabajador(int idttrabajador, DateTime fecha)
        {
            cListaAFP miAFP = new cListaAFP();
            cPeriodoTrabajador miPeriodoTrabajador = new cPeriodoTrabajador();

            DataTable oDataAFP = miAFP.ObtenerListaAFP();

            List<CapaDeNegocios.DatosLaborales.cPeriodoTrabajador> AuxiliarPeriodoTrabajador = miPeriodoTrabajador.traerPeriodosMesTrabajador(idttrabajador, fecha);
            List<CapaDeNegocios.DatosLaborales.cRegimenTrabajador> ListaRegimenTrabajador = new List<CapaDeNegocios.DatosLaborales.cRegimenTrabajador>();
            List<CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador> ListaPeriodoAFP = new List<CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador>();

            CapaDeNegocios.DatosLaborales.cPeriodoTrabajador PeriodoElegido = new CapaDeNegocios.DatosLaborales.cPeriodoTrabajador();
            CapaDeNegocios.DatosLaborales.cRegimenTrabajador RegimenElegido = new CapaDeNegocios.DatosLaborales.cRegimenTrabajador();
            CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador AFPElegido = new CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador();

            if (AuxiliarPeriodoTrabajador.Count > 0)
            {
                foreach (CapaDeNegocios.DatosLaborales.cPeriodoTrabajador item in AuxiliarPeriodoTrabajador)
                {
                    CapaDeNegocios.DatosLaborales.cRegimenTrabajador auxiliarRegimenTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenTrabajador();

                    ListaRegimenTrabajador = auxiliarRegimenTrabajador.TraerRegimenTrabajadorMes(item.IdtPeriodoTrabajador, fecha);
                    ListaPeriodoAFP = AFPElegido.TraerRegimenPensionarioxMes(item.IdtPeriodoTrabajador, fecha);

                    if (ListaPeriodoAFP.Count > 0)
                    {
                        AFPElegido = ListaPeriodoAFP[ListaPeriodoAFP.Count - 1];
                        AFPElegido.Afp = new CapaDeNegocios.cAFP();

                        foreach (DataRow rowAFP in oDataAFP.Select("idtafp = '" + AFPElegido.IdtAFP.ToString() + "'"))
                        {
                            AFPElegido.Afp.CodigoAFP = AFPElegido.IdtAFP;
                            AFPElegido.Afp.Nombre = rowAFP[1].ToString();
                        }

                        return AFPElegido;
                    }
                    else
                    {
                        return null;
                    }
                }
                return null;
            }
            else
            {
                return null;
            }
        }


        public DateTime convertirFecha(string Fecha, bool Inicio)
        {
            if (Fecha.Length == 10)
            {
                if (Inicio)
                {
                    return new DateTime(Convert.ToInt16(Fecha.Substring(6, 4)), Convert.ToInt16(Fecha.Substring(3, 2)), 1);
                }
                //para fecha fin
                else
                {

                    return new DateTime(Convert.ToInt16(Fecha.Substring(6, 4)), Convert.ToInt16(Fecha.Substring(3, 2)), DateTime.DaysInMonth(Convert.ToInt16(Fecha.Substring(6, 4)), Convert.ToInt16(Fecha.Substring(3, 2))));
                }
            }
            else
            {
                if (Fecha.Length == 9)
                {
                    if (Inicio)
                    {
                        return new DateTime(Convert.ToInt16(Fecha.Substring(5, 4)), Convert.ToInt16(Fecha.Substring(2, 2)), 1);
                    }
                    //para fecha fin
                    else
                    {

                        return new DateTime(Convert.ToInt16(Fecha.Substring(5, 4)), Convert.ToInt16(Fecha.Substring(2, 2)), DateTime.DaysInMonth(Convert.ToInt16(Fecha.Substring(5, 4)), Convert.ToInt16(Fecha.Substring(2, 2))));
                    }

                }
                else
                {
                    throw new cReglaNegociosException("Error convertir Fecha: la logntiud no es correcta 10 o 9");
                }
            }
        }
    }
}
