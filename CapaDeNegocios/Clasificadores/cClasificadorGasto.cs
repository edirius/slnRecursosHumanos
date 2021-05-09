using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDeDatos;
namespace CapaDeNegocios.Clasificadores
{
    public class cClasificadorGasto
    {
        public List<cGenerica> ObtenerListaGenericas()
        {
            try
            {
                List<cGenerica> ListaGenericas = new List<cGenerica>();
                DataTable oTablaGenerica = Conexion.GDatos.TraerDataTable("spListarGenerica");
                foreach (DataRow item in oTablaGenerica.Rows)
                {
                    cGenerica oGenerica = new cGenerica();
                    oGenerica.Idtgenerica = Convert.ToInt16(item["idtgenerica"].ToString());
                    oGenerica.Codigo = item["codigo"].ToString();
                    oGenerica.Nombre = item["nombre"].ToString();
                    oGenerica.Descripcion = item["descripcion"].ToString();
                    ListaGenericas.Add(oGenerica);
                }
                return ListaGenericas;
            }
            catch (Exception ex)
            {

                throw new cReglaNegociosException("Error al obtener la lista de genericas: " + ex.Message);
            }
        }


        public List<cSubgenerica> ObtenerListaSubgenericas(cGenerica oGenerica)
        {
            try
            {
                List<cSubgenerica> ListaSubgenericas = new List<cSubgenerica>();
                DataTable oTableSubgenericas;
                oTableSubgenericas = Conexion.GDatos.TraerDataTable("spListarSubgenerica", oGenerica.Idtgenerica);
                foreach (DataRow item in oTableSubgenericas.Rows)
                {
                    cSubgenerica oSubgenerica = new cSubgenerica();
                    oSubgenerica.Generica.Idtgenerica = oGenerica.Idtgenerica;
                    oSubgenerica.Idtsubgenerica = Convert.ToInt16(item["idtsubgenerica"].ToString());
                    oSubgenerica.Codigo = item["codigo"].ToString();
                    oSubgenerica.Nombre = item["nombre"].ToString();
                    oSubgenerica.Descripcion = item["descripcion"].ToString();
                    ListaSubgenericas.Add(oSubgenerica);
                }
                return ListaSubgenericas;
            }
            catch (Exception ex)
            {

                throw new cReglaNegociosException("Error al obtener la lista de subgenericas: " + ex.Message);
            }
        }

        public List<cSubgenerica2> ObtenerListaSubgenericas2(cSubgenerica oSubgenerica)
        {
            try
            {
                DataTable oTableSubgenerica2;
                oTableSubgenerica2 = Conexion.GDatos.TraerDataTable("spListarSubgenerica2", oSubgenerica.Idtsubgenerica);
                List<cSubgenerica2> ListaSubgenericas2 = new List<cSubgenerica2>();
                foreach (DataRow item in oTableSubgenerica2.Rows)
                {
                    cSubgenerica2 oSubgenerica2 = new cSubgenerica2();
                    oSubgenerica2.Subgenerica.Idtsubgenerica = oSubgenerica.Idtsubgenerica;
                    oSubgenerica2.Idtsubgenerica2 = Convert.ToInt16(item["Idtsubgenerica2"].ToString());
                    oSubgenerica2.Codigo = item["codigo"].ToString();
                    oSubgenerica2.Nombre = item["nombre"].ToString();
                    oSubgenerica2.Descripcion = item["descripcion"].ToString();
                    ListaSubgenericas2.Add(oSubgenerica2);
                }
                return ListaSubgenericas2;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al traer lista subgenericas2 : " + ex.Message);
            }
        }

