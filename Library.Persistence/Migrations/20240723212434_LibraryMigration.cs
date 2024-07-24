using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class LibraryMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Surname = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateOfBirth = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Country = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FileName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Path = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContentType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LibraryUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryUsers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ISBN = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Genre = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuthorId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IsBookInLibrary = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValue: true),
                    TimeOfTake = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    TimeOfReturn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ImageId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    LibraryUserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Books_LibraryUsers_LibraryUserId",
                        column: x => x.LibraryUserId,
                        principalTable: "LibraryUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Country", "DateOfBirth", "Name", "Surname" },
                values: new object[,]
                {
                    { new Guid("24a6d8d9-df41-4380-b109-d83f60aac625"), "Russia", new DateTime(1891, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mikhail", "Bulgakov" },
                    { new Guid("2fafcf8b-75a9-4c61-b3ed-be974319b076"), "Russia", new DateTime(1799, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alexander", "Pushkin" },
                    { new Guid("5ab71203-e9c7-42f3-905f-63c780c12611"), "Russia", new DateTime(1828, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lev", "Tolstoy" },
                    { new Guid("aa4ae982-75f4-400f-9ed3-b0d11c3523e2"), "Russia", new DateTime(1860, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anton", "Chekhov" },
                    { new Guid("e9e99f1f-ba87-40ee-9093-a06dc4140831"), "Russia", new DateTime(1821, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fyodor", "Dostoevsky" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "ContentType", "FileName", "Path" },
                values: new object[,]
                {
                    { new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c11"), "image/jpeg", "war_and_peace.jpeg", "D:\\Программирование\\Library\\Library.Persistence\\Image\\war_and_peace.jpeg" },
                    { new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c12"), "image/jpeg", "anna_karenina.jpeg", "D:\\Программирование\\Library\\Library.Persistence\\Image\\anna_karenina.jpeg" },
                    { new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c13"), "image/jpeg", "crime_and_punishment.jpeg", "D:\\Программирование\\Library\\Library.Persistence\\Image\\crime_and_punishment.jpeg" },
                    { new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c14"), "image/jpeg", "the_brothers_karamazov.jpeg", "D:\\Программирование\\Library\\Library.Persistence\\Image\\the_brothers_karamazov.jpeg" },
                    { new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c15"), "image/jpeg", "the_seagull.jpeg", "D:\\Программирование\\Library\\Library.Persistence\\Image\\the_seagull.jpeg" },
                    { new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c16"), "image/jpeg", "uncle_vanya.jpeg", "D:\\Программирование\\Library\\Library.Persistence\\Image\\uncle_vanya.jpeg" },
                    { new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c17"), "image/jpeg", "eugene_onegin.jpeg", "D:\\Программирование\\Library\\Library.Persistence\\Image\\eugene_onegin.jpeg" },
                    { new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c18"), "image/jpeg", "the_captains_daughter.jpeg", "D:\\Программирование\\Library\\Library.Persistence\\Image\\the_captains_daughter.jpeg" },
                    { new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c19"), "image/jpeg", "the_master_and_margarita.jpeg", "D:\\Программирование\\Library\\Library.Persistence\\Image\\the_master_and_margarita.jpeg" },
                    { new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c20"), "image/jpeg", "heart_of_a_dog.jpeg", "D:\\Программирование\\Library\\Library.Persistence\\Image\\heart_of_a_dog.jpeg" }
                });

            migrationBuilder.InsertData(
                table: "LibraryUsers",
                column: "Id",
                values: new object[]
                {
                    new Guid("2f155e1a-d652-4a4c-b799-4d7653cdb27e"),
                    new Guid("4ec7a303-11f5-46d0-a1e4-8987b9aba75b")
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "Genre", "ISBN", "ImageId", "IsBookInLibrary", "LibraryUserId", "Name", "TimeOfReturn", "TimeOfTake" },
                values: new object[] { new Guid("1a7d9b8d-6c8f-4db0-8d7b-9d9b7c0f7c2d"), new Guid("5ab71203-e9c7-42f3-905f-63c780c12611"), "A complex novel in eight parts, with more than a dozen major characters, it deals with themes of betrayal, faith, family, marriage, Imperial Russian society, desire, and rural vs. city life.", "Novel", "9780143035008", new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c12"), false, new Guid("2f155e1a-d652-4a4c-b799-4d7653cdb27e"), "Anna Karenina", null, null });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "Genre", "ISBN", "ImageId", "LibraryUserId", "Name", "TimeOfReturn", "TimeOfTake" },
                values: new object[,]
                {
                    { new Guid("1a7d9b8d-6c8f-4db0-8d7b-9d9b7c0f7c2e"), new Guid("aa4ae982-75f4-400f-9ed3-b0d11c3523e2"), "A play that deals with lost opportunities and unrequited love.", "Play", "9780140449266", new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c15"), null, "The Seagull", null, null },
                    { new Guid("1a7d9b8d-6c8f-4db0-8d7b-9d9b7c0f7c2f"), new Guid("2fafcf8b-75a9-4c61-b3ed-be974319b076"), "A historical novel that depicts the rebellion of Pugachev.", "Novel", "9780199538690", new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c18"), null, "The Captain's Daughter", null, null },
                    { new Guid("1a7d9b8d-6c8f-4db0-8d7b-9d9b7c0f7c30"), new Guid("24a6d8d9-df41-4380-b109-d83f60aac625"), "A novel about a scathing satire on Soviet Russia.", "Novel", "9780140455151", new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c20"), null, "Heart of a Dog", null, null },
                    { new Guid("24a6d8d9-df41-4380-b109-d83f60aac626"), new Guid("2fafcf8b-75a9-4c61-b3ed-be974319b076"), "A novel in verse that is a classic of Russian literature.", "Novel", "9780140448030", new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c17"), null, "Eugene Onegin", null, null }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "Genre", "ISBN", "ImageId", "IsBookInLibrary", "LibraryUserId", "Name", "TimeOfReturn", "TimeOfTake" },
                values: new object[] { new Guid("e2a6d4fd-8c3a-4b89-9fe7-9c80d9d5e9c2"), new Guid("5ab71203-e9c7-42f3-905f-63c780c12611"), "A novel that intertwines the lives of private and public individuals during the time of the Napoleonic wars.", "Novel", "9781566190275", new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c11"), false, new Guid("4ec7a303-11f5-46d0-a1e4-8987b9aba75b"), "War and Peace", null, null });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "Genre", "ISBN", "ImageId", "LibraryUserId", "Name", "TimeOfReturn", "TimeOfTake" },
                values: new object[,]
                {
                    { new Guid("e2a6d4fd-8c3a-4b89-9fe7-9c80d9d5e9c3"), new Guid("e9e99f1f-ba87-40ee-9093-a06dc4140831"), "A passionate philosophical novel that enters deeply into the ethical debates of God, free will, and morality.", "Novel", "9780374528379", new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c14"), null, "The Brothers Karamazov", null, null },
                    { new Guid("e2a6d4fd-8c3a-4b89-9fe7-9c80d9d5e9c4"), new Guid("aa4ae982-75f4-400f-9ed3-b0d11c3523e2"), "A play that portrays the visit of an elderly professor and his young wife, Yelena, to the rural estate that supports their urban lifestyle.", "Play", "9780199536696", new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c16"), null, "Uncle Vanya", null, null },
                    { new Guid("e2a6d4fd-8c3a-4b89-9fe7-9c80d9d5e9c5"), new Guid("24a6d8d9-df41-4380-b109-d83f60aac625"), "A novel that combines supernatural elements with satirical dark comedy.", "Novel", "9780141180144", new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c19"), null, "The Master and Margarita", null, null },
                    { new Guid("e9e99f1f-ba87-40ee-9093-a06dc4140832"), new Guid("e9e99f1f-ba87-40ee-9093-a06dc4140831"), "A novel about the mental anguish and moral dilemmas of an impoverished ex-student in Saint Petersburg who formulates a plan to kill an unscrupulous pawnbroker for her money.", "Novel", "9780140449136", new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c13"), null, "Crime and Punishment", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_Id",
                table: "Authors",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Id",
                table: "Books",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_ImageId",
                table: "Books",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_LibraryUserId",
                table: "Books",
                column: "LibraryUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_Id",
                table: "Images",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LibraryUsers_Id",
                table: "LibraryUsers",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "LibraryUsers");
        }
    }
}
