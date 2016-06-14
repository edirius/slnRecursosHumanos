using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDeDatos;
using CapaDeNegocios.Obras;

namespace CapaDeNegocios.Tareos
{
    public class cDiaTareo
    {

        int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        cEnumTipoDia tipoDia;

        public cEnumTipoDia TipoDia
        {
            get { return tipoDia; }
            set { tipoDia = value; }
        }

        DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }


        public Boolean NuevoDiatareo(cDiaTareo miDia)
        {
            Conexion.GDatos.Ejecutar("spCrearDiaTareo", miDia.Fecha, miDia.TipoDia.ToString(), this.codigo);
            return true;
        }

        public Boolean ModificarDiaTareo(cDiaTareo miDia)
        {
            Conexion.GDatos.Ejecutar("spModificarDiasTareo", miDia.Codigo, miDia.Fecha, miDia.TipoDia.ToString(), this.codigo);
            return true;
        }

        public Boolean ELiminarDiaTareo(cDiaTareo miDia)
        {
            Conexion.GDatos.Ejecutar("spEliminarDiaTareo", miDia.Codigo);
            return true;
        }

        public Boolean marcarDiaLaborado(cDiaTareo midia)
        {
            midia.TipoDia = cEnumTipoDia.Laborado;
            return true;
        }

        public Boolean marcarDiaNoLaborado(cDiaTareo midia)
        {
            midia.TipoDia = cEnumTipoDia.NoLaborado;
            return true;
        }
        
        //public void LLenarDiasTareo()
        //{
        //    TimeSpan miTiempo = tareo.FechaFin - tareo.FechaInicio;
        //    int auxiliarDias;
        //    auxiliarDias = miTiempo.Days;
        //    DateTime auxiliar = new DateTime();
        //    auxiliar = this.tareo.FechaInicio;
        //    for (int i = 0; i < auxiliarDias; i++)
        //    {
        //        cDiaTareo miDia = new cDiaTareo();
        //        miDia.Fecha = auxiliar;
        //        miDia.TipoDia = cEnumTipoDia.Laborado;
        //        auxiliar = auxiliar.AddDays(1);
        //        dias.Add(miDia);
        //    }
        //}
    }
}
