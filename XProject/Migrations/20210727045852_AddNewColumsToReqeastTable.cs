using Microsoft.EntityFrameworkCore.Migrations;

namespace XProject.Migrations
{
    public partial class AddNewColumsToReqeastTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "text",
                table: "requestOfferToTrainee",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "text",
                table: "requestOfferToTrainee");
        }
    }
}
