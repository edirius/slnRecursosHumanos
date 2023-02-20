using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaUsuario.ExportarSunat
{
    public class cDatosIdentificacion
    {
        cDatoArchivoExportacion tipoDocumento;
        cDatoArchivoExportacion numeroDocumento;
        cDatoArchivoExportacion paisEmisor;
        cDatoArchivoExportacion fechaNacimiento;
        cDatoArchivoExportacion apellidoPaterno;
        cDatoArchivoExportacion apellidoMaterno;
        cDatoArchivoExportacion nombres;
        cDatoArchivoExportacion sexo;
        cDatoArchivoExportacion nacionalidad;
        cDatoArchivoExportacion telefonoLargaDistancia;
        cDatoArchivoExportacion telefono;
        cDatoArchivoExportacion correoElectronico;
        cDatoArchivoExportacion tipoVia;
        cDatoArchivoExportacion nombreVia;
        cDatoArchivoExportacion numeroVia;
        cDatoArchivoExportacion departamento;
        cDatoArchivoExportacion interior;
        cDatoArchivoExportacion manzana;
        cDatoArchivoExportacion lote;
        cDatoArchivoExportacion kilometro;
        cDatoArchivoExportacion block;
        cDatoArchivoExportacion etapa;
        cDatoArchivoExportacion tipoZona;
        cDatoArchivoExportacion nombreZona;
        cDatoArchivoExportacion referencia;
        cDatoArchivoExportacion ubigeo;
        cDatoArchivoExportacion tipoVia2;
        cDatoArchivoExportacion nombreVia2;
        cDatoArchivoExportacion numeroVia2;
        cDatoArchivoExportacion departamento2;
        cDatoArchivoExportacion interior2;
        cDatoArchivoExportacion manzana2;
        cDatoArchivoExportacion lote2;
        cDatoArchivoExportacion kilometro2;
        cDatoArchivoExportacion block2;
        cDatoArchivoExportacion etapa2;
        cDatoArchivoExportacion tipoZona2;
        cDatoArchivoExportacion nombreZona2;
        cDatoArchivoExportacion referencia2;
        cDatoArchivoExportacion ubigeo2;
        cDatoArchivoExportacion indicadorEssalud;

        public cDatosIdentificacion()
        {
            tipoDocumento = new cDatoArchivoExportacion();
            tipoDocumento.Descripcion = "Tipo Documento";
            numeroDocumento = new cDatoArchivoExportacion();
            numeroDocumento.Descripcion = "Numero Documento";
            paisEmisor = new cDatoArchivoExportacion();
            paisEmisor.Descripcion = "Pais Emisor";
            fechaNacimiento = new cDatoArchivoExportacion();
            fechaNacimiento.Descripcion = "Fecha Nacimiento";
            apellidoPaterno = new cDatoArchivoExportacion();
            apellidoPaterno.Descripcion = "Apellido Paterno";
            apellidoMaterno = new cDatoArchivoExportacion();
            apellidoMaterno.Descripcion = "Apellido Materno";
            nombres = new cDatoArchivoExportacion();
            nombres.Descripcion = "Nombres";
            sexo = new cDatoArchivoExportacion();
            sexo.Descripcion = "Sexo";
            nacionalidad = new cDatoArchivoExportacion();
            nacionalidad.Descripcion = "Nacionalidad";
            telefonoLargaDistancia = new cDatoArchivoExportacion();
            telefonoLargaDistancia.Descripcion = "Telefono Larga Distancia";
            telefono = new cDatoArchivoExportacion();
            telefono.Descripcion = "Telefono";
            correoElectronico = new cDatoArchivoExportacion();
            correoElectronico.Descripcion = "Correo Electronico";
            tipoVia = new cDatoArchivoExportacion();
            tipoVia.Descripcion = "Tipo Via";
            nombreVia = new cDatoArchivoExportacion();
            nombreVia.Descripcion = "Nombre Via";
            numeroVia = new cDatoArchivoExportacion();
            numeroVia.Descripcion = "Numero Via";
            departamento = new cDatoArchivoExportacion();
            departamento.Descripcion = "Departamento";
            interior = new cDatoArchivoExportacion();
            interior.Descripcion = "Interior";
            manzana = new cDatoArchivoExportacion();
            manzana.Descripcion = "Manzana";
            lote = new cDatoArchivoExportacion();
            lote.Descripcion = "Lote";
            kilometro = new cDatoArchivoExportacion();
            kilometro.Descripcion = "Descripcion";
            block = new cDatoArchivoExportacion();
            block.Descripcion = "Block";
            etapa = new cDatoArchivoExportacion();
            etapa.Descripcion = "Etapa";
            tipoZona = new cDatoArchivoExportacion();
            tipoZona.Descripcion = "Tipo Zona";
            nombreZona = new cDatoArchivoExportacion();
            nombreZona.Descripcion = "Nombre Zona";
            referencia = new cDatoArchivoExportacion();
            referencia.Descripcion = "Referencia";
            ubigeo = new cDatoArchivoExportacion();
            ubigeo.Descripcion = "Ubigeo";
            tipoVia2 = new cDatoArchivoExportacion();
            tipoVia2.Descripcion = "Tipo Via 2";
            nombreVia2 = new cDatoArchivoExportacion();
            nombreVia2.Descripcion = "Nombre Via 2";
            numeroVia2 = new cDatoArchivoExportacion();
            numeroVia2.Descripcion = "Numero Via 2";
            departamento2 = new cDatoArchivoExportacion();
            departamento2.Descripcion = "Departamento 2";
            interior2 = new cDatoArchivoExportacion();
            interior2.Descripcion = "Interior 2";
            manzana2 = new cDatoArchivoExportacion();
            manzana2.Descripcion = "Manzana 2";
            lote2 = new cDatoArchivoExportacion();
            lote2.Descripcion = "Lote 2";
            kilometro2 = new cDatoArchivoExportacion();
            kilometro2.Descripcion = "Kilometro 2";
            block2 = new cDatoArchivoExportacion();
            block2.Descripcion = "Block 2";
            etapa2 = new cDatoArchivoExportacion();
            etapa2.Descripcion = "Etapa 2";
            tipoZona2 = new cDatoArchivoExportacion();
            tipoZona2.Descripcion = "Tipo Zona 2";
            nombreZona2 = new cDatoArchivoExportacion();
            nombreZona2.Descripcion = "Nombre Zona 2";
            referencia2 = new cDatoArchivoExportacion();
            referencia2.Descripcion = "Referencia 2";
            ubigeo2 = new cDatoArchivoExportacion();
            ubigeo2.Descripcion = "Ubigeo 2";
            indicadorEssalud = new cDatoArchivoExportacion();
            indicadorEssalud.Descripcion = "Indicador Essalud";
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

        public cDatoArchivoExportacion FechaNacimiento
        {
            get
            {
                return fechaNacimiento;
            }

            set
            {
                fechaNacimiento = value;
            }
        }

        public cDatoArchivoExportacion ApellidoPaterno
        {
            get
            {
                return apellidoPaterno;
            }

            set
            {
                apellidoPaterno = value;
            }
        }

        public cDatoArchivoExportacion ApellidoMaterno
        {
            get
            {
                return apellidoMaterno;
            }

            set
            {
                apellidoMaterno = value;
            }
        }

        public cDatoArchivoExportacion Nombres
        {
            get
            {
                return nombres;
            }

            set
            {
                nombres = value;
            }
        }

        public cDatoArchivoExportacion Sexo
        {
            get
            {
                return sexo;
            }

            set
            {
                sexo = value;
            }
        }

        public cDatoArchivoExportacion Nacionalidad
        {
            get
            {
                return nacionalidad;
            }

            set
            {
                nacionalidad = value;
            }
        }

        public cDatoArchivoExportacion TelefonoLargaDistancia
        {
            get
            {
                return telefonoLargaDistancia;
            }

            set
            {
                telefonoLargaDistancia = value;
            }
        }

        public cDatoArchivoExportacion Telefono
        {
            get
            {
                return telefono;
            }

            set
            {
                telefono = value;
            }
        }

        public cDatoArchivoExportacion CorreoElectronico
        {
            get
            {
                return correoElectronico;
            }

            set
            {
                correoElectronico = value;
            }
        }

        public cDatoArchivoExportacion TipoVia
        {
            get
            {
                return tipoVia;
            }

            set
            {
                tipoVia = value;
            }
        }

        public cDatoArchivoExportacion NombreVia
        {
            get
            {
                return nombreVia;
            }

            set
            {
                nombreVia = value;
            }
        }

        public cDatoArchivoExportacion NumeroVia
        {
            get
            {
                return numeroVia;
            }

            set
            {
                numeroVia = value;
            }
        }

        public cDatoArchivoExportacion Departamento
        {
            get
            {
                return departamento;
            }

            set
            {
                departamento = value;
            }
        }

        public cDatoArchivoExportacion Interior
        {
            get
            {
                return interior;
            }

            set
            {
                interior = value;
            }
        }

        public cDatoArchivoExportacion Manzana
        {
            get
            {
                return manzana;
            }

            set
            {
                manzana = value;
            }
        }

        public cDatoArchivoExportacion Lote
        {
            get
            {
                return lote;
            }

            set
            {
                lote = value;
            }
        }

        public cDatoArchivoExportacion Kilometro
        {
            get
            {
                return kilometro;
            }

            set
            {
                kilometro = value;
            }
        }

        public cDatoArchivoExportacion Block
        {
            get
            {
                return block;
            }

            set
            {
                block = value;
            }
        }

        public cDatoArchivoExportacion Etapa
        {
            get
            {
                return etapa;
            }

            set
            {
                etapa = value;
            }
        }

        public cDatoArchivoExportacion TipoZona
        {
            get
            {
                return tipoZona;
            }

            set
            {
                tipoZona = value;
            }
        }

        public cDatoArchivoExportacion NombreZona
        {
            get
            {
                return nombreZona;
            }

            set
            {
                nombreZona = value;
            }
        }

        public cDatoArchivoExportacion Referencia
        {
            get
            {
                return referencia;
            }

            set
            {
                referencia = value;
            }
        }

        public cDatoArchivoExportacion Ubigeo
        {
            get
            {
                return ubigeo;
            }

            set
            {
                ubigeo = value;
            }
        }

        public cDatoArchivoExportacion TipoVia2
        {
            get
            {
                return tipoVia2;
            }

            set
            {
                tipoVia2 = value;
            }
        }

        public cDatoArchivoExportacion NombreVia2
        {
            get
            {
                return nombreVia2;
            }

            set
            {
                nombreVia2 = value;
            }
        }

        public cDatoArchivoExportacion NumeroVia2
        {
            get
            {
                return numeroVia2;
            }

            set
            {
                numeroVia2 = value;
            }
        }

        public cDatoArchivoExportacion Departamento2
        {
            get
            {
                return departamento2;
            }

            set
            {
                departamento2 = value;
            }
        }

        public cDatoArchivoExportacion Interior2
        {
            get
            {
                return interior2;
            }

            set
            {
                interior2 = value;
            }
        }

        public cDatoArchivoExportacion Manzana2
        {
            get
            {
                return manzana2;
            }

            set
            {
                manzana2 = value;
            }
        }

        public cDatoArchivoExportacion Lote2
        {
            get
            {
                return lote2;
            }

            set
            {
                lote2 = value;
            }
        }

        public cDatoArchivoExportacion Kilometro2
        {
            get
            {
                return kilometro2;
            }

            set
            {
                kilometro2 = value;
            }
        }

        public cDatoArchivoExportacion Block2
        {
            get
            {
                return block2;
            }

            set
            {
                block2 = value;
            }
        }

        public cDatoArchivoExportacion Etapa2
        {
            get
            {
                return etapa2;
            }

            set
            {
                etapa2 = value;
            }
        }

        public cDatoArchivoExportacion TipoZona2
        {
            get
            {
                return tipoZona2;
            }

            set
            {
                tipoZona2 = value;
            }
        }

        public cDatoArchivoExportacion NombreZona2
        {
            get
            {
                return nombreZona2;
            }

            set
            {
                nombreZona2 = value;
            }
        }

        public cDatoArchivoExportacion Referencia2
        {
            get
            {
                return referencia2;
            }

            set
            {
                referencia2 = value;
            }
        }

        public cDatoArchivoExportacion Ubigeo2
        {
            get
            {
                return ubigeo2;
            }

            set
            {
                ubigeo2 = value;
            }
        }

        public cDatoArchivoExportacion IndicadorEssalud
        {
            get
            {
                return indicadorEssalud;
            }

            set
            {
                indicadorEssalud = value;
            }
        }
    }
}
