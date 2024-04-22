using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaffeSanGiorgio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_WaitTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WaitingTime",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WaitingTime",
                table: "Orders");
        }
    }
}
