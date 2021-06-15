using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using CapaDeNegocios.Reloj.Utilities;


using zkemkeeper;

namespace CapaDeNegocios.Reloj
{
    public class cServidorReloj
    {
        private static int idwErrorCode = 0;



        private SupportBiometricType _supportBiometricType = new SupportBiometricType();
        private string _biometricType = string.Empty;

        private cCatalogoPrivilegiosReloj CatalogoPrivilegios;

        public zkemkeeper.CZKEMClass axCZKEM1 = new zkemkeeper.CZKEMClass();

        private List<string> mensajes = new List<string>();

        Helper.SDKHelper miSDK = new Helper.SDKHelper();

        public cReloj Reloj;

        public cServidorReloj()
        {
            Reloj = new cReloj();
        }

        public class SupportBiometricType
        {
            public bool fp_available { get; set; }
            public bool face_available { get; set; }
            public bool fingerVein_available { get; set; }
            public bool palm_available { get; set; }
        }



        public List<string> Mensajes
        {
            get
            {
                return mensajes;
            }

            set
            {
                mensajes = value;
            }
        }

        public SupportBiometricType SupportBiometricType1
        {
            get
            {
                return _supportBiometricType;
            }

            set
            {
                _supportBiometricType = value;
            }
        }

        public cReloj ObtenerDatosReloj()
        {
            try
            {
                cReloj nuevoReloj = new cReloj();

                return nuevoReloj;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al obtener datos del reloj: " + ex.Message);
            }
        }

        /// <summary>
        /// Your Events will reach here if implemented
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="actionType"></param>
        private void RaiseDeviceEvent(object sender, string actionType)
        {
            switch (actionType)
            {
                case UniversalStatic.acx_Disconnect:
                    {
                        Reloj.StatusString = "EL reloj esta desconectado";
                        Reloj.Conectado = false;
                        break;
                    }

                default:
                    break;
            }

        }

        //public int sta_DownloadAllUserPhoto(cReloj oReloj, string RutaDescarga)
        //{
        //    if (oReloj.Conectado == false)
        //    {
        //        throw new cReglaNegociosException("*Por favor conectar el reloj!");
        //    }

        //    if (RutaDescarga == "")
        //    {
        //        throw new cReglaNegociosException("*Por favor seleccionar la ruta primero.");
        //    }

        //    int ret = 0;
        //    string photoPath = RutaDescarga;

        //    axCZKEM1.EnableDevice(oReloj.NumeroMaquina, false);

        //    if (axCZKEM1.GetAllUserPhoto(oReloj.NumeroMaquina, photoPath))
        //    {
        //        ret = 1;
        //        lblOutputInfo.Items.Add("Get All User Photo From the Device!");
        //    }
        //    else
        //    {
        //        axCZKEM1.GetLastError(ref idwErrorCode);
        //        ret = idwErrorCode;

        //        if (idwErrorCode != 0)
        //        {
        //            lblOutputInfo.Items.Add("*Download all user photo failed,ErrorCode: " + idwErrorCode.ToString());
        //        }
        //        else
        //        {
        //            lblOutputInfo.Items.Add("No data from terminal returns!");
        //        }
        //    }

        //    //lblOutputInfo.Items.Add("[func GetAllUserPhoto]Temporarily unsupported");

        //    axCZKEM1.EnableDevice(GetMachineNumber(), true);//enable the device

        //    return ret;
        //}

        public List<cHuellaUsuarioReloj> sta_readAttLog(cReloj oReloj)
        {
            List<cHuellaUsuarioReloj> ListaHuellasReloj = new List<cHuellaUsuarioReloj>();

            if (oReloj.Conectado == false)
            {
                throw new cReglaNegociosException("*Por favor conectar el reloj primero!");
            }

            int ret = 0;

            axCZKEM1.EnableDevice(oReloj.NumeroMaquina, false);//disable the device

            string sdwEnrollNumber = "";
            int idwVerifyMode = 0;
            int idwInOutMode = 0;
            int idwYear = 0;
            int idwMonth = 0;
            int idwDay = 0;
            int idwHour = 0;
            int idwMinute = 0;
            int idwSecond = 0;
            int idwWorkcode = 0;

            if (axCZKEM1.ReadGeneralLogData(oReloj.NumeroMaquina))
            {
                

                while (axCZKEM1.SSR_GetGeneralLogData(oReloj.NumeroMaquina, out sdwEnrollNumber, out idwVerifyMode,
                            out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute, out idwSecond, ref idwWorkcode))//conseguir records de la maquina
                {
                    cHuellaUsuarioReloj oHuellaUsuarioReloj = new cHuellaUsuarioReloj();
                    oHuellaUsuarioReloj.IdUsuario = sdwEnrollNumber;
                    oHuellaUsuarioReloj.IdwYear = idwYear;
                    oHuellaUsuarioReloj.IdwMonth = idwMonth;
                    oHuellaUsuarioReloj.IdwDay = idwDay;
                    oHuellaUsuarioReloj.IdwHour = idwHour;
                    oHuellaUsuarioReloj.IdwMinute = idwMinute;
                    oHuellaUsuarioReloj.IdwSecond = idwSecond;
                    oHuellaUsuarioReloj.IdwVerifyMode = idwVerifyMode;
                    oHuellaUsuarioReloj.IdwInOutMode = idwInOutMode;
                    oHuellaUsuarioReloj.IdwWorkcode = idwWorkcode;
                    oHuellaUsuarioReloj.ActualizarFecha();
                    ListaHuellasReloj.Add(oHuellaUsuarioReloj);
                }
                ret = 1;
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                ret = idwErrorCode;

                if (idwErrorCode != 0)
                {
                    Mensajes.Add("*Error al leer log  del reloj, ErrorCode: " + idwErrorCode.ToString());
                }
                else
                {
                    Mensajes.Add("No hay datos en el reloj!");
                }
            }

            axCZKEM1.EnableDevice(oReloj.NumeroMaquina, true);//enable the device

            return ListaHuellasReloj;
        }


