using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Planillas
{
    public class cMaestroAportacionE
    {
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        string codigo;

        string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        string codigoSunat;

        public string CodigoSunat
        {
            get { return codigoSunat; }
            set { codigoSunat = value; }
        }

        string formula;

        public string Formula
        {
            get { return formula; }
            set { formula = value; }
        }

        string abreviacion;

        public string Codigo
        {
            get
            {
                return codigo;
            }

            set
            {
                codigo = value;
            }
        }

        public string Abreviacion
        {
            get
            {
                return abreviacion;
            }

            set
            {
                abreviacion = value;
            }
        }
    }
}
