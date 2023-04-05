using IdentityModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Text.Json;



namespace Imperial_Metric.WebApi.Extensions
{
    public static class ServiceExtensions
    {

        public static void AddSwaggerExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Imperial Metric",
                    Description = "This is Test Api Nothing To Serious",
                    Contact = new OpenApiContact
                    {
                        Name = "Collins Ddumba",
                        Email = "collinsmaverick11@gmail.com",
                    }
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Description = "Please enter a valid token",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            },
                            Scheme = "Bearer",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        }, new List<string>()
                    },
                });
            });
        }

        public static void AddControllersExtension(this IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                });
        }

        //Configure CORS to allow any origin, header and method. 
        //Change the CORS policy based on your requirements.
        //More info see: https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-3.0

        public static void AddCorsExtension(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });
        }


        public static void AddVersionedApiExplorerExtension(this IServiceCollection services)
        {
            services.AddVersionedApiExplorer(o =>
            {
                o.GroupNameFormat = "'v'VVV";
                o.SubstituteApiVersionInUrl = true;
            });
        }
        public static void AddApiVersioningExtension(this IServiceCollection services)
        {
            services.AddApiVersioning(config =>
            {
                // Specify the default API Version as 1.0
                config.DefaultApiVersion = new ApiVersion(1, 0);
                // If the client hasn't specified the API version in the request, use the default API version number 
                config.AssumeDefaultVersionWhenUnspecified = true;
                // Advertise the API versions supported for the particular endpoint
                config.ReportApiVersions = true;
            });
        }
        public static void AddJWTAuthentication(this IServiceCollection services, IConfiguration configuration)
        {

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)//IdentityServerAuthenticationDefaults.AuthenticationScheme
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = configuration["Sts:ServerUrl"];
                    options.RequireHttpsMetadata = false;
                })
                //.AddJwtBearer(options =>
                //{
                    
                //    options.TokenValidationParameters = new TokenValidationParameters()
                //    {
                //        ClockSkew = TimeSpan.Zero,
                //        ValidateIssuer = true,
                //        ValidateAudience = true,
                //        ValidateLifetime = true,
                //        ValidateIssuerSigningKey = true,
                //        ValidIssuer = "ImperialToMertic",
                //        ValidAudience = "ImperialToMertic",
                //        IssuerSigningKey = new SymmetricSecurityKey(
                //            Encoding.UTF8.GetBytes("32ewrerwerwerwerwe")
                //        ),
                //    };
                //})
            ;

        }
        public static void AddAuthorizationPolicies(this IServiceCollection services, IConfiguration configuration)
        {
            string admin = configuration["ApiRoles:AdminRole"],
                    user = configuration["ApiRoles:ManagerRole"];

            services.AddAuthorization(options =>
            {
                options.AddPolicy(AuthorizationConsts.AdminPolicy, policy => policy.RequireAssertion(context => HasRole(context.User, admin)));
                options.AddPolicy(AuthorizationConsts.UserPolicy, policy => policy.RequireAssertion(context => HasRole(context.User, user) || HasRole(context.User, admin)));
             });
        }
        public static bool HasRole(ClaimsPrincipal user, string role)
        {
            if (string.IsNullOrEmpty(role))
                return false;

            return user.HasClaim(c =>
                                (c.Type == JwtClaimTypes.Role || c.Type == $"client_{JwtClaimTypes.Role}") &&
                                System.Array.Exists(c.Value.Split(','), e => e == role)
                            );
        }

    }

}
