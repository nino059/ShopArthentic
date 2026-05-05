using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arthentic.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddDisplayOrderToCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artists_AspNetUsers_UserId",
                table: "Artists");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Paintings_PaintingId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Paintings_Categories_CategoryId",
                table: "Paintings");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Paintings_PaintingId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Artists_UserId",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "Caption",
                table: "PaintingImages");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FacebookUrl",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "InstagramUrl",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Artists");

            migrationBuilder.RenameColumn(
                name: "IsMainImage",
                table: "PaintingImages",
                newName: "IsMain");

            migrationBuilder.RenameColumn(
                name: "DisplayOrder",
                table: "PaintingImages",
                newName: "SortOrder");

            migrationBuilder.AlterColumn<string>(
                name: "Medium",
                table: "Paintings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Paintings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BirthYear",
                table: "Artists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeathYear",
                table: "Artists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Artists",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Paintings_PaintingId",
                table: "OrderDetails",
                column: "PaintingId",
                principalTable: "Paintings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Paintings_Categories_CategoryId",
                table: "Paintings",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Paintings_PaintingId",
                table: "Reviews",
                column: "PaintingId",
                principalTable: "Paintings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Paintings_PaintingId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Paintings_Categories_CategoryId",
                table: "Paintings");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Paintings_PaintingId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "BirthYear",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "DeathYear",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Artists");

            migrationBuilder.RenameColumn(
                name: "SortOrder",
                table: "PaintingImages",
                newName: "DisplayOrder");

            migrationBuilder.RenameColumn(
                name: "IsMain",
                table: "PaintingImages",
                newName: "IsMainImage");

            migrationBuilder.AlterColumn<string>(
                name: "Medium",
                table: "Paintings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Paintings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Caption",
                table: "PaintingImages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FacebookUrl",
                table: "Artists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstagramUrl",
                table: "Artists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Artists",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Artists_UserId",
                table: "Artists",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_AspNetUsers_UserId",
                table: "Artists",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Paintings_PaintingId",
                table: "OrderDetails",
                column: "PaintingId",
                principalTable: "Paintings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Paintings_Categories_CategoryId",
                table: "Paintings",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Paintings_PaintingId",
                table: "Reviews",
                column: "PaintingId",
                principalTable: "Paintings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
