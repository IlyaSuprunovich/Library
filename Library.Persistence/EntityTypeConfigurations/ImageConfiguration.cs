using Library.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

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

            builder.Property(image => image.Data)
                .IsRequired();

            builder.Property(image => image.ContentType)
                .IsRequired();

            builder.HasOne(image => image.Book)
                   .WithOne(book => book.Image)
                   .HasForeignKey<Image>(image => image.BookId)
                   .OnDelete(DeleteBehavior.Cascade);

            string patch = $"{Environment.CurrentDirectory}\\Image\\";

            builder.HasData(
                new Image
                {
                    Id = new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c11"),
                    FileName = "war_and_peace.jpeg",
                    Data = File.ReadAllBytes($"{patch}war_and_peace.jpeg"),
                    ContentType = "image/jpeg",
                    BookId = new Guid("e2a6d4fd-8c3a-4b89-9fe7-9c80d9d5e9c2"),
                },
                new Image
                {
                    Id = new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c12"),
                    FileName = "anna_karenina.jpeg",
                    Data = File.ReadAllBytes($"{patch}anna_karenina.jpeg"),
                    ContentType = "image/jpeg",
                    BookId = new Guid("1a7d9b8d-6c8f-4db0-8d7b-9d9b7c0f7c2d"),
                },
                new Image
                {
                    Id = new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c13"),
                    FileName = "crime_and_punishment.jpeg",
                    Data = File.ReadAllBytes($"{patch}crime_and_punishment.jpeg"),
                    ContentType = "image/jpeg",
                    BookId = new Guid("e9e99f1f-ba87-40ee-9093-a06dc4140832"),
                },
                new Image
                {
                    Id = new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c14"),
                    FileName = "the_brothers_karamazov.jpeg",
                    Data = File.ReadAllBytes($"{patch}the_brothers_karamazov.jpeg"),
                    ContentType = "image/jpeg",
                    BookId = new Guid("e2a6d4fd-8c3a-4b89-9fe7-9c80d9d5e9c3"),
                },
                new Image
                {
                    Id = new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c15"),
                    FileName = "the_seagull.jpeg",
                    Data = File.ReadAllBytes($"{patch}the_seagull.jpeg"),
                    ContentType = "image/jpeg",
                    BookId = new Guid("1a7d9b8d-6c8f-4db0-8d7b-9d9b7c0f7c2e"),
                },
                new Image
                {
                    Id = new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c16"),
                    FileName = "uncle_vanya.jpeg",
                    Data = File.ReadAllBytes($"{patch}uncle_vanya.jpeg"),
                    ContentType = "image/jpeg",
                    BookId = new Guid("e2a6d4fd-8c3a-4b89-9fe7-9c80d9d5e9c4"),
                },
                new Image
                {
                    Id = new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c17"),
                    FileName = "eugene_onegin.jpeg",
                    Data = File.ReadAllBytes($"{patch}eugene_onegin.jpeg"),
                    ContentType = "image/jpeg",
                    BookId = new Guid("24a6d8d9-df41-4380-b109-d83f60aac626"),
                },
                new Image
                {
                    Id = new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c18"),
                    FileName = "the_captains_daughter.jpeg",
                    Data = File.ReadAllBytes($"{patch}the_captains_daughter.jpeg"),
                    ContentType = "image/jpeg",
                    BookId = new Guid("1a7d9b8d-6c8f-4db0-8d7b-9d9b7c0f7c2f"),
                },
                new Image
                {
                    Id = new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c19"),
                    FileName = "the_master_and_margarita.jpeg",
                    Data = File.ReadAllBytes($"{patch}the_master_and_margarita.jpeg"),
                    ContentType = "image/jpeg",
                    BookId = new Guid("e2a6d4fd-8c3a-4b89-9fe7-9c80d9d5e9c5"),
                },
                new Image
                {
                    Id = new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c20"),
                    FileName = "heart_of_a_dog.jpeg",
                    Data = File.ReadAllBytes($"{patch}heart_of_a_dog.jpeg"),
                    ContentType = "image/jpeg",
                    BookId = new Guid("1a7d9b8d-6c8f-4db0-8d7b-9d9b7c0f7c30"),
                }
            );
        }
    }
}
