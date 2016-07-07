using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios.DatosLaborales
{
    public class cPeriodoTrabajador
    {
        int sidtperiodotrabajador;
        string sfechainicio;
        string sfechafin;
        int sidtmotivofinperiodo;
        int sidttrabajador;

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
        public int IdtMotivoFinPeriodo
        {
            get { return sidtmotivofinperiodo; }
            set { sidtmotivofinperiodo = value; }
        }
        public int IdtTrabajador
        {
            get { return sidttrabajador; }
            set { sidttrabajador = value; }
        }

        public DataTable ListarPeriodoTrabajador(int IdtTrabajador)
        {
            return Conexion.GDatos.TraerDataTable("spListarPeriodoTrabajador", IdtTrabajador);
        }

        public Boolean CrearPeriodoTrabajador(cPeriodoTrabajador miPeriodoTrabajador)
        {
            Conexion.GDatos.Ejecutar("spCrearPeriodoTrabajador", miPeriodoTrabajador.FechaInicio, miPeriodoTrabajador.FechaFin, miPeriodoTrabajador.IdtMotivoFinPeriodo, miPeriodoTrabajador.IdtTrabajador);
            return true;
        }

        public Boolean ModificarPeriodoTrabajador(cPeriodoTrabajador miPeriodoTrabajador)
        {
            Conexion.GDatos.Ejecutar("spModificarPeriodoTrabajador", miPeriodoTrabajador.IdtPeriodoTrabajador, miPeriodoTrabajador.FechaInicio, miPeriodoTrabajador.FechaFin, miPeriodoTrabajador.IdtMotivoFinPeriodo, miPeriodoTrabajador.IdtTrabajador);
            return true;
        }

        public Boolean EliminarPeriodoTrabajador(int IdtPeriodoTrabajador)
        {
            Conexion.GDatos.Ejecutar("spELiminarPeriodoTrabajador", IdtPeriodoTrabajador);
            return true;
        }
    }
}
