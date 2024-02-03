using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoyalLibrary4.Migrations
{
    public partial class book2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DropIndex(
                name: "IX_BookPublisher_BookId",
                table: "BookPublisher");

            migrationBuilder.DropIndex(
                name: "IX_BookAuthor_BookId",
                table: "BookAuthor");
            */
            migrationBuilder.AddColumn<bool>(
                name: "WantRead",
                table: "Book",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

           /* migrationBuilder.AddPrimaryKey(
                name: "PK_BookPublisher",
                table: "BookPublisher",
                columns: new[] { "BookId", "PublisherId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookAuthor",
                table: "BookAuthor",
                columns: new[] { "BookId", "AuthorId" });
           */
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {/*
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookPublisher",
                table: "BookPublisher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookAuthor",
                table: "BookAuthor");
            */
            migrationBuilder.DropColumn(
                name: "WantRead",
                table: "Book");
            /*
            migrationBuilder.CreateIndex(
                name: "IX_BookPublisher_BookId",
                table: "BookPublisher",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthor_BookId",
                table: "BookAuthor",
                column: "BookId");
            */
        }
    }
}
