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
    public class cTareoHorasAcumuladas
    {
        int sidttareohorasacumuladas;
        DateTime sfecha;
        string sdescripcion;
        string scategoria;
        double stotalhoras;
        int sidttareo;

        public int Idttareohorasacumuladas
        {
            get { return sidttareohorasacumuladas; }
            set { sidttareohorasacumuladas = value; }
        }
        public DateTime Fecha
        {
            get { return sfecha; }
            set { sfecha = value; }
        }
        public string Descripcion
        {
            get { return sdescripcion; }
            set { sdescripcion = value; }
        }
        public string Categoria
        {
            get { return scategoria; }
            set { scategoria = value; }
        }
        public double Totalhoras
        {
            get { return stotalhoras; }
            set { stotalhoras = value; }
        }
        public int Idttareo
        {
            get { return sidttareo; }
            set { sidttareo = value; }
        }

        public DataTable ListarTareoHorasAcumuladas(int idttareo)
        {
            return Conexion.GDatos.TraerDataTable("spListarTareoHorasAcumuladas", idttareo);
        }

        public Boolean CrearTareoHorasAcumuladas(cTareoHorasAcumuladas miTareoHorasAcumuladas)
        {
            Conexion.GDatos.Ejecutar("spCrearTareoHorasAcumuladas", miTareoHorasAcumuladas.Fecha, miTareoHorasAcumuladas.Descripcion, miTareoHorasAcumuladas.Categoria, miTareoHorasAcumuladas.Totalhoras, miTareoHorasAcumuladas.Idttareo);
            return true;
        }

        public Boolean ModificarTareoHorasAcumuladas(cTareoHorasAcumuladas miTareoHorasAcumuladas)
        {
            Conexion.GDatos.Ejecutar("spModificarTareoHorasAcumuladas", miTareoHorasAcumuladas.Idttareohorasacumuladas, miTareoHorasAcumuladas.Fecha, miTareoHorasAcumuladas.Descripcion, miTareoHorasAcumuladas.Categoria, miTareoHorasAcumuladas.Totalhoras, miTareoHorasAcumuladas.Idttareo);
            return true;
        }

        public Boolean EliminarTareoHorasAcumuladas(int idttareo)
        {
            Conexion.GDatos.Ejecutar("spEliminarTareoHorasAcumuladas", idttareo);
            return true;
        }

        public DataTable ImprimirTareoHorasAcumuladas(int idtmeta, string fecha)
        {
            return Conexion.GDatos.TraerDataTable("spTareoHorasAcumuladas", idtmeta, fecha);
        }
    }
}
