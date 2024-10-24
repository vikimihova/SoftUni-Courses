using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMovieImageUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("106a8beb-dd68-4695-9653-1b1ef8a09f5b"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("15c24d31-4014-47af-8e03-f01fda352876"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("8219006f-7a66-4fee-96bb-b86737fe3247"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("014b2d42-8385-4f47-9f2f-65bc310d0ebf"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("5d30166d-1bd8-4d02-b6a6-f9b1efee9e05"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("80c0bba6-561b-4788-914a-006a4988e95a"));

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Movies",
                type: "nvarchar(2083)",
                maxLength: 2083,
                nullable: true,
                defaultValue: "~/images/no-image.png");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "ApplicationUsersMovies",
                columns: table => new
                {
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsersMovies", x => new { x.ApplicationUserId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_ApplicationUsersMovies_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplicationUsersMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsersMovies_MovieId",
                table: "ApplicationUsersMovies",
                column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUsersMovies");

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

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Movies");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("106a8beb-dd68-4695-9653-1b1ef8a09f5b"), "Varna", "Cinema City" },
                    { new Guid("15c24d31-4014-47af-8e03-f01fda352876"), "Sofia", "Cinema City" },
                    { new Guid("8219006f-7a66-4fee-96bb-b86737fe3247"), "Plovdiv", "Cinema City" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("014b2d42-8385-4f47-9f2f-65bc310d0ebf"), "After investigating a mysterious transmission of unknown origin, the crew of a commercial spacecraft encounters a deadly lifeform.", "Ridley Scott", 105, "Horror", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alien" },
                    { new Guid("5d30166d-1bd8-4d02-b6a6-f9b1efee9e05"), "Harry Potter, Ron and Hermione return to Hogwarts School of Witchcraft and Wizardry for their third year of study, where they delve into the mystery surrounding an escaped prisoner who poses a dangerous threat to the young wizard.", "Alfonso Cuarón", 120, "Fantasy", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter and the Prisoner of Azkaban" },
                    { new Guid("80c0bba6-561b-4788-914a-006a4988e95a"), "Three actors accept an invitation to a Mexican village to perform their onscreen bandit fighter roles, unaware that it is the real thing.", "John Landis", 110, "Comedy", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Three Amigos!" }
                });
        }
    }
}
