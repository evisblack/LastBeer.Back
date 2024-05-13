using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LastBeer.Back.Migrations
{
    /// <inheritdoc />
    public partial class TablaVisitedBar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFavourite",
                table: "FavouriteBars");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFavourite",
                table: "FavouriteBars",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
