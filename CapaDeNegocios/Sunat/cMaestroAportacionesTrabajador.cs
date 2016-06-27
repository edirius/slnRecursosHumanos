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
    public class cMaestroAportacionesTrabajador
    {
        int sidtmaestroaportacionestrabajador;
        string scodigo;
        string sdescripcion;
        string scalculo;

        public int IdtMaestroAportacionesTrabajador
        {
            get { return sidtmaestroaportacionestrabajador; }
            set { sidtmaestroaportacionestrabajador = value; }
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

        public DataTable ListarMaestroAportacionesTrabajador()
        {
            return Conexion.GDatos.TraerDataTable("spListarMaestroAportacionesTrabajador");
        }

        public Boolean CrearMaestroAportacionesTrabajador(cMaestroAportacionesTrabajador miMaestroAportacionesTrabajador)
        {
            Conexion.GDatos.Ejecutar("spCrearMaestroAportacionesTrabajador", miMaestroAportacionesTrabajador.Codigo, miMaestroAportacionesTrabajador.Descripcion, miMaestroAportacionesTrabajador.Calculo);
            return true;
        }

        public Boolean ModificarMaestroAportacionesTrabajador(cMaestroAportacionesTrabajador miMaestroAportacionesTrabajador)
        {
            Conexion.GDatos.Ejecutar("spModificarMaestroAportacionesTrabajador", miMaestroAportacionesTrabajador.IdtMaestroAportacionesTrabajador, miMaestroAportacionesTrabajador.Codigo, miMaestroAportacionesTrabajador.Descripcion, miMaestroAportacionesTrabajador.Calculo);
            return true;
        }

        public Boolean EliminarMaestroAportacionesTrabajador(cMaestroAportacionesTrabajador miMaestroAportacionesTrabajador)
        {
            Conexion.GDatos.Ejecutar("spELiminarMaestroAportacionesTrabajador", miMaestroAportacionesTrabajador.IdtMaestroAportacionesTrabajador);
            return true;
        }
    }
}