        public List<cEspecifica> ListaEspecificas(cSubgenerica2 oSubgenerica2)
        {
            try
            {
                List<cEspecifica> ListaEspecificas = new List<cEspecifica>();
                DataTable oTableEspecificas;
                oTableEspecificas = Conexion.GDatos.TraerDataTable("spListarEspecifica", oSubgenerica2.Idtsubgenerica2);
                foreach (DataRow item in oTableEspecificas.Rows)
                {
                    cEspecifica oEspecifica = new cEspecifica();
                    oEspecifica.Subgenerica2.Idtsubgenerica2 = oSubgenerica2.Idtsubgenerica2;
                    oEspecifica.Idtespecifica = Convert.ToInt16(item["idtespecifica"].ToString());
                    oEspecifica.Codigo = item["codigo"].ToString();
                    oEspecifica.Nombre = item["nombre"].ToString();
                    oEspecifica.Descripcion = item["descripcion"].ToString();
                    ListaEspecificas.Add(oEspecifica);
                }
                return ListaEspecificas;
            }
            catch (Exception ex)
            {

                throw new cReglaNegociosException("Error al obtener las especificas: " + ex.Message);
            }
        }

        public List<cEspecifica2> ListaEspecificas2(cEspecifica oEspecifica)
        {
            try
            {
                List<cEspecifica2> ListaEspecificas2 = new List<cEspecifica2>();
                DataTable oTableEspecificas;
                oTableEspecificas = Conexion.GDatos.TraerDataTable("spListarEspecifica2", oEspecifica.Idtespecifica);
                foreach (DataRow item in oTableEspecificas.Rows)
                {
                    cEspecifica2 oEspecifica2 = new cEspecifica2();
                    oEspecifica2.Especifica.Idtespecifica = oEspecifica.Idtespecifica;
                    oEspecifica2.IdtEspecifica2 = Convert.ToInt16(item["idtespecifica2"].ToString());
                    oEspecifica2.Codigo = item["codigo"].ToString();
                    oEspecifica2.Nombre = item["nombre"].ToString();
                    oEspecifica2.Descripcion = item["descripcion"].ToString();
                    ListaEspecificas2.Add(oEspecifica2);
                }
                return ListaEspecificas2;
            }
            catch (Exception ex)
            {

                throw  new cReglaNegociosException("Error al obtener lista de especificas: " + ex.Message);
            }
        }

