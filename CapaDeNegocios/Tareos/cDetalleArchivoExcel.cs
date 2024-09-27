using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Tareos
{
    
    public class cDetalleArchivoExcel
    {
        string nombres;
        string apellidopaterno;
        string apellidomaterno;
        string dni;
        string cargo;
        int dias;
        int codigoTrabajador;
        string nombresValidado;
        string apellidoPaternoValidado;
        string apellidoMaternoValidado;
        DateTime fechaNacimiento;
        string sexo;
        string direccion;
        string estadoCivil;
        string observaciones;
        string cuentaBancaria;

        Boolean trabajadorEncontrado;

        public cDetalleArchivoExcel()
        {
            trabajadorEncontrado = false;
        }

        public string Nombres
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

        public string Dni
        {
            get
            {
                return dni;
            }

            set
            {
                dni = value;
            }
        }

        public string Cargo
        {
            get
            {
                return cargo;
            }

            set
            {
                cargo = value;
            }
        }

        public int Dias
        {
            get
            {
                return dias;
            }

            set
            {
                dias = value;
            }
        }

        public string Apellidopaterno
        {
            get
            {
                return apellidopaterno;
            }

            set
            {
                apellidopaterno = value;
            }
        }

        public string Apellidomaterno
        {
            get
            {
                return apellidomaterno;
            }

            set
            {
                apellidomaterno = value;
            }
        }

        public bool TrabajadorEncontrado
        {
            get
            {
                return trabajadorEncontrado;
            }

            set
            {
                trabajadorEncontrado = value;
            }
        }

        public int CodigoTrabajador
        {
            get
            {
                return codigoTrabajador;
            }

            set
            {
                codigoTrabajador = value;
            }
        }

        public string NombresValidado
        {
            get
            {
                return nombresValidado;
            }

            set
            {
                nombresValidado = value;
            }
        }

        public string ApellidoPaternoValidado
        {
            get
            {
                return apellidoPaternoValidado;
            }

            set
            {
                apellidoPaternoValidado = value;
            }
        }

        public string ApellidoMaternoValidado
        {
            get
            {
                return apellidoMaternoValidado;
            }

            set
            {
                apellidoMaternoValidado = value;
            }
        }

        public DateTime FechaNacimiento
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

        public string Sexo
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

        public string Direccion
        {
            get
            {
                return direccion;
            }

            set
            {
                direccion = value;
            }
        }

        public string EstadoCivil
        {
            get
            {
                return estadoCivil;
            }

            set
            {
                estadoCivil = value;
            }
        }

        public string Observaciones
        {
            get
            {
                return observaciones;
            }

            set
            {
                observaciones = value;
            }
        }

        public string CuentaBancaria
        {
            get
            {
                return cuentaBancaria;
            }

            set
            {
                cuentaBancaria = value;
            }
        }
    }
}
