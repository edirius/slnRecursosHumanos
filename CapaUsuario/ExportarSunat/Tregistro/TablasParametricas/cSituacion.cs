﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaUsuario.ExportarSunat.Tregistro.TablasParametricas
{
    public class cSituacion
    {
        private string numero;
        private string descripcion;
        private string descripcionAbreviada;

        public string Numero
        {
            get
            {
                return numero;
            }

            set
            {
                numero = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }

        public string DescripcionAbreviada
        {
            get
            {
                return descripcionAbreviada;
            }

            set
            {
                descripcionAbreviada = value;
            }
        }
    }
}