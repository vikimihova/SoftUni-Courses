using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTicketsAvailability : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("27955fd6-6164-49bb-a4f0-e35b5fda1689"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("6490f8ce-8263-4512-9796-d1bc0b90e821"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("dd4bbbce-148c-43c7-a42e-97bbd10e8f60"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("5ea1935f-b397-4dcc-987a-c74e1e49bc12"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("7b35e8eb-77fd-404c-b37f-249b079b861e"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("8bfe60f6-7e15-44cc-a4d7-f6167347bb58"));

            migrationBuilder.AddColumn<int>(
                name: "AvailableTickets",
                table: "CinemasMovies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("433e82c0-6c3e-4c20-bd52-0e41e8174024"), "Plovdiv", "Cinema City" },
                    { new Guid("502db06d-9573-42ae-9b0a-e903c47d8c61"), "Sofia", "Cinema City" },
                    { new Guid("9ef8e29b-c8aa-4c21-9db9-7466b0517432"), "Varna", "Cinema City" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("28ce3438-789e-40df-9cb2-f74c4b4d39d7"), "Three actors accept an invitation to a Mexican village to perform their onscreen bandit fighter roles, unaware that it is the real thing.", "John Landis", 110, "Comedy", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Three Amigos!" },
                    { new Guid("5092cca2-18a5-4961-9e54-a63f65a206cd"), "Harry Potter, Ron and Hermione return to Hogwarts School of Witchcraft and Wizardry for their third year of study, where they delve into the mystery surrounding an escaped prisoner who poses a dangerous threat to the young wizard.", "Alfonso Cuarón", 120, "Fantasy", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter and the Prisoner of Azkaban" },
                    { new Guid("ffb599ea-b908-4ee8-8c64-b3784357b7fa"), "After investigating a mysterious transmission of unknown origin, the crew of a commercial spacecraft encounters a deadly lifeform.", "Ridley Scott", 105, "Horror", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alien" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("433e82c0-6c3e-4c20-bd52-0e41e8174024"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("502db06d-9573-42ae-9b0a-e903c47d8c61"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("9ef8e29b-c8aa-4c21-9db9-7466b0517432"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("28ce3438-789e-40df-9cb2-f74c4b4d39d7"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("5092cca2-18a5-4961-9e54-a63f65a206cd"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("ffb599ea-b908-4ee8-8c64-b3784357b7fa"));

            migrationBuilder.DropColumn(
                name: "AvailableTickets",
                table: "CinemasMovies");

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("27955fd6-6164-49bb-a4f0-e35b5fda1689"), "Varna", "Cinema City" },
                    { new Guid("6490f8ce-8263-4512-9796-d1bc0b90e821"), "Plovdiv", "Cinema City" },
                    { new Guid("dd4bbbce-148c-43c7-a42e-97bbd10e8f60"), "Sofia", "Cinema City" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("5ea1935f-b397-4dcc-987a-c74e1e49bc12"), "Harry Potter, Ron and Hermione return to Hogwarts School of Witchcraft and Wizardry for their third year of study, where they delve into the mystery surrounding an escaped prisoner who poses a dangerous threat to the young wizard.", "Alfonso Cuarón", 120, "Fantasy", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter and the Prisoner of Azkaban" },
                    { new Guid("7b35e8eb-77fd-404c-b37f-249b079b861e"), "After investigating a mysterious transmission of unknown origin, the crew of a commercial spacecraft encounters a deadly lifeform.", "Ridley Scott", 105, "Horror", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alien" },
                    { new Guid("8bfe60f6-7e15-44cc-a4d7-f6167347bb58"), "Three actors accept an invitation to a Mexican village to perform their onscreen bandit fighter roles, unaware that it is the real thing.", "John Landis", 110, "Comedy", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Three Amigos!" }
                });
        }
    }
}
