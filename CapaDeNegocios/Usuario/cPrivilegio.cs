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
        public bool MenuTrabajadores { get; set; }
        public bool MenuTareos { get; set; }
        public bool MenuMetas { get; set; }
        public bool MenuPlanillas { get; set; }
        public bool MenuTablasParametricass { get; set; }
        public bool MenuExportarDatos { get; set; }
        public bool MenuReportes { get; set; }
        public bool MenuBoletas { get;  set; }


        public DataTable ListaPrivilegios()
        {
            return Conexion.GDatos.TraerDataTable("spListaPrivilegios");
        }

        public int AgregarPrivilegio (cPrivilegio NuevoPrivilegio)
        {
            return Conexion.GDatos.Ejecutar("spCrearPrivilegios2", NuevoPrivilegio.Descripcion, NuevoPrivilegio.MenuAFP, NuevoPrivilegio.MenuUsuario, NuevoPrivilegio.MenuTrabajadores, NuevoPrivilegio.MenuTareos, NuevoPrivilegio.MenuMetas, NuevoPrivilegio.MenuPlanillas, NuevoPrivilegio.MenuTablasParametricass, NuevoPrivilegio.MenuExportarDatos, NuevoPrivilegio.MenuReportes, NuevoPrivilegio.MenuBoletas);
        }

        public int ModificarPrivilegio (cPrivilegio PrivilegioModificar)
        {
            return Conexion.GDatos.Ejecutar("spModificarPrivilegios2", PrivilegioModificar.codigo, PrivilegioModificar.Descripcion, PrivilegioModificar.MenuAFP, PrivilegioModificar.MenuUsuario, PrivilegioModificar.MenuTrabajadores, PrivilegioModificar.MenuTareos, PrivilegioModificar.MenuMetas, PrivilegioModificar.MenuPlanillas, PrivilegioModificar.MenuTablasParametricass, PrivilegioModificar.MenuExportarDatos, PrivilegioModificar.MenuReportes, PrivilegioModificar.MenuBoletas);
        }

        public int EliminarPrivilegio (cPrivilegio PrivilegioAEliminar)
        {
            return Conexion.GDatos.Ejecutar("spEliminarPrivilegios", PrivilegioAEliminar.Codigo);
        }
    }
}
