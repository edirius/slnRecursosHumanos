using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDeNegocios.DatosLaborales;
using System.Data;
using CapaDeDatos;
using CapaDeNegocios.Trabajadores;

namespace CapaDeNegocios
{
    public class cPeriodo
    {
        public cPeriodo(cTrabajador miTrabajador)
        {
            trabajador = miTrabajador;
            fechaFin = new cFinPeriodo();
            motivoFinPeriodo = new cMotivoFinPeriodo();
        }

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

        private DataTable listaPeriodos;

        public DataTable ListaPeriodos
        {
            get { return listaPeriodos; }
            set { listaPeriodos = value; }
        }

        public cTrabajador Trabajador
        {
            get
            {
                return trabajador;
            }

            set
            {
                trabajador = value;
            }
        }

        public DataTable TraerPeriodos(int codigoTrabajador)
        {
            listaPeriodos = Conexion.GDatos.TraerDataTable("spTraerPeriodosTrabajador", codigoTrabajador);
            return listaPeriodos;
        }

        public Boolean CrearPeriodo(cPeriodo miPeriodo)
        {
            ValidarPeriodoParaCrear(miPeriodo);
            if (miPeriodo.fechaFin.TieneFin)
            {
                Conexion.GDatos.Ejecutar("spCrearPeriodo", miPeriodo.trabajador.IdTrabajador, miPeriodo.fechaInicio, miPeriodo.FechaFin, miPeriodo.motivoFinPeriodo.Codigo);
            }
            else
            {
                Conexion.GDatos.Ejecutar("spCrearPeriodo", miPeriodo.trabajador.IdTrabajador, miPeriodo.fechaInicio, null, null);
            }
                 return true;
        }

        public void ValidarPeriodoParaModificar(cPeriodo miPeriodo)
        {
            DataTable tAuxiliar;
            tAuxiliar = TraerPeriodos(miPeriodo.trabajador.IdTrabajador);

            DateTime auxiliarFechaInicio;
            DateTime auxiliarFechaFin;
            int auxiliarCodigo;

            for (int i = 0; i < tAuxiliar.Rows.Count; i++)
            {
                auxiliarCodigo = Convert.ToInt16(tAuxiliar.Rows[i][0]);
                auxiliarFechaInicio = Convert.ToDateTime(tAuxiliar.Rows[i][2]);
                auxiliarFechaFin = Convert.ToDateTime(tAuxiliar.Rows[i][3]);

                if (miPeriodo.codigo > auxiliarCodigo)
                {
                    if (miPeriodo.fechaInicio <= auxiliarFechaFin.Date)
                    {
                        throw new cReglaNegociosException("La fecha de Inicio no puede ser menor a las anteriores fechas");
                    }

                    if (miPeriodo.fechaFin.FechaFin.Date <= auxiliarFechaFin.Date)
                    {
                        throw new cReglaNegociosException("La fecha de Fin de periodo no puede ser menor o igual a las anteriores fechas");
                    }
                }
                else
                {
                    if (miPeriodo.codigo < auxiliarCodigo)
                    {
                        if (miPeriodo.fechaInicio.Date >= auxiliarFechaInicio.Date)
                        {
                            throw new cReglaNegociosException("La fecha de Inicio no puede ser mayor o igual a las posteriores fechas");
                        }

                        if (miPeriodo.fechaFin.FechaFin.Date  >= auxiliarFechaInicio.Date)
                        {
                            throw new cReglaNegociosException("La fecha de Fin de periodo no puede ser mayor o igual a las posteriores fechas");
                        }
                    }
                    
                }
                
            }



            //tAuxiliar = Conexion.GDatos.TraerDataTable("spValidarPeriodoFechaInicio", miPeriodo.FechaInicio, miPeriodo.TrabajadorServidorPersonal.IdTrabajador);
            //if (Convert.ToInt16(tAuxiliar.Rows[0][0].ToString()) == 1)
            //{
            //    throw new cReglaNegociosException(tAuxiliar.Rows[0][1].ToString());
            //}
            //tAuxiliar = Conexion.GDatos.TraerDataTable("spValidarPeriodoFechaFin", miPeriodo.FechaFin.FechaFin, miPeriodo.TrabajadorServidorPersonal.IdTrabajador);
            //if (Convert.ToInt16(tAuxiliar.Rows[0][0].ToString()) == 1)
            //{
            //    throw new cReglaNegociosException(tAuxiliar.Rows[0][1].ToString());
            //}
        }

        public void ValidarPeriodoParaCrear(cPeriodo miPeriodo)
        {
            DataTable tAuxiliar;
            tAuxiliar = TraerPeriodos(miPeriodo.trabajador.IdTrabajador);

            DateTime auxiliarFechaInicio;
            DateTime auxiliarFechaFin;
            int auxiliarCodigo;

            for (int i = 0; i < tAuxiliar.Rows.Count; i++)
            {
                auxiliarCodigo = Convert.ToInt16(tAuxiliar.Rows[i][0]);
                auxiliarFechaInicio = Convert.ToDateTime(tAuxiliar.Rows[i][2]);
                auxiliarFechaFin = Convert.ToDateTime(tAuxiliar.Rows[i][3]);

                    if (miPeriodo.fechaInicio <= auxiliarFechaFin.Date)
                    {
                        throw new cReglaNegociosException("La fecha de Inicio no puede ser menor a las anteriores fechas");
                    }

                    if (miPeriodo.fechaFin.FechaFin <= auxiliarFechaFin.Date)
                    {
                        throw new cReglaNegociosException("La fecha de Fin de periodo no puede ser menor o igual a las anteriores fechas");
                    }
            }
        }

        public Boolean ModificarPeriodo (cPeriodo miPeriodo)
        {
            ValidarPeriodoParaModificar(miPeriodo);
            if (miPeriodo.fechaFin.TieneFin)
            {
                Conexion.GDatos.Ejecutar("spModificarPeriodo", miPeriodo.codigo, miPeriodo.trabajador.IdTrabajador, miPeriodo.fechaInicio, miPeriodo.FechaFin.FechaFin, miPeriodo.motivoFinPeriodo.Codigo);
            }
            else
            {
                Conexion.GDatos.Ejecutar("spModificarPeriodo", miPeriodo.codigo, miPeriodo.trabajador.IdTrabajador, miPeriodo.fechaInicio, DBNull.Value, DBNull.Value);
            }
            
            return true;
        }

        public Boolean EliminarPeriodo(cPeriodo miPeriodo)
        {
            Conexion.GDatos.Ejecutar("spEliminarPeriodo", miPeriodo.codigo);
            return true;
        }

        private cTrabajador trabajador; 
       
    }
}
