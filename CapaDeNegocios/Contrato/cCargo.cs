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
            Conexion.GDatos.Ejecutar("EliminarCargo", miCargo.codigo);
            return true;
        }

        public DataTable ListaCargos()
        {
            return Conexion.GDatos.TraerDataTable("spListarCargos");
        }
    }
}
