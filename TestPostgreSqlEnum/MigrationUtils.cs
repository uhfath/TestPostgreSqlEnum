using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPostgreSqlEnum
{
	internal static class MigrationUtils
	{
		public static MigrationBuilder InsertClients(this MigrationBuilder migrationBuilder)
		{
            migrationBuilder.InsertData(
                "Clients",
                new[]
                {
                    nameof(MedService.API.Database.Entities.Data.Client.Id),
                    nameof(MedService.API.Database.Entities.Data.Client.Name),
                    nameof(MedService.API.Database.Entities.Data.Client.SexType),
                },
                new object[]
                {
                    1,
                    "name_female_test",
                    MedService.API.Database.Entities.Enums.SexType.Female
                });

            migrationBuilder.InsertData(
                "Clients",
                new[]
                {
                    nameof(MedService.API.Database.Entities.Data.Client.Id),
                    nameof(MedService.API.Database.Entities.Data.Client.Name),
                    nameof(MedService.API.Database.Entities.Data.Client.SexType),
                },
                new object[]
                {
                    2,
                    "name_male_test",
                    MedService.API.Database.Entities.Enums.SexType.Male
                });

            return migrationBuilder;
		}
	}
}
