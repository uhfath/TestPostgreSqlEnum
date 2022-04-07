using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestPostgreSqlEnum.Migrations.TempDb
{
    public partial class TempSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertTemps();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
