using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios.DatosLaborales
{
    public class cCategoriaOcupacional
    {
        int sidtcategoriaocupacional;
        string scodigo;
        string sdescripcion;

        public int IdTCategoriaOcupacional
        {
            get { return sidtcategoriaocupacional; }
            set { sidtcategoriaocupacional = value; }
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

        public DataTable ListarCategoriaOcupacional()
        {
            return Conexion.GDatos.TraerDataTable("spListarCategoriaOcupacional");
        }

        public Boolean CrearCategoriaOcupacional(cCategoriaOcupacional miCategoriaOcupacional)
        {
            Conexion.GDatos.Ejecutar("spCrearCategoriaOcupacional", miCategoriaOcupacional.Codigo, miCategoriaOcupacional.Descripcion);
            return true;
        }

        public Boolean ModificarCategoriaOcupacional(cCategoriaOcupacional miCategoriaOcupacional)
        {
            Conexion.GDatos.Ejecutar("spModificarCategoriaOcupacional", miCategoriaOcupacional.IdTCategoriaOcupacional, miCategoriaOcupacional.Codigo, miCategoriaOcupacional.Descripcion);
            return true;
        }

        public Boolean EliminarCategoriaOcupacional(cCategoriaOcupacional miCategoriaOcupacional)
        {
            Conexion.GDatos.Ejecutar("spELiminarCategoriaOcupacional", miCategoriaOcupacional.IdTCategoriaOcupacional);
            return true;
        }
    }
}
