﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios.Asistencia
{
    public class cAsistenciaTrabajador
    {
        int sidtasistenciatrabajador;
        DateTime sfecha;
        string stipo;
        int sidttrabajador;

        public int IdtAsistenciaTrabajador
        {
            get { return sidtasistenciatrabajador; }
            set { sidtasistenciatrabajador = value; }
        }
        public DateTime Fecha
        {
            get { return sfecha; }
            set { sfecha = value; }
        }
        public string Tipo
        {
            get { return stipo; }
            set { stipo = value; }
        }
        public int IdtTrabajador
        {
            get { return sidttrabajador; }
            set { sidttrabajador = value; }
        }

        public DataTable ListarAsistenciaTrabajador(int IdtTrabajador)
        {
            return Conexion.GDatos.TraerDataTable("spListarAsistenciaTrabajador", IdtTrabajador);
        }

        public DataTable ListarAsistenciaTrabajadorxMes(int IdtTrabajador, DateTime mes)
        {
            return Conexion.GDatos.TraerDataTable("spListarAsistenciaTrabajadorxMes", mes, IdtTrabajador);
        }

        

        public DataTable ListarAsistenciaTrabajadorxMesxFalta(int IdtTrabajador, DateTime mes)
        {
            return Conexion.GDatos.TraerDataTable("spListarAsistenciaTrabajadorxMesxFalta", mes, IdtTrabajador);
        }


        public Boolean CrearAsistenciaTrabajador(cAsistenciaTrabajador miAsistenciaTrabajador)
        {
            Conexion.GDatos.Ejecutar("spCrearAsistenciaTrabajador", miAsistenciaTrabajador.Fecha, miAsistenciaTrabajador.Tipo, miAsistenciaTrabajador.IdtTrabajador);
            return true;
        }

        public Boolean ModificarAsistenciaTrabajador(cAsistenciaTrabajador miAsistenciaTrabajador)
        {
            Conexion.GDatos.Ejecutar("spModificarAsistenciaTrabajador", miAsistenciaTrabajador.IdtAsistenciaTrabajador, miAsistenciaTrabajador.Fecha, miAsistenciaTrabajador.Tipo, miAsistenciaTrabajador.IdtTrabajador);
            return true;
        }

        public Boolean EliminarAsistenciaTrabajador(int IdtAsistenciaTrabajador)
        {
            Conexion.GDatos.Ejecutar("spELiminarAsistenciaTrabajador", IdtAsistenciaTrabajador);
            return true;
        }
    }
}
