using IdentityServer.Domain;
using IdentityServer.Persistence.EntityTypeConfigurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
/*            builder.Entity<AppUser>(entity => entity.ToTable(name: "User"));
            builder.Entity<IdentityRole>(entity => entity.ToTable(name: "Role"));
            builder.Entity<IdentityUserRole<string>>(entity => entity.ToTable(name: "UserRole"));
            builder.Entity<IdentityUserLogin<string>>(entity => entity.ToTable(name: "UserLogin"));
            builder.Entity<IdentityUserToken<string>>(entity => entity.ToTable(name: "UserToken"));
            builder.Entity<IdentityRoleClaim<string>>(entity => entity.ToTable(name: "RoleClaim"));

            builder.Entity<AppUser>().HasData(
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

            builder.Entity<IdentityRole>().HasData(
                    new IdentityRole
                    {
                        Id = "1",
                        Name = "Admin",
                        NormalizedName = "ADMIN",
                        ConcurrencyStamp = "stamp"

                    },

                    new IdentityRole
                    {
                        Id = "2",
                        Name = "User",
                        NormalizedName = "USER",
                        ConcurrencyStamp = "stamp2"
                    });

            builder.Entity<IdentityUserRole<string>>().HasData(

                new IdentityUserRole<string> { UserId = "4ec7a303-11f5-46d0-a1e4-8987b9aba75b", RoleId = "1" },
                new IdentityUserRole<string> { UserId = "2f155e1a-d652-4a4c-b799-4d7653cdb27e", RoleId = "2" }
                );*/

            builder.ApplyConfiguration(new AppUserConfiguration());
            builder.ApplyConfiguration(new IdentityUserRoleConfiguration());
            builder.ApplyConfiguration(new IdentityRoleConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
