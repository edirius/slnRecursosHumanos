using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.ImportadorDatos
{
    public class archivoImportador
    {
        string _Dni;
        string _Nombres;
        string _ApellidoPaterno;
        string _ApellidoMaterno;
        bool _Activo;

        public string Dni
        {
            get
            {
                return _Dni;
            }

            set
            {
                _Dni = value;
            }
        }

        public string Nombres
        {
            get
            {
                return _Nombres;
            }

            set
            {
                _Nombres = value;
            }
        }

        public string ApellidoPaterno
        {
            get
            {
                return _ApellidoPaterno;
            }

            set
            {
                _ApellidoPaterno = value;
            }
        }

        public string ApellidoMaterno
        {
            get
            {
                return _ApellidoMaterno;
            }

            set
            {
                _ApellidoMaterno = value;
            }
        }

        public bool Activo
        {
            get
            {
                return _Activo;
            }

            set
            {
                _Activo = value;
            }
        }
    }
}
