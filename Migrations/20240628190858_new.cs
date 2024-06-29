using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalAppG.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Jobs_jobId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "jobId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Jobs_jobId",
                table: "AspNetUsers",
                column: "jobId",
                principalTable: "Jobs",
                principalColumn: "Job_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Jobs_jobId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "jobId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Jobs_jobId",
                table: "AspNetUsers",
                column: "jobId",
                principalTable: "Jobs",
                principalColumn: "Job_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
