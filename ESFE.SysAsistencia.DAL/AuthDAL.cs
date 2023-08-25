using System;
using System.Threading;
using System.Threading.Tasks;
// RestSharp usings
using RestSharp;
using RestSharp.Authenticators;
using ESFE.SysAsistencia.EN; // Asegúrate de agregar esta referencia al espacio de nombres correcto

namespace ESFE.SysAsistencia.DAL
{
    public class AuthDAL
    {
        public async Task<Auth> Login(string correo, string contrasenia)
        {
            // Crea el cliente RestSharp
            var options = new RestClientOptions("https://esfe-asistencia-api-dev.fl0.io/api");
            var client = new RestClient(options);

            var request = new RestRequest("/asistencia", Method.Post);
            var cancellationToken = new CancellationToken(); // Debes definir un token de cancelación

            // Agregar los parámetros en el cuerpo de la solicitud
            
            request.AddObject(new { correo = correo, contrasenia = contrasenia });

            var response = await client.PostAsync<Auth>(request, cancellationToken);

            // Procesar la respuesta aquí
            if (response != null)
            {
                Console.WriteLine("Respuesta exitosa:");
                Console.WriteLine(response);
                return response;
            }
            else
            {
                Console.WriteLine("Error en la solicitud:");
                return null;
            }
        }
    }
}
