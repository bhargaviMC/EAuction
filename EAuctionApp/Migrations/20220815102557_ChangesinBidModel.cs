using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EAuctionApp.Migrations
{
    public partial class ChangesinBidModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "BidDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "BidDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "BidDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "BidDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "BidDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "BidDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "BidDetails");

            migrationBuilder.DropColumn(
                name: "City",
                table: "BidDetails");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "BidDetails");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "BidDetails");

            migrationBuilder.DropColumn(
                name: "State",
                table: "BidDetails");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "BidDetails");
        }
    }
}
