﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios.Planillas
{
    public class cDetallePlanillaDescuentos
    {
        int sidtdetalleplanilladescuentos;
        decimal smonto;
        int sidtmaestrodescuentos;
        int sidtdetalleplanilla;
        Sunat.cMaestroDescuentos maestroDescuento;

        public int IdtDetallePlanillaDescuentos
        {
            get { return sidtdetalleplanilladescuentos; }
            set { sidtdetalleplanilladescuentos = value; }
        }
        public decimal Monto
        {
            get { return smonto; }
            set { smonto = value; }
        }
        public int IdtMaestroDescuentos
        {
            get { return sidtmaestrodescuentos; }
            set { sidtmaestrodescuentos = value; }
        }
        public int IdtDetallePlanilla
        {
            get { return sidtdetalleplanilla; }
            set { sidtdetalleplanilla = value; }
        }

        public Sunat.cMaestroDescuentos MaestroDescuento
        {
            get
            {
                return maestroDescuento;
            }

            set
            {
                maestroDescuento = value;
            }
        }

        public DataTable ListarPlanillaXDescuentosXBoletaPago(int pidPlanilla, int pidtregimenlaboral, int pid_trabajador)
        {
            return Conexion.GDatos.TraerDataTable("spListarPlanillaXDescuentosXBoletaPago", pidPlanilla, pidtregimenlaboral, pid_trabajador);
        }

        public DataTable ListarPlanillaXDescuentos(int pidPlanilla, int idRegimenLaboral, int idTrabajador)
        {
            return Conexion.GDatos.TraerDataTable("spListarPlanillaXDescuentos", pidPlanilla, idRegimenLaboral, idTrabajador);
        }

        public DataTable ListarDetallePlanillaDescuentos(int IdtDetallePlanilla)
        {
            return Conexion.GDatos.TraerDataTable("spListarDetallePlanillaDescuentos", IdtDetallePlanilla);
        }

        public Boolean CrearDetallePlanillaDescuentos(cDetallePlanillaDescuentos miDetallePlanillaDescuentos)
        {
            Conexion.GDatos.Ejecutar("spCrearDetallePlanillaDescuentos", miDetallePlanillaDescuentos.Monto, miDetallePlanillaDescuentos.IdtMaestroDescuentos, miDetallePlanillaDescuentos.IdtDetallePlanilla);
            return true;
        }

        public Boolean ModificarDetallePlanillaDescuentos(cDetallePlanillaDescuentos miDetallePlanillaDescuentos)
        {
            Conexion.GDatos.Ejecutar("spModificarDetallePlanillaDescuentos", miDetallePlanillaDescuentos.IdtDetallePlanillaDescuentos, miDetallePlanillaDescuentos.Monto, miDetallePlanillaDescuentos.IdtMaestroDescuentos, miDetallePlanillaDescuentos.IdtDetallePlanilla);
            return true;
        }

        public Boolean EliminarDetallePlanillaDescuentos(int IdtDetallePlanillaDescuentos)
        {
            Conexion.GDatos.Ejecutar("spELiminarDetallePlanillaDescuentos", IdtDetallePlanillaDescuentos);
            return true;
        }
    }
}
