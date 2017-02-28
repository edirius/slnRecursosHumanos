using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.PlanillaNueva
{
    public class cPeriodoRegimenPensionario
    {
        public cPeriodoRegimenPensionario ()
        {
            MiAFP = new cAFP();
        }
        int idRegimenPensionario;
        DateTime fechaInicio;
        DateTime fechaFin;
        string cuspp;
        string tipoComision;
        cAFP miAFP;

        public int IdRegimenPensionario
        {
            get
            {
                return idRegimenPensionario;
            }

            set
            {
                idRegimenPensionario = value;
            }
        }

        public DateTime FechaInicio
        {
            get
            {
                return fechaInicio;
            }

            set
            {
                fechaInicio = value;
            }
        }

        public DateTime FechaFin
        {
            get
            {
                return fechaFin;
            }

            set
            {
                fechaFin = value;
            }
        }

        public string Cuspp
        {
            get
            {
                return cuspp;
            }

            set
            {
                cuspp = value;
            }
        }

        public string TipoComision
        {
            get
            {
                return tipoComision;
            }

            set
            {
                tipoComision = value;
            }
        }

        public cAFP MiAFP
        {
            get
            {
                return miAFP;
            }

            set
            {
                miAFP = value;
            }
        }
    }
}