        public List<cHuellaUsuarioReloj> sta_readAttLog(cReloj oReloj, string Inicio, string Fin)
        {
            List<cHuellaUsuarioReloj> ListaHuellasReloj = new List<cHuellaUsuarioReloj>();

            if (oReloj.Conectado == false)
            {
                throw new cReglaNegociosException("*Por favor conectar el reloj primero!");
            }

            int ret = 0;

            axCZKEM1.EnableDevice(oReloj.NumeroMaquina, false);//disable the device

            string sdwEnrollNumber = "";
            int idwVerifyMode = 0;
            int idwInOutMode = 0;
            int idwYear = 0;
            int idwMonth = 0;
            int idwDay = 0;
            int idwHour = 0;
            int idwMinute = 0;
            int idwSecond = 0;
            int idwWorkcode = 0;

            if (axCZKEM1.ReadTimeGLogData(oReloj.NumeroMaquina, Inicio, Fin) )
            {


                while (axCZKEM1.SSR_GetGeneralLogData(oReloj.NumeroMaquina, out sdwEnrollNumber, out idwVerifyMode,
                            out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute, out idwSecond, ref idwWorkcode))//conseguir records de la maquina
                {
                    cHuellaUsuarioReloj oHuellaUsuarioReloj = new cHuellaUsuarioReloj();
                    oHuellaUsuarioReloj.IdUsuario = sdwEnrollNumber;
                    oHuellaUsuarioReloj.IdwYear = idwYear;
                    oHuellaUsuarioReloj.IdwMonth = idwMonth;
                    oHuellaUsuarioReloj.IdwDay = idwDay;
                    oHuellaUsuarioReloj.IdwHour = idwHour;
                    oHuellaUsuarioReloj.IdwMinute = idwMinute;
                    oHuellaUsuarioReloj.IdwSecond = idwSecond;
                    oHuellaUsuarioReloj.IdwVerifyMode = idwVerifyMode;
                    oHuellaUsuarioReloj.IdwInOutMode = idwInOutMode;
                    oHuellaUsuarioReloj.IdwWorkcode = idwWorkcode;
                    oHuellaUsuarioReloj.ActualizarFecha();
                    ListaHuellasReloj.Add(oHuellaUsuarioReloj);
                }
                ret = 1;
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                ret = idwErrorCode;

                if (idwErrorCode != 0)
                {
                    Mensajes.Add("*Error al leer log  del reloj, ErrorCode: " + idwErrorCode.ToString());
                }
                else
                {
                    Mensajes.Add("No hay datos en el reloj!");
                }
            }

            axCZKEM1.EnableDevice(oReloj.NumeroMaquina, true);//enable the device

            return ListaHuellasReloj;
        }

        public int sta_DeleteAttLog(cReloj oReloj)
        {
            if (oReloj.Conectado == false)
            {
                Mensajes.Add("*Por favor conectar primero el reloj!");
                return -1024;
            }

            int ret = 0;

            axCZKEM1.EnableDevice(oReloj.NumeroMaquina, false);//disable the device


            if (axCZKEM1.ClearGLog(oReloj.NumeroMaquina))
            {
                axCZKEM1.RefreshData(oReloj.NumeroMaquina);
                ret = 1;
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                ret = idwErrorCode;

                if (idwErrorCode != 0)
                {
                    Mensajes.Add("* Borrado los registros de huella del reloj, ErrorCode: " + idwErrorCode.ToString());
                }
                else
                {
                    Mensajes.Add("No hay registros en el reloj!");
                }
            }

            axCZKEM1.EnableDevice(oReloj.NumeroMaquina, true);//enable the device

            return ret;
        }

