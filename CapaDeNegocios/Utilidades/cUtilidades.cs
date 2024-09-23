using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

        public int ConvertirMesANumero(string pmes)
        {
            int x = 0;
            switch (pmes)
            {
                case "ENERO":
                    x = 1;
                    break;
                case "FEBRERO":
                    x = 2;
                    break;
                case "MARZO":
                    x = 3;
                    break;
                case "ABRIL":
                    x = 4;
                    break;
                case "MAYO":
                    x = 5;
                    break;
                case "JUNIO":
                    x = 6;
                    break;
                case "JULIO":
                    x = 7;
                    break;
                case "AGOSTO":
                    x = 8;
                    break;
                case "SETIEMBRE":
                    x = 9;
                    break;
                case "OCTUBRE":
                    x = 10;
                    break;
                case "NOVIEMBRE":
                    x = 11;
                    break;
                case "DICIEMBRE":
                    x = 12;
                    break;
            }
            return x;
        }

        public bool ArchivoEstaAbierto(string rutaArchivo)
        {
            FileInfo file = new FileInfo(rutaArchivo);
            bool estaAbierto = IsFileinUse(file, rutaArchivo);

            return estaAbierto;

        }

        protected virtual bool IsFileinUse(FileInfo file, string path)
        {
            FileStream stream = null;

            if (!File.Exists(path))
            {
                return false;
            }
            else
            {
                try
                {
                    stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);

                }
                catch (IOException)
                {
                    //the file is unavailable because it is:
                    //still being written to
                    //or being processed by another thread
                    //or does not exist (has already been processed)
                    return true;

                }
                finally
                {
                    if (stream != null)
                        stream.Close();
                }
                return false;
            }
        }
    }
}
