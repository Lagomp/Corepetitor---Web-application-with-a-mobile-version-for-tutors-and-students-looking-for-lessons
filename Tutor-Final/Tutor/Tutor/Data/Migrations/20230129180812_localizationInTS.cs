using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tutor.Data.Migrations
{
    public partial class localizationInTS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Localization",
                table: "Enrollments");

            migrationBuilder.AddColumn<string>(
                name: "Localization",
                table: "TeacherSubjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Localization",
                table: "TeacherSubjects");

            migrationBuilder.AddColumn<string>(
                name: "Localization",
                table: "Enrollments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
