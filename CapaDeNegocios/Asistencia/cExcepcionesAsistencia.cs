using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Asistencia
{
    public class cExcepcionesAsistencia
    {
        int _CodigoExcepcion;
        string _Tipo;
        string _Comentario;
        DateTime _InicioExcepcion;
        DateTime _FinExcepcion;
        cTrabajador _Trabajador;

        public cExcepcionesAsistencia()
        {
            _InicioExcepcion = DateTime.Now;
            _FinExcepcion = DateTime.Now;
        }
        public int CodigoExcepcion
        {
            get
            {
                return _CodigoExcepcion;
            }

            set
            {
                _CodigoExcepcion = value;
            }
        }

        public string Tipo
        {
            get
            {
                return _Tipo;
            }

            set
            {
                _Tipo = value;
            }
        }

        public DateTime InicioExcepcion
        {
            get
            {
                return _InicioExcepcion;
            }

            set
            {
                _InicioExcepcion = value;
            }
        }

        public DateTime FinExcepcion
        {
            get
            {
                return _FinExcepcion;
            }

            set
            {
                _FinExcepcion = value;
            }
        }

        public cTrabajador Trabajador
        {
            get
            {
                return _Trabajador;
            }

            set
            {
                _Trabajador = value;
            }
        }

        public string Comentario
        {
            get
            {
                return _Comentario;
            }

            set
            {
                _Comentario = value;
            }
        }

      
    }
}
