using Microsoft.EntityFrameworkCore;
using Npgsql;
using MedService.API.Database.Entities.Enums;
using MedService.API.Database.Entities.Data;
using Microsoft.Extensions.Logging;

namespace MedService.API.Database;

public class MedServiceDbContext : DbContext
{
	public const string DatabaseSchema = "public";

	//private static readonly IEnumerable<IModelBuilderBase> ModelBuilders = AssemblyUtils.GetCurrentAssemblyTypeInstances<IModelBuilderBase>();
	//private static readonly IEnumerable<IModelBuilderSubtypesBase> ModelBuilderSubtypes = AssemblyUtils.GetCurrentAssemblyTypeInstances<IModelBuilderSubtypesBase>();

	public DbSet<Client> Clients { get; protected set; }

	static MedServiceDbContext()
	{
		NpgsqlConnection.GlobalTypeMapper.MapEnum<SexType>($"{DatabaseSchema}.{NpgsqlConnection.GlobalTypeMapper.DefaultNameTranslator.TranslateTypeName(nameof(SexType))}", NpgsqlConnection.GlobalTypeMapper.DefaultNameTranslator);
	}

	//private static void AddExtensions(ModelBuilder modelBuilder)
	//{
	//	modelBuilder
	//		.HasCollation("case_insensitive", "und-u-ks-level2", "icu", false)
	//		.HasPostgresExtension("citext")
	//		.HasPostgresExtension("uuid-ossp")
	//		.UseIdentityAlwaysColumns()
	//	;
	//}

	private static void MapTypes(ModelBuilder modelBuilder)
	{
		modelBuilder
			.HasPostgresEnum<SexType>()
		;
	}

	//private static void ApplyModelBuilders(ModelBuilder modelBuilder)
	//{
	//	ModelBuilders
	//		.Process(b => b.Build(modelBuilder));

	//	ModelBuilderSubtypes
	//		.Process(b => b.Build(modelBuilder));
	//}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		//AddExtensions(modelBuilder);
		MapTypes(modelBuilder);

		//modelBuilder.ProcessAllEntitiesAttributes();
		//ApplyModelBuilders(modelBuilder);
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
		optionsBuilder
			.UseNpgsql(@"Host=localhost;Database=TestEnum;Username=postgres;Password=123")
			.LogTo(Console.WriteLine, LogLevel.Information)
			.EnableSensitiveDataLogging()
		;

	public MedServiceDbContext()
	{
	}
}
