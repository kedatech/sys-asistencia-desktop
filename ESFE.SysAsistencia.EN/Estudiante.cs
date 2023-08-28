﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Esfe.SysAsistencia.EN
{
    /// <summary>
    /// Clase que representa a un Estudiante.
    /// Creador: Eliseo Arévalo
    /// </summary>
    public class Estudiante
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("codigo")]
        public string Codigo { get; set; }

        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }

        [JsonPropertyName("correo")]
        public string Correo { get; set; }

        [JsonPropertyName("telefono")]
        public string Telefono { get; set; }

        [JsonPropertyName("grupoId")]
        public int GrupoId { get; set; }

        [JsonPropertyName("grupoName")]
        public string GrupoName { get; set; }

        [JsonPropertyName("rfid")]
        public string Rfid { get; set; }


    }

    
}