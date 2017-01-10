using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDeDatos;
using CapaDeNegocios.Obras;
namespace CapaDeNegocios.Contrato
{
    public class cContrato
    {
        int sidtcontrato;
        DateTime sfecharegistro;
        string snumerodocumento;
        DateTime sfechainicio;
        DateTime sfechafin;
        decimal smontopago;
        string sruc;
        int sidtplantillacontrato;
        int sidtcargo;
        int sidtmeta;
        int sidttrabajador;

        public int Idtcontrato
        {
            get { return sidtcontrato; }
            set { sidtcontrato = value; }
        }
        public DateTime Fecharegistro
        {
            get { return sfecharegistro; }
            set { sfecharegistro = value; }
        }
        public string NumeroDocumento
        {
            get { return snumerodocumento; }
            set { snumerodocumento = value; }
        }
        public DateTime FechaInicio
        {
            get { return sfechainicio; }
            set { sfechainicio = value; }
        }
        public DateTime FechaFin
        {
            get { return sfechafin; }
            set { sfechafin = value; }
        }
        public decimal MontoPago
        {
            get { return smontopago; }
            set { smontopago = value; }
        }
        public string RUC
        {
            get { return sruc; }
            set { sruc = value; }
        }
        public int Idtplantillacontrato
        {
            get { return sidtplantillacontrato; }
            set { sidtplantillacontrato = value; }
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
        public int Idttrabajador
        {
            get { return sidttrabajador; }
            set { sidttrabajador = value; }
        }

        public DataTable ListarContrato(int IdtTrabajador)
        {
            return Conexion.GDatos.TraerDataTable("spListarContrato", IdtTrabajador);
        }

        public Boolean CrearContrato(cContrato miContrato)
        {
            Conexion.GDatos.Ejecutar("spCrearContrato", miContrato.Fecharegistro, miContrato.NumeroDocumento, miContrato.FechaInicio, miContrato.FechaFin, miContrato.MontoPago, miContrato.RUC, miContrato.Idtplantillacontrato, miContrato.IdtCargo, miContrato.IdtMeta, miContrato.Idttrabajador);
            return true;
        }

        public Boolean ModificarContrato(cContrato miContrato)
        {
            Conexion.GDatos.Ejecutar("spModificarContrato", miContrato.Idtcontrato, miContrato.Fecharegistro, miContrato.NumeroDocumento, miContrato.FechaInicio, miContrato.FechaFin, miContrato.MontoPago, miContrato.RUC, miContrato.Idtplantillacontrato, miContrato.IdtCargo, miContrato.IdtMeta, miContrato.Idttrabajador);
            return true;
        }

        public Boolean EliminarContrato(int IdtContrato)
        {
            Conexion.GDatos.Ejecutar("spELiminarContrato", IdtContrato);
            return true;
        }
    }
}
