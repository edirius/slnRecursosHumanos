using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeNegocios;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace CapaUsuario.ImportadorExcel
{

    public partial class frmVerificadorDNI : Form
    {
        public cTrabajador oTrabajador = new cTrabajador();
        public DataTable TablaTrabajadores = new DataTable();

        HttpClient client;
        
        private string URL = "";
        private string token = "";

        public frmVerificadorDNI()
        {
            InitializeComponent();
        }

        private void frmVerificadorDNI_Load(object sender, EventArgs e)
        {
            CargaInicial();
        }

        private void CargaInicial()
        {
            TablaTrabajadores =  oTrabajador.ObtenerListaTrabajadores("t");

            TablaTrabajadores.Columns.Add("NOMBREV");
            TablaTrabajadores.Columns.Add("APELLIDOPV");
            TablaTrabajadores.Columns.Add("APELLIDOMV");
            TablaTrabajadores.Columns.Add("OBSERVACIONES");
            dtgVerificadorDNI.DataSource = TablaTrabajadores;

            //string StudentJSON = JsonConvert.SerializeObject(token);

            //StringContent Content = new StringContent(StudentJSON,
            //System.Text.Encoding.UTF8, "application / json");


        }

        private void btnVerificarDNI_Click(object sender, EventArgs e)
        {
            foreach (DataRow item in TablaTrabajadores.Rows)
            {
            //DataRow item = TablaTrabajadores.Rows[0];
                string dniParaVerificar = item["dni"].ToString();

                trabajadorValidado myTraba = TraerTrabajadorValidado(dniParaVerificar);

                if (myTraba !=null)
                {
                    item["NOMBREV"] = myTraba.Data.nombres;
                    item["APELLIDOPV"] = myTraba.Data.apellido_paterno;
                    item["APELLIDOMV"] = myTraba.Data.apellido_materno;

                    string nombreparaverificar = item["nombres"].ToString();
                    string nombreVerificado = item["NOMBREV"].ToString();

                    string apellidoPparaverificar = item["apellidoPaterno"].ToString();
                    string apellidoPVerificado = item["APELLIDOPV"].ToString();

                    string apellidoMparaverificar = item["apellidoMaterno"].ToString();
                    string apellidoMVerificado = item["APELLIDOMV"].ToString();

                    string observaciones = "";


                    if (nombreparaverificar.Trim() != nombreVerificado.Trim())
                    {
                        observaciones = observaciones + " Nombre diferente";
                    }

                    if (apellidoPparaverificar.Trim() != apellidoPVerificado.Trim())
                    {
                        observaciones = observaciones + " | Apellido paterno diferente";
                    }

                    if (apellidoMparaverificar.Trim() != apellidoMVerificado.Trim())
                    {
                        observaciones = observaciones + " | Apellido materno diferente";
                    }

                    item["OBSERVACIONES"] = observaciones;
                    System.Threading.Thread.Sleep(5000);
                }
                else
                {
                    item["OBSERVACIONES"] = "No se comprobo";
                }
            }
                
        }

        private trabajadorValidado TraerTrabajadorValidado(string myDNI)
        {
            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                client = new HttpClient();
                client.DefaultRequestHeaders.ProxyAuthorization = null;

                URL = "https://apiperu.dev/api/dni/" + myDNI;
                client.BaseAddress = new Uri(URL);

                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer 6449af0dcdd7991b8d2c956a6312a2f63ff76eef85c50113b6c90a97d0d42e5f");



                HttpResponseMessage response = client.GetAsync(URL).Result;


                trabajadorValidado myTra = new trabajadorValidado();
                string respuesta = response.Content.ReadAsStringAsync().Result;


                myTra = JsonConvert.DeserializeObject<trabajadorValidado>(respuesta);

                return myTra;
            }
            catch (Exception)
            {
                return null;
                
            }
            

        }
    }

    [JsonObject(ItemRequired = Required.Always)]

    public class trabajadorValidado
    {
        public class data
        {
            
            public string numero { get; set; }
            public string nombre_completo { get; set; }
            public string nombres { get; set; }
            public string apellido_paterno { get; set; }
            public string apellido_materno { get; set; }
            public string codigo_verificacion { get; set; }
            public string direccion { get; set; }
            public string direccion_completa { get; set; }
            public string ubigeo_sunat { get; set; }
            public string[] ubigeo { get; set; }
        }

        [JsonProperty("data")]
        public data Data { get; set; }
    }
}
