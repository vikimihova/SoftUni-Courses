using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNoImageUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("3193081e-e633-4aee-885e-743814af0b92"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("b77ed17b-dc87-4ce0-89d6-978b777b3f4c"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("dc260d19-7f0d-44c8-95c9-1ab4f2245b3c"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("020ede14-cf78-4757-af03-4c8aa0186035"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("8dd08a05-0b0e-4527-b774-d08234da9bb1"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("9e2ffc51-3804-4639-95ce-9daba2d6e222"));

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Movies",
                type: "nvarchar(2083)",
                maxLength: 2083,
                nullable: true,
                defaultValue: "/images/no-image.png",
                oldClrType: typeof(string),
                oldType: "nvarchar(2083)",
                oldMaxLength: 2083,
                oldNullable: true,
                oldDefaultValue: "~/images/no-image.png");

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("65e0e6d4-677a-4427-b7a4-5d2742139fd2"), "Varna", "Cinema City" },
                    { new Guid("d441fe86-2759-45f8-9977-56dbabc338f0"), "Sofia", "Cinema City" },
                    { new Guid("e51ec83f-06e1-4dab-ad5e-fda60a6fdf07"), "Plovdiv", "Cinema City" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("497383fc-f435-4f46-881d-29e982a641f6"), "Three actors accept an invitation to a Mexican village to perform their onscreen bandit fighter roles, unaware that it is the real thing.", "John Landis", 110, "Comedy", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Three Amigos!" },
                    { new Guid("c2568acc-b57c-42a7-aa27-edad17ebe44c"), "After investigating a mysterious transmission of unknown origin, the crew of a commercial spacecraft encounters a deadly lifeform.", "Ridley Scott", 105, "Horror", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alien" },
                    { new Guid("da87e59c-fdb0-47c1-8d93-d1133c50a54e"), "Harry Potter, Ron and Hermione return to Hogwarts School of Witchcraft and Wizardry for their third year of study, where they delve into the mystery surrounding an escaped prisoner who poses a dangerous threat to the young wizard.", "Alfonso Cuarón", 120, "Fantasy", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter and the Prisoner of Azkaban" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("65e0e6d4-677a-4427-b7a4-5d2742139fd2"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("d441fe86-2759-45f8-9977-56dbabc338f0"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("e51ec83f-06e1-4dab-ad5e-fda60a6fdf07"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("497383fc-f435-4f46-881d-29e982a641f6"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("c2568acc-b57c-42a7-aa27-edad17ebe44c"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("da87e59c-fdb0-47c1-8d93-d1133c50a54e"));

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Movies",
                type: "nvarchar(2083)",
                maxLength: 2083,
                nullable: true,
                defaultValue: "~/images/no-image.png",
                oldClrType: typeof(string),
                oldType: "nvarchar(2083)",
                oldMaxLength: 2083,
                oldNullable: true,
                oldDefaultValue: "/images/no-image.png");

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("3193081e-e633-4aee-885e-743814af0b92"), "Plovdiv", "Cinema City" },
                    { new Guid("b77ed17b-dc87-4ce0-89d6-978b777b3f4c"), "Varna", "Cinema City" },
                    { new Guid("dc260d19-7f0d-44c8-95c9-1ab4f2245b3c"), "Sofia", "Cinema City" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("020ede14-cf78-4757-af03-4c8aa0186035"), "Three actors accept an invitation to a Mexican village to perform their onscreen bandit fighter roles, unaware that it is the real thing.", "John Landis", 110, "Comedy", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Three Amigos!" },
                    { new Guid("8dd08a05-0b0e-4527-b774-d08234da9bb1"), "Harry Potter, Ron and Hermione return to Hogwarts School of Witchcraft and Wizardry for their third year of study, where they delve into the mystery surrounding an escaped prisoner who poses a dangerous threat to the young wizard.", "Alfonso Cuarón", 120, "Fantasy", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter and the Prisoner of Azkaban" },
                    { new Guid("9e2ffc51-3804-4639-95ce-9daba2d6e222"), "After investigating a mysterious transmission of unknown origin, the crew of a commercial spacecraft encounters a deadly lifeform.", "Ridley Scott", 105, "Horror", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alien" }
                });
        }
    }
}
