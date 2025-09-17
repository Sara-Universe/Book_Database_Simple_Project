using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBaseExample.Migrations
{
    /// <inheritdoc />
    public partial class AddUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserFavoriteBooks",
                columns: table => new
                {
                    FavoriteBooksId = table.Column<int>(type: "int", nullable: false),
                    FavoriteByUsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavoriteBooks", x => new { x.FavoriteBooksId, x.FavoriteByUsersId });
                    table.ForeignKey(
                        name: "FK_UserFavoriteBooks_Books_FavoriteBooksId",
                        column: x => x.FavoriteBooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFavoriteBooks_Users_FavoriteByUsersId",
                        column: x => x.FavoriteByUsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserFavoriteBooks_FavoriteByUsersId",
                table: "UserFavoriteBooks",
                column: "FavoriteByUsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFavoriteBooks");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
