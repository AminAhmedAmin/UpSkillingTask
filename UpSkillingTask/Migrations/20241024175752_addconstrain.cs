using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UpSkillingTask.Migrations
{
    /// <inheritdoc />
    public partial class addconstrain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CK_Book_Price_NonNegative",
                table: "Books",
                sql: "[Price] >= 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Book_Stock_NonNegative",
                table: "Books",
                sql: "[Stock] >= 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Book_Price_NonNegative",
                table: "Books");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Book_Stock_NonNegative",
                table: "Books");
        }
    }
}