        public int sta_GetUserInfo(cReloj oReloj, string txtUserID, string txtName, string cbPrivilege, string txtCardnumber, string txtPassword)
        {
            if (oReloj.Conectado == false)
            {
                Mensajes.Add("*Por favor conectar el reloj primero");
                return -1024;
            }

            if (txtUserID.Trim() == "")
            {
                Mensajes.Add("*Por favor ponga primero el usaurio ID!");
                return -1023;
            }

            int iPIN2Width = 0;
            string strTemp = "";
            axCZKEM1.GetSysOption(oReloj.NumeroMaquina, "~PIN2Width", out strTemp);
            iPIN2Width = Convert.ToInt32(strTemp);

            if (txtUserID.Length > iPIN2Width)
            {
                Mensajes.Add("*Usuario ID error! El numero maximo es " + iPIN2Width.ToString());
                return -1022;
            }

            int idwErrorCode = 0;
            int iPrivilege = 0;
            string strName = "";
            string strCardno = "";
            string strPassword = "";
            bool bEnabled = false;

            axCZKEM1.EnableDevice(oReloj.NumeroMaquina, false);
            if (axCZKEM1.SSR_GetUserInfo(oReloj.NumeroMaquina, txtUserID.Trim(), out strName, out strPassword, out iPrivilege, out bEnabled))//upload the user's information(card number included)
            {
                axCZKEM1.GetStrCardNumber(out strCardno);
                if (strCardno.Equals("0"))
                {
                    strCardno = "";
                }
                txtName = strName;
                txtPassword = strPassword;
                txtCardnumber = strCardno;
                cbPrivilege = iPrivilege.ToString();
                Mensajes.Add("Se obtuvo la informacion del usuario");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                //modify by Leonard 2017/12/18
                txtName = " ";
                txtPassword = " ";
                txtCardnumber = " ";
                cbPrivilege = "5";
                Mensajes.Add("El usuario no existe");
                //end by Leonard
                Mensajes.Add("*Operacion fallida,ErrorCode=" + idwErrorCode.ToString());
            }
            axCZKEM1.EnableDevice(oReloj.NumeroMaquina, true);

            return 1;
        }

        public List<cUsuarioReloj> sta_GetAllUserFPInfo(cReloj oReloj)
        {
            List<cUsuarioReloj> NuevaListaUsuariosReloj = new List<cUsuarioReloj>();
            if (oReloj.Conectado == false)
            {
                throw new cReglaNegociosException("*Por favor conectar el reloj!");
            }

            string sEnrollNumber = "";
            bool bEnabled = false;
            string sName = "";
            string sPassword = "";
            int iPrivilege = 0;
            string sFPTmpData = "";
            string sCardnumber = "";
            int idwFingerIndex = 0;
            int iFlag = 0;
            int iFPTmpLength = 0;
            int i = 0;
            int num = 0;
            int iFpCount = 0;



            axCZKEM1.EnableDevice(oReloj.NumeroMaquina, false);
            axCZKEM1.ReadAllUserID(oReloj.NumeroMaquina);//read all the user information to the memory  except fingerprint Templates
            axCZKEM1.ReadAllTemplate(oReloj.NumeroMaquina);//read all the users' fingerprint templates to the memory
            while (axCZKEM1.SSR_GetAllUserInfo(oReloj.NumeroMaquina, out sEnrollNumber, out sName, out sPassword, out iPrivilege, out bEnabled))//get all the users' information from the memory
            {
                cUsuarioReloj oUsuario = new cUsuarioReloj();
                axCZKEM1.GetStrCardNumber(out sCardnumber);//get the card number from the memory             

                oUsuario.NumeroInscripcion = sEnrollNumber;

                if (bEnabled == true)
                {
                    oUsuario.Activo = true;
                }
                else
                {
                    oUsuario.Activo = false;
                }

                oUsuario.Nombre = sName;
                oUsuario.NumeroTarjeta = sCardnumber;
                oUsuario.Password = sPassword;
                oUsuario.PrivilegioReloj = CatalogoPrivilegios.ObtenerListaPrivilegiosReloj().Find(x => x.Codigo == iPrivilege);

                i = 0;
                for (idwFingerIndex = 0; idwFingerIndex < 10; idwFingerIndex++)
                {
                    cHuellaDedo oHuellaDedo = new cHuellaDedo();
                    oHuellaDedo.IndiceHuella = idwFingerIndex;
                    if (axCZKEM1.GetUserTmpExStr(oReloj.NumeroMaquina, sEnrollNumber, idwFingerIndex, out iFlag, out sFPTmpData, out iFPTmpLength))//obtener la cadena de plantillas correspondiente y la longitud de la memoria
                    {
                        oHuellaDedo.Flag = iFlag;
                        oHuellaDedo.FPTmpData = sFPTmpData;
                    }
                    oUsuario.HuellaDedos.Add(oHuellaDedo);
                    iFpCount++;
                }
                num++;
                //prgSta.Value = num % 100;
                NuevaListaUsuariosReloj.Add(oUsuario);
            }
            //prgSta.Value = 100;
            Mensajes.Add("Usuarios bajados: " + num.ToString() + " ,  Numero huellas : " + iFpCount.ToString());
            axCZKEM1.EnableDevice(oReloj.NumeroMaquina, true);
            return NuevaListaUsuariosReloj;
        }

