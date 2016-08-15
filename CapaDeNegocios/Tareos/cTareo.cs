using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDeDatos;
using CapaDeNegocios.Obras;

namespace CapaDeNegocios.Tareos
{
    public class cTareo
    {
        int sidttareo;
        int snumero;
        DateTime sfechainicio;
        DateTime sfechafin;
        string sdescripcion;
        bool sestado = false;

        public int IdTTareo
        {
            get { return sidttareo; }
            set { sidttareo = value; }
        }

        public int Numero
        {
            get { return snumero; }
            set { snumero = value; }
        }

        public DateTime FechaInicio
        {
            get { return sfechainicio; }
            set { sfechainicio = value; }
        }

        public DateTime FechaFin
        {
            get { return sfechafin; }
            set { sfechafin = value; }
        }

        public string Descripcion
        {
            get { return sdescripcion; }
            set { sdescripcion = value; }
        }

        public bool Estado
        {
            get { return sestado; }
            set { sestado = value; }
        }

        public DataTable ListarTareo(int IdtMeta)
        {
            return Conexion.GDatos.TraerDataTable("spListarTareo", IdtMeta);
        }

        public Boolean CrearTareo(cTareo miTareo, cMeta miMeta)
        {
            Conexion.GDatos.Ejecutar("spCrearTareo", miTareo.Numero, miTareo.FechaInicio, miTareo.FechaFin, miTareo.Descripcion, miTareo.Estado, miMeta.Codigo);
            return true;
        }

        public Boolean ModificarTareo(cTareo miTareo, cMeta miMeta)
        {
            Conexion.GDatos.Ejecutar("spModificarTareo", miTareo.IdTTareo, miTareo.Numero, miTareo.FechaInicio, miTareo.FechaFin, miTareo.Descripcion, miTareo.Estado, miMeta.Codigo);
            return true;
        }

        public Boolean EliminarTareo(int IdTTareo)
        {
            Conexion.GDatos.Ejecutar("spELiminarTareo", IdTTareo);
            return true;
        }
    }
}
