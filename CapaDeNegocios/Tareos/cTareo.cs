using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDeDatos;
using CapaDeNegocios.Obras;

namespace CapaDeNegocios.Tareos
{
    public class cTareo
    {
        int sidttareo;
        int snumero;
        DateTime sfechainicio;
        DateTime sfechafin;
        string sdescripcion;
        bool sestado = false;
        cMeta _Meta;
        List<cDetalleTareo> _ListaDetallesTareo;

        public cTareo()
        {
            _Meta = new cMeta();
            _ListaDetallesTareo = new List<cDetalleTareo>();
        }

        public int IdTTareo
        {
            get { return sidttareo; }
            set { sidttareo = value; }
        }

        public int Numero
        {
            get { return snumero; }
            set { snumero = value; }
        }

        public DateTime FechaInicio
        {
            get { return sfechainicio; }
            set { sfechainicio = value; }
        }

        public DateTime FechaFin
        {
            get { return sfechafin; }
            set { sfechafin = value; }
        }

        public string Descripcion
        {
            get { return sdescripcion; }
            set { sdescripcion = value; }
        }

        public bool Estado
        {
            get { return sestado; }
            set { sestado = value; }
        }

        public cMeta Meta
        {
            get
            {
                return _Meta;
            }

            set
            {
                _Meta = value;
            }
        }

        public List<cDetalleTareo> ListaDetallesTareo
        {
            get
            {
                return _ListaDetallesTareo;
            }

            set
            {
                _ListaDetallesTareo = value;
            }
        }

        public DataTable ListarTareo(int IdtMeta)
        {
            return Conexion.GDatos.TraerDataTable("spListarTareo", IdtMeta);
        }

        public Boolean CrearTareo(cTareo miTareo, cMeta miMeta)
        {
            Conexion.GDatos.Ejecutar("spCrearTareo", miTareo.Numero, miTareo.FechaInicio, miTareo.FechaFin, miTareo.Descripcion, miTareo.Estado, miMeta.Codigo);
            return true;
        }

        public Boolean ModificarTareo(cTareo miTareo, cMeta miMeta)
        {
            Conexion.GDatos.Ejecutar("spModificarTareo", miTareo.IdTTareo, miTareo.Numero, miTareo.FechaInicio, miTareo.FechaFin, miTareo.Descripcion, miTareo.Estado, miMeta.Codigo);
            return true;
        }

        public Boolean EliminarTareo(int IdTTareo)
        {
            Conexion.GDatos.Ejecutar("spELiminarTareo", IdTTareo);
            return true;
        }

        public DataTable ImprimirTareo(int IdtMeta, int IdTTareo)
        {
            return Conexion.GDatos.TraerDataTable("spTareoObras", IdtMeta, IdTTareo);
        }

        public List<cTareo> BuscarTrabajadorTareo(cTrabajador oTrabajador, DateTime MesTareo)
        {
            try
            {
                DataTable oData = new DataTable();

                oData = Conexion.GDatos.TraerDataTable("spBuscarTrabajadortareo", oTrabajador.IdTrabajador, MesTareo);

                List<cTareo> oListaTareo = new List<cTareo>();

                foreach (DataRow item in oData.Rows)
                {
                    cTareo oTareo = new cTareo();
                    cDetalleTareo oDetalle = new cDetalleTareo();

                    oTareo.IdTTareo = Convert.ToInt16(item["idttareo"].ToString());
                    oTareo.sdescripcion = item["descripcion"].ToString();
                    oTareo.Numero = Convert.ToInt16(item["numero"].ToString());
                    oTareo.FechaInicio = Convert.ToDateTime(item["fechainicio"].ToString());
                    oTareo.FechaFin = Convert.ToDateTime(item["fechafin"].ToString());
                    oTareo.Meta.Codigo = Convert.ToInt16(item["idtmeta"].ToString());
                    oTareo.Meta.Nombre = item["nombre"].ToString();
                    oTareo.Meta.Numero = Convert.ToInt32(item["numero"].ToString());
                    oDetalle.IdTDetalleTareo = Convert.ToInt32(item["idtdetalletareo"].ToString());
                    oDetalle.DiasTareo = item["diastareo"].ToString();
                    oDetalle.TotalDias = Convert.ToInt16(item["totaldias"].ToString());
                    oTareo.ListaDetallesTareo.Add(oDetalle);
                    oListaTareo.Add(oTareo);
                }

                return oListaTareo;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al buscar Trabajador en el tareo: " + ex.Message);
            }
        }
    }
}
