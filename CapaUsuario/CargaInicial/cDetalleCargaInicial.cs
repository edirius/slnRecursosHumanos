using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeNegocios;
using CapaDeNegocios.DatosLaborales;

namespace CapaUsuario.CargaInicial
{
    public class cDetalleCargaInicial
    {
        private cTrabajador miTrabajador;
        private CapaDeNegocios.DatosLaborales.cPeriodoTrabajador miPeriodo;
        private CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador miPeriodoAFP;
        private cRegimenSaludTrabajador miPeriodoSalud;
        private CapaDeNegocios.DatosLaborales.cRegimenTrabajador miTipoTrabajador;

        public cDetalleCargaInicial()
        {
            miTrabajador = new cTrabajador();
            miPeriodo = new cPeriodoTrabajador();
            miPeriodoAFP = new cRegimenPensionarioTrabajador();
            miPeriodoSalud = new cRegimenSaludTrabajador();
            miTipoTrabajador = new cRegimenTrabajador();
        }

        public cTrabajador MiTrabajador
        {
            get
            {
                return miTrabajador;
            }

            set
            {
                miTrabajador = value;
            }
        }

        public cPeriodoTrabajador MiPeriodo
        {
            get
            {
                return miPeriodo;
            }

            set
            {
                miPeriodo = value;
            }
        }

        public cRegimenPensionarioTrabajador MiPeriodoAFP
        {
            get
            {
                return miPeriodoAFP;
            }

            set
            {
                miPeriodoAFP = value;
            }
        }

        public cRegimenTrabajador MiTipoTrabajador
        {
            get
            {
                return miTipoTrabajador;
            }

            set
            {
                miTipoTrabajador = value;
            }
        }

       
    }
}
