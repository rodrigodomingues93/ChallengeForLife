using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChallengeForLife.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiagonalSums",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InputValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OutputValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagonalSums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VeryBigSums",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InputValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OutputValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeryBigSums", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiagonalSums");

            migrationBuilder.DropTable(
                name: "VeryBigSums");
        }
    }
}
