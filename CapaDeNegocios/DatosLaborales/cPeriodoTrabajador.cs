using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

using CapaDeDatos;

namespace CapaDeNegocios.DatosLaborales
{
    public class cPeriodoTrabajador
    {
        int sidtperiodotrabajador;
        string sfechainicio;
        string sfechafin;
        int sidtmotivofinperiodo;
        int sidttrabajador;

        public int IdtPeriodoTrabajador
        {
            get { return sidtperiodotrabajador; }
            set { sidtperiodotrabajador = value; }
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
        public int IdtMotivoFinPeriodo
        {
            get { return sidtmotivofinperiodo; }
            set { sidtmotivofinperiodo = value; }
        }
        public int IdtTrabajador
        {
            get { return sidttrabajador; }
            set { sidttrabajador = value; }
        }

        public DataTable ListarPeriodoTrabajador(int IdtTrabajador)
        {
            return Conexion.GDatos.TraerDataTable("spListarPeriodoTrabajador", IdtTrabajador);
        }

        public Boolean CrearPeriodoTrabajador(cPeriodoTrabajador miPeriodoTrabajador)
        {
            Conexion.GDatos.Ejecutar("spCrearPeriodoTrabajador", miPeriodoTrabajador.FechaInicio, miPeriodoTrabajador.FechaFin, miPeriodoTrabajador.IdtMotivoFinPeriodo, miPeriodoTrabajador.IdtTrabajador);
            return true;
        }

        public Boolean ModificarPeriodoTrabajador(cPeriodoTrabajador miPeriodoTrabajador)
        {
            Conexion.GDatos.Ejecutar("spModificarPeriodoTrabajador", miPeriodoTrabajador.IdtPeriodoTrabajador, miPeriodoTrabajador.FechaInicio, miPeriodoTrabajador.FechaFin, miPeriodoTrabajador.IdtMotivoFinPeriodo, miPeriodoTrabajador.IdtTrabajador);
            return true;
        }

        public Boolean EliminarPeriodoTrabajador(int IdtPeriodoTrabajador)
        {
            Conexion.GDatos.Ejecutar("spEliminarPeriodoTrabajador", IdtPeriodoTrabajador);
            return true;
        }

        public Boolean BajaPeriodoTrabajador(string fechafin, int idtmotivofinperiodo, int idtperiodotrabajador)
        {
            Conexion.GDatos.Ejecutar("spBajaPeriodoTrabajador", fechafin, idtmotivofinperiodo, idtperiodotrabajador);
            return true;
        }


        /// <summary>
        /// Metodo para traer el ultimo periodo de trabajador
        /// idtperiodotrabajador,fechainicio,fechafin,idtmotivofinperiodo,idttrabajador
        /// </summary>
        /// <param name="idtPeriodoTrabajador"></param>
        /// <returns></returns>
        public cPeriodoTrabajador traerUltimoPeriodoTrabajador (int idTrabajador)
        {
            try
            {
                

                DataTable listaPeriodos;
                listaPeriodos =   Conexion.GDatos.TraerDataTable("spListarPeriodoTrabajador", idTrabajador);
                if (listaPeriodos.Rows.Count == 0)
                {
                    throw new cReglaNegociosException("Error, no existe periodos para el trabajador ");
                }


                cPeriodoTrabajador nuevoPeriodoTrabajador = new cPeriodoTrabajador();
                        nuevoPeriodoTrabajador.IdtPeriodoTrabajador = Convert.ToInt16(listaPeriodos.Rows[listaPeriodos.Rows.Count -1][0].ToString());
                        nuevoPeriodoTrabajador.sfechainicio = listaPeriodos.Rows[listaPeriodos.Rows.Count - 1][1].ToString();
                        nuevoPeriodoTrabajador.sfechafin = "";
                        nuevoPeriodoTrabajador.IdtMotivoFinPeriodo = Convert.ToInt16(listaPeriodos.Rows[listaPeriodos.Rows.Count - 1][3].ToString());
                        nuevoPeriodoTrabajador.IdtTrabajador = Convert.ToInt16(listaPeriodos.Rows[listaPeriodos.Rows.Count - 1][4].ToString());
                        


                return nuevoPeriodoTrabajador;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en traer el periodo del trabajador: " + ex.Message);
            }
        }

        /// <summary>
        /// Metodo para traer los periodos que tiene el trabajador segun el mes que se pide
        /// </summary>
        /// <param name="idTrabajaddor"></param>
        /// <param name="mesBuscado"></param>
        /// <returns></returns>
        public List<cPeriodoTrabajador> traerPeriodosMesTrabajador(int idTrabajador, DateTime mesBuscado)
        {
            try
            {
                List<cPeriodoTrabajador> ListaPeriodosParaRetornar = new List<cPeriodoTrabajador>(); 

                DataTable listaPeriodos;
                listaPeriodos = Conexion.GDatos.TraerDataTable("spListarPeriodoTrabajador", idTrabajador);
                if (listaPeriodos.Rows.Count == 0)
                {
                    throw new cReglaNegociosException("Error, no existe periodos para el trabajador ");
                }

                DateTime fechaFinTemporal;
                DateTime fechaInicioTemporal;
                foreach (DataRow  item in listaPeriodos.Rows)
                {
                    if (item[2] == null || item[2].ToString()== "")
                    {
                        fechaFinTemporal = new DateTime(3000, 12, 31); 
                    }
                    else
                    {
                        fechaFinTemporal = Convert.ToDateTime(item[2].ToString());
                    }

                    fechaInicioTemporal = Convert.ToDateTime(item[1].ToString());

                    if (new DateTime(mesBuscado.Year, mesBuscado.Month, 1).Date >= new DateTime(fechaInicioTemporal.Year, fechaInicioTemporal.Month, 1) && new DateTime(mesBuscado.Year, mesBuscado.Month,DateTime.DaysInMonth(mesBuscado.Year, mesBuscado.Month))<= new DateTime(fechaFinTemporal.Year, fechaFinTemporal.Month, DateTime.DaysInMonth(fechaFinTemporal.Year, fechaFinTemporal.Month))) 
                    {
                        cPeriodoTrabajador nuevoPeriodoTrabajador = new cPeriodoTrabajador();
                        nuevoPeriodoTrabajador.IdtPeriodoTrabajador = Convert.ToInt16(item[0].ToString());
                        nuevoPeriodoTrabajador.sfechainicio = item[1].ToString();
                        nuevoPeriodoTrabajador.sfechafin = item[2].ToString();
                        nuevoPeriodoTrabajador.IdtMotivoFinPeriodo = Convert.ToInt16(item[3].ToString());
                        nuevoPeriodoTrabajador.IdtTrabajador = Convert.ToInt16(item[4].ToString());
                        ListaPeriodosParaRetornar.Add(nuevoPeriodoTrabajador);
                    }
                }
                return ListaPeriodosParaRetornar;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo traerPeriodosMesTrabajador-cperiodoTrabajador: " + ex.Message);
            }
        }

        public cPeriodoTrabajador TraerPeriodoTrabajadorXID (int pidtperiodo)
        {
            try
            {
                cPeriodoTrabajador miPeriodo = new cPeriodoTrabajador();
                DataTable tablaPeriodo = Conexion.GDatos.TraerDataTable("spTraerPeriodoXID", pidtperiodo);
                foreach (DataRow item in tablaPeriodo.Rows)
                {
                    miPeriodo.IdtPeriodoTrabajador = Convert.ToInt32(item[0]);
                    miPeriodo.FechaInicio = item[1].ToString();
                    miPeriodo.FechaFin = item[2].ToString();
                    miPeriodo.IdtMotivoFinPeriodo = Convert.ToInt32(item[3]);
                    miPeriodo.IdtTrabajador = Convert.ToInt32(item[4]);
                }
                return miPeriodo;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo TraerPeriodoTrabajadorXID: " + ex.Message);
            }
        }
    }
}
