using Microsoft.EntityFrameworkCore.Migrations;

namespace XProject.Migrations
{
    public partial class AddColumes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "finalPrice",
                table: "requestOfferToTrainee",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "requestOfferToTrainee",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "finalPrice",
                table: "requestOfferToTrainee");

            migrationBuilder.DropColumn(
                name: "status",
                table: "requestOfferToTrainee");
        }
    }
}