        public int sta_batch_SetAllUserFPInfo(cReloj oReloj, List<cUsuarioReloj> ListaUsuariosReloj)
        {
            if (oReloj.Conectado == false)
            {
                throw new cReglaNegociosException("*Por favor conectar el reloj primero!");
            }

            if (ListaUsuariosReloj.Count == 0)
            {
                throw new cReglaNegociosException("*No hay datos para actualizar en el reloj!");
            }

            string sEnrollNumber = "";
            string sEnabled = "";
            bool bEnabled = false;

            string sName = "";
            string sPassword = "";
            int iPrivilege = 0;
            string sFPTmpData = "";
            string sCardnumber = "";
            int idwFingerIndex = 0;
            string sdwFingerIndex = "";
            int iFlag = 0;
            string sFlag = "";
            int num = 0;

            axCZKEM1.EnableDevice(oReloj.NumeroMaquina, false);
            if (axCZKEM1.BeginBatchUpdate(oReloj.NumeroMaquina, 1))//create memory space for batching data
            {
                foreach (cUsuarioReloj item in ListaUsuariosReloj)
                {
                    sEnrollNumber = item.NumeroInscripcion;
                    sEnabled = item.Activo.ToString();
                    if (sEnabled == "true")
                    {
                        bEnabled = true;
                    }
                    else
                    {
                        bEnabled = false;
                    }
                    sName = item.Nombre;
                    sCardnumber = item.NumeroTarjeta;
                    sPassword = item.Password;
                    sdwFingerIndex = item.HuellaDedos[0].IndiceHuella.ToString();
                    sFlag = item.HuellaDedos[0].Flag.ToString();
                    sFPTmpData = item.HuellaDedos[0].FPTmpData;
                    iPrivilege = item.PrivilegioReloj.Codigo;

                    if (sCardnumber != "" && sCardnumber != "0")
                    {
                        axCZKEM1.SetStrCardNumber(sCardnumber);
                    }
                    if (axCZKEM1.SSR_SetUserInfo(oReloj.NumeroMaquina, sEnrollNumber, sName, sPassword, iPrivilege, bEnabled))//upload user information to the device
                    {
                        if (sdwFingerIndex != "" && sFlag != "" && sFPTmpData != "")
                        {
                            idwFingerIndex = Convert.ToInt32(sdwFingerIndex);
                            iFlag = Convert.ToInt32(sFlag);
                            axCZKEM1.SetUserTmpExStr(oReloj.NumeroMaquina, sEnrollNumber, idwFingerIndex, iFlag, sFPTmpData);//upload templates information to the device
                        }
                        num++;
                        //prgSta.Value = num % 100;
                    }
                    else
                    {
                        axCZKEM1.GetLastError(ref idwErrorCode);
                        Mensajes.Add("*Usuario " + sEnrollNumber + " error,ErrorCode=!" + idwErrorCode.ToString());
                        //axCZKEM1.EnableDevice(iMachineNumber, true);
                        //return -1022;
                    }
                }

            }
            axCZKEM1.BatchUpdate(oReloj.NumeroMaquina);//upload all the information in the memory
            axCZKEM1.RefreshData(oReloj.NumeroMaquina);//the data in the device should be refreshed
            axCZKEM1.EnableDevice(oReloj.NumeroMaquina, true);
            Mensajes.Add("Usuario Actualizado");
            return 1;
        }

        public int sta_SetUserInfo(cReloj oReloj, string txtUserID, string txtName, string cbPrivilege, string txtCardnumber, string txtPassword)
        {
            if (oReloj.Conectado == false)
            {
                Mensajes.Add("*Por favor conecta el reloj primero!");
                return -1024;
            }

            if (txtUserID.Trim() == "" || cbPrivilege.Trim() == "")
            {
                Mensajes.Add("*Please input data first!");
                return -1023;
            }

            int iPrivilege = Convert.ToInt16(cbPrivilege);

            bool bFlag = false;
            if (iPrivilege == 5)
            {
                Mensajes.Add("*User Defined Role is Error! Please Register again!");
                return -1023;
            }

            /*
            if(iPrivilege == 4)
            {
                axCZKEM1.IsUserDefRoleEnable(iMachineNumber, 4, out bFlag);

                if (bFlag == false)
                {
                    lblOutputInfo.Items.Add("*User Defined Role is unable!");
                    return -1023;
                }
            }
             */
            //lblOutputInfo.Items.Add("[func IsUserDefRoleEnable]Temporarily unsupported");

            int iPIN2Width = 0;
            int iIsABCPinEnable = 0;
            int iT9FunOn = 0;
            string strTemp = "";
            axCZKEM1.GetSysOption(oReloj.NumeroMaquina, "~PIN2Width", out strTemp);
            iPIN2Width = Convert.ToInt32(strTemp);
            axCZKEM1.GetSysOption(oReloj.NumeroMaquina, "~IsABCPinEnable", out strTemp);
            iIsABCPinEnable = Convert.ToInt32(strTemp);
            axCZKEM1.GetSysOption(oReloj.NumeroMaquina, "~T9FunOn", out strTemp);
            iT9FunOn = Convert.ToInt32(strTemp);
            /*
            axCZKEM1.GetDeviceInfo(iMachineNumber, 76, ref iPIN2Width);
            axCZKEM1.GetDeviceInfo(iMachineNumber, 77, ref iIsABCPinEnable);
            axCZKEM1.GetDeviceInfo(iMachineNumber, 78, ref iT9FunOn);
            */

            if (txtUserID.Length > iPIN2Width)
            {
                Mensajes.Add("*User ID error! El maximo longitud es " + iPIN2Width.ToString());
                return -1022;
            }

            if (iIsABCPinEnable == 0 || iT9FunOn == 0)
            {
                if (txtUserID.Substring(0, 1) == "0")
                {
                    Mensajes.Add("*User ID error! La primera letra no puede ser 0");
                    return -1022;
                }

                foreach (char tempchar in txtUserID.ToCharArray())
                {
                    if (!(char.IsDigit(tempchar)))
                    {
                        Mensajes.Add("*User ID error! El usuario ID solo soporta numeros");
                        return -1022;
                    }
                }
            }
            int idwErrorCode = 0;
            string sdwEnrollNumber = txtUserID.Trim();
            string sName = txtName.Trim();
            string sCardnumber = txtCardnumber.Trim();
            string sPassword = txtPassword.Trim();

            bool bEnabled = true;
            /*if (iPrivilege == 4)
            {
                bEnabled = false;
                iPrivilege = 0;
            }
            else
            {
                bEnabled = true;
            }*/

            axCZKEM1.EnableDevice(oReloj.NumeroMaquina, false);
            axCZKEM1.SetStrCardNumber(sCardnumber);//Before you using function SetUserInfo,set the card number to make sure you can upload it to the device
            if (axCZKEM1.SSR_SetUserInfo(oReloj.NumeroMaquina, sdwEnrollNumber, sName, sPassword, iPrivilege, bEnabled))//upload the user's information(card number included)
            {
                Mensajes.Add("Informacion grabada correctamente");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                Mensajes.Add("*Operacion fallida, ErrorCode=" + idwErrorCode.ToString());
            }
            axCZKEM1.RefreshData(oReloj.NumeroMaquina);//the data in the device should be refreshed
            axCZKEM1.EnableDevice(oReloj.NumeroMaquina, true);

            return 1;
        }

