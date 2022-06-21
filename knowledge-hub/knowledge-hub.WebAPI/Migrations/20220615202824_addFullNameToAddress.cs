﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace knowledge_hub.WebAPI.Migrations
{
    public partial class addFullNameToAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Addresses");
        }
    }
}
