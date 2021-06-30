using System;
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
                    throw new cReglaNegociosException("Error, el trabajador no esta activo ");
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

    }
}
