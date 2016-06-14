using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Obras
{
    public class cGrupoFuncional
    {
        int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }


        string grupoFuncional;

        public string GrupoFuncional
        {
            get { return grupoFuncional; }
            set { grupoFuncional = value; }
        }

        string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        int año;

        public int Año
        {
            get { return año; }
            set { año = value; }
        }

        cDivisionFuncional divisionFuncional;

        public cDivisionFuncional DivisionFuncional
        {
            get { return divisionFuncional; }
            set { divisionFuncional = value; }
        }
    }
}
