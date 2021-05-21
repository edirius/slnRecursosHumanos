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
    }
}
