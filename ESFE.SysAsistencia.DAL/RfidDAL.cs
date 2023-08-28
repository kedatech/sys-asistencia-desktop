using ESFE.SysAsistencia.EN;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static ESFE.SysAsistencia.DAL.ComunApi;

namespace ESFE.SysAsistencia.DAL
{
    /// <summary>
    /// Clase para hacer uso del RFID y hacer consulta por API
    /// Creador: Eiseo Arévalo
    /// </summary>
    public  class RfidDAL
    {
        public async Task<bool> PostUid(string uid, int estudianteId)
        {
            var request = new RestRequest("/rfid", Method.Post);
            var cancellationToken = new CancellationToken(); // Debes definir un token de cancelación

            // Agregar los parámetros en el cuerpo de la solicitud
            request.AddBody(new { uid, estudianteId});

            try
            {
                var response = await restClient.ExecuteAsync(request, cancellationToken);

                // Procesar la respuesta aquí
                if (response != null) // Verifica si la respuesta fue exitosa (código 200)
                {

                    return true;
                }
                else
                {
                    Console.WriteLine("Error en la solicitud:");
                    if (response != null)
                    {
                        Console.WriteLine("Código de estado HTTP: " + response.StatusCode);
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepción al realizar la solicitud:");
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
