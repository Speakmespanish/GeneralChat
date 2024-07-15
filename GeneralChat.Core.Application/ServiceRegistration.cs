using GeneralChat.Core.Application.Interfaces.Services;
using GeneralChat.Core.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralChat.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICommentService, CommentService>();
        }
    }
}
