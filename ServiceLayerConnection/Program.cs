using ServiceLayerConnection.Class;

try
{
    // Muestra un mensaje inicial en la consola.
    Console.WriteLine("----------- Service Layer Consola ----------");

    // Crea una instancia de la clase ServiceLayer.
    ServiceLayer serviceLayer = new ServiceLayer();

    // Solicita credenciales de acceso para iniciar sesión en el Service Layer.
    Console.WriteLine("Solicitando credenciales de acceso");
    Task<HttpResponseMessage> httpResponse = serviceLayer.Login(); // Llama al método Login para realizar la solicitud.

    // Indica que la solicitud se está ejecutando.
    Console.WriteLine("Ejecutando Solicitud...");

    // Espera la respuesta de la solicitud de inicio de sesión y obtiene el contenido en formato de cadena.
    var loginResult = httpResponse.Result.Content.ReadAsStringAsync().Result;

    // Muestra la respuesta de la solicitud de inicio de sesión en la consola.
    Console.WriteLine("Respuesta: " + loginResult);


    // Realiza la solicitud para obtener los socios de negocio.
    Task<HttpResponseMessage> httpResponseItems = serviceLayer.CreateBP("V12","Prueba ", "XAXX010101000");
    Console.WriteLine("Ejecutando Solicitud...");

    // Espera la respuesta de la solicitud para obtener socios de negocio y obtiene el contenido en formato de cadena.
    var itemsResult = httpResponseItems.Result.Content.ReadAsStringAsync().Result;

    // Muestra la respuesta de la solicitud en la consola.
    Console.WriteLine("Respuesta: " + itemsResult);
}
catch (Exception ex)
{
    // Captura y muestra cualquier excepción que ocurra durante la ejecución del código.
    Console.WriteLine(ex.ToString());
}

// Espera a que el usuario presione una tecla antes de cerrar la consola.
Console.ReadKey();
