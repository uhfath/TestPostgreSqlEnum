using Microsoft.EntityFrameworkCore;
using Npgsql;
using MedService.API.Database.Entities.Enums;
using MedService.API.Database.Entities.Data;
using Microsoft.Extensions.Logging;
using TestPostgreSqlEnum;

namespace MedService.API.Database;

public class TempDbContext : DbContext
{
	public const string DatabaseSchema = "temp";

	public DbSet<TempModel> Temps { get; protected set; }

	private static string TranslateTypeName<T>() => NameTranslator.TranslateTypeName(typeof(T).Name);
	private static readonly INpgsqlNameTranslator NameTranslator = NpgsqlConnection.GlobalTypeMapper.DefaultNameTranslator;

	static TempDbContext()
	{
		NpgsqlConnection.GlobalTypeMapper.MapEnum<TempEnumType>($"{DatabaseSchema}.{TranslateTypeName<TempEnumType>()}", NameTranslator);
	}

	private static void MapTypes(ModelBuilder modelBuilder)
	{
		modelBuilder
			.HasPostgresEnum<TempEnumType>(DatabaseSchema, TranslateTypeName<TempEnumType>(), NameTranslator)
		;
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		MapTypes(modelBuilder);
		modelBuilder.HasDefaultSchema(DatabaseSchema);
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
		optionsBuilder
			.UseNpgsql(@"Host=localhost;Database=TestEnum;Username=postgres;Password=123")
			.LogTo(Console.WriteLine, LogLevel.Trace)
			.EnableSensitiveDataLogging()
		;

	public TempDbContext()
	{
	}
}
