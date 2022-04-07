using MedService.API.Database;
using Microsoft.EntityFrameworkCore;

{
	//await using var context = new MedService.API.Database.MedServiceDbContext();

	//await context.Database.EnsureDeletedAsync();
	//await context.Database.MigrateAsync();

	//await using var connection = (Npgsql.NpgsqlConnection)context.Database.GetDbConnection();
	//await connection.OpenAsync();
	//connection.ReloadTypes();

	//context.Clients.Add(new()
	//{
	//	Name = "test_female",
	//	SexType = MedService.API.Database.Entities.Enums.SexType.Female
	//});

	//context.Clients.Add(new()
	//{
	//	Name = "test_male",
	//	SexType = MedService.API.Database.Entities.Enums.SexType.Male
	//});

	//await context.SaveChangesAsync();
}

{
	await using var tempContext = new TempDbContext();
	var temps = await tempContext.Temps.AsNoTracking().ToListAsync();
	temps.ForEach(c => Console.WriteLine("Id: {0}, Enum: {1}", c.Id, c.TempEnum));
}
{
	await using var context = new MedServiceDbContext();
	var clients = await context.Clients.AsNoTracking().ToListAsync();
	clients.ForEach(c => Console.WriteLine("Id: {0}, Name: {1}, Sex: {2}", c.Id, c.Name, c.SexType));
}
