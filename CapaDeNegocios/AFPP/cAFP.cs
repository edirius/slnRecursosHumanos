using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CapaDeNegocios
{
    public class cAFP
    {
        private int codigoAFP;

        public int CodigoAFP
        {
            get { return codigoAFP; }
            set { codigoAFP = value; }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string codigosunat;

        public string Codigosunat
        {
            get { return codigosunat; }
            set { codigosunat = value; }
        }

        private string tipo;

        private BindingList<cComisionesAFP> comisionesAFP;

        public BindingList<cComisionesAFP> ComisionesAFP
        {
            get { return comisionesAFP; }
            set { comisionesAFP = value; }
        }

        public cComisionesAFP cComisionesAFP
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public string Tipo
        {
            get
            {
                return tipo;
            }

            set
            {
                tipo = value;
            }
        }
    }
}
