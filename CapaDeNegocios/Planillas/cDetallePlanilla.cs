using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Planillas
{
    public class cDetallePlanilla
    {
        int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        cTrabajador trabajador;

        public cTrabajador Trabajador
        {
            get { return trabajador; }
            set { trabajador = value; }
        }
        cDescuentos[] listaDescuentos;

        public cDescuentos[] ListaDescuentos
        {
            get { return listaDescuentos; }
            set { listaDescuentos = value; }
        }
        cAportaciones[] listaAportaciones;

        public cAportaciones[] ListaAportaciones
        {
            get { return listaAportaciones; }
            set { listaAportaciones = value; }
        }
        cIngresos[] listaIngresos;

        public cIngresos[] ListaIngresos
        {
            get { return listaIngresos; }
            set { listaIngresos = value; }
        }


    }
}
