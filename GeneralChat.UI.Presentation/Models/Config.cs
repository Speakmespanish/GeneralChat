namespace GeneralChat.UI.Presentation.Models
{
    using System;
    using Microsoft.Extensions.Configuration;

    public class Config
    {
        public static string SecretKey { get; } = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        public static string SqlConnectionString { get; set; }

        public Config(IConfiguration configuration)
        {
            SqlConnectionString = configuration.GetConnectionString("DefaultConnection");
        }
    }

}