        public int sta_GetCapacityInfo(cReloj miReloj)
        {
            int ret = 0;

            int adminCnt = 0;
            int userCount = 0;
            int fpCnt = 0;
            int recordCnt = 0;
            int pwdCnt = 0;
            int oplogCnt = 0;
            int faceCnt = 0;

            if (miReloj.Conectado == false)
            {
                throw new cReglaNegociosException("* POr favor conectar el reloj primero.");
               
            }

            axCZKEM1.EnableDevice(miReloj.NumeroMaquina, false);//disable the device

            axCZKEM1.GetDeviceStatus(miReloj.NumeroMaquina, 2, ref userCount);
            axCZKEM1.GetDeviceStatus(miReloj.NumeroMaquina, 1, ref adminCnt);
            axCZKEM1.GetDeviceStatus(miReloj.NumeroMaquina, 3, ref fpCnt);
            axCZKEM1.GetDeviceStatus(miReloj.NumeroMaquina, 4, ref pwdCnt);
            axCZKEM1.GetDeviceStatus(miReloj.NumeroMaquina, 5, ref oplogCnt);
            axCZKEM1.GetDeviceStatus(miReloj.NumeroMaquina, 6, ref recordCnt);
            axCZKEM1.GetDeviceStatus(miReloj.NumeroMaquina, 21, ref faceCnt);

            axCZKEM1.EnableDevice(miReloj.NumeroMaquina, true);//enable the device

            Reloj.UserCount = userCount;
            Reloj.RecordCnt = recordCnt;
            Reloj.FaceCnt = faceCnt;
            Reloj.AdminCnt = adminCnt;
            Reloj.FpCnt = fpCnt;
            Reloj.PwdCnt = pwdCnt;
            Reloj.OplogCnt = oplogCnt;

            Mensajes.Add("Se obtuvo los datos del reloj");

            ret = 1;
            return ret;
        }
        public int sta_GetDeviceInfo(cReloj oReloj)
        {
            int iRet = 0;

            string sFirmver = "";
            string sMac = "";
            string sPlatform = "";
            string sSN = "";
            string sProducter = "";
            string sDeviceName = "";
            int iFPAlg = 0;
            int iFaceAlg = 0;
            string sProductTime = "";
            string strTemp = "";

            if (oReloj.Conectado == false)
            {
                Mensajes.Add("*Por favor conectar el reloj primero!");
                return -1024;
            }

            axCZKEM1.EnableDevice(oReloj.NumeroMaquina, false);//disable the device

            axCZKEM1.GetSysOption(oReloj.NumeroMaquina, "~ZKFPVersion", out strTemp);
            iFPAlg = Convert.ToInt32(strTemp);

            axCZKEM1.GetSysOption(oReloj.NumeroMaquina, "ZKFaceVersion", out strTemp);
            iFaceAlg = Convert.ToInt32(strTemp);

            /*
            axCZKEM1.GetDeviceInfo(GetMachineNumber(), 72, ref iFPAlg);
            axCZKEM1.GetDeviceInfo(GetMachineNumber(), 73, ref iFaceAlg);
            */

            axCZKEM1.GetVendor(ref sProducter);
            axCZKEM1.GetProductCode(oReloj.NumeroMaquina, out sDeviceName);
            axCZKEM1.GetDeviceMAC(oReloj.NumeroMaquina, ref sMac);
            axCZKEM1.GetFirmwareVersion(oReloj.NumeroMaquina, ref sFirmver);

            /*
            if (sta_GetDeviceType() == 1)
            {
                axCZKEM1.GetDeviceFirmwareVersion(GetMachineNumber(), ref sFirmver);
            }
             */
            //lblOutputInfo.Items.Add("[func GetDeviceFirmwareVersion]Temporarily unsupported");

            axCZKEM1.GetPlatform(oReloj.NumeroMaquina, ref sPlatform);
            axCZKEM1.GetSerialNumber(oReloj.NumeroMaquina, out sSN);
            axCZKEM1.GetDeviceStrInfo(oReloj.NumeroMaquina, 1, out sProductTime);

            axCZKEM1.EnableDevice(oReloj.NumeroMaquina, true);//enable the device

            Mensajes.Add("Se obtuvo la información del dispositivo correctamente");
            iRet = 1;

            oReloj.SFirmver = sFirmver;
            oReloj.SMac = sMac;
            oReloj.SPlatform = sPlatform;
            oReloj.SSN = sSN;
            oReloj.SProducter = sProducter;
            oReloj.SDeviceName = sDeviceName;
            oReloj.IFPAlg = iFPAlg;
            oReloj.IFaceAlg = iFaceAlg;
            oReloj.SProductTime = sProductTime;

            return iRet;
        }


