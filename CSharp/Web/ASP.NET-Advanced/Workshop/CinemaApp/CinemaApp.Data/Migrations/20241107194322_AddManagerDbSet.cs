using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddManagerDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Manager_AspNetUsers_UserId",
                table: "Manager");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Manager",
                table: "Manager");

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

            migrationBuilder.RenameTable(
                name: "Manager",
                newName: "Managers");

            migrationBuilder.RenameIndex(
                name: "IX_Manager_UserId",
                table: "Managers",
                newName: "IX_Managers_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Managers",
                table: "Managers",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("5a232af7-2065-4c98-8ce3-1e16cf9e4c39"), "Varna", "Cinema City" },
                    { new Guid("e2b56978-a160-479a-b835-cf7acdabaf4f"), "Sofia", "Cinema City" },
                    { new Guid("efcbe403-741a-4d53-bc3b-9da0a7b30be0"), "Plovdiv", "Cinema City" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("2f801f4d-8865-4dfc-9267-046bbee508a9"), "After investigating a mysterious transmission of unknown origin, the crew of a commercial spacecraft encounters a deadly lifeform.", "Ridley Scott", 105, "Horror", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alien" },
                    { new Guid("9f9d191c-78ee-4fc9-bd5c-98a9d8f026ee"), "Harry Potter, Ron and Hermione return to Hogwarts School of Witchcraft and Wizardry for their third year of study, where they delve into the mystery surrounding an escaped prisoner who poses a dangerous threat to the young wizard.", "Alfonso Cuarón", 120, "Fantasy", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter and the Prisoner of Azkaban" },
                    { new Guid("e532c8af-18b1-4b86-a129-b0f3868141f5"), "Three actors accept an invitation to a Mexican village to perform their onscreen bandit fighter roles, unaware that it is the real thing.", "John Landis", 110, "Comedy", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Three Amigos!" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_AspNetUsers_UserId",
                table: "Managers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Managers_AspNetUsers_UserId",
                table: "Managers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Managers",
                table: "Managers");

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("5a232af7-2065-4c98-8ce3-1e16cf9e4c39"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("e2b56978-a160-479a-b835-cf7acdabaf4f"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("efcbe403-741a-4d53-bc3b-9da0a7b30be0"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("2f801f4d-8865-4dfc-9267-046bbee508a9"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("9f9d191c-78ee-4fc9-bd5c-98a9d8f026ee"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("e532c8af-18b1-4b86-a129-b0f3868141f5"));

            migrationBuilder.RenameTable(
                name: "Managers",
                newName: "Manager");

            migrationBuilder.RenameIndex(
                name: "IX_Managers_UserId",
                table: "Manager",
                newName: "IX_Manager_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Manager",
                table: "Manager",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Manager_AspNetUsers_UserId",
                table: "Manager",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
