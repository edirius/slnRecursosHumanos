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
    }
}
