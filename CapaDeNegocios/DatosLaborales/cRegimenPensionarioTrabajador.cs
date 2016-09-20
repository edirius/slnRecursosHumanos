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
    }
}
