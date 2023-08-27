using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using ESFE.SysAsistencia.EN;
using static ESFE.SysAsistencia.DAL.ComunApi;

namespace ESFE.SysAsistencia.DAL
{
    public class AuthDAL     
    {
        public async Task<Auth> Login(string correo, string contrasenia)
        {
            var request = new RestRequest("/auth/login", Method.Post);
            var cancellationToken = new CancellationToken(); // Debes definir un token de cancelación

            // Agregar los parámetros en el cuerpo de la solicitud
            request.AddBody(new { correo = correo, contrasenia = contrasenia });

            try
            {
                var response = await restClient.ExecuteAsync(request, cancellationToken);

                // Procesar la respuesta aquí
                if (response != null) // Verifica si la respuesta fue exitosa (código 200)
                {
                    using (var responseStream = new MemoryStream(response.RawBytes))
                    {
                        responseStream.Position = 0; // Posicionar el puntero al principio del flujo
                        var auth = await JsonSerializer.DeserializeAsync<Auth>(responseStream);

                        Console.WriteLine("Respuesta exitosa:");
                        Console.WriteLine(response.Content); // Puedes acceder al contenido de la respuesta
                        return auth;
                    }
                }
                else
                {
                    Console.WriteLine("Error en la solicitud:");
                    if (response != null)
                    {
                        Console.WriteLine("Código de estado HTTP: " + response.StatusCode);
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepción al realizar la solicitud:");
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
