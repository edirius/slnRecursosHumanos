using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Obras
{
    public class cProgramaPresupuestal
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
        string programaPresupuestal;

        public string ProgramaPresupuestal
        {
            get { return programaPresupuestal; }
            set { programaPresupuestal = value; }
        }

        int año;

        public int Año
        {
            get { return año; }
            set { año = value; }
        }
    }
}
