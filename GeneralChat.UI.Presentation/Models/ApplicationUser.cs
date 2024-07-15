using Microsoft.AspNetCore.Identity;

namespace GeneralChat.UI.Presentation.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Propiedades adicionales según tu descripción
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } // Considera utilizar el sistema de hashes de contraseñas de Identity
        public int Edad { get; set; }
        public int IdEstatus { get; set; }
    }
}
