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
    }
}
