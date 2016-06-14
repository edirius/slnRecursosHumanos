using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Obras
{
    public class cMeta
    {
        int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        int año;

        public int Año
        {
            get { return año; }
            set { año = value; }
        }

        string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        int numero;

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        cFinalidad finalidad;

        public cFinalidad Finalidad
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

        cActividadObra actividadObra;

        public cActividadObra ActividadObra
        {
            get { return actividadObra; }
            set { actividadObra = value; }
        }

    }
}
