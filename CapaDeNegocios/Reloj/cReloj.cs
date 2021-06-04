using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Reloj
{
    public class cReloj
    {
        string _IP;
        int _Puerto;
        int _NumeroMaquina;
        string _StatusString;
        bool _Conectado;
        string _InformacionReloj;

        string _SFirmver = "";
        string _SMac = "";
        string _SPlatform = "";
        string _SSN = "";
        string _SProductTime = "";
        string _SDeviceName = "";
        int _IFPAlg = 0;
        int _IFaceAlg = 0;
        string _SProducter = "";

        int _adminCnt = 0;
        int _userCount = 0;
        int _fpCnt = 0;
        int _recordCnt = 0;
        int _pwdCnt = 0;
        int _oplogCnt = 0;
        int _faceCnt = 0;


        public string IP
        {
            get
            {
                return _IP;
            }

            set
            {
                _IP = value;
            }
        }

        public int Puerto
        {
            get
            {
                return _Puerto;
            }

            set
            {
                _Puerto = value;
            }
        }

        public int NumeroMaquina
        {
            get
            {
                return _NumeroMaquina;
            }

            set
            {
                _NumeroMaquina = value;
            }
        }

        public string StatusString
        {
            get
            {
                return _StatusString;
            }

            set
            {
                _StatusString = value;
            }
        }

        public bool Conectado
        {
            get
            {
                return _Conectado;
            }

            set
            {
                _Conectado = value;
            }
        }

        public string InformacionReloj
        {
            get
            {
                return _InformacionReloj;
            }

            set
            {
                _InformacionReloj = value;
            }
        }

        public string SFirmver
        {
            get
            {
                return _SFirmver;
            }

            set
            {
                _SFirmver = value;
            }
        }

        public string SMac
        {
            get
            {
                return _SMac;
            }

            set
            {
                _SMac = value;
            }
        }

        public string SPlatform
        {
            get
            {
                return _SPlatform;
            }

            set
            {
                _SPlatform = value;
            }
        }

        public string SSN
        {
            get
            {
                return _SSN;
            }

            set
            {
                _SSN = value;
            }
        }

        public string SProductTime
        {
            get
            {
                return _SProductTime;
            }

            set
            {
                _SProductTime = value;
            }
        }

        public string SDeviceName
        {
            get
            {
                return _SDeviceName;
            }

            set
            {
                _SDeviceName = value;
            }
        }

        public int IFPAlg
        {
            get
            {
                return _IFPAlg;
            }

            set
            {
                _IFPAlg = value;
            }
        }

        public int IFaceAlg
        {
            get
            {
                return _IFaceAlg;
            }

            set
            {
                _IFaceAlg = value;
            }
        }

        public string SProducter
        {
            get
            {
                return _SProducter;
            }

            set
            {
                _SProducter = value;
            }
        }

        public int AdminCnt
        {
            get
            {
                return _adminCnt;
            }

            set
            {
                _adminCnt = value;
            }
        }

        public int UserCount
        {
            get
            {
                return _userCount;
            }

            set
            {
                _userCount = value;
            }
        }

        public int FpCnt
        {
            get
            {
                return _fpCnt;
            }

            set
            {
                _fpCnt = value;
            }
        }

        public int RecordCnt
        {
            get
            {
                return _recordCnt;
            }

            set
            {
                _recordCnt = value;
            }
        }

        public int PwdCnt
        {
            get
            {
                return _pwdCnt;
            }

            set
            {
                _pwdCnt = value;
            }
        }

        public int OplogCnt
        {
            get
            {
                return _oplogCnt;
            }

            set
            {
                _oplogCnt = value;
            }
        }

        public int FaceCnt
        {
            get
            {
                return _faceCnt;
            }

            set
            {
                _faceCnt = value;
            }
        }
    }
}
