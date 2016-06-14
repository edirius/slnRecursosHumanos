using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios
{
    public class cTrabajador
    {
        private string dni;

        public string Dni
        {
            get { return dni; }
            set { dni = value; }
        }
        private string nombres;

        public string Nombres
        {
            get { return nombres; }
            set { nombres = value; }
        }
        private string apellidoPaterno;

        public string ApellidoPaterno
        {
            get { return apellidoPaterno; }
            set { apellidoPaterno = value; }
        }
        private string apellidoMaterno;

        public string ApellidoMaterno
        {
            get { return apellidoMaterno; }
            set { apellidoMaterno = value; }
        }
        private EnumSexo sexo;

        public EnumSexo Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

        private enumEstadoCivil estadoCivil;

        public enumEstadoCivil EstadoCivil
        {
            get { return estadoCivil; }
            set { estadoCivil = value; }
        }

        private string direccion;

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        private string celularTrabajo;

        public string CelularTrabajo
        {
            get { return celularTrabajo; }
            set { celularTrabajo = value; }
        }
        private string celularPersonal;

        public string CelularPersonal
        {
            get { return celularPersonal; }
            set { celularPersonal = value; }
        }
        private int idTrabajador;

        public int IdTrabajador
        {
            get { return idTrabajador; }
            set { idTrabajador = value; }
        }
        private List<cPeriodo> periodos;

        public List<cPeriodo> Periodos
        {
            get { return periodos; }
            set { periodos = value; }
        }

        private byte[] foto;

        public byte[] Foto
        {
            get { return foto; }
            set { foto = value; }
        }
        private DateTime fechaNacimiento;

        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }

        private cNacionalidad miNacionalidad;

        public cNacionalidad MiNacionalidad
        {
            get { return miNacionalidad; }
            set { miNacionalidad = value; }
        }

        private cTipoVia miTipoVia;

        public cTipoVia MiTipoVia
        {
            get { return miTipoVia; }
            set { miTipoVia = value; }
        }

        private string nombreVia;

        public string NombreVia
        {
            get { return nombreVia; }
            set { nombreVia = value; }
        }

        private string numeroVia;

        public string NumeroVia
        {
            get { return numeroVia; }
            set { numeroVia = value; }
        }

        private string departamentoInterior;

        public string DepartamentoInterior
        {
            get { return departamentoInterior; }
            set { departamentoInterior = value; }
        }
        
        private cTipoZona miTipoZOna;

        public cTipoZona MiTipoZOna
        {
            get { return miTipoZOna; }
            set { miTipoZOna = value; }
        }

        private string nombreZona;

        public string NombreZona
        {
            get { return nombreZona; }
            set { nombreZona = value; }
        }

        private string referencia;

        public string Referencia
        {
            get { return referencia; }
            set { referencia = value; }
        }

        private cDepartamento miDepartamento;

        public cDepartamento MiDepartamento
        {
            get { return miDepartamento; }
            set { miDepartamento = value; }
        }
        private cProvincia miProvincia;

        public cProvincia MiProvincia
        {
            get { return miProvincia; }
            set { miProvincia = value; }
        }
        private cDistrito miDistrito;

        public cDistrito MiDistrito
        {
            get { return miDistrito; }
            set { miDistrito = value; }
        }

        private string correoElectronico;

        public string CorreoElectronico
        {
            get { return correoElectronico; }
            set { correoElectronico = value; }
        }


        public cTrabajador traerTrabajador(int codigoTrabajador)
        {
            cTrabajador miTrabajador = new cTrabajador();
            DataTable dt = Conexion.GDatos.TraerDataTable("spTraerTrabajador", codigoTrabajador);
            if (dt.Rows.Count > 0)
            {

                miTrabajador.idTrabajador = Convert.ToInt16(dt.Rows[0][0]);
                miTrabajador.nombres = Convert.ToString(dt.Rows[0][1]);
                miTrabajador.apellidoPaterno = Convert.ToString(dt.Rows[0][2]);
                miTrabajador.ApellidoMaterno = Convert.ToString(dt.Rows[0][3]);
                switch (Convert.ToString(dt.Rows[0][4]))
                {
                    case "M":
                        miTrabajador.sexo = EnumSexo.Masculino;
                        break;
                    case "F":
                        miTrabajador.sexo = EnumSexo.Femenino;
                        break;
                    default:
                        break;
                }
                switch (Convert.ToString(dt.Rows[0][5]))
                {
                    case "Casado":
                        miTrabajador.estadoCivil = enumEstadoCivil.Casado;
                        break;
                    case "Soltero":
                        miTrabajador.estadoCivil = enumEstadoCivil.Soltero;
                        break;
                    case "Divorciado":
                        miTrabajador.estadoCivil = enumEstadoCivil.Divorciado;
                        break;
                    case "Viudo":
                        miTrabajador.estadoCivil = enumEstadoCivil.Viudo;
                        break;
                    default:
                        break;
                }

                miTrabajador.direccion = Convert.ToString(dt.Rows[0][6]);
                miTrabajador.dni = Convert.ToString(dt.Rows[0][7]);
                miTrabajador.celularPersonal = Convert.ToString(dt.Rows[0][8]);
                miTrabajador.celularTrabajo = Convert.ToString(dt.Rows[0][9]);
                miTrabajador.fechaNacimiento = Convert.ToDateTime(dt.Rows[0][10]);
                if (dt.Rows[0][11] != DBNull.Value )
                {
                    miTrabajador.foto = (Byte[])(dt.Rows[0][11]);
                }
                else
                {
                    miTrabajador.foto = null;
                }
                miTrabajador.correoElectronico = Convert.ToString(dt.Rows[0][12]);
                miTrabajador.miTipoVia = new cTipoVia();
                miTrabajador.miTipoVia.Codigo = Convert.ToInt16(dt.Rows[0][13]);
                miTrabajador.nombreVia = Convert.ToString(dt.Rows[0][14]);
                miTrabajador.numeroVia = Convert.ToString(dt.Rows[0][15]);
                miTrabajador.departamentoInterior = Convert.ToString(dt.Rows[0][16]);
                miTrabajador.miTipoZOna = new cTipoZona();
                miTrabajador.miTipoZOna.Codigo = Convert.ToInt16(dt.Rows[0][17]);
                miTrabajador.nombreZona = Convert.ToString(dt.Rows[0][18]);
                miTrabajador.Referencia = Convert.ToString(dt.Rows[0][19]);
                miTrabajador.miDistrito = new cDistrito();
                miTrabajador.miDistrito.Codigo = Convert.ToInt16(dt.Rows[0][20]);
                miTrabajador.miNacionalidad = new cNacionalidad();
                miTrabajador.miNacionalidad.Codigo = Convert.ToInt16(dt.Rows[0][21]);

                miTrabajador.miTipoVia = miTrabajador.miTipoVia.TraerTipoVia(miTrabajador.miTipoVia.Codigo);
                miTrabajador.miTipoZOna = miTrabajador.miTipoZOna.TraerTipoZona(miTrabajador.miTipoZOna.Codigo);
                miTrabajador.miNacionalidad = miTrabajador.miNacionalidad.TraerNacionalidad(miTrabajador.miNacionalidad.Codigo);
                miTrabajador.miDistrito = miTrabajador.miDistrito.TraerDistrito(miTrabajador.miDistrito.Codigo);
                miTrabajador.MiProvincia = new cProvincia();
                miTrabajador.MiProvincia = miTrabajador.MiProvincia.TraerProvincia(miTrabajador.miDistrito.MiProvincia.Codigo );
                miTrabajador.miDepartamento = new cDepartamento();
                miTrabajador.miDepartamento = miTrabajador.miDepartamento.TraerDepartamento(miTrabajador.miProvincia.MiDepartamento.Codigo );

                return miTrabajador;
            }
            else
            {
                return null;
            }
        }

        public cAFP cAFP
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

    }
}
