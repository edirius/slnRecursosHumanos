using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeDatos;

namespace CapaDeNegocios
{
    public class cValidaciones
    {
        /* ===========================Ingreso de solo numeros y solo letras========*/
        //ingresar solo numeros
        public void SoloNumeros(KeyPressEventArgs pE)
        {
            try
            {
                if (char.IsDigit(pE.KeyChar))
                {
                    pE.Handled = false;
                }
                else if (char.IsControl(pE.KeyChar))
                {
                    pE.Handled = false;
                }
                else if (char.IsPunctuation(pE.KeyChar))
                {
                    pE.Handled = false;
                }
                else
                {
                    pE.Handled = true;
                }
            }
            catch { }
        }

        //ingresar solo letras
        public void SoloLetras(KeyPressEventArgs pE)
        {
            try
            {

                if (Char.IsLetter(pE.KeyChar))
                {
                    pE.Handled = false;
                }
                else if (Char.IsControl(pE.KeyChar))
                {
                    pE.Handled = false;
                }
                else if (Char.IsSeparator(pE.KeyChar))
                {
                    pE.Handled = false;
                }
                else
                {
                    pE.Handled = true;
                }
            }
            catch { }
            
        }
    }
}
