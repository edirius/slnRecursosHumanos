using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDeNegocios.DatosLaborales;
using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios
{
    public class cPeriodo
    {
        private int codigo;

        /// <summary>
        /// Codigo del Periodo en la base de datos
        /// </summary>
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        /// <summary>
        /// Fecha de Inicio del Periodo
        /// </summary>
        private DateTime fechaInicio;

        public DateTime FechaInicio
        {
            get { return fechaInicio; }
            set { fechaInicio = value; }
        }

        private cFinPeriodo fechaFin;
       
        /// <summary>
        /// Clase que contiene si existe la fecha de fin asi como la misma
        /// </summary>
        public cFinPeriodo FechaFin
        {
            get { return fechaFin; }
            set {fechaFin = value;}
        }

        /// <summary>
        /// Clase que contiene los motivos de fin de periodo
        /// </summary>
 
        private cMotivoFinPeriodo motivoFinPeriodo;

        public cMotivoFinPeriodo MotivoFinPeriodo
        {
            get { return motivoFinPeriodo; }
            set { motivoFinPeriodo = value; }
        }

        private cPeriodoTipoTrabajador[] periodoTipoTrabajador;

        /// <summary>
        /// Lista de los Periodos de Tipo de Trabajador
        /// </summary>
        public cPeriodoTipoTrabajador[] PeriodoTipoTrabajador
        {
            get { return periodoTipoTrabajador; }
            set { periodoTipoTrabajador = value; }
        }

        /// <summary>
        /// Lista de los Periodos del Sistema de Pensiones
        /// </summary>
        private cPeriodoSistemaPension[] periodosSistemaPension;

        public cPeriodoSistemaPension[] PeriodosSistemaPension
        {
            get { return periodosSistemaPension; }
            set { periodosSistemaPension = value; }
        } 


        private DataTable listaPeriodos;

        public DataTable ListaPeriodos
        {
            get { return listaPeriodos; }
            set { listaPeriodos = value; }
        }

        public DataTable TraerPeriodos(int codigoTrabajador)
        {
            listaPeriodos = Conexion.GDatos.TraerDataTable("spTraerPeriodosTrabajador", codigoTrabajador);
            return listaPeriodos;
        }

        public Boolean CrearPeriodo(cPeriodo miPeriodo, int codigoTrabajador)
        {
            ValidarPeriodo(miPeriodo);
            if (miPeriodo.fechaFin.TieneFin)
            {
                Conexion.GDatos.Ejecutar("spCrearPeriodo", codigoTrabajador, miPeriodo.fechaInicio, miPeriodo.FechaFin, miPeriodo.motivoFinPeriodo.Codigo);
            }
            else
            {
                Conexion.GDatos.Ejecutar("spCrearPeriodo", codigoTrabajador, miPeriodo.fechaInicio, null, null);
            }
                 return true;
        }

        private Boolean ValidarPeriodo(cPeriodo miPeriodo)
        {
            if (listaPeriodos.Rows.Count > 0)
            {
                DateTime fechaInicioAuxiliar;
                DateTime fechaFinAuxiliar;

                for (int i = 0; i < listaPeriodos.Rows.Count ; i++)
                {
                    fechaInicioAuxiliar = Convert.ToDateTime(listaPeriodos.Rows[i][2]);
                    fechaFinAuxiliar = Convert.ToDateTime(listaPeriodos.Rows[i][3]);

                    if (miPeriodo.fechaInicio < fechaFinAuxiliar)
                    {
                        throw new Exception("La fecha de inicio debe ser mayor a la ultima fecha de periodo");
                    }
                    else
                    {
                        return true;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean ModificarPeriodo (cPeriodo miPeriodo, int codigoTrabajador)
        {
            if (miPeriodo.fechaFin.TieneFin)
            {
                Conexion.GDatos.Ejecutar("spModificarPeriodo", miPeriodo.codigo, codigoTrabajador, miPeriodo.fechaInicio, miPeriodo.FechaFin.FechaFin, miPeriodo.motivoFinPeriodo.Codigo);
            }
            else
            {
                Conexion.GDatos.Ejecutar("spModificarPeriodo", miPeriodo.codigo, codigoTrabajador, miPeriodo.fechaInicio, DBNull.Value, DBNull.Value);
            }
            
            return true;
        }

        public Boolean EliminarPeriodo(cPeriodo miPeriodo)
        {
            Conexion.GDatos.Ejecutar("spEliminarPeriodo", miPeriodo.codigo);
            return true;
        }

        public cTrabajador cTrabajador
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }
}
