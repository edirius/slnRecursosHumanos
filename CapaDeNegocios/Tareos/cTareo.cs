using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeNegocios.Obras;
using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios.Tareos
{
    public class cTareo
    {
        int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        DateTime fechaInicio;

        public DateTime FechaInicio
        {
            get { return fechaInicio; }
            set { fechaInicio = value; }
        }
        DateTime fechaFinal;

        public DateTime FechaFinal
        {
            get { return fechaFinal; }
            set { fechaFinal = value; }
        }

        private cTrabajador ingenieroResponsable;

        public cTrabajador IngenieroResponsable
        {
            get { return ingenieroResponsable; }
            set { ingenieroResponsable = value; }
        }


        private cMeta meta;

        public cMeta Meta
        {
            get { return meta; }
            set { meta = value; }
        }

        enumTipoTareo tipoTareo;

        public enumTipoTareo TipoTareo
        {
            get { return tipoTareo; }
            set { tipoTareo = value; }
        }

        private cDetalleTareo miDetalleTareo;

        public cDetalleTareo MiDetalleTareo
        {
            get { return miDetalleTareo; }
            set { miDetalleTareo = value; }
        }
        

        public Boolean AgregarDetalleTareo(cDetalleTareo miDetalleTareo)
        {
            Conexion.GDatos.Ejecutar("spCrearDetalleTareo", miDetalleTareo.Obrero.IdTrabajador, this.codigo);
            return true;
        }

        public Boolean ModificarDetalleTareo(cDetalleTareo miDetalleTareo)
        {
            Conexion.GDatos.Ejecutar("spModificarDetalleTareo", miDetalleTareo.Codigo, miDetalleTareo.Obrero.IdTrabajador, this.codigo);
            return true;
        }

        public Boolean EliminarDetalleTareo(cDetalleTareo miDetalleTareo)
        {
            Conexion.GDatos.Ejecutar("spEliminarDetalleTareo", miDetalleTareo.Codigo);
            return true;
        }


    }

}