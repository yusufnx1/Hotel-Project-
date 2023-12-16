using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelProject.DataAccesLayer.Migrations
{
    public partial class addsenmessage1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_sendMessages",
                table: "sendMessages");

            migrationBuilder.RenameTable(
                name: "sendMessages",
                newName: "SendMessages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SendMessages",
                table: "SendMessages",
                column: "SendMessageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SendMessages",
                table: "SendMessages");

            migrationBuilder.RenameTable(
                name: "SendMessages",
                newName: "sendMessages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sendMessages",
                table: "sendMessages",
                column: "SendMessageId");
        }
    }
}
