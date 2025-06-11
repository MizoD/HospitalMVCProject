using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalMVCProject.Migrations
{
    /// <inheritdoc />
    public partial class editDoctors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Avilable",
                table: "Doctors",
                newName: "Available");

            migrationBuilder.AddColumn<int>(
                name: "Traffic",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Traffic",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "Available",
                table: "Doctors",
                newName: "Avilable");
        }
    }
}