        public int ConectarRelojXIP(ref cReloj miReloj)
        {
            try
            {
                int portNumber = 4370;
                if (!int.TryParse(miReloj.Puerto.ToString(), out portNumber))
                    throw new Exception("No es valido el puerto");

                bool isValidIpA = UniversalStatic.ValidateIP(miReloj.IP);
                if (!isValidIpA)
                    throw new Exception("El IP es invalido !!");

                isValidIpA = UniversalStatic.PingTheDevice(miReloj.IP);
                if (!isValidIpA)
                    throw new Exception("El reloj con IP " + miReloj.IP + ":" + miReloj.Puerto + " no responde!");

                axCZKEM1.SetCommPassword(miReloj.NumeroMaquina);

                if (miReloj.Conectado == true)
                {
                    axCZKEM1.Disconnect();
                    sta_UnRegRealTime();
                    miReloj.Conectado = false;
                    //connected = false;
                    return -2; //disconnect
                }

                if (axCZKEM1.Connect_Net(miReloj.IP, Convert.ToInt32(miReloj.Puerto)) == true)
                {
                    miReloj.Conectado = true;
                    sta_RegRealTime(miReloj);
                    Mensajes.Add("Conectado con el reloj");

                    //get Biotype
                    sta_getBiometricType(miReloj);

                    return 1;
                }
                else
                {
                    axCZKEM1.GetLastError(ref idwErrorCode);
                    Mensajes.Add("*No se puede conectar con el reloj, ErrorCode=" + idwErrorCode.ToString());

                    return idwErrorCode;
                }

            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al conectar reloj: " + ex.Message);
            }
        }

        private string sta_getSysOptions(string option, cReloj oReloj)
        {
            string value = string.Empty;
            axCZKEM1.GetSysOption(Reloj.NumeroMaquina, option, out value);
            return value;
        }

        /// <summary>
        /// get support type
        /// </summary>
        /// <returns></returns>
        public void sta_getBiometricType(cReloj miReloj)
        {
            string result = string.Empty;
            result = sta_getSysOptions("BiometricType", miReloj);
            if (!string.IsNullOrEmpty(result))
            {
                SupportBiometricType1.fp_available = result[1] == '1';
                SupportBiometricType1.face_available = result[2] == '1';
                if (result.Length >= 9)
                {
                    SupportBiometricType1.fingerVein_available = result[7] == '1';
                    SupportBiometricType1.palm_available = result[8] == '1';
                }
            }
            _biometricType = result;
        }

        public void sta_UnRegRealTime()
        {
            this.axCZKEM1.OnFinger -= new zkemkeeper._IZKEMEvents_OnFingerEventHandler(axCZKEM1_OnFinger);
            this.axCZKEM1.OnVerify -= new zkemkeeper._IZKEMEvents_OnVerifyEventHandler(axCZKEM1_OnVerify);
            this.axCZKEM1.OnAttTransactionEx -= new zkemkeeper._IZKEMEvents_OnAttTransactionExEventHandler(axCZKEM1_OnAttTransactionEx);
            this.axCZKEM1.OnFingerFeature -= new zkemkeeper._IZKEMEvents_OnFingerFeatureEventHandler(axCZKEM1_OnFingerFeature);
            this.axCZKEM1.OnDeleteTemplate -= new zkemkeeper._IZKEMEvents_OnDeleteTemplateEventHandler(axCZKEM1_OnDeleteTemplate);
            this.axCZKEM1.OnNewUser -= new zkemkeeper._IZKEMEvents_OnNewUserEventHandler(axCZKEM1_OnNewUser);
            this.axCZKEM1.OnHIDNum -= new zkemkeeper._IZKEMEvents_OnHIDNumEventHandler(axCZKEM1_OnHIDNum);
            this.axCZKEM1.OnAlarm -= new zkemkeeper._IZKEMEvents_OnAlarmEventHandler(axCZKEM1_OnAlarm);
            this.axCZKEM1.OnDoor -= new zkemkeeper._IZKEMEvents_OnDoorEventHandler(axCZKEM1_OnDoor);
            this.axCZKEM1.OnEnrollFingerEx -= new zkemkeeper._IZKEMEvents_OnEnrollFingerExEventHandler(axCZKEM1_OnEnrollFingerEx);
            this.axCZKEM1.OnWriteCard += new zkemkeeper._IZKEMEvents_OnWriteCardEventHandler(axCZKEM1_OnWriteCard);
            this.axCZKEM1.OnEmptyCard += new zkemkeeper._IZKEMEvents_OnEmptyCardEventHandler(axCZKEM1_OnEmptyCard);
            this.axCZKEM1.OnHIDNum += new zkemkeeper._IZKEMEvents_OnHIDNumEventHandler(axCZKEM1_OnHIDNum);
            this.axCZKEM1.OnAttTransaction -= new zkemkeeper._IZKEMEvents_OnAttTransactionEventHandler(axCZKEM1_OnAttTransaction);
            this.axCZKEM1.OnKeyPress += new zkemkeeper._IZKEMEvents_OnKeyPressEventHandler(axCZKEM1_OnKeyPress);
            this.axCZKEM1.OnEnrollFinger += new zkemkeeper._IZKEMEvents_OnEnrollFingerEventHandler(axCZKEM1_OnEnrollFinger);

        }

