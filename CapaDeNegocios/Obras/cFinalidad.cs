using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Obras
{
    public class cFinalidad
    {
        int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        string finalidad;

        public string Finalidad
        {
            get { return finalidad; }
            set { finalidad = value; }
        }

        cGrupoFuncional grupoFuncional;

        public cGrupoFuncional GrupoFuncional
        {
            get { return grupoFuncional; }
            set { grupoFuncional = value; }
        }

    }
}
