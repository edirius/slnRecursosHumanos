using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using System.Data;

namespace CapaDeNegocios.Obras
{
    public class cCadenaProgramaticaFuncional
    {
        public Boolean NuevaFuncion(cFuncion miFuncion)
        {
            Conexion.GDatos.Ejecutar("spCrearFuncion", miFuncion.Nombre, miFuncion.Funcion, miFuncion.Año);
            return true;
        }

        public Boolean ModificarFuncion(cFuncion miFuncion)
        {
            Conexion.GDatos.Ejecutar("spModificarFuncion",miFuncion.Codigo, miFuncion.Nombre, miFuncion.Funcion, miFuncion.Año);
            return true;
        }

        public Boolean EliminarFuncion(cFuncion miFuncion)
        {
            Conexion.GDatos.Ejecutar("spEliminarFuncion", miFuncion.Codigo);
            return true;
        }

        public DataTable ListarFunciones()
        {
            return Conexion.GDatos.TraerDataTable("spListarFuncion");
        }

        public Boolean NuevaDivisionFuncional(cDivisionFuncional miDivisionFuncional)
        {
            Conexion.GDatos.Ejecutar("spCrearDivisionFuncional", miDivisionFuncional.Nombre, miDivisionFuncional.CodigoFuncional, miDivisionFuncional.Año, miDivisionFuncional.Funcion.Codigo);
            return true;
        }

        public Boolean ModificarDivisionFuncional (cDivisionFuncional miDivisionFuncional)
        {
            Conexion.GDatos.Ejecutar("spModificarDivisionFuncional", miDivisionFuncional.Codigo, miDivisionFuncional.Nombre, miDivisionFuncional.CodigoFuncional, miDivisionFuncional.Año, miDivisionFuncional.Funcion.Codigo);
            return true;
        }

        public Boolean EliminarDivisionFuncional (cDivisionFuncional miDivisionFuncional)
        {
            Conexion.GDatos.Ejecutar("spEliminarDivisionFuncional",miDivisionFuncional.Codigo);
            return true;
        }

        public DataTable ListarDivisionFuncional(cFuncion miFuncion)
        {
            return Conexion.GDatos.TraerDataTable ("spListarDivisionFuncional", miFuncion.Codigo);
        }

        public Boolean CrearGrupoFuncional(cGrupoFuncional miGrupoFuncional)
        {
            Conexion.GDatos.Ejecutar("spCrearGrupoFuncional",miGrupoFuncional.Nombre, miGrupoFuncional.GrupoFuncional, miGrupoFuncional.Año, miGrupoFuncional.DivisionFuncional.Codigo);
            return true;
        }

        public Boolean ModificarGrupoFuncional (cGrupoFuncional miGrupoFuncional)
        {
            Conexion.GDatos.Ejecutar("spModificarGrupoFuncional",miGrupoFuncional.Codigo, miGrupoFuncional.Nombre, miGrupoFuncional.GrupoFuncional, miGrupoFuncional.Año, miGrupoFuncional.DivisionFuncional.Codigo);
            return true;
        }

        public Boolean EliminarGrupoFuncional(cGrupoFuncional miGrupoFuncional)
        {
            Conexion.GDatos.Ejecutar("spEliminarGrupoFuncional", miGrupoFuncional.DivisionFuncional.Codigo );
            return true;
        }

        public DataTable ListarGrupoFuncional(cDivisionFuncional miDivisionFuncional)
        {
            return Conexion.GDatos.TraerDataTable("spListarGrupoFuncional", miDivisionFuncional.Codigo); 
        }

        public Boolean CrearProgramaPresupuestal(cProgramaPresupuestal miProgramaPresupuestal)
        {
            Conexion.GDatos.Ejecutar("spCrearProgramaPresupuestal", miProgramaPresupuestal.Nombre, miProgramaPresupuestal.ProgramaPresupuestal, miProgramaPresupuestal.Año);
            return true;
        }

