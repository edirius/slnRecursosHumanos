using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDeDatos;
using CapaDeNegocios.Obras;


namespace CapaDeNegocios.ResidenteMeta
{
    public class cResidenteMeta
    {
        int sidtresidentemeta;

        public int IdtResidenteMeta
        {
            get { return sidtresidentemeta; }
            set { sidtresidentemeta = value; }
        }

        public DataTable ListarResidenteMeta(cTrabajador miTrabajador)
        {
            return Conexion.GDatos.TraerDataTable("spListarResidenteMeta", miTrabajador.IdTrabajador);
        }

        public Boolean CrearResidenteMeta(cMeta miMeta, cTrabajador miTrabajador)
        {
            Conexion.GDatos.Ejecutar("spCrearResidenteMeta", miMeta.Codigo, miTrabajador.IdTrabajador);
            return true;
        }

        public Boolean ModificarResidenteMeta(cResidenteMeta miResidenteMeta, cMeta miMeta, cTrabajador miTrabajador)
        {
            Conexion.GDatos.Ejecutar("spModificarResidenteMeta", miResidenteMeta.IdtResidenteMeta, miMeta.Codigo, miTrabajador.IdTrabajador);
            return true;
        }

        public Boolean EliminarResidenteMeta(cResidenteMeta miResidenteMeta)
        {
            Conexion.GDatos.Ejecutar("spELiminarResidenteMeta", miResidenteMeta.IdtResidenteMeta);
            return true;
        }
    }
}
