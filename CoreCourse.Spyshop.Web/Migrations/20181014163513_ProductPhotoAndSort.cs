using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreCourse.Spyshop.Web.Migrations
{
    public partial class ProductPhotoAndSort : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SortNumber",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SortNumber",
                table: "Products");
        }
    }
}
