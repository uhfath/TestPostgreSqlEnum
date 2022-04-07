using Microsoft.EntityFrameworkCore;
using Npgsql;
using MedService.API.Database.Entities.Enums;
using MedService.API.Database.Entities.Data;
using Microsoft.Extensions.Logging;

namespace MedService.API.Database;

public class MedServiceDbContext : DbContext
{
	public const string DatabaseSchema = "public";

	public DbSet<Client> Clients { get; protected set; }

	static MedServiceDbContext()
	{
		var nameTranslator = NpgsqlConnection.GlobalTypeMapper.DefaultNameTranslator;
		NpgsqlConnection.GlobalTypeMapper.MapEnum<SexType>($"{DatabaseSchema}.{nameTranslator.TranslateTypeName(nameof(SexType))}", nameTranslator);

		//NpgsqlConnection.GlobalTypeMapper.MapEnum<SexType>();
	}

	private static void MapTypes(ModelBuilder modelBuilder)
	{
		var nameTranslator = NpgsqlConnection.GlobalTypeMapper.DefaultNameTranslator;

		modelBuilder
			.HasPostgresEnum<SexType>(DatabaseSchema, nameTranslator.TranslateTypeName(nameof(SexType)), nameTranslator);
		;
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		MapTypes(modelBuilder);
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
		optionsBuilder
			.UseNpgsql(@"Host=localhost;Database=TestEnum;Username=postgres;Password=123")
			.LogTo(Console.WriteLine, LogLevel.Trace)
			.EnableSensitiveDataLogging()
		;

	public MedServiceDbContext()
	{
	}
}