        public int sta_RegRealTime(cReloj miReloj)
        {
            if (miReloj.Conectado == false)
            {
                Mensajes.Add("*Por favor conectar primero el reloj");
                return -1024;
            }

            int ret = 0;

            if (axCZKEM1.RegEvent(miReloj.NumeroMaquina, 65535))//Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
            {
                //common interface
                this.axCZKEM1.OnFinger += new zkemkeeper._IZKEMEvents_OnFingerEventHandler(axCZKEM1_OnFinger);
                this.axCZKEM1.OnVerify += new zkemkeeper._IZKEMEvents_OnVerifyEventHandler(axCZKEM1_OnVerify);
                this.axCZKEM1.OnFingerFeature += new zkemkeeper._IZKEMEvents_OnFingerFeatureEventHandler(axCZKEM1_OnFingerFeature);
                this.axCZKEM1.OnDeleteTemplate += new zkemkeeper._IZKEMEvents_OnDeleteTemplateEventHandler(axCZKEM1_OnDeleteTemplate);
                this.axCZKEM1.OnNewUser += new zkemkeeper._IZKEMEvents_OnNewUserEventHandler(axCZKEM1_OnNewUser);
                this.axCZKEM1.OnHIDNum += new zkemkeeper._IZKEMEvents_OnHIDNumEventHandler(axCZKEM1_OnHIDNum);
                this.axCZKEM1.OnAlarm += new zkemkeeper._IZKEMEvents_OnAlarmEventHandler(axCZKEM1_OnAlarm);
                this.axCZKEM1.OnDoor += new zkemkeeper._IZKEMEvents_OnDoorEventHandler(axCZKEM1_OnDoor);

                //only for color device
                this.axCZKEM1.OnAttTransactionEx += new zkemkeeper._IZKEMEvents_OnAttTransactionExEventHandler(axCZKEM1_OnAttTransactionEx);
                this.axCZKEM1.OnEnrollFingerEx += new zkemkeeper._IZKEMEvents_OnEnrollFingerExEventHandler(axCZKEM1_OnEnrollFingerEx);

                //only for black&white device
                this.axCZKEM1.OnAttTransaction -= new zkemkeeper._IZKEMEvents_OnAttTransactionEventHandler(axCZKEM1_OnAttTransaction);
                this.axCZKEM1.OnWriteCard += new zkemkeeper._IZKEMEvents_OnWriteCardEventHandler(axCZKEM1_OnWriteCard);
                this.axCZKEM1.OnEmptyCard += new zkemkeeper._IZKEMEvents_OnEmptyCardEventHandler(axCZKEM1_OnEmptyCard);
                this.axCZKEM1.OnKeyPress += new zkemkeeper._IZKEMEvents_OnKeyPressEventHandler(axCZKEM1_OnKeyPress);
                this.axCZKEM1.OnEnrollFinger += new zkemkeeper._IZKEMEvents_OnEnrollFingerEventHandler(axCZKEM1_OnEnrollFinger);


                ret = 1;
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                ret = idwErrorCode;

                if (idwErrorCode != 0)
                {
                    Mensajes.Add("*RegEvent failed,ErrorCode: " + idwErrorCode.ToString());
                }
                else
                {
                    Mensajes.Add("*No data from terminal returns!");
                }
            }
            return ret;
        }

        //Cuando pones tu dedo en el sensor del reloj, este evento se activará
        void axCZKEM1_OnFinger()
        {
            throw new NotImplementedException();
        }

        //Despues pongas el dedo en el sensor(o acerques la tarjeta en la maquina), este evento se activará.
        //Si pasas la verificación, el valor devuelto userid será el número de inscripción del usuario, o de lo contrario el valor será -1;
        void axCZKEM1_OnVerify(int UserID)
        {
            if (UserID != -1)
            {
                Mensajes.Add("El usuario con el id: " + UserID);
            }
            else
            {
                Mensajes.Add("Fallo al validar la huella...");
            }

            throw new NotImplementedException();
        }

        //Si tu huella (o tu tarjeta) pasa la verificacion, este evento se activará, solo para color device
        void axCZKEM1_OnAttTransactionEx(string EnrollNumber, int IsInValid, int AttState, int VerifyMethod, int Year, int Month, int Day, int Hour, int Minute, int Second, int WorkCode)
        {
            string time = Year + "-" + Month + "-" + Day + " " + Hour + ":" + Minute + ":" + Second;

            Mensajes.Add("Verificado OK.UserID=" + EnrollNumber + " isInvalid=" + IsInValid.ToString() + " state=" + AttState.ToString() + " verifystyle=" + VerifyMethod.ToString() + " time=" + time);

            throw new NotImplementedException();
        }

