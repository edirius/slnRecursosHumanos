using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;

namespace CapaDeNegocios.VerificadorDNI
{
    

    public class cVerificadorDNI
    {
        HttpClient client;
        private string URL = "";

        public trabajadorValidado TraerTrabajadorValidado(string myDNI, string bearer)
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
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + bearer);



                HttpResponseMessage response = client.GetAsync(URL).Result;


                trabajadorValidado myTra = new trabajadorValidado();
                string respuesta = response.Content.ReadAsStringAsync().Result;


                myTra = JsonConvert.DeserializeObject<trabajadorValidado>(respuesta);

                return myTra;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException(ex.Message);

            }


        }
    }


}
