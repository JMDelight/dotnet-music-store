using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicStore.Migrations
{
    public partial class updateSale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_AspNetUsers_ApplicationUserId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_ApplicationUserId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Sales");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Sales",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_UserId",
                table: "Sales",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_AspNetUsers_UserId",
                table: "Sales",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_AspNetUsers_UserId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_UserId",
                table: "Sales");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Sales",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Sales",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ApplicationUserId",
                table: "Sales",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_AspNetUsers_ApplicationUserId",
                table: "Sales",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
