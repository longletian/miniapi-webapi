using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace miniapi_webapi.Migrations
{
    public partial class updatemigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_user_t_department_DepartmentEntityId",
                table: "t_user");

            migrationBuilder.DropIndex(
                name: "IX_t_user_DepartmentEntityId",
                table: "t_user");

            migrationBuilder.DropColumn(
                name: "DepartmentEntityId",
                table: "t_user");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_DepartmentId",
                table: "t_user",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_t_user_t_department_DepartmentId",
                table: "t_user",
                column: "DepartmentId",
                principalTable: "t_department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_user_t_department_DepartmentId",
                table: "t_user");

            migrationBuilder.DropIndex(
                name: "IX_t_user_DepartmentId",
                table: "t_user");

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentEntityId",
                table: "t_user",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_DepartmentEntityId",
                table: "t_user",
                column: "DepartmentEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_t_user_t_department_DepartmentEntityId",
                table: "t_user",
                column: "DepartmentEntityId",
                principalTable: "t_department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
