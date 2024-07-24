using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Library.Domain.Entities;

namespace Library.Persistence.EntityTypeConfigurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(image => image.Id);

            builder.HasIndex(image => image.Id)
                   .IsUnique();

            builder.Property(image => image.FileName)
                .IsRequired();

            builder.Property(image => image.Path)
                .IsRequired();

            builder.Property(image => image.ContentType)
                .IsRequired();

            string[] currentDirectory = Directory.GetCurrentDirectory().Split('\\');
            currentDirectory[currentDirectory.Length - 1] = "Library.Persistence\\Image\\";
            string path = Path.Combine(currentDirectory);


            builder.HasData(
                new Image
                {
                    Id = new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c11"),
                    FileName = "war_and_peace.jpeg",
                    Path = $"{path}war_and_peace.jpeg",
                    ContentType = "image/jpeg"
                },
                new Image
                {
                    Id = new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c12"),
                    FileName = "anna_karenina.jpeg",
                    Path = $"{path}anna_karenina.jpeg",
                    ContentType = "image/jpeg"
                },
                new Image
                {
                    Id = new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c13"),
                    FileName = "crime_and_punishment.jpeg",
                    Path = $"{path}crime_and_punishment.jpeg",
                    ContentType = "image/jpeg"
                },
                new Image
                {
                    Id = new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c14"),
                    FileName = "the_brothers_karamazov.jpeg",
                    Path = $"{path}the_brothers_karamazov.jpeg",
                    ContentType = "image/jpeg"
                },
                new Image
                {
                    Id = new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c15"),
                    FileName = "the_seagull.jpeg",
                    Path = $"{path}the_seagull.jpeg",
                    ContentType = "image/jpeg"
                },
                new Image
                {
                    Id = new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c16"),
                    FileName = "uncle_vanya.jpeg",
                    Path = $"{path}uncle_vanya.jpeg",
                    ContentType = "image/jpeg"
                },
                new Image
                {
                    Id = new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c17"),
                    FileName = "eugene_onegin.jpeg",
                    Path = $"{path}eugene_onegin.jpeg",
                    ContentType = "image/jpeg"
                },
                new Image
                {
                    Id = new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c18"),
                    FileName = "the_captains_daughter.jpeg",
                    Path = $"{path}the_captains_daughter.jpeg",
                    ContentType = "image/jpeg"
                },
                new Image
                {
                    Id = new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c19"),
                    FileName = "the_master_and_margarita.jpeg",
                    Path = $"{path}the_master_and_margarita.jpeg",
                    ContentType = "image/jpeg"
                },
                new Image
                {
                    Id = new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c20"),
                    FileName = "heart_of_a_dog.jpeg",
                    Path = $"{path}heart_of_a_dog.jpeg",
                    ContentType = "image/jpeg"
                }
            );
        }
    }
}
