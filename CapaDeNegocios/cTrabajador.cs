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

        public cTrabajador()
        {
            this.miDepartamento = new cDepartamento();
            this.MiDistrito = new cDistrito();
            this.miNacionalidad = new cNacionalidad();
            this.miProvincia = new cProvincia();
            this.miTipoVia = new cTipoVia();
            this.miTipoZOna = new cTipoZona();
            
        }
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
        private Boolean essaludvida;

        public bool Essaludvida
        {
            get { return essaludvida; }
            set { essaludvida = value; }
        }
        private Boolean ssuspencionrenta4ta;

        public bool Suspencionrenta4ta
        {
            get { return ssuspencionrenta4ta; }
            set { ssuspencionrenta4ta = value; }
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
                miTrabajador.essaludvida  = Convert.ToBoolean(dt.Rows[0][22]);
                miTrabajador.ssuspencionrenta4ta = Convert.ToBoolean(dt.Rows[0][23]);

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

        public Boolean AgregarTrabajador(cTrabajador trabajador)
        {
            string sexo = "";
            int essalud= 0;

            switch (trabajador.Sexo)
            {
                case EnumSexo.Masculino:
                    sexo = "M";
                    break;
                case EnumSexo.Femenino:
                    sexo = "F";
                    break;
                default:

                    break;
            }

            switch (trabajador.essaludvida)     
            {
                case true:
                    essalud = 1;
                    break;
                case false:
                    essalud = 0;
                    break;
                default:
                    break;
            }
            Conexion.GDatos.Ejecutar("spCrearTrabajador", trabajador.Nombres, trabajador.ApellidoPaterno, trabajador.ApellidoMaterno, sexo, trabajador.EstadoCivil.ToString(), trabajador.Direccion, trabajador.Dni, trabajador.CelularPersonal, trabajador.CelularTrabajo, trabajador.FechaNacimiento, trabajador.Foto, trabajador.CorreoElectronico, trabajador.MiTipoVia.Codigo, trabajador.NombreVia, trabajador.NumeroVia, trabajador.DepartamentoInterior, trabajador.MiTipoZOna.Codigo, trabajador.NombreZona, trabajador.Referencia, trabajador.MiDistrito.Codigo, trabajador.MiNacionalidad.Codigo, essalud, trabajador.Suspencionrenta4ta);

            return true;
        }

        public Boolean ModificarTrabajador(cTrabajador trabajador)
        {
            string sexo = "";
            int essalud = 0;
            switch (trabajador.Sexo)
            {
                case EnumSexo.Masculino:
                    sexo = "M";
                    break;
                case EnumSexo.Femenino:
                    sexo = "F";
                    break;
                default:

                    break;
            }

            switch (trabajador.essaludvida)
            {
                case true:
                    essalud = 1;
                    break;
                case false:
                    essalud = 0;
                    break;
                default:
                    break;
            }

            Conexion.GDatos.Ejecutar("spModificarTrabajador", trabajador.IdTrabajador, trabajador.Nombres, trabajador.ApellidoPaterno, trabajador.ApellidoMaterno, sexo, trabajador.EstadoCivil.ToString(), trabajador.Direccion, trabajador.Dni, trabajador.CelularPersonal, trabajador.CelularTrabajo, trabajador.FechaNacimiento, trabajador.Foto, trabajador.CorreoElectronico, trabajador.MiTipoVia.Codigo, trabajador.NombreVia, trabajador.NumeroVia, trabajador.DepartamentoInterior, trabajador.MiTipoZOna.Codigo, trabajador.NombreZona, trabajador.Referencia, trabajador.MiDistrito.Codigo, trabajador.MiNacionalidad.Codigo, essalud, trabajador.Suspencionrenta4ta);
            return true;
        }

        public Boolean EliminarTrabajador(cTrabajador trabajador)
        {
            Conexion.GDatos.Ejecutar("spEliminarTrabajador", trabajador.IdTrabajador);
            return true;
        }

        public DataTable ObtenerListaTrabajadores(string FiltroTrabajadores)
        {
            string filtro = "t";
            switch (FiltroTrabajadores)
            {
                case "Activos":
                    filtro = "a";
                    break;
                case "Inactivos":
                    filtro = "i";
                    break;
                case "Todos":
                    filtro = "t";
                    break;
                case "Sin Periodo Laboral":
                    filtro = "s";
                    break;
            }
            return Conexion.GDatos.TraerDataTable("spListarTrabajadores", filtro);
        }

        public DataTable ObtenerListaTrabajadores(string FiltroTrabajadores, string fnombres, string fapellidoPaterno, string fapellidoMaterno, string fdni, string fRegimen, string fmeta)
        {
            string filtro = "t";
            string regimenfiltro = "%";
            string filtroMeta = "%";
            switch (FiltroTrabajadores)
            {
                case "Activos":
                    filtro = "a";
                    break;
                case "Inactivos":
                    filtro = "i";
                    break;
                case "Todos":
                    filtro = "t";
                    break;
                case "Sin Periodo Laboral":
                    filtro = "s";
                    break;
            }

            switch (fRegimen)
            {
                case "Todos":
                    regimenfiltro = "%";
                    break;
                case "CAS":
                    regimenfiltro = "15";
                    break;
                case "728":
                    regimenfiltro = "01";
                    break;
                case "276":
                    regimenfiltro = "02";
                    break;
            }

            if (fmeta != "Todos")
            {
                filtroMeta = fmeta; 
            }
            else
            {
                filtroMeta = "%";
            }
            return Conexion.GDatos.TraerDataTable("spListarTrabajadoresFiltro", filtro, fnombres + '%', fapellidoPaterno + '%', fapellidoMaterno + '%', fdni + '%', regimenfiltro, filtroMeta);
        }
    }
}
