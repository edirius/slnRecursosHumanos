using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios.DatosLaborales
{
    public class cRegimenTrabajador
    {
        int sidtregimentrabajador;
        string scondicion;
        bool sservidorconfianza;
        string snumerodocumento;
        string speriodicidad;
        string stipopago;
        decimal smontopago;
        string sfechainicio;
        string sfechafin;
        string sruc;
        int sidtregimenlaboral;
        int sidttipotrabajador;
        int sidttipocontrato;
        int sidtcategoriaocupacional;
        int sidtocupacion;
        int sidtcargo;
        int sidtmeta;
        int sidtperiodotrabajador;
        public cCargo Cargo { get; set; }

        public cRegimenTrabajador()
        {
            Cargo = new cCargo();
        }

        public int IdtRegimenTrabajador
        {
            get { return sidtregimentrabajador; }
            set { sidtregimentrabajador = value; }
        }
        public string Condicion
        {
            get { return scondicion; }
            set { scondicion = value; }
        }
        public bool ServidorConfianza
        {
            get { return sservidorconfianza; }
            set { sservidorconfianza = value; }
        }
        public string NumeroDocumento
        {
            get { return snumerodocumento; }
            set { snumerodocumento = value; }
        }
        public string Periodicidad
        {
            get { return speriodicidad; }
            set { speriodicidad = value; }
        }
        public string TipoPago
        {
            get { return stipopago; }
            set { stipopago = value; }
        }
        public decimal MontoPago
        {
            get { return smontopago; }
            set { smontopago = value; }
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
        public string RUC
        {
            get { return sruc; }
            set { sruc = value; }
        }
        public int IdtRegimenLaboral
        {
            get { return sidtregimenlaboral; }
            set { sidtregimenlaboral = value; }
        }
        public int IdtTipoTrabajador
        {
            get { return sidttipotrabajador; }
            set { sidttipotrabajador = value; }
        }
        public int IdtTipoContrato
        {
            get { return sidttipocontrato; }
            set { sidttipocontrato = value; }
        }
        public int IdtCategoriaOcupacional
        {
            get { return sidtcategoriaocupacional; }
            set { sidtcategoriaocupacional = value; }
        }
        public int IdtOcupacion
        {
            get { return sidtocupacion; }
            set { sidtocupacion = value; }
        }
        public int IdtCargo
        {
            get { return sidtcargo; }
            set { sidtcargo = value; }
        }
        public int IdtMeta
        {
            get { return sidtmeta; }
            set { sidtmeta = value; }
        }
        public int IdtPeriodoTrabajador
        {
            get { return sidtperiodotrabajador; }
            set { sidtperiodotrabajador = value; }
        }

        public DataTable ListarRegimenTrabajador(int IdtPeriodoTrabajador)
        {
            return Conexion.GDatos.TraerDataTable("spListarRegimenTrabajador", IdtPeriodoTrabajador);
        }

        public Boolean CrearRegimenTrabajador(cRegimenTrabajador miRegimenTrabajador)
        {
            Conexion.GDatos.Ejecutar("spCrearRegimenTrabajador", miRegimenTrabajador.Condicion, miRegimenTrabajador.ServidorConfianza, miRegimenTrabajador.NumeroDocumento, miRegimenTrabajador.Periodicidad, miRegimenTrabajador.TipoPago, miRegimenTrabajador.MontoPago, miRegimenTrabajador.FechaInicio, miRegimenTrabajador.FechaFin, miRegimenTrabajador.RUC, miRegimenTrabajador.IdtRegimenLaboral, miRegimenTrabajador.IdtTipoTrabajador, miRegimenTrabajador.IdtTipoContrato, miRegimenTrabajador.IdtCategoriaOcupacional, miRegimenTrabajador.IdtOcupacion, miRegimenTrabajador.IdtCargo, miRegimenTrabajador.IdtMeta, miRegimenTrabajador.IdtPeriodoTrabajador);
            return true;
        }

        public Boolean ModificarRegimenTrabajador(cRegimenTrabajador miRegimenTrabajador)
        {
            Conexion.GDatos.Ejecutar("spModificarRegimenTrabajador", miRegimenTrabajador.IdtRegimenTrabajador, miRegimenTrabajador.Condicion, miRegimenTrabajador.ServidorConfianza, miRegimenTrabajador.NumeroDocumento, miRegimenTrabajador.Periodicidad, miRegimenTrabajador.TipoPago, miRegimenTrabajador.MontoPago, miRegimenTrabajador.FechaInicio, miRegimenTrabajador.FechaFin, miRegimenTrabajador.RUC, miRegimenTrabajador.IdtRegimenLaboral, miRegimenTrabajador.IdtTipoTrabajador, miRegimenTrabajador.IdtTipoContrato, miRegimenTrabajador.IdtCategoriaOcupacional, miRegimenTrabajador.IdtOcupacion, miRegimenTrabajador.IdtCargo, miRegimenTrabajador.IdtMeta, miRegimenTrabajador.IdtPeriodoTrabajador);
            return true;
        }

        public Boolean EliminarRegimenTrabajador(int IdtRegimenTrabajador)
        {
            Conexion.GDatos.Ejecutar("spELiminarRegimenTrabajador", IdtRegimenTrabajador);
            return true;
        }

        public Boolean BajaRegimenTrabajador(string fechafin, int IdtPeriodoTrabajador)
        {
            Conexion.GDatos.Ejecutar("spBajaRegimenTrabajador", fechafin, IdtPeriodoTrabajador);
            return true;
        }


        /// <summary>
        /// Metodo para traer el ultimo regimen del trabajador.
        /// idtregimentrabajador, condicion, servidorconfianza, numerodocumento, periodicidad, tipopago, montopago, fechainicio, fechafin, ruc,
        /// idtregimenlaboral, idttipotrabajador, idttipocontrato, idtcategoriaocupacional, idtocupacion, idtcargo, idtmeta, idtperiodotrabajador
        /// </summary>
        /// <param name="idtPeriodoTrabajador"></param>
        /// <returns></returns>
        public cRegimenTrabajador TraerUltimoRegimenTrabajador(int idtPeriodoTrabajador)
        {
            try
            {
                List<cRegimenTrabajador> listaPeriodosTrabajador = new List<cRegimenTrabajador>();

                DataTable listaPeriodos;
                listaPeriodos = Conexion.GDatos.TraerDataTable("spListarRegimenTrabajador", idtPeriodoTrabajador);

                foreach (DataRow item in listaPeriodos.Rows)
                {


                    if ((item[8] == null) || (item[8].ToString() == ""))
                    {
                        cRegimenTrabajador nuevoPeriodoTrabajador = new cRegimenTrabajador();
                        nuevoPeriodoTrabajador.IdtRegimenTrabajador = Convert.ToInt16(item[0].ToString());
                        nuevoPeriodoTrabajador.Condicion = item[1].ToString();
                        nuevoPeriodoTrabajador.ServidorConfianza = Convert.ToBoolean(item[2]);
                        nuevoPeriodoTrabajador.NumeroDocumento = item[3].ToString();
                        nuevoPeriodoTrabajador.Periodicidad = item[4].ToString();
                        nuevoPeriodoTrabajador.TipoPago = item[5].ToString();
                        nuevoPeriodoTrabajador.MontoPago = Convert.ToDecimal(item[6]);
                        nuevoPeriodoTrabajador.FechaInicio = item[7].ToString();
                        nuevoPeriodoTrabajador.sfechafin = "";
                        nuevoPeriodoTrabajador.RUC = item[9].ToString();
                        nuevoPeriodoTrabajador.IdtRegimenLaboral = Convert.ToInt16(item[10].ToString());
                        nuevoPeriodoTrabajador.IdtTipoTrabajador = Convert.ToInt16(item[11].ToString());
                        nuevoPeriodoTrabajador.IdtTipoContrato = Convert.ToInt16(item[12].ToString());
                        nuevoPeriodoTrabajador.IdtCategoriaOcupacional = Convert.ToInt16(item[13].ToString());
                        nuevoPeriodoTrabajador.IdtOcupacion = Convert.ToInt16(item[14].ToString());
                        nuevoPeriodoTrabajador.IdtCargo = Convert.ToInt16(item[15].ToString());
                        nuevoPeriodoTrabajador.IdtMeta = Convert.ToInt16(item[16].ToString());
                        nuevoPeriodoTrabajador.IdtPeriodoTrabajador = Convert.ToInt16(item[17]);
                        listaPeriodosTrabajador.Add(nuevoPeriodoTrabajador);
                    }

                }

                if (listaPeriodosTrabajador.Count == 0)
                {
                    throw new cReglaNegociosException("Error,  el regimen laboral del  trabajador no esta activo ");
                }
                else
                {
                    return listaPeriodosTrabajador[0];
                }
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en traer el regimen laboral del trabajador: " + ex.Message);
            }
        }


        public cRegimenTrabajador TraerUltimoRegimenTrabajadorInclusoTerminado(int idtPeriodoTrabajador)
        {
            try
            {
                List<cRegimenTrabajador> listaPeriodosTrabajador = new List<cRegimenTrabajador>();

                DataTable listaPeriodos;
                listaPeriodos = Conexion.GDatos.TraerDataTable("spListarRegimenTrabajador", idtPeriodoTrabajador);

                foreach (DataRow item in listaPeriodos.Rows)
                {

                        cRegimenTrabajador nuevoPeriodoTrabajador = new cRegimenTrabajador();
                        nuevoPeriodoTrabajador.IdtRegimenTrabajador = Convert.ToInt16(item[0].ToString());
                        nuevoPeriodoTrabajador.Condicion = item[1].ToString();
                        nuevoPeriodoTrabajador.ServidorConfianza = Convert.ToBoolean(item[2]);
                        nuevoPeriodoTrabajador.NumeroDocumento = item[3].ToString();
                        nuevoPeriodoTrabajador.Periodicidad = item[4].ToString();
                        nuevoPeriodoTrabajador.TipoPago = item[5].ToString();
                        nuevoPeriodoTrabajador.MontoPago = Convert.ToDecimal(item[6]);
                        nuevoPeriodoTrabajador.FechaInicio = item[7].ToString();
                        nuevoPeriodoTrabajador.sfechafin = "";
                        nuevoPeriodoTrabajador.RUC = item[9].ToString();
                        nuevoPeriodoTrabajador.IdtRegimenLaboral = Convert.ToInt16(item[10].ToString());
                        nuevoPeriodoTrabajador.IdtTipoTrabajador = Convert.ToInt16(item[11].ToString());
                        nuevoPeriodoTrabajador.IdtTipoContrato = Convert.ToInt16(item[12].ToString());
                        nuevoPeriodoTrabajador.IdtCategoriaOcupacional = Convert.ToInt16(item[13].ToString());
                        nuevoPeriodoTrabajador.IdtOcupacion = Convert.ToInt16(item[14].ToString());
                        nuevoPeriodoTrabajador.IdtCargo = Convert.ToInt16(item[15].ToString());
                        nuevoPeriodoTrabajador.IdtMeta = Convert.ToInt16(item[16].ToString());
                        nuevoPeriodoTrabajador.IdtPeriodoTrabajador = Convert.ToInt16(item[17]);
                        listaPeriodosTrabajador.Add(nuevoPeriodoTrabajador);

                }

                if (listaPeriodosTrabajador.Count == 0)
                {
                    throw new cReglaNegociosException("Error,  el regimen laboral del  trabajador no esta activo ");
                }
                else
                {
                    return listaPeriodosTrabajador[listaPeriodosTrabajador.Count - 1];
                }
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en traer el regimen laboral del trabajador: " + ex.Message);
            }
        }


        /// <summary>
        /// Metodo para traer el ultimo regimen del trabajador.
        /// idtregimentrabajador, condicion, servidorconfianza, numerodocumento, periodicidad, tipopago, montopago, fechainicio, fechafin, ruc,
        /// idtregimenlaboral, idttipotrabajador, idttipocontrato, idtcategoriaocupacional, idtocupacion, idtcargo, idtmeta, idtperiodotrabajador
        /// </summary>
        /// <param name="idtPeriodoTrabajador"></param>
        /// <returns></returns>
        public List<cRegimenTrabajador> TraerRegimenTrabajadorMes(int idtPeriodoTrabajador, DateTime Fecha)
        {
            try
            {
                Fecha = new DateTime(Fecha.Year, Fecha.Month, 1);
                List<cRegimenTrabajador> listaPeriodosTrabajador = new List<cRegimenTrabajador>();

                DataTable listaPeriodos;
                listaPeriodos = Conexion.GDatos.TraerDataTable("spListarRegimenTrabajador", idtPeriodoTrabajador);

                foreach (DataRow item in listaPeriodos.Rows)
                {
                    //convierte la fecha al primer dia del mes
                    DateTime fechaRegimenInicio = convertirFecha(item[7].ToString(),true);
                    fechaRegimenInicio = new DateTime(fechaRegimenInicio.Year, fechaRegimenInicio.Month, 1);
                    DateTime fechaRegimenFin;
                    if ((item[8] == null) || (item[8].ToString() == ""))
                    {
                        fechaRegimenFin = new DateTime(3000, 12, 31);
                    }
                    else
                    {
                        fechaRegimenFin = convertirFecha(item[8].ToString(),false);
                    }
                        
                    if ( Fecha.Date >= fechaRegimenInicio.Date && Fecha.Date <= fechaRegimenFin)
                    {
                        cRegimenTrabajador nuevoPeriodoTrabajador = new cRegimenTrabajador();
                        nuevoPeriodoTrabajador.IdtRegimenTrabajador = Convert.ToInt16(item[0].ToString());
                        nuevoPeriodoTrabajador.Condicion = item[1].ToString();
                        nuevoPeriodoTrabajador.ServidorConfianza = Convert.ToBoolean(item[2]);
                        nuevoPeriodoTrabajador.NumeroDocumento = item[3].ToString();
                        nuevoPeriodoTrabajador.Periodicidad = item[4].ToString();
                        nuevoPeriodoTrabajador.TipoPago = item[5].ToString();
                        nuevoPeriodoTrabajador.MontoPago = Convert.ToDecimal(item[6]);
                        nuevoPeriodoTrabajador.FechaInicio = item[7].ToString();
                        nuevoPeriodoTrabajador.sfechafin = "";
                        nuevoPeriodoTrabajador.RUC = item[9].ToString();
                        nuevoPeriodoTrabajador.IdtRegimenLaboral = Convert.ToInt16(item[10].ToString());
                        nuevoPeriodoTrabajador.IdtTipoTrabajador = Convert.ToInt16(item[11].ToString());
                        nuevoPeriodoTrabajador.IdtTipoContrato = Convert.ToInt16(item[12].ToString());
                        nuevoPeriodoTrabajador.IdtCategoriaOcupacional = Convert.ToInt16(item[13].ToString());
                        nuevoPeriodoTrabajador.IdtOcupacion = Convert.ToInt16(item[14].ToString());
                        nuevoPeriodoTrabajador.IdtCargo = Convert.ToInt16(item[15].ToString());
                        nuevoPeriodoTrabajador.IdtMeta = Convert.ToInt16(item[16].ToString());
                        nuevoPeriodoTrabajador.IdtPeriodoTrabajador = Convert.ToInt16(item[17]);
                        listaPeriodosTrabajador.Add(nuevoPeriodoTrabajador);
                    }

                }

                return listaPeriodosTrabajador;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en traer el regimen laboral del trabajador: " + ex.Message);
            }
        }

        /// <summary>
        /// Metodo para traer Regimen Trabajador por ID
        /// </summary>
        /// <param name="idtRegimenTrabajador"></param>
        /// <returns></returns>
        public cRegimenTrabajador TraerRegimenTrabajadorXId (int idtRegimenTrabajador)
        {
            try
            {
                DataTable TablaRegimenTrabajador;
                TablaRegimenTrabajador = Conexion.GDatos.TraerDataTable("spTraerRegimenTrabajador", idtRegimenTrabajador);
                cRegimenTrabajador nuevoPeriodoTrabajador = new cRegimenTrabajador();
                foreach (DataRow item in TablaRegimenTrabajador.Rows)
                {
                    nuevoPeriodoTrabajador.IdtRegimenTrabajador = Convert.ToInt16(item[0].ToString());
                    nuevoPeriodoTrabajador.Condicion = item[1].ToString();
                    nuevoPeriodoTrabajador.ServidorConfianza = Convert.ToBoolean(item[2]);
                    nuevoPeriodoTrabajador.NumeroDocumento = item[3].ToString();
                    nuevoPeriodoTrabajador.Periodicidad = item[4].ToString();
                    nuevoPeriodoTrabajador.TipoPago = item[5].ToString();
                    nuevoPeriodoTrabajador.MontoPago = Convert.ToDecimal(item[6]);
                    nuevoPeriodoTrabajador.FechaInicio = item[7].ToString();
                    nuevoPeriodoTrabajador.sfechafin = "";
                    nuevoPeriodoTrabajador.RUC = item[9].ToString();
                    nuevoPeriodoTrabajador.IdtRegimenLaboral = Convert.ToInt16(item[10].ToString());
                    nuevoPeriodoTrabajador.IdtTipoTrabajador = Convert.ToInt16(item[11].ToString());
                    nuevoPeriodoTrabajador.IdtTipoContrato = Convert.ToInt16(item[12].ToString());
                    nuevoPeriodoTrabajador.IdtCategoriaOcupacional = Convert.ToInt16(item[13].ToString());
                    nuevoPeriodoTrabajador.IdtOcupacion = Convert.ToInt16(item[14].ToString());
                    nuevoPeriodoTrabajador.IdtCargo = Convert.ToInt16(item[15].ToString());
                    nuevoPeriodoTrabajador.IdtMeta = Convert.ToInt16(item[16].ToString());
                    nuevoPeriodoTrabajador.IdtPeriodoTrabajador = Convert.ToInt16(item[17]);
                }
                return nuevoPeriodoTrabajador;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo TraerRegimenTrabajadorXId: " + ex.Message);
            }
        }

        public DateTime convertirFecha(string Fecha, bool Inicio)
        {
            if (Fecha.Length == 10 )
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
                    throw new cReglaNegociosException("Error convertir Fecha: la logntiud no es correcta 10 o 9"  );
                }
            }
        }
    }
}
