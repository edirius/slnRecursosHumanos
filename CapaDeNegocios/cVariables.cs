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
        decimal ssueldominimo;
        decimal suit;
        decimal sdieta;

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
        public decimal SueldoMinimo
        {
            get { return ssueldominimo; }
            set { ssueldominimo = value; }
        }
        public decimal UIT
        {
            get { return suit; }
            set { suit = value; }
        }
        public decimal Dieta
        {
            get { return sdieta; }
            set { sdieta = value; }
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
            Conexion.GDatos.Ejecutar("spCrearVariables", miVariables.Año, miVariables.SueldoMinimo, miVariables.UIT, miVariables.Dieta);
            return true;
        }

        public Boolean ModificarVariables(cVariables miVariables)
        {
            Conexion.GDatos.Ejecutar("spModificarVariables", miVariables.IdtVariables, miVariables.Año, miVariables.SueldoMinimo, miVariables.UIT, miVariables.Dieta);
            return true;
        }

        public Boolean EliminarVariables(int idtvariables)
        {
            Conexion.GDatos.Ejecutar("spEliminarVariables", idtvariables);
            return true;
        }
    }
}
