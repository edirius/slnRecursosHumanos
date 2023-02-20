using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaUsuario.ExportarSunat
{
    public class cDatosPeriodo
    {
        cDatoArchivoExportacion tipoDocumento;
        cDatoArchivoExportacion numeroDocumento;
        cDatoArchivoExportacion paisEmisor;
        cDatoArchivoExportacion categoria;
        cDatoArchivoExportacion tipoRegistro;
        cDatoArchivoExportacion fechaInicio;
        cDatoArchivoExportacion fechaFin;
        cDatoArchivoExportacion indicadorTipoRegistro;
        cDatoArchivoExportacion epsServiciosPropios;

        public cDatosPeriodo()
        {
            tipoDocumento = new cDatoArchivoExportacion();
            tipoDocumento.Descripcion = "Tipo Documento";
            numeroDocumento = new cDatoArchivoExportacion();
            numeroDocumento.Descripcion = "Numero Documento";
            paisEmisor = new cDatoArchivoExportacion();
            paisEmisor.Descripcion = "Descripcion";
            categoria = new cDatoArchivoExportacion();
            categoria.Descripcion = "Categoria";
            tipoRegistro = new cDatoArchivoExportacion();
            tipoRegistro.Descripcion = "Tipo Registro";
            fechaInicio = new cDatoArchivoExportacion();
            fechaInicio.Descripcion = "Fecha Inicio";
            fechaFin = new cDatoArchivoExportacion();
            fechaFin.Descripcion = "Fecha Fin";
            indicadorTipoRegistro = new cDatoArchivoExportacion();
            indicadorTipoRegistro.Descripcion = "Indicador Tipo Registro";
            epsServiciosPropios = new cDatoArchivoExportacion();
            epsServiciosPropios.Descripcion = "EPS ";
        }

        public cDatoArchivoExportacion TipoDocumento
        {
            get
            {
                return tipoDocumento;
            }

            set
            {
                tipoDocumento = value;
            }
        }

        public cDatoArchivoExportacion NumeroDocumento
        {
            get
            {
                return numeroDocumento;
            }

            set
            {
                numeroDocumento = value;
            }
        }

        public cDatoArchivoExportacion PaisEmisor
        {
            get
            {
                return paisEmisor;
            }

            set
            {
                paisEmisor = value;
            }
        }

        public cDatoArchivoExportacion TipoRegistro
        {
            get
            {
                return tipoRegistro;
            }

            set
            {
                tipoRegistro = value;
            }
        }

        public cDatoArchivoExportacion FechaInicio
        {
            get
            {
                return fechaInicio;
            }

            set
            {
                fechaInicio = value;
            }
        }

        public cDatoArchivoExportacion FechaFin
        {
            get
            {
                return fechaFin;
            }

            set
            {
                fechaFin = value;
            }
        }

        public cDatoArchivoExportacion IndicadorTipoRegistro
        {
            get
            {
                return indicadorTipoRegistro;
            }

            set
            {
                indicadorTipoRegistro = value;
            }
        }

        public cDatoArchivoExportacion EpsServiciosPropios
        {
            get
            {
                return epsServiciosPropios;
            }

            set
            {
                epsServiciosPropios = value;
            }
        }

        public cDatoArchivoExportacion Categoria
        {
            get
            {
                return categoria;
            }

            set
            {
                categoria = value;
            }
        }
    }
}
