using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeNegocios.Clasificadores;

namespace CapaDeNegocios.ClasificadorMeta
{
    public class cDetalleClasificadorMeta
    {
        int _IdttdetalleDatosmetaclasificador;
        cClasificadorMeta _ClasificadorMeta;
        Clasificadores.cEspecifica2 _Especifica;
        string _Concepto;


        public cDetalleClasificadorMeta()
        {
            _ClasificadorMeta = new cClasificadorMeta();
            _Especifica = new cEspecifica2();
        }

        public int IdttdetalleDatosmetaclasificador
        {
            get
            {
                return _IdttdetalleDatosmetaclasificador;
            }

            set
            {
                _IdttdetalleDatosmetaclasificador = value;
            }
        }

        public cClasificadorMeta ClasificadorMeta
        {
            get
            {
                return _ClasificadorMeta;
            }

            set
            {
                _ClasificadorMeta = value;
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
