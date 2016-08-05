using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDeDatos;
using CapaDeNegocios.Sunat;

namespace CapaDeNegocios.Sunat
{
    public class cMaestroIngresos
    {
        int sidtmaestroingresos;
        string scodigo;
        string sdescripcion;
        bool sessalud_trabajador = false;
        bool sessalud_cbssp = false;
        bool sessalud_agrario = false;
        bool sessalud_sctr = false;
        bool simpuesto_extraord = false;
        bool sderechos_sociales = false;
        bool ssenati = false;
        bool ssnp = false;
        bool sspp = false;
        bool srenta_5ta = false;
        bool sessalud_pensionista = false;
        bool scontrib_solidaria = false;
        string scalculo;
        string stipo;

        public int IdtMaestroIngresos
        {
            get { return sidtmaestroingresos; }
            set { sidtmaestroingresos = value; }
        }
        public string  Codigo
        {
            get { return scodigo; }
            set { scodigo = value; }
        }
        public string Descripcion
        {
            get { return sdescripcion; }
            set { sdescripcion = value; }
        }
        public bool Essalud_trabajador
        {
            get { return sessalud_trabajador; }
            set { sessalud_trabajador = value; }
        }
        public bool Essalud_cbssp
        {
            get { return sessalud_cbssp; }
            set { sessalud_cbssp = value; }
        }
        public bool Essalud_agrario
        {
            get { return sessalud_agrario; }
            set { sessalud_agrario = value; }
        }
        public bool Essalud_sctr
        {
            get { return sessalud_sctr; }
            set { sessalud_sctr = value; }
        }
        public bool Impuesto_extraord
        {
            get { return simpuesto_extraord; }
            set { simpuesto_extraord = value; }
        }
        public bool Derechos_sociales
        {
            get { return sderechos_sociales; }
            set { sderechos_sociales = value; }
        }
        public bool Senati
        {
            get { return ssenati; }
            set { ssenati = value; }
        }
        public bool Snp
        {
            get { return ssnp; }
            set { ssnp = value; }
        }
        public bool Spp
        {
            get { return sspp; }
            set { sspp = value; }
        }
        public bool Renta_5ta
        {
            get { return srenta_5ta; }
            set { srenta_5ta = value; }
        }
        public bool Essalud_pensionista
        {
            get { return sessalud_pensionista; }
            set { sessalud_pensionista = value; }
        }
        public bool Contrib_solidaria
        {
            get { return scontrib_solidaria; }
            set { scontrib_solidaria = value; }
        }
        public string Calculo
        {
            get { return scalculo; }
            set { scalculo = value; }
        }
        public string Tipo
        {
            get { return stipo; }
            set { stipo = value; }
        }

        public DataTable ListarMaestroIngresos(string Tipo)
        {
            return Conexion.GDatos.TraerDataTable("spListarMaestroIngresos", Tipo);
        }

        public Boolean CrearMaestroIngresos(cMaestroIngresos miMaestroIngresos)
        {
            Conexion.GDatos.Ejecutar("spCrearMaestroIngresos", miMaestroIngresos.Codigo, miMaestroIngresos.Descripcion, miMaestroIngresos.Essalud_trabajador, miMaestroIngresos.Essalud_cbssp, miMaestroIngresos.Essalud_agrario, miMaestroIngresos.Essalud_sctr, miMaestroIngresos.Impuesto_extraord, miMaestroIngresos.Derechos_sociales, miMaestroIngresos.Senati, miMaestroIngresos.Snp, miMaestroIngresos.Spp, miMaestroIngresos.Renta_5ta, miMaestroIngresos.Essalud_pensionista, miMaestroIngresos.Contrib_solidaria, miMaestroIngresos.Calculo, miMaestroIngresos.Tipo);
            return true;
        }

        public Boolean ModificarMaestroIngresos(cMaestroIngresos miMaestroIngresos)
        {
            Conexion.GDatos.Ejecutar("spModificarMaestroIngresos", miMaestroIngresos.IdtMaestroIngresos, miMaestroIngresos.Codigo, miMaestroIngresos.Descripcion, miMaestroIngresos.Essalud_trabajador, miMaestroIngresos.Essalud_cbssp, miMaestroIngresos.Essalud_agrario, miMaestroIngresos.Essalud_sctr, miMaestroIngresos.Impuesto_extraord, miMaestroIngresos.Derechos_sociales, miMaestroIngresos.Senati, miMaestroIngresos.Snp, miMaestroIngresos.Spp, miMaestroIngresos.Renta_5ta, miMaestroIngresos.Essalud_pensionista, miMaestroIngresos.Contrib_solidaria, miMaestroIngresos.Calculo, miMaestroIngresos.Tipo);
            return true;
        }

        public Boolean EliminarMaestroIngresos(int IdtMaestroIngresos)
        {
            Conexion.GDatos.Ejecutar("spELiminarMaestroIngresos", IdtMaestroIngresos);
            return true;
        }
    }
}
