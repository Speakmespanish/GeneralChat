using System;

namespace GeneralChat.UI.Presentation.Models
{
    public class ChatMessage
    {
        public int ID { get; set; }
        public DateTime FECHA_HORA { get; set; } = DateTime.UtcNow; // Asegúrate de tener esta propiedad definida correctamente
        public string USUARIO { get; set; }
        public string MENSAJE { get; set; }
    }
}
