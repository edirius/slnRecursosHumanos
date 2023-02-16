using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDeDatos;
using CapaDeNegocios.DatosLaborales;

namespace CapaDeNegocios.Planillas
{
    public class cPlantillaPlanilla
    {
        int sidtplantillaplanilla;
        string sdescripcion;
        int sorden;
        string stipo;
        int scodigo;
        bool stareo;

        public int IdtPlantillaPlanilla
        {
            get { return sidtplantillaplanilla; }
            set { sidtplantillaplanilla = value; }
        }
        public string Descripcion
        {
            get { return sdescripcion; }
            set { sdescripcion = value; }
        }
        public int Orden
        {
            get { return sorden; }
            set { sorden = value; }
        }
        public string Tipo
        {
            get { return stipo; }
            set { stipo = value; }
        }
        public int Codigo
        {
            get { return scodigo; }
            set { scodigo = value; }
        }

        public bool Tareo
        {
            get
            {
                return stareo;
            }

            set
            {
                stareo = value;
            }
        }

        public DataTable ListarDescripcionPlantillaPlanilla()
        {
            return Conexion.GDatos.TraerDataTable("spListarDescripcionPlantillaPlanilla");
        }

        public DataTable ListarPlantillaPlanilla(string Descripcion)
        {
            return Conexion.GDatos.TraerDataTable("spListarPlantillaPlanilla", Descripcion);
        }

        public Boolean CrearPlantillaPlanilla(cPlantillaPlanilla miPlantillaPlanilla)
        {
            Conexion.GDatos.Ejecutar("spCrearPlantillaPlanilla", miPlantillaPlanilla.Descripcion, miPlantillaPlanilla.Orden, miPlantillaPlanilla.Tipo, miPlantillaPlanilla.Codigo, miPlantillaPlanilla.Tareo);
            return true;
        }

        public Boolean ModificarPlantillaPlanilla(cPlantillaPlanilla miPlantillaPlanilla)
        {
            Conexion.GDatos.Ejecutar("spModificarPlantillaPlanilla", miPlantillaPlanilla.IdtPlantillaPlanilla, miPlantillaPlanilla.Descripcion, miPlantillaPlanilla.Orden, miPlantillaPlanilla.Tipo, miPlantillaPlanilla.Codigo, miPlantillaPlanilla.Tareo);
            return true;
        }

        public Boolean EliminarPlantillaPlanilla(int IdtPlantillaPlanilla)
        {
            Conexion.GDatos.Ejecutar("spELiminarPlantillaPlanilla", IdtPlantillaPlanilla);
            return true;
        }
    }
}
