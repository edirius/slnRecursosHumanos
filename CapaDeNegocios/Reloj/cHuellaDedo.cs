using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Reloj
{
    public class cHuellaDedo
    {
        int _IndiceHuella;
        int _flag;
        string _FPTmpData;
        int _FPTmpLength;

        public int IndiceHuella
        {
            get
            {
                return _IndiceHuella;
            }

            set
            {
                _IndiceHuella = value;
            }
        }

        public int Flag
        {
            get
            {
                return _flag;
            }

            set
            {
                _flag = value;
            }
        }

        public string FPTmpData
        {
            get
            {
                return _FPTmpData;
            }

            set
            {
                _FPTmpData = value;
            }
        }

        public int FPTmpLength
        {
            get
            {
                return _FPTmpLength;
            }

            set
            {
                _FPTmpLength = value;
            }
        }
    }
}
