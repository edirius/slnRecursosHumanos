using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios.DatosLaborales
{
    public class cRegimenSaludTrabajador
    {
        int sidtregimensaludtrbajador;
        string sregimensalud;
        string sfechainicio;
        string sfechafin;
        string sentidadprestadorasalud;
        int sidtperiodotrabajor;

        public int IdtRegimenSaludTrabajador
        {
            get { return sidtregimensaludtrbajador; }
            set { sidtregimensaludtrbajador = value; }
        }
        public string RegimenSalud
        {
            get { return sregimensalud; }
            set { sregimensalud = value; }
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
        public string EntidadPrestadoraSalud
        {
            get { return sentidadprestadorasalud; }
            set { sentidadprestadorasalud = value; }
        }
        public int IdtPeriodoTrabajador
        {
            get { return sidtperiodotrabajor; }
            set { sidtperiodotrabajor = value; }
        }

        public DataTable ListarRegimenSaludTrabajador(int IdtPeriodoTrabajador)
        {
            return Conexion.GDatos.TraerDataTable("spListarRegimenSaludTrabajador", IdtPeriodoTrabajador);
        }

        public Boolean CrearRegimenSaludTrabajador(cRegimenSaludTrabajador miRegimenSaludTrabajador)
        {
            Conexion.GDatos.Ejecutar("spCrearRegimenSaludTrabajador", miRegimenSaludTrabajador.RegimenSalud, miRegimenSaludTrabajador.FechaInicio, miRegimenSaludTrabajador.FechaFin, miRegimenSaludTrabajador.EntidadPrestadoraSalud, miRegimenSaludTrabajador.IdtPeriodoTrabajador);
            return true;
        }

        public Boolean ModificarRegimenSaludTrabajador(cRegimenSaludTrabajador miRegimenSaludTrabajador)
        {
            Conexion.GDatos.Ejecutar("spModificarRegimenSaludTrabajador", miRegimenSaludTrabajador.IdtRegimenSaludTrabajador, miRegimenSaludTrabajador.RegimenSalud, miRegimenSaludTrabajador.FechaInicio, miRegimenSaludTrabajador.FechaFin, miRegimenSaludTrabajador.EntidadPrestadoraSalud, miRegimenSaludTrabajador.IdtPeriodoTrabajador);
            return true;
        }

        public Boolean EliminarRegimenSaludTrabajador(int IdtRegimenSaludTrabajador)
        {
            Conexion.GDatos.Ejecutar("spELiminarRegimenSaludTrabajador", IdtRegimenSaludTrabajador);
            return true;
        }

        public Boolean BajaRegimenSaludTrabajador(string fechafin, int IdtPeriodoTrabajador)
        {
            Conexion.GDatos.Ejecutar("spBajaRegimenSaludTrabajador", fechafin, IdtPeriodoTrabajador);
            return true;
        }


        /// <summary>
        /// Metodo para traer el ultimo regimen de salud
        /// idtregimensaludtrabajador, regimensalud,fechainicio,fechafin,entidadprestadorasalud,idtperiodotrabajador
        /// </summary>
        /// <param name="idtPeriodoTrabajador"></param>
        /// <returns></returns>
        public cRegimenSaludTrabajador TraerUltimoRegimenSalud(int idtPeriodoTrabajador)
        {
            try
            {
                List<cRegimenSaludTrabajador> listaPeriodosTrabajador = new List<cRegimenSaludTrabajador>();

                DataTable listaPeriodos;
                listaPeriodos = Conexion.GDatos.TraerDataTable("spListarRegimenSaludTrabajador", idtPeriodoTrabajador);

                foreach (DataRow item in listaPeriodos.Rows)
                {


                    if ((item[3] == null) || (item[3].ToString() == ""))
                    {
                        cRegimenSaludTrabajador nuevoPeriodoTrabajador = new cRegimenSaludTrabajador();
                        nuevoPeriodoTrabajador.IdtRegimenSaludTrabajador = Convert.ToInt16(item[0].ToString());
                        nuevoPeriodoTrabajador.RegimenSalud = item[1].ToString();
                        nuevoPeriodoTrabajador.sfechainicio = item[2].ToString();
                        nuevoPeriodoTrabajador.sfechafin = "";
                        nuevoPeriodoTrabajador.EntidadPrestadoraSalud = item[4].ToString();
                        nuevoPeriodoTrabajador.IdtPeriodoTrabajador = Convert.ToInt16(item[5]);
                        listaPeriodosTrabajador.Add(nuevoPeriodoTrabajador);
                    }

                }

                if (listaPeriodosTrabajador.Count == 0)
                {
                    throw new cReglaNegociosException("Error, el regimen de salud del trabajador no esta activo ");
                }
                else
                {
                    return listaPeriodosTrabajador[0];
                }
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en traer el periodo de regimen de salud trabajador: " + ex.Message);
            }
        }
    }
}