        public Boolean ModificarProgramaPresupuestal (cProgramaPresupuestal miProgramaPresupuestal)
        {
            Conexion.GDatos.Ejecutar("spModificarProgramaPresupuestal", miProgramaPresupuestal.Codigo, miProgramaPresupuestal.Nombre, miProgramaPresupuestal.ProgramaPresupuestal, miProgramaPresupuestal.Año);
            return true;
        }

        public Boolean EliminarProgramaPresupuestal(cProgramaPresupuestal miProgramaPresupuestal)
        {
            Conexion.GDatos.Ejecutar("spEliminarProgramaPresupuestal", miProgramaPresupuestal.Codigo);
            return true;
        }

        public DataTable ListarProgramaPresupuestal ()
        {
            return Conexion.GDatos.TraerDataTable("spListarProgramaPresupuestal");
        }

        public Boolean CrearProductoProyecto(cProductoProyecto miProductoProyecto)
        {
            Conexion.GDatos.Ejecutar("spCrearProductoProyecto", miProductoProyecto.Nombre, miProductoProyecto.ProductoProyecto, miProductoProyecto.Año, miProductoProyecto.ProgramaPresupuestal.Codigo);
            return true;
        }
        public Boolean ModificarProductoProyecto(cProductoProyecto miProductoProyecto)
        {
            Conexion.GDatos.Ejecutar("spModificarProductoProyecto",miProductoProyecto.Codigo, miProductoProyecto.Nombre, miProductoProyecto.ProductoProyecto, miProductoProyecto.Año, miProductoProyecto.ProgramaPresupuestal.Codigo);
            return true;
        }

        public Boolean ELiminarProductoProyecto(cProductoProyecto miProductoProyecto)
        {
            Conexion.GDatos.Ejecutar("spEliminarProductoProyecto", miProductoProyecto.Codigo);
            return true;
        }

        public DataTable ListarProductoProyecto(cProgramaPresupuestal miProgramaPresupuestal)
        {
            return Conexion.GDatos.TraerDataTable("spListarProductoProyecto", miProgramaPresupuestal.Codigo);
        }

        public Boolean CrearActividadObra(cActividadObra miActividadObra)
        {
            Conexion.GDatos.Ejecutar("spCrearActividadObra", miActividadObra.Nombre, miActividadObra.ActividadObra, miActividadObra.Año, miActividadObra.ProductoProyecto.Codigo);
            return true;
        }

        public Boolean ModificarActividadObra(cActividadObra miActividadObra)
        {
            Conexion.GDatos.Ejecutar("spModificarActividadObra", miActividadObra.Codigo, miActividadObra.Nombre, miActividadObra.ActividadObra, miActividadObra.Año, miActividadObra.ProductoProyecto.Codigo);
            return true;
        }

        public Boolean EliminarActividadObra(cActividadObra miActividadObra)
        {
            Conexion.GDatos.Ejecutar("spEliminarActividadObra",miActividadObra.Codigo);
            return true;
        }

        public DataTable ListarActividadObra(cProductoProyecto miProductoProyecto)
        {
             return Conexion.GDatos.TraerDataTable("spListarActividadObra", miProductoProyecto.Codigo);
        }

        public Boolean  CrearMeta(cMeta miMeta)
        {
            Conexion.GDatos.Ejecutar("spCrearMeta", miMeta.Año, miMeta.Nombre, miMeta.Numero, miMeta.GrupoFuncional.Codigo, miMeta.ActividadObra.Codigo);
            return true;
        }

        public Boolean ModificarMeta(cMeta miMeta)
        {
            Conexion.GDatos.Ejecutar("spModificarMeta", miMeta.Codigo, miMeta.Año, miMeta.Nombre, miMeta.Numero, miMeta.GrupoFuncional.Codigo, miMeta.ActividadObra.Codigo);
            return true;
        }

        public Boolean  EliminarMeta(cMeta miMeta)
        {
            Conexion.GDatos.Ejecutar("spELiminarMeta", miMeta.Codigo);
            return true;
        }

        public DataTable ListarMetas()
        {
            return Conexion.GDatos.TraerDataTable("spListarMetas");
        }

        public DataTable ListarMetas(int año)
        {
            return Conexion.GDatos.TraerDataTable("spListarMetasXAño", año); 
        }
    }
}
