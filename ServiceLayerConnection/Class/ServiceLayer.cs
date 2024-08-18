using ServiceLayerConnection.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServiceLayerConnection.Class
{
    public class ServiceLayer
    {
        public HttpClient HttpClient;

        public ServiceLayer() 
        { 
            HttpClientHandler httpClientHandler = new HttpClientHandler();

            httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient = new HttpClient(httpClientHandler);
            HttpClient.BaseAddress = new Uri("https://GDLOVALLADARE:50000/");
            HttpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<HttpResponseMessage> Login()
        {
            Login loginData = new() { UserName = "manager", Password = "Sapb1234", CompanyDB = "SBO_PRUEBAS" };            
            string json = JsonSerializer.Serialize(loginData);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await HttpClient.PostAsync("b1s/v2/Login", content);
            return response;

        }

        public async Task<HttpResponseMessage> getItems()
        {
            HttpResponseMessage response = await HttpClient.GetAsync("b1s/v2/Items");
            return response;

        }

        public async Task<HttpResponseMessage> getAcuerdosGlobales()
        {
            HttpResponseMessage response = await HttpClient.GetAsync("b1s/v2/BlanketAgreements");
            return response;
        }

        public async Task<HttpResponseMessage> getSN()
        {
            HttpResponseMessage response = await HttpClient.GetAsync("b1s/v2/BusinessPartners");
            return response;
        }
    }
}
