using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Obras
{
    public class cProductoProyecto
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
        string productoProyecto;

        public string ProductoProyecto
        {
            get { return productoProyecto; }
            set { productoProyecto = value; }
        }

        int año;

        public int Año
        {
            get { return año; }
            set { año = value; }
        }

        cProgramaPresupuestal programaPresupuestal;

        public cProgramaPresupuestal ProgramaPresupuestal
        {
            get { return programaPresupuestal; }
            set { programaPresupuestal = value; }
        }

    }
}
