
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios.Tareos
{
    public class cDetalleTareo
    {
        int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        cTareo tareo;

        public cTareo Tareo
        {
            get { return tareo; }
            set { tareo = value; }
        }
        cObrero obrero;

        public cObrero Obrero
        {
            get { return obrero; }
            set { obrero = value; }
        }
        List<cDiaTareo> dias;

        public List<cDiaTareo> Dias
        {
            get { return dias; }
            set { dias = value; }
        }

        public void LLenarDiasTareo()
        {
            TimeSpan miTiempo = tareo.FechaFinal - tareo.FechaInicio;
            int auxiliarDias;
            auxiliarDias = miTiempo.Days;
            DateTime auxiliar = new DateTime();
            auxiliar = this.tareo.FechaInicio;
            for (int i = 0; i < auxiliarDias; i++)
            {
                cDiaTareo miDia = new cDiaTareo();
                miDia.Fecha = auxiliar;
                miDia.TipoDia = cEnumTipoDia.Laborado;
                auxiliar = auxiliar.AddDays(1);
                dias.Add(miDia);
            }
        }

        public Boolean marcarDiaLaborado(cDiaTareo midia )
        {
            midia.TipoDia = cEnumTipoDia.Laborado;
            return true;
        }

        public Boolean marcarDiaNoLaborado(cDiaTareo midia)
        {
            midia.TipoDia = cEnumTipoDia.NoLaborado;
            return true;
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
    }
}
