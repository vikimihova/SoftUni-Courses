using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddManager : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("6a45d990-3ca1-4ab7-97c1-60077cd598bb"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("b76389d0-6c2a-42da-aece-c42e4afa7ed2"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("f413bdb4-4dd8-4918-a65e-8d6d7d0ff108"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("22c7b2fd-644e-4385-92da-3e8c3921e763"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("26483124-5a16-4749-bfcb-aafc98ae0204"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("e9b71883-aeee-4dc7-9af7-b60f377ec234"));

            migrationBuilder.CreateTable(
                name: "Manager",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkPhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manager_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("0089d521-a0d5-4e83-a7cf-391ae0fe6c5e"), "Varna", "Cinema City" },
                    { new Guid("4b16989a-db4c-4774-b67c-0ace4245e64c"), "Sofia", "Cinema City" },
                    { new Guid("aa80542d-43a8-4f16-9c40-01dde2a6724c"), "Plovdiv", "Cinema City" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("85db2b3e-4d02-49c7-b0b2-9a4eb0784d01"), "After investigating a mysterious transmission of unknown origin, the crew of a commercial spacecraft encounters a deadly lifeform.", "Ridley Scott", 105, "Horror", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alien" },
                    { new Guid("c0cdb1ac-15c0-40a3-a7bb-b882918d441c"), "Harry Potter, Ron and Hermione return to Hogwarts School of Witchcraft and Wizardry for their third year of study, where they delve into the mystery surrounding an escaped prisoner who poses a dangerous threat to the young wizard.", "Alfonso Cuarón", 120, "Fantasy", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter and the Prisoner of Azkaban" },
                    { new Guid("d9553254-c142-4771-8484-dd2f3ef2d184"), "Three actors accept an invitation to a Mexican village to perform their onscreen bandit fighter roles, unaware that it is the real thing.", "John Landis", 110, "Comedy", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Three Amigos!" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Manager_UserId",
                table: "Manager",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Manager");

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("0089d521-a0d5-4e83-a7cf-391ae0fe6c5e"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("4b16989a-db4c-4774-b67c-0ace4245e64c"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("aa80542d-43a8-4f16-9c40-01dde2a6724c"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("85db2b3e-4d02-49c7-b0b2-9a4eb0784d01"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("c0cdb1ac-15c0-40a3-a7bb-b882918d441c"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("d9553254-c142-4771-8484-dd2f3ef2d184"));

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("6a45d990-3ca1-4ab7-97c1-60077cd598bb"), "Plovdiv", "Cinema City" },
                    { new Guid("b76389d0-6c2a-42da-aece-c42e4afa7ed2"), "Sofia", "Cinema City" },
                    { new Guid("f413bdb4-4dd8-4918-a65e-8d6d7d0ff108"), "Varna", "Cinema City" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("22c7b2fd-644e-4385-92da-3e8c3921e763"), "After investigating a mysterious transmission of unknown origin, the crew of a commercial spacecraft encounters a deadly lifeform.", "Ridley Scott", 105, "Horror", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alien" },
                    { new Guid("26483124-5a16-4749-bfcb-aafc98ae0204"), "Three actors accept an invitation to a Mexican village to perform their onscreen bandit fighter roles, unaware that it is the real thing.", "John Landis", 110, "Comedy", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Three Amigos!" },
                    { new Guid("e9b71883-aeee-4dc7-9af7-b60f377ec234"), "Harry Potter, Ron and Hermione return to Hogwarts School of Witchcraft and Wizardry for their third year of study, where they delve into the mystery surrounding an escaped prisoner who poses a dangerous threat to the young wizard.", "Alfonso Cuarón", 120, "Fantasy", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter and the Prisoner of Azkaban" }
                });
        }
    }
}
