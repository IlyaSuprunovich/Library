using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer.Persistence.EntityTypeConfigurations
{
    public class IdentityUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.ToTable("UserRole");

            builder.HasData(
                new IdentityUserRole<string> { UserId = "4ec7a303-11f5-46d0-a1e4-8987b9aba75b", 
                    RoleId = "1" },
                new IdentityUserRole<string> { UserId = "2f155e1a-d652-4a4c-b799-4d7653cdb27e", 
                    RoleId = "2" }
            );
        }
    }
}
