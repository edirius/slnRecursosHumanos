using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDeDatos;
using CapaDeNegocios.Sunat;

namespace CapaDeNegocios.Sunat
{
    public class cMaestroAportacionesEmpleador
    {
        int sidtmaestroaportacionesempleador;
        string scodigo;
        string sdescripcion;
        string scalculo;
        string sAbreviacion;

        public int IdtMaestroAportacionesEmpleador
        {
            get { return sidtmaestroaportacionesempleador; }
            set { sidtmaestroaportacionesempleador = value; }
        }
        public string Codigo
        {
            get { return scodigo; }
            set { scodigo = value; }
        }
        public string Descripcion
        {
            get { return sdescripcion; }
            set { sdescripcion = value; }
        }
        public string Calculo
        {
            get { return scalculo; }
            set { scalculo = value; }
        }
        public string Abreviacion
        {
            get { return sAbreviacion; }
            set { sAbreviacion = value; }
        }

        public DataTable ListarAbreviacionDeIdtmaestroaempleador(int pidtmaestroaempleador)
        {
            return Conexion.GDatos.TraerDataTable("spListarAbreviacionDeIdtmaestroaempleador", pidtmaestroaempleador);
        }

        public DataTable ListarMaestroAportacionesEmpleador()
        {
            return Conexion.GDatos.TraerDataTable("spListarMaestroAportacionesEmpleador");
        }

        public cMaestroAportacionesEmpleador TraerAportacionEmpleadorXId(int idAportacionEmpleador)
        {
            cMaestroAportacionesEmpleador maestroAportacion = new cMaestroAportacionesEmpleador();
            DataTable auxiliar = Conexion.GDatos.TraerDataTable("spTraerAportacionEmpleadorXID");
            if (auxiliar.Rows.Count > 0 )
            {
                maestroAportacion.IdtMaestroAportacionesEmpleador = Convert.ToInt32(auxiliar.Rows[0][0].ToString());
                maestroAportacion.Codigo = auxiliar.Rows[0][1].ToString();
                maestroAportacion.Descripcion = auxiliar.Rows[0][2].ToString();
                maestroAportacion.Calculo = auxiliar.Rows[0][3].ToString();
                maestroAportacion.Abreviacion = auxiliar.Rows[0][4].ToString();

                return maestroAportacion;

            }
            else
            {
                return null;
            }
        }

        public Boolean CrearMaestroAportacionesEmpleador(cMaestroAportacionesEmpleador miMaestroAportacionesEmpleador)
        {
            Conexion.GDatos.Ejecutar("spCrearMaestroAportacionesEmpleador", miMaestroAportacionesEmpleador.Codigo, miMaestroAportacionesEmpleador.Descripcion, miMaestroAportacionesEmpleador.Calculo,miMaestroAportacionesEmpleador.Abreviacion);
            return true;
        }

        public Boolean ModificarMaestroAportacionesEmpleador(cMaestroAportacionesEmpleador miMaestroAportacionesEmpleador)
        {
            Conexion.GDatos.Ejecutar("spModificarMaestroAportacionesEmpleador", miMaestroAportacionesEmpleador.IdtMaestroAportacionesEmpleador, miMaestroAportacionesEmpleador.Codigo, miMaestroAportacionesEmpleador.Descripcion, miMaestroAportacionesEmpleador.Calculo, miMaestroAportacionesEmpleador.Abreviacion);
            return true;
        }

        public Boolean EliminarMaestroAportacionesEmpleador(cMaestroAportacionesEmpleador miMaestroAportacionesEmpleador)
        {
            Conexion.GDatos.Ejecutar("spELiminarMaestroAportacionesEmpleador", miMaestroAportacionesEmpleador.IdtMaestroAportacionesEmpleador);
            return true;
        }
    }
}
