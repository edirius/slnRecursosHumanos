using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDeDatos;
using CapaDeNegocios.Sunat;

namespace CapaDeNegocios.Sunat
{
    public class cMaestroDescuentos
    {
        int sidtmaestrodescuentos;
        string scodigo;
        string sdescripcion;
        string scalculo;
        string sabreviacion;
        bool afectoSueldo;
        bool afectoNeto;

        public int IdtMaestroDescuentos
        {
            get { return sidtmaestrodescuentos; }
            set { sidtmaestrodescuentos = value; }
        }
        public string Codigo
        {
            get { return scodigo; }
            set { scodigo = value; }
        }
        public string Descripcion
        {
            get { return sdescripcion; }
            set { sdescripcion = value; }
        }
        public string Calculo
        {
            get { return scalculo; }
            set { scalculo = value; }
        }

        public string Abreviacion
        {
            get { return sabreviacion; }
            set { sabreviacion = value; }
        }

        public bool AfectoSueldo
        {
            get
            {
                return afectoSueldo;
            }

            set
            {
                afectoSueldo = value;
            }
        }

        public bool AfectoNeto
        {
            get
            {
                return afectoNeto;
            }

            set
            {
                afectoNeto = value;
            }
        }

        public DataTable ListarMaestroDescuentos()
        {
            return Conexion.GDatos.TraerDataTable("spListarMaestroDescuentos");
        }

        public DataTable ListarAbreviacionDeIdtmaestrodescuentos(int pidtmaestrodescuentos)
        {
            return Conexion.GDatos.TraerDataTable("spListarAbreviacionDeIdtmaestrodescuentos",pidtmaestrodescuentos);
        }

        public Boolean CrearMaestroDescuentos(cMaestroDescuentos miMaestroDescuentos)
        {
            Conexion.GDatos.Ejecutar("spCrearMaestroDescuentos", miMaestroDescuentos.Codigo, miMaestroDescuentos.Descripcion, miMaestroDescuentos.Calculo, miMaestroDescuentos.Abreviacion, miMaestroDescuentos.AfectoSueldo, miMaestroDescuentos.AfectoNeto);
            return true;
        }

        public Boolean ModificarMaestroDescuentos(cMaestroDescuentos miMaestroDescuentos)
        {
            Conexion.GDatos.Ejecutar("spModificarMaestroDescuentos", miMaestroDescuentos.IdtMaestroDescuentos, miMaestroDescuentos.Codigo, miMaestroDescuentos.Descripcion, miMaestroDescuentos.Calculo, miMaestroDescuentos.Abreviacion, miMaestroDescuentos.AfectoSueldo, miMaestroDescuentos.AfectoNeto);
            return true;
        }

        public Boolean EliminarMaestroDescuentos(cMaestroDescuentos miMaestroDescuentos)
        {
            Conexion.GDatos.Ejecutar("spELiminarMaestroDescuentos", miMaestroDescuentos.IdtMaestroDescuentos);
            return true;
        }
    }
}
