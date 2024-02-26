using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        //Vinculo entre rol y usuario
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "07655f71-90c3-445c-9bb4-983463cea466",
                    UserId = "28ad3b37-c788-4930-b3f8-9d06c1d59ae6"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "945a3c35-89c1-4b90-b485-14319378b702",
                    UserId = "3af526db-b8be-4e87-9639-5bd9b93c880e"
                }
            );
        }
    }
}
