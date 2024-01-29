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

        public trabajadorValidado TraerTrabajadorValidado(string myDNI)
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


}
