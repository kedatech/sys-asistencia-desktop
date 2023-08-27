using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ESFE.SysAsistencia.DAL
{
    public class ComunApi
    {
        public class ApiResponse<T>
        {
            [JsonPropertyName("data")]
            public T Data { get; set; }

            [JsonPropertyName("message")]
            public string Message { get; set; }

            [JsonPropertyName("success")]
            public bool Success { get; set; }
        }

    }
}
