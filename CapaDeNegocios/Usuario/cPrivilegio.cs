using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using System.Data;

namespace CapaDeNegocios.Usuario
{
    public class cPrivilegio
    {
        private int codigo;
        private string descripcion;
        private Boolean menuAFP;
        private Boolean menuUsuario;

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

        public bool MenuAFP
        {
            get
            {
                return menuAFP;
            }

            set
            {
                menuAFP = value;
            }
        }

        public bool MenuUsuario
        {
            get
            {
                return menuUsuario;
            }

            set
            {
                menuUsuario = value;
            }
        }

        public DataTable ListaPrivilegios()
        {
            return Conexion.GDatos.TraerDataTable("spListaPrivilegios");
        }

        public int AgregarPrivilegio (cPrivilegio NuevoPrivilegio)
        {
            return Conexion.GDatos.Ejecutar("spCrearPrivilegios", NuevoPrivilegio.Descripcion, NuevoPrivilegio.MenuAFP, NuevoPrivilegio.MenuUsuario);
        }

        public int ModificarPrivilegio (cPrivilegio PrivilegioModificar)
        {
            return Conexion.GDatos.Ejecutar("spModificarPrivilegios", PrivilegioModificar.codigo, PrivilegioModificar.Descripcion, PrivilegioModificar.MenuAFP, PrivilegioModificar.MenuUsuario);
        }

        public int EliminarPrivilegio (cPrivilegio PrivilegioAEliminar)
        {
            return Conexion.GDatos.Ejecutar("spEliminarPrivilegios", PrivilegioAEliminar.Codigo);
        }
    }
}
