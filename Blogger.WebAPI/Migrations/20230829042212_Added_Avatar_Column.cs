using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blogger.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Added_Avatar_Column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserAvatar",
                schema: "Identity",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserAvatar",
                schema: "Identity",
                table: "AspNetUsers");
        }
    }
}
