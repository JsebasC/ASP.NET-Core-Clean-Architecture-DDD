using CleanArchitecture.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        //Semillas de datos
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            //Usuario Administrador
            builder.HasData(new ApplicationUser
            {
                Id = "28ad3b37-c788-4930-b3f8-9d06c1d59ae6",
                Email = "admin@localhost.com",
                NormalizedEmail = "admin@localhost.com",
                Nombre = "Full",
                Apellidos = "Administrador",
                UserName = "admin",
                PasswordHash = hasher.HashPassword(null, "admin123"),
                EmailConfirmed = true
            });

            //Usuario Estandar
            builder.HasData(new ApplicationUser
            {
                Id = "3af526db-b8be-4e87-9639-5bd9b93c880e",
                Email = "juanperez@localhost.com",
                NormalizedEmail = "juanperez@localhost.com",
                Nombre = "Juan",
                Apellidos = "Perez",
                UserName = "juanperez",
                PasswordHash = hasher.HashPassword(null, "admin123"),
                EmailConfirmed = true
            });
        }
    }
}
