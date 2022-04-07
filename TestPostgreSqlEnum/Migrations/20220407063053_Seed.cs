using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestPostgreSqlEnum.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertClients();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
