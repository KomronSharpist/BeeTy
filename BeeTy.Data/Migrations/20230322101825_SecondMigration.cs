using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeeTy.Data.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId1",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Workers_WorkerId1",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_Users_UserId1",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_Workers_WorkerId1",
                table: "Plans");

            migrationBuilder.DropIndex(
                name: "IX_Plans_UserId1",
                table: "Plans");

            migrationBuilder.DropIndex(
                name: "IX_Plans_WorkerId1",
                table: "Plans");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserId1",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_WorkerId1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "WorkerId1",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "WorkerId1",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "WorkerId",
                table: "Plans",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Plans",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<int>(
                name: "BlogForeignKey",
                table: "Plans",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "WorkerId",
                table: "Orders",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Orders",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<int>(
                name: "BlogForeignKey",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Plans_BlogForeignKey",
                table: "Plans",
                column: "BlogForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BlogForeignKey",
                table: "Orders",
                column: "BlogForeignKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_BlogForeignKey",
                table: "Orders",
                column: "BlogForeignKey",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Workers_BlogForeignKey",
                table: "Orders",
                column: "BlogForeignKey",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_Users_BlogForeignKey",
                table: "Plans",
                column: "BlogForeignKey",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_Workers_BlogForeignKey",
                table: "Plans",
                column: "BlogForeignKey",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_BlogForeignKey",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Workers_BlogForeignKey",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_Users_BlogForeignKey",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_Workers_BlogForeignKey",
                table: "Plans");

            migrationBuilder.DropIndex(
                name: "IX_Plans_BlogForeignKey",
                table: "Plans");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BlogForeignKey",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BlogForeignKey",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "BlogForeignKey",
                table: "Orders");

            migrationBuilder.AlterColumn<long>(
                name: "WorkerId",
                table: "Plans",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Plans",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Plans",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkerId1",
                table: "Plans",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "WorkerId",
                table: "Orders",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Orders",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Orders",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkerId1",
                table: "Orders",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plans_UserId1",
                table: "Plans",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_WorkerId1",
                table: "Plans",
                column: "WorkerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId1",
                table: "Orders",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_WorkerId1",
                table: "Orders",
                column: "WorkerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId1",
                table: "Orders",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Workers_WorkerId1",
                table: "Orders",
                column: "WorkerId1",
                principalTable: "Workers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_Users_UserId1",
                table: "Plans",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_Workers_WorkerId1",
                table: "Plans",
                column: "WorkerId1",
                principalTable: "Workers",
                principalColumn: "Id");
        }
    }
}