        public void CrearGenerica(cGenerica oGenerica)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spCrearGenerica", oGenerica.Codigo, oGenerica.Nombre, oGenerica.Descripcion);
            }
            catch (Exception ex)
            {

                throw new cReglaNegociosException("Error al crear la generica: cClasificador.cs: " + ex.Message);
            }
        }

        public void CrearSubgenerica(cSubgenerica oSubgenerica)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spCrearSubgenerica", oSubgenerica.Generica.Idtgenerica,  oSubgenerica.Codigo, oSubgenerica.Nombre, oSubgenerica.Descripcion);
            }
            catch (Exception ex)
            {

                throw new cReglaNegociosException("Error al crear la subgenerica cClasificador.cs: " + ex.Message);
            }
        }

        public void CrearSubgenerica2 (cSubgenerica2 oSubgenerica2)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spCrearSubgenerica2", oSubgenerica2.Subgenerica.Idtsubgenerica, oSubgenerica2.Codigo, oSubgenerica2.Nombre, oSubgenerica2.Descripcion);
            }
            catch (Exception ex)
            {

                throw new cReglaNegociosException("Error al crear la subgenerica2 : cClasificador.cs: " + ex.Message);
            }
        }

        public void CrearEspecifica(cEspecifica oEspecifica)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spCrearEspecifica", oEspecifica.Subgenerica2.Idtsubgenerica2, oEspecifica.Codigo, oEspecifica.Nombre, oEspecifica.Descripcion);
            }
            catch (Exception ex)
            {

                throw new cReglaNegociosException("Error al crear la especifica: cClasificar.cs: " + ex.Message);
            }
        }

        public void CrearEspecifica2(cEspecifica2 oEspecifica2)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spCrearEspecifica2",oEspecifica2.Especifica.Idtespecifica,  oEspecifica2.Codigo, oEspecifica2.Nombre, oEspecifica2.Descripcion);
            }
            catch (Exception ex)
            {

                throw new cReglaNegociosException("Error al crear la especifica 2: cClasificadorGasto.cs: " + ex.Message);
            }
        }

        public void ModificarGenerica(cGenerica oGenerica)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spModificarGenerica", oGenerica.Idtgenerica, oGenerica.Codigo, oGenerica.Nombre, oGenerica.Descripcion );
            }
            catch (Exception ex)
            {

                throw new cReglaNegociosException("Error al modificar la generica: cClasificador.cs: " + ex.Message);
            }
        }

        public void ModificarSubgenerica(cSubgenerica oSubgenerica)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spModificarSubgenerica", oSubgenerica.Idtsubgenerica, oSubgenerica.Codigo, oSubgenerica.Nombre, oSubgenerica.Descripcion);
            }
            catch (Exception ex)
            {

                throw new cReglaNegociosException("Error al modificar la subgenerica: cClasificador.cs: " + ex.Message);
            }
        }

        public void ModificarSubgenerica2(cSubgenerica2 oSubgenerica2)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spModificarSubgenerica2", oSubgenerica2.Idtsubgenerica2, oSubgenerica2.Codigo, oSubgenerica2.Nombre, oSubgenerica2.Descripcion);
            }
            catch (Exception ex)
            {

                throw new cReglaNegociosException("Error al modificar la subgenerica2: cClasificador.cs: " + ex.Message);
            }
        }

        public void ModificarEspecifica(cEspecifica oEspecifica)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spModificarEspecifica", oEspecifica.Idtespecifica, oEspecifica.Codigo, oEspecifica.Nombre, oEspecifica.Descripcion);
            }
            catch (Exception ex)
            {

                throw new cReglaNegociosException("Error al modificar la especifica: cEspecifica:" + ex.Message);
            }
        }

        public void ModificarEspecifica2(cEspecifica2 oEspecifica2)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spModificarEspecifica2", oEspecifica2.IdtEspecifica2, oEspecifica2.Especifica.Idtespecifica, oEspecifica2.Codigo, oEspecifica2.Nombre, oEspecifica2.Descripcion);
            }
            catch (Exception ex)
            {

                throw new cReglaNegociosException("Error al modificar la especifica2: cEspecifica2: " + ex.Message);
            }
        }

        public void EliminarGenerica(cGenerica oGenerica)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spEliminarGenerica", oGenerica.Idtgenerica);
            }
            catch (Exception ex)
            {

                throw new cReglaNegociosException("Error al eliminar la Generica: cClasificador.cs: " + ex.Message);
            }
        }

        public void EliminarSubgenerica(cSubgenerica oSubgenerica)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spEliminarSubgenerica", oSubgenerica.Idtsubgenerica);
            }
            catch (Exception ex)
            {

                throw new cReglaNegociosException("Error al eliminar la subgenerica: cClasificador.cs: " + ex.Message);
            }
        }

        public void EliminarSubgenerica2(cSubgenerica2 oSubgenerica2)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spEliminarSubgenerica2", oSubgenerica2.Idtsubgenerica2);
            }
            catch (Exception ex)
            {

                throw new cReglaNegociosException("Error al eliminar la subgenerica2: cClasificador.cs: " + ex.Message);
            }
        }

        public void EliminarEspecifica(cEspecifica oEspecifica)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spEliminarEspecifica", oEspecifica.Idtespecifica);
            }
            catch (Exception ex)
            {

                throw new cReglaNegociosException("Error al eliminar la especifica: cEspecifica:" + ex.Message);
            }
        }

        public void EliminarEspecifica2(cEspecifica2 oEspecifica2)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spEliminarEspecifica2", oEspecifica2.IdtEspecifica2);
            }
            catch (Exception ex)
            {

                throw new cReglaNegociosException("Error al modificar la especifica2: cEspecifica2: " + ex.Message);
            }
        }


    }
}
