using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EAuctionApp.Migrations
{
    public partial class MobileConstrainIntToLongChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "SellerMobile",
                table: "ProductDetails",
                type: "bigint",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 10);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SellerMobile",
                table: "ProductDetails",
                type: "int",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldMaxLength: 10);
        }
    }
}
