namespace Cards.Infrastructure
{
    using Cards.Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PreparateDatabase(this IApplicationBuilder app)
        {
            using var scopesScope = app.ApplicationServices.CreateScope();

            var services = scopesScope.ServiceProvider;

            MigrateDatabase(services);



            return app;
        }

        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<ApplicationDbContext>();
            data.Database.Migrate();
        }
    }
}
