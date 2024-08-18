using ServiceLayerConnection.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServiceLayerConnection.Class
{
    // Clase que maneja la conexión y solicitudes al Service Layer de SAP Business One.
    public class ServiceLayer
    {
        // HttpClient para manejar las solicitudes HTTP.
        public HttpClient HttpClient;

        // Constructor de la clase ServiceLayer.
        public ServiceLayer()
        {
            // Configura el manejador de HttpClient para omitir la validación de certificados SSL.
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            // Inicializa HttpClient con el manejador configurado.
            HttpClient = new HttpClient(httpClientHandler);
            HttpClient.BaseAddress = new Uri("https://GDLOVALLADARE:50000/"); // Establece la dirección base para las solicitudes.
            HttpClient.DefaultRequestHeaders.Add("Accept", "application/json"); // Añade el encabezado para aceptar respuestas en formato JSON.
        }


        // Método asincrónico para iniciar sesión en el Service Layer.
        public async Task<HttpResponseMessage> Login()
        {
            // Crea un objeto con las credenciales de inicio de sesión.
            Login loginData = new() { UserName = "manager", Password = "Sapb1234", CompanyDB = "SBO_PRUEBAS" };
            string json = JsonSerializer.Serialize(loginData); // Serializa el objeto de credenciales a JSON.
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json"); // Prepara el contenido de la solicitud.
            HttpResponseMessage response = await HttpClient.PostAsync("b1s/v2/Login", content); // Envía la solicitud POST para iniciar sesión.
            return response; // Retorna la respuesta del servidor.
        }

        

        
        #region CRUD BusinessPartner
        // Método asincrónico para obtener la lista de socios de negocio.
        public async Task<HttpResponseMessage> getBP()
        {
            HttpResponseMessage response = await HttpClient.GetAsync("b1s/v2/BusinessPartners"); // Envía una solicitud GET para obtener los socios de negocio.
            return response; // Retorna la respuesta del servidor.
        }

        //Crear socio de negocio
        public async Task<HttpResponseMessage> CreateBP(string cardCode, string cardName, string federalTaxID)
        {
            BP bp = new()
            {
                CardCode = cardCode,
                CardName = cardName,
                FederalTaxID = federalTaxID 
            };

            // Serializa el objeto a JSON.
            string json = JsonSerializer.Serialize(bp);

            // Prepara el contenido de la solicitud HTTP.
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            // Envía la solicitud POST al endpoint de creación de artículos en el Service Layer.
            HttpResponseMessage response = await HttpClient.PostAsync("b1s/v2/BusinessPartners", content);

            // Retorna la respuesta del servidor.
            return response;
        }

        #endregion

        #region CRUD Items

        // Método asincrónico para obtener la lista de artículos.
        public async Task<HttpResponseMessage> getItems()
        {
            HttpResponseMessage response = await HttpClient.GetAsync("b1s/v2/Items"); // Envía una solicitud GET para obtener los artículos.
            return response; // Retorna la respuesta del servidor.
        }

        //Crear articulos
        public async Task<HttpResponseMessage> CreateItem(string itemCode, string itemName, bool salesItem, bool inventoryItem,bool purchanseItem)
        {
            Items item = new() { 
                ItemCode= itemCode, 
                ItemName = itemName,
                SalesItem = salesItem? "tYES" : "tNO",
                InventoryItem=inventoryItem ? "tYES" : "tNO",
                PurchaseItem = purchanseItem ? "tYES" : "tNO"
            };

            // Serializa el objeto a JSON.
            string json = JsonSerializer.Serialize(item);

            // Prepara el contenido de la solicitud HTTP.
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            // Envía la solicitud POST al endpoint de creación de artículos en el Service Layer.
            HttpResponseMessage response = await HttpClient.PostAsync("b1s/v2/Items", content);

            // Retorna la respuesta del servidor.
            return response;
        }

        #endregion

        // Método asincrónico para obtener los acuerdos globales.
        public async Task<HttpResponseMessage> getAcuerdosGlobales()
        {
            HttpResponseMessage response = await HttpClient.GetAsync("b1s/v2/BlanketAgreements"); // Envía una solicitud GET para obtener los acuerdos globales.
            return response; // Retorna la respuesta del servidor.
        }

    }
}
