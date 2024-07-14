using GeneralChat.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GeneralChat.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<GeneralChatDatabaseContext>(opt =>
            {
                var ConnectionString = configuration.GetConnectionString("ChatDatabase");
                opt.UseSqlServer(ConnectionString);
            });
        }
    }
}
