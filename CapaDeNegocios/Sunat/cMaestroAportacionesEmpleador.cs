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
    public class cMaestroAportacionesEmpleador
    {
        int sidtmaestroaportacionesempleador;
        string scodigo;
        string sdescripcion;
        string scalculo;

        public int IdtMaestroAportacionesEmpleador
        {
            get { return sidtmaestroaportacionesempleador; }
            set { sidtmaestroaportacionesempleador = value; }
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

        public DataTable ListarMaestroAportacionesEmpleador()
        {
            return Conexion.GDatos.TraerDataTable("spListarMaestroAportacionesEmpleador");
        }

        public Boolean CrearMaestroAportacionesEmpleador(cMaestroAportacionesEmpleador miMaestroAportacionesEmpleador)
        {
            Conexion.GDatos.Ejecutar("spCrearMaestroAportacionesEmpleador", miMaestroAportacionesEmpleador.Codigo, miMaestroAportacionesEmpleador.Descripcion, miMaestroAportacionesEmpleador.Calculo);
            return true;
        }

        public Boolean ModificarMaestroAportacionesEmpleador(cMaestroAportacionesEmpleador miMaestroAportacionesEmpleador)
        {
            Conexion.GDatos.Ejecutar("spModificarMaestroAportacionesEmpleador", miMaestroAportacionesEmpleador.IdtMaestroAportacionesEmpleador, miMaestroAportacionesEmpleador.Codigo, miMaestroAportacionesEmpleador.Descripcion, miMaestroAportacionesEmpleador.Calculo);
            return true;
        }

        public Boolean EliminarMaestroAportacionesEmpleador(cMaestroAportacionesEmpleador miMaestroAportacionesEmpleador)
        {
            Conexion.GDatos.Ejecutar("spELiminarMaestroAportacionesEmpleador", miMaestroAportacionesEmpleador.IdtMaestroAportacionesEmpleador);
            return true;
        }
    }
}
