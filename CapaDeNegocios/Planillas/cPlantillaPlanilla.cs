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
        string stipo;
        int scodigo;
        int sidtregimenlaboral;

        public int IdtPlantillaPlanilla
        {
            get { return sidtplantillaplanilla; }
            set { sidtplantillaplanilla = value; }
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
        public int IdtRegimenLaboral
        {
            get { return sidtregimenlaboral; }
            set { sidtregimenlaboral = value; }
        }

        public DataTable ListarPlantillaPlanilla(int IdtRegimenLaboral)
        {
            return Conexion.GDatos.TraerDataTable("spListarPlantillaPlanilla", IdtRegimenLaboral);
        }

        public Boolean CrearPlantillaPlanilla(cPlantillaPlanilla miPlantillaPlanilla)
        {
            Conexion.GDatos.Ejecutar("spCrearPlantillaPlanilla", miPlantillaPlanilla.Tipo, miPlantillaPlanilla.Codigo, miPlantillaPlanilla.IdtRegimenLaboral);
            return true;
        }

        public Boolean ModificarPlantillaPlanilla(cPlantillaPlanilla miPlantillaPlanilla)
        {
            Conexion.GDatos.Ejecutar("spModificarPlantillaPlanilla", miPlantillaPlanilla.IdtPlantillaPlanilla, miPlantillaPlanilla.Tipo, miPlantillaPlanilla.Codigo, miPlantillaPlanilla.IdtRegimenLaboral);
            return true;
        }

        public Boolean EliminarPlantillaPlanilla(int IdtPlantillaPlanilla)
        {
            Conexion.GDatos.Ejecutar("spELiminarPlantillaPlanilla", IdtPlantillaPlanilla);
            return true;
        }
    }
}
