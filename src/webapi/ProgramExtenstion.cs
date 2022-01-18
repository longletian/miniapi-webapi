namespace miniapi_webapi
{
    public static class ProgramExtenstion
    {
        public static void AddCommonService(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen();
        }

        public static void AddDbContextService(this WebApplicationBuilder builder,IConfiguration configuration)
        {
            builder.Services.AddPooledDbContextFactory<AppDbContext>((option) =>
            {
                option.UseMySql(configuration.GetConnectionString("DbConnect"), new MySqlServerVersion(new Version(8, 0, 27)))
                            .LogTo(Console.WriteLine, LogLevel.Debug)
                            .EnableSensitiveDataLogging()
                            .EnableDetailedErrors();
            });
        }
    }
}
