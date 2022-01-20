namespace miniapi_webapi
{
    public static class ProgramExtenstion
    {
        public static void AddCommonService(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();

            builder.Services.AddScoped<IUserRepository, UserRepository>();
        }

        /// <summary>
        /// 注入数据库连接
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="configuration"></param>
        public static void AddDbContextService(this WebApplicationBuilder builder, string conStr)
        {
            builder.Services.AddDbContextPool<AppDbContext>((option) =>
            {
                option.UseMySql(conStr, new MySqlServerVersion(new Version(8, 0, 27)))
                    .LogTo(Console.WriteLine, LogLevel.Debug)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            });

        }

        /// <summary>
        /// 注入graphql
        /// </summary>
        /// <param name="builder"></param>
        public static void AddGraphqlService(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddGraphQLServer()
                .AddQueryType<UserQuery>();
        }

        public static void ConfigurationService(this WebApplicationBuilder builder)
        {
            builder?.Host.ConfigureAppConfiguration((c) =>
            {
                c.SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                   .AddEnvironmentVariables();
            });
        }

        public static void UseGraphqlUI(this IApplicationBuilder builder)
        {
            builder.UseGraphQLVoyager(new VoyagerOptions()
            {
                GraphQLEndPoint = "/graphql"
            }, "/graphql-voyager");
        }
    }
}
