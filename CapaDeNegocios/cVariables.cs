using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios
{
    public class cVariables
    {
        int sidtvariables;
        string saño;
        int ssueldominimo;
        int suit;
        public int IdtVariables
        {
            get { return sidtvariables; }
            set { sidtvariables = value; }
        }
        public string Año
        {
            get { return saño; }
            set { saño = value; }
        }
        public int SueldoMinimo
        {
            get { return ssueldominimo; }
            set { ssueldominimo = value; }
        }
        public int UIT
        {
            get { return suit; }
            set { suit = value; }
        }

        public DataTable ListarVariables()
        {
            return Conexion.GDatos.TraerDataTable("spListarVariables");
        }
        public DataTable ListarTextBox(string año)
        {
            return Conexion.GDatos.TraerDataTable("spListarUIT", año);
        }
        public DataTable ListarUIT(string año)
        {
            return Conexion.GDatos.TraerDataTable("spListarUIT", año);
        }
        public DataTable ListarAños()
        {
            return Conexion.GDatos.TraerDataTable("spListarAños");
        }
        public Boolean CrearVariables(cVariables miVariables)
        {
            Conexion.GDatos.Ejecutar("spCrearVariables", miVariables.Año, miVariables.SueldoMinimo, miVariables.UIT);
            return true;
        }

        public Boolean ModificarVariables(cVariables miVariables)
        {
            Conexion.GDatos.Ejecutar("spModificarVariables", miVariables.IdtVariables, miVariables.Año, miVariables.SueldoMinimo, miVariables.UIT);
            return true;
        }

        public Boolean EliminarVariables(int idtvariables)
        {
            Conexion.GDatos.Ejecutar("spEliminarVariables", idtvariables);
            return true;
        }
    }
}
