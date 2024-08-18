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