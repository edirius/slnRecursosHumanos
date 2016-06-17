using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeNegocios;
using CapaDeDatos;
using System.Data;

namespace CapaDeNegocios.DatosLaborales
{
    public class cPeriodoTipoTrabajador
    {
        public cPeriodoTipoTrabajador ()
        {
            tipoTrabajador = new cTipoTrabajador();
            fechaFinal = new cFinPeriodo();
        }

        private int codigo;


        private DateTime fechaInicio;

        public DateTime FechaInicio
        {
            get { return fechaInicio; }
            set { fechaInicio = value; }
        }
        private cFinPeriodo fechaFinal;

        public cFinPeriodo FechaFinal
        {
            get { return fechaFinal; }
            set { fechaFinal = value; }
        }

        private cTipoTrabajador tipoTrabajador;

        public cTipoTrabajador TipoTrabajador
        {
            get { return tipoTrabajador; }
            set { tipoTrabajador = value; }
        }

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

        public cTrabajador MiTrabajador
        {
            get
            {
                return miTrabajador;
            }

            set
            {
                miTrabajador = value;
            }
        }

        cTrabajador miTrabajador;


        public Boolean AgregarPeriodoTipoTrabajador(cPeriodoTipoTrabajador miPeriodo)
        {
            Conexion.GDatos.Ejecutar("spCrearPeriodoTipoTrabajador", miPeriodo.miTrabajador.IdTrabajador, miPeriodo.fechaInicio, miPeriodo.fechaFinal.FechaFin, miPeriodo.tipoTrabajador.Codigo);
            return true;
        }

        public Boolean ModificarPeriodoTipoTrabajador(cPeriodoTipoTrabajador miPeriodo)
        {
            Conexion.GDatos.Ejecutar("spModificarPeriodoTipoTrabajador", miPeriodo.codigo , miPeriodo.miTrabajador.IdTrabajador, miPeriodo.fechaInicio, miPeriodo.fechaFinal.FechaFin, miPeriodo.tipoTrabajador.Codigo);
            return true;
        }

        public Boolean EliminarPeriodoTipoTrabajador(cPeriodoTipoTrabajador miPeriodo)
        {
            Conexion.GDatos.Ejecutar("spEliminarPeriodoTipoTrabajador", miPeriodo.codigo);
            return true;
        }
    }
}
