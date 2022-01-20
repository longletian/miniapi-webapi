using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace miniapi_webapi.Migrations
{
    public partial class updatemigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_user_t_department_DepartmentEntityId",
                table: "t_user");

            migrationBuilder.AlterColumn<Guid>(
                name: "DepartmentEntityId",
                table: "t_user",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_t_user_t_department_DepartmentEntityId",
                table: "t_user",
                column: "DepartmentEntityId",
                principalTable: "t_department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_user_t_department_DepartmentEntityId",
                table: "t_user");

            migrationBuilder.AlterColumn<Guid>(
                name: "DepartmentEntityId",
                table: "t_user",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_t_user_t_department_DepartmentEntityId",
                table: "t_user",
                column: "DepartmentEntityId",
                principalTable: "t_department",
                principalColumn: "Id");
        }
    }
}
