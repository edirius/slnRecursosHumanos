using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Obras
{
    public class cActividadObra
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

        string actividadObra;

        public string ActividadObra
        {
            get { return actividadObra; }
            set { actividadObra = value; }
        }

        int año;

        public int Año
        {
            get { return año; }
            set { año = value; }
        }

        cProductoProyecto productoProyecto;

        public cProductoProyecto ProductoProyecto
        {
            get { return productoProyecto; }
            set { productoProyecto = value; }
        }
    }
}
