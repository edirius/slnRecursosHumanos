using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeNegocios.Clasificadores;
using CapaDeNegocios.Obras;
using CapaDeNegocios.Planillas;

namespace CapaDeNegocios.ClasificadorMeta
{
    public class cClasificadorMeta
    {
        int _Idttdatosmetaclasificador;
        Obras.cMeta _Meta;
        Planillas.cPlantillaPlanilla _Plantilla;
        Clasificadores.cEspecifica2 _Especifica;
        string _Concepto;

        public cClasificadorMeta()
        {
            _Meta = new cMeta();
            _Plantilla = new cPlantillaPlanilla();
            _Especifica = new cEspecifica2();
        }
        public int Idttdatosmetaclasificador
        {
            get
            {
                return _Idttdatosmetaclasificador;
            }

            set
            {
                _Idttdatosmetaclasificador = value;
            }
        }

        public cMeta Meta
        {
            get
            {
                return _Meta;
            }

            set
            {
                _Meta = value;
            }
        }

        public cPlantillaPlanilla Plantilla
        {
            get
            {
                return _Plantilla;
            }

            set
            {
                _Plantilla = value;
            }
        }

        public cEspecifica2 Especifica
        {
            get
            {
                return _Especifica;
            }

            set
            {
                _Especifica = value;
            }
        }

        public string Concepto
        {
            get
            {
                return _Concepto;
            }

            set
            {
                _Concepto = value;
            }
        }
    }
}
