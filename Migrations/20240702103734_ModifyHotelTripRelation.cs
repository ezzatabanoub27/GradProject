using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalAppG.Migrations
{
    /// <inheritdoc />
    public partial class ModifyHotelTripRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Hotels_hotelId",
                table: "Trips");

            migrationBuilder.AlterColumn<int>(
                name: "hotelId",
                table: "Trips",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Hotels_hotelId",
                table: "Trips",
                column: "hotelId",
                principalTable: "Hotels",
                principalColumn: "Hotel_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Hotels_hotelId",
                table: "Trips");

            migrationBuilder.AlterColumn<int>(
                name: "hotelId",
                table: "Trips",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Hotels_hotelId",
                table: "Trips",
                column: "hotelId",
                principalTable: "Hotels",
                principalColumn: "Hotel_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
