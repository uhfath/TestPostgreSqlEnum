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

	private static string TranslateTypeName<T>() => NameTranslator.TranslateTypeName(typeof(T).Name);
	private static readonly INpgsqlNameTranslator NameTranslator = NpgsqlConnection.GlobalTypeMapper.DefaultNameTranslator;

	static MedServiceDbContext()
	{
		NpgsqlConnection.GlobalTypeMapper.MapEnum<SexType>($"{DatabaseSchema}.{TranslateTypeName<SexType>()}", NameTranslator);
	}

	private static void MapTypes(ModelBuilder modelBuilder)
	{
		modelBuilder
			.HasPostgresEnum<SexType>(DatabaseSchema, TranslateTypeName<SexType>(), NameTranslator)
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
