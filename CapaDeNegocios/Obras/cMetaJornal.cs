using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDeDatos;
using CapaDeNegocios.Obras;

namespace CapaDeNegocios.Obras
{
    public class cMetaJornal
    {
        int sidtmetajornal;
        string scategoria;
        double sjornal;

        public int IdtMetaJornal
        {
            get { return sidtmetajornal; }
            set { sidtmetajornal = value; }
        }
        public string Categoria
        {
            get { return scategoria; }
            set { scategoria = value; }
        }
        public double Jornal
        {
            get { return sjornal; }
            set { sjornal = value; }
        }

        public DataTable ListarMetaJornal(int Codigo)
        {
            return Conexion.GDatos.TraerDataTable("spListarMetaJornal", Codigo);
        }

        public Boolean CrearMetaJornal(cMetaJornal miMetaJornal, cMeta miMeta)
        {
            Conexion.GDatos.Ejecutar("spCrearMetaJornal", miMetaJornal.Categoria, miMetaJornal.Jornal, miMeta.Codigo);
            return true;
        }

        public Boolean ModificarMetaJornal(cMetaJornal miMetaJornal, cMeta miMeta)
        {
            Conexion.GDatos.Ejecutar("spModificarMetaJornal", miMetaJornal.IdtMetaJornal, miMetaJornal.Categoria, miMetaJornal.Jornal, miMeta.Codigo);
            return true;
        }

        public Boolean EliminarMetaJornal(int IdtMetaJornal)
        {
            Conexion.GDatos.Ejecutar("spELiminarMetaJornal", IdtMetaJornal);
            return true;
        }
    }
}
