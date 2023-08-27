using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using ESFE.SysAsistencia.EN;
using Esfe.SysAsistencia.EN;
using static ESFE.SysAsistencia.DAL.ComunApi;

namespace ESFE.SysAsistencia.DAL
{
    public class EstudianteDAL
    {
        public async Task<Estudiante[]> GetEstudiantes(int idDocente)
        {
           

            var request = new RestRequest($"/estudiante/docente/{idDocente}", Method.Get);
            var cancellationToken = new CancellationToken(); // Debes definir un token de cancelación

            try
            {
                var response = await restClient.ExecuteAsync(request, cancellationToken);

                // Procesar la respuesta aquí
                if (response.IsSuccessful) // Verifica si la respuesta fue exitosa (código 200)
                {
                    using (var responseStream = new MemoryStream(response.RawBytes))
                    {
                        responseStream.Position = 0; // Posicionar el puntero al principio del flujo
                        var apiResponse = await JsonSerializer.DeserializeAsync<ApiResponse<Estudiante[]>>(responseStream);

                        if (apiResponse != null && apiResponse.Success)
                        {
                            var estudiantes = apiResponse.Data;
                            Console.WriteLine("Respuesta exitosa:");
                            foreach (var estudiante in estudiantes)
                            {
                                Console.WriteLine($"ID: {estudiante.Id}, Nombre: {estudiante.Nombre}");
                            }
                            return estudiantes;
                        }
                        else
                        {
                            Console.WriteLine("Error en la respuesta de la API:");
                            Console.WriteLine("Mensaje: " + apiResponse?.Message);
                            return null;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Error en la solicitud:");
                    Console.WriteLine("Código de estado HTTP: " + response.StatusCode);
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
