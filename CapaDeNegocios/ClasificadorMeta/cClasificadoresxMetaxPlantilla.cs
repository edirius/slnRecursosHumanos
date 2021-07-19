using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios.ClasificadorMeta
{
    public class cClasificadoresxMetaxPlantilla
    {

        public void CrearClasificadorMeta(cClasificadorMeta oClasificadorMeta)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spCrearDatosMetaClasificador", oClasificadorMeta.Meta.Codigo, oClasificadorMeta.Plantilla.Descripcion, oClasificadorMeta.Especifica.IdtEspecifica2, oClasificadorMeta.Concepto);
            }
            catch (Exception ex)
            {

                throw new cReglaNegociosException("Error al crear el clasificador-meta: " + ex.Message);
            }
        }

        public void ModificarClasificadorMeta(cClasificadorMeta oClasificadorMeta)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spModificarDatosMetaClasificador", oClasificadorMeta.Idttdatosmetaclasificador, oClasificadorMeta.Meta.Codigo, oClasificadorMeta.Plantilla.Descripcion, oClasificadorMeta.Especifica.IdtEspecifica2, oClasificadorMeta.Concepto);
            }
            catch (Exception ex)
            {

                throw new cReglaNegociosException("Error al modificar el clasificador-meta: " + ex.Message);
            }
        }

        public void EliminarClasificadorMeta(cClasificadorMeta oClasificadorMeta)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spEliminarDatosMetaClasificador", oClasificadorMeta.Idttdatosmetaclasificador);
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al eliminar el clasificador-meta: " + ex.Message);
            }
        }



        public List<cClasificadorMeta> ListaClasificadoresMeta(Planillas.cPlantillaPlanilla oPlantilla, Obras.cMeta oMeta)
        {
            try
            {
                List<cClasificadorMeta> ListaClasificadoresMeta = new List<cClasificadorMeta>();
                DataTable oTableClasificadorMeta;
                oTableClasificadorMeta = Conexion.GDatos.TraerDataTable("spTraerDatosMetaClasificador", oMeta.Codigo, oPlantilla.Descripcion);
                foreach (DataRow item in oTableClasificadorMeta.Rows)
                {
                    cClasificadorMeta oClasificador = new cClasificadorMeta();
                    oClasificador.Idttdatosmetaclasificador = Convert.ToInt16(item["idttdatosmetaclasificador"].ToString());
                    oClasificador.Meta.Codigo = Convert.ToInt16(item["idtmeta"].ToString());
                    
                    oClasificador.Plantilla.Descripcion = item["plantillaplanilla"].ToString();
                    oClasificador.Especifica.IdtEspecifica2 = Convert.ToInt16(item["idtespecifica2"].ToString());
                    oClasificador.Especifica.Codigo = item["codigo"].ToString();
                    oClasificador.Especifica.Nombre = item["nombre"].ToString();
                    oClasificador.Concepto = item["concepto"].ToString();

                    ListaClasificadoresMeta.Add(oClasificador);
                }
                return ListaClasificadoresMeta;
            }
            catch (Exception ex)
            {

                throw new cReglaNegociosException("Error al traer clasificador-meta: " + ex.Message);
            }
        }

        public DataTable BuscarMaestroIngresoXCodigo(string codigoMaestroIngreso)
        {
            return Conexion.GDatos.TraerDataTable("spBuscarTituloxCodigo", codigoMaestroIngreso);
        }
    }
}
