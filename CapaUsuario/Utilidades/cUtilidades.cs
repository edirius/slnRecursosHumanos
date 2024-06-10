using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaUsuario.Utilidades
{
    public class cUtilidades
    {
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

        public List<int> ListaAños()
        {
            List<int> Lista = new List<int>();

            int añoInicial = DateTime.Now.Year;
            int añoFinal = añoInicial - 10;

            for (int i = añoInicial; i > (añoFinal); i--)
            {
                Lista.Add(i);
            }
            return Lista;
        }
    }
}