        //Cuando haya registrado su dedo, este evento se activará y devolverá la calidad de la huella digital que ha registrado.
        void axCZKEM1_OnFingerFeature(int Score)
        {
            Mensajes.Add("Press dedo score=" + Score.ToString());

            throw new NotImplementedException();
        }

        // Cuando haya eliminado una plantilla de huella digital, se activará este evento.
        void axCZKEM1_OnDeleteTemplate(int EnrollNumber, int FingerIndex)
        {
            Mensajes.Add("Borrado una plantilla del dedo" + "...UserID=" + EnrollNumber.ToString() + "..FingerIndex=" + FingerIndex.ToString());

            throw new NotImplementedException();
        }

        // Cuando haya inscrito un nuevo usuario, se activará este evento.
        void axCZKEM1_OnNewUser(int EnrollNumber)
        {
            Mensajes.Add("Inscrito nuevo usuario con el UserID=" + EnrollNumber.ToString());

            throw new NotImplementedException();
        }

        //Cuando desliza una tarjeta hacia el dispositivo, este evento se activará para mostrarle el número de la tarjeta.
        void axCZKEM1_OnHIDNum(int CardNumber)
        {
            Mensajes.Add("Tarjeta Evento " + "...Cardnumber=" + CardNumber.ToString());

            throw new NotImplementedException();
        }

        // Cuando ocurra la máquina de desmantelamiento o alarma de coacción, active este evento.
        void axCZKEM1_OnAlarm(int AlarmType, int EnrollNumber, int Verified)
        {
            Mensajes.Add("Alarma activada" + "...AlarmType=" + AlarmType.ToString() + "...EnrollNumber=" + EnrollNumber.ToString() + "...Verified=" + Verified.ToString());

            throw new NotImplementedException();
        }

        //Evento Puerta Sensor
        void axCZKEM1_OnDoor(int EventType)
        {
            Mensajes.Add("Door opened" + "...EventType=" + EventType.ToString());

            throw new NotImplementedException();
        }

        // Cuando esté registrando la plantilla de la huella de su dedo, se activará este evento.
        void axCZKEM1_OnEnrollFingerEx(string EnrollNumber, int FingerIndex, int ActionResult, int TemplateLength)
        {
            if (ActionResult == 0)
            {
                Mensajes.Add("Dedo inscrito correctamente. UserID=" + EnrollNumber.ToString() + "...FingerIndex=" + FingerIndex.ToString());
            }
            else
            {
                Mensajes.Add("Error al inscirbir el dedod. Result=" + ActionResult.ToString());
            }
            throw new NotImplementedException();
        }

        //Cuando tu haz escrito dentro de la tarjeta Mifare, este evento se activará.
        void axCZKEM1_OnWriteCard(int iEnrollNumber, int iActionResult, int iLength)
        {
            if (iActionResult == 0)
            {
                Mensajes.Add("Write Mifare Card OK" + "...EnrollNumber=" + iEnrollNumber.ToString() + "...TmpLength=" + iLength.ToString());
            }
            else
            {
                Mensajes.Add("...Write Failed");
            }
        }

        // Cuando hayas vaciado la carta Mifare, se activará este evento. 
        void axCZKEM1_OnEmptyCard(int iActionResult)
        {
            if (iActionResult == 0)
            {
                Mensajes.Add("Empty Mifare Card OK...");
            }
            else
            {
                Mensajes.Add("Empty Failed...");
            }
        }

        // Si su huella digital (o su tarjeta) pasa la verificación, este evento se activará, solo para el dispositivo negro% blanco
        private void axCZKEM1_OnAttTransaction(int EnrollNumber, int IsInValid, int AttState, int VerifyMethod, int Year, int Month, int Day, int Hour, int Minute, int Second)
        {
            string time = Year + "-" + Month + "-" + Day + " " + Hour + ":" + Minute + ":" + Second;
            Mensajes.Add("Verify OK.UserID=" + EnrollNumber.ToString() + " isInvalid=" + IsInValid.ToString() + " state=" + AttState.ToString() + " verifystyle=" + VerifyMethod.ToString() + " time=" + time);

            throw new NotImplementedException();
        }

        //Cuando presiones el keypad, este evento se activará.
        void axCZKEM1_OnKeyPress(int iKey)
        {
            Mensajes.Add("RTEvent OnKeyPress ha sido activado, Key: " + iKey.ToString());
        }

        // Cuando esté registrando su dedo, se activará este evento.
        void axCZKEM1_OnEnrollFinger(int EnrollNumber, int FingerIndex, int ActionResult, int TemplateLength)
        {
            if (ActionResult == 0)
            {
                Mensajes.Add("Dedo registrado. UserID=" + EnrollNumber + "...FingerIndex=" + FingerIndex.ToString());
            }
            else
            {
                Mensajes.Add("Fallo registrando el dedo. Result=" + ActionResult.ToString());
            }
            throw new NotImplementedException();
        }

        public bool PingReloj(cReloj miReloj)
        {
            try
            {
                string ipAddress = miReloj.IP;

                bool isValidIpA = UniversalStatic.ValidateIP(ipAddress);
                if (!isValidIpA)
                    throw new Exception("El IP is invalido !!");

                isValidIpA = UniversalStatic.PingTheDevice(ipAddress);
                if (isValidIpA)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al hacer ping el reloj: " + ex.Message);
            }
        }


    }
}
