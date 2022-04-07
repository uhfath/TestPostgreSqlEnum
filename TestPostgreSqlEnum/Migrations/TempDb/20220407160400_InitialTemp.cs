using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TestPostgreSqlEnum;

#nullable disable

namespace TestPostgreSqlEnum.Migrations.TempDb
{
    public partial class InitialTemp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "temp");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:temp.temp_enum_type", "value1,value2");

            migrationBuilder.CreateTable(
                name: "Temps",
                schema: "temp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TempEnum = table.Column<TempEnumType>(type: "temp.temp_enum_type", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temps", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Temps",
                schema: "temp");
        }
    }
}
