using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using System.Data;

namespace CapaDeNegocios.Contrato
{
    public class cCargo
    {
        int codigo;
        string descripcion;

        public int Codigo
        {
            get
            {
                return codigo;
            }

            set
            {
                codigo = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }

        public Boolean AgregarCargo (cCargo miCargo)
        {
            Conexion.GDatos.Ejecutar("spCrearCargo", miCargo.descripcion);
            return true;
        }

        public Boolean ModificarCargo (cCargo miCargo)
        {
            Conexion.GDatos.Ejecutar("spModificarCargo", miCargo.codigo, miCargo.descripcion);
            return true;
        }

        public Boolean EliminarCargo (cCargo miCargo)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spEliminarCargo", miCargo.codigo);
                return true;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al eliminar el cargo: Verifique que no se haya usado en algun trabajador: " + ex.Message);
            }
            
        }

        public DataTable ListaCargos()
        {
            return Conexion.GDatos.TraerDataTable("spListarCargos");
        }
    }
}
