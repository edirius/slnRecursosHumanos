using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDeDatos;
using CapaDeNegocios.Sunat;

namespace CapaDeNegocios.DatosLaborales
{
    public class cPeriodoTrabajador
    {
        int sidtperiodotrabajador;
        string sfechainicio;
        string sfechafin;

        public int IdtPeriodoTrabajador
        {
            get { return sidtperiodotrabajador; }
            set { sidtperiodotrabajador = value; }
        }
        public string FechaInicio
        {
            get { return sfechainicio; }
            set { sfechainicio = value; }
        }
        public string FechaFin
        {
            get { return sfechafin; }
            set { sfechafin = value; }
        }

        public DataTable ListarPeriodoTrabajador(cTrabajador miTrabajador)
        {
            return Conexion.GDatos.TraerDataTable("spListarPeriodoTrabajador", miTrabajador.IdTrabajador);
        }

        public Boolean CrearPeriodoTrabajador(cPeriodoTrabajador miPeriodoTrabajador, cMotivoFinPeriodo miMotivoFinPeriodo, cTrabajador miTrabajador)
        {
            Conexion.GDatos.Ejecutar("spCrearPeriodoTrabajador", miPeriodoTrabajador.FechaInicio, miPeriodoTrabajador.FechaFin, miMotivoFinPeriodo.Codigo, miTrabajador.IdTrabajador);
            return true;
        }

        public Boolean ModificarPeriodoTrabajador(cPeriodoTrabajador miPeriodoTrabajador, cMotivoFinPeriodo miMotivoFinPeriodo, cTrabajador miTrabajador)
        {
            Conexion.GDatos.Ejecutar("spModificarPeriodoTrabajador", miPeriodoTrabajador.IdtPeriodoTrabajador, miPeriodoTrabajador.FechaInicio, miPeriodoTrabajador.FechaFin, miMotivoFinPeriodo.Codigo, miTrabajador.IdTrabajador);
            return true;
        }

        public Boolean EliminarPeriodoTrabajador(cPeriodoTrabajador miPeriodoTrabajador)
        {
            Conexion.GDatos.Ejecutar("spELiminarPeriodoTrabajador", miPeriodoTrabajador.IdtPeriodoTrabajador);
            return true;
        }
    }
}
