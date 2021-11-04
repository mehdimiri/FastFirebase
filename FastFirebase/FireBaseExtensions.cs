using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFirebase
{
    public static class FirebaseExtensions
    {
        public static IServiceCollection AddFirebase(this IServiceCollection services, Action<PushOptions> setupAction)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (setupAction == null)
            {
                throw new ArgumentNullException(nameof(setupAction));
            }

            services.Configure(setupAction);
            services.TryAddSingleton<IPushService, PushService>();
            return services;
        }
    }
}
