using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Utilidades
{
    public class cUtilidades
    {
        public string DevolverLetraExcel(int numero)
        {
            string letra = "";
            switch (numero)
            {
                case 1:
                    letra = "A";
                    break;
                case 2:
                    letra = "B";
                    break;
                case 3:
                    letra = "C";
                    break;
                case 4:
                    letra = "D";
                    break;
                case 5:
                    letra = "E";
                    break;
                case 6:
                    letra = "F";
                    break;
                case 7:
                    letra = "G";
                    break;
                case 8:
                    letra = "H";
                    break;
                case 9:
                    letra = "I";
                    break;
                case 10:
                    letra = "J";
                    break;
                case 11:
                    letra = "K";
                    break;
                case 12:
                    letra = "L";
                    break;
                case 13:
                    letra = "M";
                    break;
                case 14:
                    letra = "N";
                    break;
                case 15:
                    letra = "O";
                    break;
                case 16:
                    letra = "P";
                    break;
                case 17:
                    letra = "Q";
                    break;
                case 18:
                    letra = "R";
                    break;
                case 19:
                    letra = "S";
                    break;
                case 20:
                    letra = "T";
                    break;
                case 21:
                    letra = "U";
                    break;
                case 22:
                    letra = "V";
                    break;
                case 23:
                    letra = "W";
                    break;
                case 24:
                    letra = "X";
                    break;
                case 25:
                    letra = "Y";
                    break;
                case 26:
                    letra = "Z";
                    break;
                case 27:
                    letra = "AA";
                    break;
                case 28:
                    letra = "AB";
                    break;
                case 29:
                    letra = "AC";
                    break;
                case 30:
                    letra = "AD";
                    break;

                default:
                    break;
            }

            return letra;
        }
    }
}
