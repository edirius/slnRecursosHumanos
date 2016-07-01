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

        public DataTable ListarPlantillaPlanilla(cTipoTrabajador miTipoTrabajador)
        {
            return Conexion.GDatos.TraerDataTable("spListarPlantillaPlanilla", miTipoTrabajador.Codigo);
        }

        public Boolean CrearPlantillaPlanilla(cTipoTrabajador miTipoTrabajador, cPlantillaPlanilla miPlantillaPlanilla)
        {
            Conexion.GDatos.Ejecutar("spCrearPlantillaPlanilla", miTipoTrabajador.Codigo, miPlantillaPlanilla.Tipo, miPlantillaPlanilla.Codigo);
            return true;
        }

        public Boolean ModificarPlantillaPlanilla(cTipoTrabajador miTipoTrabajador, cPlantillaPlanilla miPlantillaPlanilla)
        {
            Conexion.GDatos.Ejecutar("spModificarPlantillaPlanilla", miPlantillaPlanilla.IdtPlantillaPlanilla, miTipoTrabajador.Codigo, miPlantillaPlanilla.Tipo, miPlantillaPlanilla.Codigo);
            return true;
        }

        public Boolean EliminarPlantillaPlanilla(cPlantillaPlanilla miPlantillaPlanilla)
        {
            Conexion.GDatos.Ejecutar("spELiminarPlantillaPlanilla", miPlantillaPlanilla.IdtPlantillaPlanilla);
            return true;
        }
    }
}
