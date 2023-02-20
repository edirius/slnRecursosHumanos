using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaUsuario.ExportarSunat
{
    public class cDatosTrabajador
    {
        cDatoArchivoExportacion tipoDocumento;
        cDatoArchivoExportacion numeroDocumento;
        cDatoArchivoExportacion paisEmisor;
        cDatoArchivoExportacion regimenLaboral;
        cDatoArchivoExportacion situacionEducativa;
        cDatoArchivoExportacion ocupacion;
        cDatoArchivoExportacion discapacidad;
        cDatoArchivoExportacion cuspp;
        cDatoArchivoExportacion sctrPension;
        cDatoArchivoExportacion tipoContrato;
        cDatoArchivoExportacion sujetoRegimenAlternativo;
        cDatoArchivoExportacion sujetoJornadaMaxima;
        cDatoArchivoExportacion sujetoHorarioNocturno;
        cDatoArchivoExportacion sindicalizado;
        cDatoArchivoExportacion periocidadIngreso;
        cDatoArchivoExportacion montoRemuneracionBasica;
        cDatoArchivoExportacion situacion;
        cDatoArchivoExportacion renta5taExonerada;
        cDatoArchivoExportacion situacionEspecial;
        cDatoArchivoExportacion tipoPago;
        cDatoArchivoExportacion categoriaOcupacion;
        cDatoArchivoExportacion convenioPagoDobleTributacion;
        cDatoArchivoExportacion ruc;

        public cDatosTrabajador()
        {
            tipoDocumento = new cDatoArchivoExportacion();
            tipoDocumento.Descripcion = "Tipo Documento";
            numeroDocumento = new cDatoArchivoExportacion();
            numeroDocumento.Descripcion = "Numero Documento";
            paisEmisor = new cDatoArchivoExportacion();
            paisEmisor.Descripcion = "Descripcion";
            regimenLaboral = new cDatoArchivoExportacion();
            regimenLaboral.Descripcion = "Regimen Laboral";
            situacionEducativa = new cDatoArchivoExportacion();
            situacionEducativa.Descripcion = "Situacion Educativa";
            ocupacion = new cDatoArchivoExportacion();
            ocupacion.Descripcion = "Ocupacion";
            discapacidad = new cDatoArchivoExportacion();
            discapacidad.Descripcion = "Discapacidad";
            cuspp = new cDatoArchivoExportacion();
            cuspp.Descripcion = "CUSPP";
            sctrPension = new cDatoArchivoExportacion();
            sctrPension.Descripcion = "SCTR";
            tipoContrato = new cDatoArchivoExportacion();
            tipoContrato.Descripcion = "Tipo Contrato";
            sujetoRegimenAlternativo = new cDatoArchivoExportacion();
            sujetoRegimenAlternativo.Descripcion = "Sujeto Regimen Alternativo";
            sujetoJornadaMaxima = new cDatoArchivoExportacion();
            sujetoJornadaMaxima.Descripcion = "Jornada Maxima";
            sujetoHorarioNocturno = new cDatoArchivoExportacion();
            sujetoHorarioNocturno.Descripcion = "Sujeto Horario Nocturno";
            sindicalizado = new cDatoArchivoExportacion();
            sindicalizado.Descripcion = "Sindicalizado";
            periocidadIngreso = new cDatoArchivoExportacion();
            periocidadIngreso.Descripcion = "Periocidad Ingreso";
            montoRemuneracionBasica = new cDatoArchivoExportacion();
            montoRemuneracionBasica.Descripcion = "Remuneracion Basica";
            situacion = new cDatoArchivoExportacion();
            situacion.Descripcion = "Situacion";
            renta5taExonerada = new cDatoArchivoExportacion();
            renta5taExonerada.Descripcion = "Renta 5ta Exonerada";
            situacionEspecial = new cDatoArchivoExportacion();
            situacionEspecial.Descripcion = "Situacion Especial";
            tipoPago = new cDatoArchivoExportacion();
            tipoPago.Descripcion = "Tipo Pago";
            categoriaOcupacion = new cDatoArchivoExportacion();
            categoriaOcupacion.Descripcion = "Categoria Descripcion";
            convenioPagoDobleTributacion = new cDatoArchivoExportacion();
            convenioPagoDobleTributacion.Descripcion = "Convenio Pago Doble Tributacion";
            ruc = new cDatoArchivoExportacion();
            ruc.Descripcion = "RUC";
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

        public cDatoArchivoExportacion RegimenLaboral
        {
            get
            {
                return regimenLaboral;
            }

            set
            {
                regimenLaboral = value;
            }
        }

        public cDatoArchivoExportacion SituacionEducativa
        {
            get
            {
                return situacionEducativa;
            }

            set
            {
                situacionEducativa = value;
            }
        }

        public cDatoArchivoExportacion Ocupacion
        {
            get
            {
                return ocupacion;
            }

            set
            {
                ocupacion = value;
            }
        }

        public cDatoArchivoExportacion Discapacidad
        {
            get
            {
                return discapacidad;
            }

            set
            {
                discapacidad = value;
            }
        }

        public cDatoArchivoExportacion Cuspp
        {
            get
            {
                return cuspp;
            }

            set
            {
                cuspp = value;
            }
        }

        public cDatoArchivoExportacion SctrPension
        {
            get
            {
                return sctrPension;
            }

            set
            {
                sctrPension = value;
            }
        }

        public cDatoArchivoExportacion TipoContrato
        {
            get
            {
                return tipoContrato;
            }

            set
            {
                tipoContrato = value;
            }
        }

        public cDatoArchivoExportacion SujetoRegimenAlternativo
        {
            get
            {
                return sujetoRegimenAlternativo;
            }

            set
            {
                sujetoRegimenAlternativo = value;
            }
        }

        public cDatoArchivoExportacion SujetoJornadaMaxima
        {
            get
            {
                return sujetoJornadaMaxima;
            }

            set
            {
                sujetoJornadaMaxima = value;
            }
        }

        public cDatoArchivoExportacion SujetoHorarioNocturno
        {
            get
            {
                return sujetoHorarioNocturno;
            }

            set
            {
                sujetoHorarioNocturno = value;
            }
        }

        public cDatoArchivoExportacion Sindicalizado
        {
            get
            {
                return sindicalizado;
            }

            set
            {
                sindicalizado = value;
            }
        }

        public cDatoArchivoExportacion PeriocidadIngreso
        {
            get
            {
                return periocidadIngreso;
            }

            set
            {
                periocidadIngreso = value;
            }
        }

        public cDatoArchivoExportacion MontoRemuneracionBasica
        {
            get
            {
                return montoRemuneracionBasica;
            }

            set
            {
                montoRemuneracionBasica = value;
            }
        }

        public cDatoArchivoExportacion Situacion
        {
            get
            {
                return situacion;
            }

            set
            {
                situacion = value;
            }
        }

        public cDatoArchivoExportacion TipoPago
        {
            get
            {
                return tipoPago;
            }

            set
            {
                tipoPago = value;
            }
        }

        public cDatoArchivoExportacion CategoriaOcupacion
        {
            get
            {
                return categoriaOcupacion;
            }

            set
            {
                categoriaOcupacion = value;
            }
        }

        public cDatoArchivoExportacion ConvenioPagoDobleTributacion
        {
            get
            {
                return convenioPagoDobleTributacion;
            }

            set
            {
                convenioPagoDobleTributacion = value;
            }
        }

        public cDatoArchivoExportacion Ruc
        {
            get
            {
                return ruc;
            }

            set
            {
                ruc = value;
            }
        }

        public cDatoArchivoExportacion Renta5taExonerada
        {
            get
            {
                return renta5taExonerada;
            }

            set
            {
                renta5taExonerada = value;
            }
        }

        public cDatoArchivoExportacion SituacionEspecial
        {
            get
            {
                return situacionEspecial;
            }

            set
            {
                situacionEspecial = value;
            }
        }
    }
}
