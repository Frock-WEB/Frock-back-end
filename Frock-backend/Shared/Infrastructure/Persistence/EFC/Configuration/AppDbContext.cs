using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Frock_backend.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Frock_backend.IAM.Domain.Model.Aggregates;

namespace Frock_backend.Shared.Infrastructure.Persistence.EFC.Configuration
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {

        /// <summary>
        ///     On configuring the database context
        /// </summary>
        /// <remarks>
        ///     This method is used to configure the database context.
        ///     It also adds the created and updated date interceptor to the database context.
        /// </remarks>
        /// <param name="builder">
        ///     The option builder for the database context
        /// </param>
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.AddCreatedUpdatedInterceptor();
            base.OnConfiguring(builder);
        }

        /// <summary>
        ///     On creating the database model
        /// </summary>
        /// <remarks>
        ///     This method is used to create the database model for the application.
        /// </remarks>
        /// <param name="builder">
        ///     The model builder for the database context
        /// </param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // IAM Context

            builder.Entity<User>().HasKey(u => u.Id);
            builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(u => u.Username).IsRequired();
            builder.Entity<User>().Property(u => u.PasswordHash).IsRequired();
            builder.Entity<User>().Property(u => u.Role).HasConversion<string>().IsRequired();

            builder.UseSnakeCaseNamingConvention();
        }
    }
}
