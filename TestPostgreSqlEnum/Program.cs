using Microsoft.EntityFrameworkCore;

{
	await using var context = new MedService.API.Database.MedServiceDbContext();
	await context.Database.EnsureDeletedAsync();
	await context.Database.EnsureCreatedAsync();

	context.Clients.Add(new()
	{
		Name = "test_female",
		SexType = MedService.API.Database.Entities.Enums.SexType.Female
	});

	context.Clients.Add(new()
	{
		Name = "test_male",
		SexType = MedService.API.Database.Entities.Enums.SexType.Male
	});

	await context.SaveChangesAsync();
}

{
	await using var context = new MedService.API.Database.MedServiceDbContext();
	var clients = await context.Clients.ToListAsync();
	clients.ForEach(c => Console.WriteLine("Id: {0}, Name: {1}, Sex: {2}", c.Id, c.Name, c.SexType));
	Console.ReadLine();
}
