using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDeDatos;
using CapaDeNegocios.Obras;


namespace CapaDeNegocios.ResidenteMeta
{
    public class cResidenteMeta
    {
        int sidtresidentemeta;
        cMeta miMeta;
        cTrabajador miTrabajador;
        string meta;
        string trabajador;

        public int IdtResidenteMeta
        {
            get { return sidtresidentemeta; }
            set { sidtresidentemeta = value; }
        }

        public cMeta MiMeta
        {
            get
            {
                return miMeta;
            }

            set
            {
                miMeta = value;
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

        public string Meta
        {
            get
            {
                return meta;
            }

            set
            {
                meta = value;
            }
        }

        public string Trabajador
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

        public cResidenteMeta()
        {
            this.MiMeta = new cMeta();
            this.MiTrabajador = new cTrabajador();
        }

        public List<cResidenteMeta> TraerResidenteMeta(int año, Boolean TodasLasMetas)
        {
            try
            {
                List<cResidenteMeta> ListaResidenteMeta = new List<cResidenteMeta>();
                if (TodasLasMetas)
                {
                    CapaDeNegocios.Obras.cCadenaProgramaticaFuncional miCadena = new cCadenaProgramaticaFuncional();
                    DataTable metas = miCadena.ListarMetas(año);
                    DataTable lista = Conexion.GDatos.TraerDataTable("spListarResidenteMetaXAño", año);
                    foreach (DataRow item in metas.Rows)
                    {
                        Boolean encontrado = false;
                        foreach (DataRow item2 in lista.Rows)
                        {
                            if (Convert.ToInt32(item["idtmeta"].ToString()) == Convert.ToInt32(item2["idtmeta"].ToString()))
                            {
                                encontrado = true;
                                cResidenteMeta res = new cResidenteMeta();
                                res.IdtResidenteMeta = Convert.ToInt32(item2["idtresidentemeta"].ToString());
                                res.MiMeta.Codigo = Convert.ToInt32(item2["idtmeta"].ToString());
                                res.MiTrabajador.IdTrabajador = Convert.ToInt32(item2["idttrabajador"].ToString());
                                res.MiTrabajador.Dni = item2["dni"].ToString();
                                res.MiTrabajador.Nombres = item2["nombres"].ToString();
                                res.MiTrabajador.ApellidoPaterno = item2["apellidopaterno"].ToString();
                                res.MiTrabajador.ApellidoMaterno = item2["apellidomaterno"].ToString();
                                res.MiMeta.Año = Convert.ToInt32(item2["año"].ToString());
                                res.MiMeta.Numero = Convert.ToInt32(item2["numero"].ToString());
                                res.MiMeta.Nombre = item2["nombre"].ToString();
                                res.Meta = item2["numero"].ToString() + " - " + item2["nombre"].ToString();
                                res.Trabajador = item2["dni"].ToString() + " - " + item2["nombres"].ToString() + " " + item2["apellidopaterno"].ToString() + " " + item2["apellidomaterno"].ToString();
                                ListaResidenteMeta.Add(res);
                            }
                        }

                        if (!encontrado)
                        {
                            cResidenteMeta res = new cResidenteMeta();
                            res.IdtResidenteMeta = 0;
                            res.MiMeta.Codigo = Convert.ToInt32(item["idtmeta"].ToString());
                            res.MiTrabajador.IdTrabajador = 0;
                            res.MiMeta.Año = año;
                            res.MiMeta.Numero = 0;
                            res.MiMeta.Nombre = item["nombreMeta"].ToString();
                            res.Meta = item["nombreMeta"].ToString();
                            res.Trabajador = "NO ASIGNADO";
                            ListaResidenteMeta.Add(res);
                        }
                    }
                }
                else
                {
                    DataTable lista = Conexion.GDatos.TraerDataTable("spListarResidenteMetaXAño", año);
                    foreach (DataRow item in lista.Rows)
                    {
                        cResidenteMeta res = new cResidenteMeta();
                        res.IdtResidenteMeta = Convert.ToInt32(item["idtresidentemeta"].ToString());
                        res.MiMeta.Codigo = Convert.ToInt32(item["idtmeta"].ToString());
                        res.MiTrabajador.IdTrabajador = Convert.ToInt32(item["idttrabajador"].ToString());
                        res.MiTrabajador.Dni = item["dni"].ToString();
                        res.MiTrabajador.Nombres = item["nombres"].ToString();
                        res.MiTrabajador.ApellidoPaterno = item["apellidopaterno"].ToString();
                        res.MiTrabajador.ApellidoMaterno = item["apellidomaterno"].ToString();
                        res.MiMeta.Año = Convert.ToInt32(item["año"].ToString());
                        res.MiMeta.Numero = Convert.ToInt32(item["numero"].ToString());
                        res.MiMeta.Nombre = item["nombre"].ToString();
                        res.Meta = item["numero"].ToString() + " - " + item["nombre"].ToString();
                        res.Trabajador = item["dni"].ToString() + " - " + item["nombres"].ToString() + " " + item["apellidopaterno"].ToString() + " " + item["apellidomaterno"].ToString();
                        ListaResidenteMeta.Add(res);
                    }
                }
                
                return ListaResidenteMeta;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo TraerResidenteMeta: " + ex.Message);
            }
        }
        public DataTable ListarResidenteMeta(cTrabajador miTrabajador)
        {
            return Conexion.GDatos.TraerDataTable("spListarResidenteMeta", miTrabajador.IdTrabajador);
        }

        public Boolean CrearResidenteMeta(cMeta miMeta, cTrabajador miTrabajador)
        {
            Conexion.GDatos.Ejecutar("spCrearResidenteMeta", miMeta.Codigo, miTrabajador.IdTrabajador);
            return true;
        }

        public Boolean ModificarResidenteMeta(cResidenteMeta miResidenteMeta, cMeta miMeta, cTrabajador miTrabajador)
        {
            Conexion.GDatos.Ejecutar("spModificarResidenteMeta", miResidenteMeta.IdtResidenteMeta, miMeta.Codigo, miTrabajador.IdTrabajador);
            return true;
        }

        public Boolean EliminarResidenteMeta(cResidenteMeta miResidenteMeta)
        {
            Conexion.GDatos.Ejecutar("spELiminarResidenteMeta", miResidenteMeta.IdtResidenteMeta);
            return true;
        }
    }
}
