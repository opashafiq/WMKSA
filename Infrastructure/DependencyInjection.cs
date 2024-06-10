using Application.Common.Interfaces;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Infrastructure
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IJsonWebTokenService, JsonWebTokenService>();

            //// JWT Token Generation Symmetric Key and Services
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this-is-signing-key this-is-signing-key this-is-signing-key")); // This should be the key given during token creation
            var tokenValidationParameter = new TokenValidationParameters()
            {
                IssuerSigningKey = signingKey,
                ValidateIssuer = false,
                ValidateAudience = false
            };

            // Validate the incoming JWT here
            services.AddAuthentication
                (x => x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(jwt =>
                    {
                        jwt.TokenValidationParameters = tokenValidationParameter;
                    }
                    );


            //////////////////////////////////////////////////


            return services;
        }
    }
}
