using IdentityServer.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer.Persistence.EntityTypeConfigurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("User");

            builder.HasData(
                new AppUser
                {
                    Id = "4ec7a303-11f5-46d0-a1e4-8987b9aba75b",
                    FirstName = "Ilya",
                    Surname = "Suprunovich",
                    UserName = "ilyas",
                    NormalizedUserName = "ILYAS",
                    PasswordHash = "AQAAAAIAAYagAAAAEL5Gl55VQKbLyrBDSlSZOe/Kuy+FixM0F3EMgmM6Rpc1p5cBo/j3++qLV/WGGYY3UA==",
                    SecurityStamp = "JOJOODV4ENTP3QVBJTT4B66P6VFOL35F",
                    ConcurrencyStamp = "122b3299-78bc-43ae-9738-3674b51b19d9",
                    // Password : 123456Qw*
                },
                new AppUser
                {
                    Id = "2f155e1a-d652-4a4c-b799-4d7653cdb27e",
                    FirstName = "Vlad",
                    Surname = "Vladov",
                    UserName = "user",
                    NormalizedUserName = "USER",
                    PasswordHash = "AQAAAAIAAYagAAAAEFaWGRo25wrgLg7x9iV5zTbh5LX4ah6I6wbxoosisR8+4pkN5kCGJL+9QS5vum3jTA==",
                    SecurityStamp = "TCUAOH2JHZ74OW5K5T5N5UZGWY6PUFBD",
                    ConcurrencyStamp = "20170531-a113-460a-a566-3fb61ae71e69",
                    // Password : 654321Qw*
                }
            );
        }
    }

}
