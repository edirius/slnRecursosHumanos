using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios
{
    public class cFuenteFinanciamiento
    {
        int sidtfuentefinanciamiento;
        string scodigo;
        string sdescripcion;

        public int IdTFuenteFinanciamiento
        {
            get { return sidtfuentefinanciamiento; }
            set { sidtfuentefinanciamiento = value; }
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

        public DataTable ListarFuenteFinanciamiento()
        {
            return Conexion.GDatos.TraerDataTable("spListarFuenteFinanciamiento");
        }

        public Boolean CrearFuenteFinanciamiento(cFuenteFinanciamiento miFuenteFinanciamiento)
        {
            Conexion.GDatos.Ejecutar("spCrearFuenteFinanciamiento", miFuenteFinanciamiento.Codigo, miFuenteFinanciamiento.Descripcion);
            return true;
        }

        public Boolean ModificarFuenteFinanciamiento(cFuenteFinanciamiento miFuenteFinanciamiento)
        {
            Conexion.GDatos.Ejecutar("spModificarFuenteFinanciamiento", miFuenteFinanciamiento.IdTFuenteFinanciamiento, miFuenteFinanciamiento.Codigo, miFuenteFinanciamiento.Descripcion);
            return true;
        }

        public Boolean EliminarFuenteFinanciamiento(int IdTFuenteFinanciamiento)
        {
            Conexion.GDatos.Ejecutar("spELiminarFuenteFinanciamiento", IdTFuenteFinanciamiento);
            return true;
        }
    }
}
