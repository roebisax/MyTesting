using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Server
{
    public static class AuthenticationExtensions
    {
        /// <summary>
        /// Definiert die Authentifikation mittels Bärer- Token und setzt den TokenKey.
        /// Der TokenKey wird von dem <see cref="JwtAuthenticationManager"/> ausgelesen, welcher auf die appsettings.json refernziert
        /// </summary>
        /// <param name="services"></param>
        public static void AddJwtAuthentication(this IServiceCollection services)
        {
            // Authentication hinzufügen mit dem JwtBaererDefault- Schema
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                // Options werden durch die Action erst bei Ausführung herangezogen
                // Deshalb wird hier ein Scope erstellt
                var scopeFactory = services
                    .BuildServiceProvider()
                    .GetRequiredService<IServiceScopeFactory>();

                // Scope erstellen, damit der JwtService reolved werden kann.
                using (var scope = scopeFactory.CreateScope())
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(scope.ServiceProvider.GetRequiredService<IJwtAuthenicationManager>().GetTokenKey()),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                }

            });

            // Authentifikations- Manager hinzufügen
            services.AddSingleton<IJwtAuthenicationManager, JwtAuthenticationManager>();

            // Autorisierung hinzufügen
            services.AddAuthorization();
        }
    }
}
