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
        string stipo;
        string scondicion;
        bool sservidorconfianza;
        string snumerodocumento;
        string speriodicidad;
        string stipopago;
        int smontopago;
        string sfechainicio;
        string sfechafin;
        string sruc;
        int sidttipocontrato;
        int sidtcargo;
        int sidtmeta;
        int sidttrabajador;

        public int IdtRegimenTrabajador
        {
            get { return sidtregimentrabajador; }
            set { sidtregimentrabajador = value; }
        }
        public string Tipo
        {
            get { return stipo; }
            set { stipo = value; }
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
        public int MontoPago
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
        public int IdtTipoContrato
        {
            get { return sidttipocontrato; }
            set { sidttipocontrato = value; }
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
        public int IdtTrabajador
        {
            get { return sidttrabajador; }
            set { sidttrabajador = value; }
        }

        public DataTable ListarRegimenTrabajador(int IdtTrabajador)
        {
            return Conexion.GDatos.TraerDataTable("spListarRegimenTrabajador", IdtTrabajador);
        }

        public Boolean CrearRegimenTrabajador(cRegimenTrabajador miRegimenTrabajador)
        {
            Conexion.GDatos.Ejecutar("spCrearRegimenTrabajador", miRegimenTrabajador.Tipo, miRegimenTrabajador.Condicion, miRegimenTrabajador.ServidorConfianza, miRegimenTrabajador.NumeroDocumento, miRegimenTrabajador.Periodicidad, miRegimenTrabajador.TipoPago, miRegimenTrabajador.MontoPago, miRegimenTrabajador.FechaInicio, miRegimenTrabajador.FechaFin, miRegimenTrabajador.RUC, miRegimenTrabajador.IdtTipoContrato, miRegimenTrabajador.IdtCargo, miRegimenTrabajador.IdtMeta, miRegimenTrabajador.IdtTrabajador);
            return true;
        }

        public Boolean ModificarRegimenTrabajador(cRegimenTrabajador miRegimenTrabajador)
        {
            Conexion.GDatos.Ejecutar("spModificarRegimenTrabajador", miRegimenTrabajador.IdtRegimenTrabajador, miRegimenTrabajador.Tipo, miRegimenTrabajador.Condicion, miRegimenTrabajador.ServidorConfianza, miRegimenTrabajador.NumeroDocumento, miRegimenTrabajador.Periodicidad, miRegimenTrabajador.TipoPago, miRegimenTrabajador.MontoPago, miRegimenTrabajador.FechaInicio, miRegimenTrabajador.FechaFin, miRegimenTrabajador.RUC, miRegimenTrabajador.IdtTipoContrato, miRegimenTrabajador.IdtCargo, miRegimenTrabajador.IdtMeta, miRegimenTrabajador.IdtTrabajador);
            return true;
        }

        public Boolean EliminarRegimenTrabajador(int IdtRegimenTrabajador)
        {
            Conexion.GDatos.Ejecutar("spELiminarRegimenTrabajador", IdtRegimenTrabajador);
            return true;
        }
    }
}
