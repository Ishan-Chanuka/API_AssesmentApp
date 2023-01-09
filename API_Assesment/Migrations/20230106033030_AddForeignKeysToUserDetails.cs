using Microsoft.EntityFrameworkCore.Migrations;

namespace API_Assesment.Migrations
{
    public partial class AddForeignKeysToUserDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_RoleType",
                table: "UserDetails",
                column: "RoleType");

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_Status",
                table: "UserDetails",
                column: "Status");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDetails_RoleType_RoleType",
                table: "UserDetails",
                column: "RoleType",
                principalTable: "RoleType",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDetails_Status_Status",
                table: "UserDetails",
                column: "Status",
                principalTable: "Status",
                principalColumn: "StatusID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDetails_RoleType_RoleType",
                table: "UserDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDetails_Status_Status",
                table: "UserDetails");

            migrationBuilder.DropIndex(
                name: "IX_UserDetails_RoleType",
                table: "UserDetails");

            migrationBuilder.DropIndex(
                name: "IX_UserDetails_Status",
                table: "UserDetails");
        }
    }
}
