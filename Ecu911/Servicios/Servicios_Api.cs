using System.Text;
using Newtonsoft.Json;
using System.Net.Http.Headers;


namespace Ecu911.Servicios
{
    public class Servicios_Api
    {


        //private static string _clave;
        //private static string _usuario;
        //private static string _baseUrl;
        //private static string _token;

        //public Servicios_Api()
        //{

           
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

        //        _usuario = builder.GetSection("ApiSetting:usuario").Value;
        //        _clave = builder.GetSection("ApiSetting:clave").Value;
        //        _baseUrl = builder.GetSection("ApiSetting:baseUrl").Value;
         

            
        //}

        ////USAR REFERENCIAS 
        //public async Task Autenticar()
        //{

        //    var cliente = new HttpClient();
        //    cliente.BaseAddress = new Uri(_baseUrl);

        //    var credenciales = new User() { UserName = _usuario, PasswordHash = _clave };

        //    var content = new StringContent(JsonConvert.SerializeObject(credenciales), Encoding.UTF8, "application/json");
        //    var response = await cliente.PostAsync("api/Autenticacion/Validar", content);
        //    var json_respuesta = await response.Content.ReadAsStringAsync();

        //    var resultado = JsonConvert.DeserializeObject<ResultadoCredencial>(json_respuesta);
        //    _token = resultado.token;
        //}
    }
}
