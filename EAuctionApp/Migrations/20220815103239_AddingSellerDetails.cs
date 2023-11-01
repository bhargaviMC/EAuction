using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EAuctionApp.Migrations
{
    public partial class AddingSellerDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BidName",
                table: "BidDetails");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "ProductDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ProductDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SellerAddress",
                table: "ProductDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SellerFirstName",
                table: "ProductDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SellerLastName",
                table: "ProductDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SellerMobile",
                table: "ProductDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SellerZipCode",
                table: "ProductDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "ProductDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "SellerAddress",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "SellerFirstName",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "SellerLastName",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "SellerMobile",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "SellerZipCode",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "State",
                table: "ProductDetails");

            migrationBuilder.AddColumn<string>(
                name: "BidName",
                table: "BidDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
