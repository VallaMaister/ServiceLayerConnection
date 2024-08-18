# 🧪 SAP Business One Service Layer with C# 

Este repositorio está dedicado a demostrar cómo interactuar con el **Service Layer** de **SAP Business One** utilizando **C#**. Aquí encontrarás ejemplos prácticos y snippets de código que muestran cómo utilizar C# para acceder y manipular datos a través del Service Layer.

## 📋 Descripción

El objetivo de este repositorio es proporcionar ejemplos claros de cómo utilizar C# para conectarse al Service Layer de SAP Business One, realizar operaciones CRUD, manejar autenticación, y trabajar con las APIs de SAP.

### ¿Qué es el Service Layer?

El **Service Layer** es una capa de servicios basada en OData y REST que permite a los desarrolladores interactuar con SAP Business One de manera programática, proporcionando un acceso sencillo y flexible a los datos y funcionalidades de SAP Business One.

## 💻 Cómo usar la Clase `ServiceLayer`

Para usar la clase `ServiceLayer` en tu proyecto, sigue estos pasos:

1. **Añadir la clase `ServiceLayer` y el modelo `Login`:** Incluye los archivos `ServiceLayer.cs` y `Login.cs` en tu proyecto.

2. **Modificar los datos de acceso:** Cambia los valores de `UserName`, `Password`, y `CompanyDB` en el método `Login` dentro de `ServiceLayer.cs` para que coincidan con tus credenciales de SAP Business One.

3. **Ejemplo de Uso en `Program.cs`:**

   ```csharp
   using ServiceLayerConnection.Class;

   try
   {
       Console.WriteLine("----------- Service Layer Consola ----------");
       ServiceLayer serviceLayer = new ServiceLayer();
       Console.WriteLine("Solicitando credenciales de acceso");
       Task<HttpResponseMessage> httpResponse = serviceLayer.Login();
       Console.WriteLine("Ejecutando Solicitud...");
       var loginResult = httpResponse.Result.Content.ReadAsStringAsync().Result;
       Console.WriteLine("Respuesta: " + loginResult);
       Console.ReadKey();
       Task<HttpResponseMessage> httpResponseItems = serviceLayer.getSN();
       Console.WriteLine("Ejecutando Solicitud...");
       var itemsResult = httpResponseItems.Result.Content.ReadAsStringAsync().Result;
       Console.WriteLine("Respuesta: " + itemsResult);
   }
   catch(Exception ex)
   {
       Console.WriteLine(ex.ToString());
   }
   Console.ReadKey();
   ```
4. **Ejemplo de Uso en `ServiceLayer.cs`:**
   
   ```csharp
      using ServiceLayerConnection.Model;
      using System;
      using System.Net.Http;
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
                  HttpClient.BaseAddress = new Uri("https://YourServer:50000/");
                  HttpClient.DefaultRequestHeaders.Add("Accept", "application/json");
              }
      
              public async Task<HttpResponseMessage> Login()
              {
                  Login loginData = new() { UserName = "your-username", Password = "your-password", CompanyDB = "your-companydb" };            
                  string json = JsonSerializer.Serialize(loginData);
                  HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                  HttpResponseMessage response = await HttpClient.PostAsync("b1s/v2/Login", content);
                  return response;
              }
      
              public async Task<HttpResponseMessage> getSN()
              {
                  HttpResponseMessage response = await HttpClient.GetAsync("b1s/v2/BusinessPartners");
                  return response;
              }
          }
      }
     ```
5. **Ejemplo de Uso en `Login.cs`:**
   
   ```csharp
      using System;

      namespace ServiceLayerConnection.Model
      {
          public class Login
          {
              public required string UserName { get; set; }
              public required string Password { get; set; }
              public required string CompanyDB { get; set; }
          }
      }
     ```

Este README ahora se centra en cómo utilizar la clase ServiceLayer para interactuar con el Service Layer de SAP Business One usando C#. Asegúrate de actualizar los datos de acceso (`UserName`, `Password`, y `CompanyDB`) para que coincidan con los de tu entorno SAP Business One.
