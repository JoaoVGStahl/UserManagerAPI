using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApi.Data.Migrations
{
    public partial class UserEmailUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_usuario_Email",
                table: "usuario",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_usuario_Email",
                table: "usuario");
        }
    }
}
