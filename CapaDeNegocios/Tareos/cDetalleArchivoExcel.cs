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
    }
}
