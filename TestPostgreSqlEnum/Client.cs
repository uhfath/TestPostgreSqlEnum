using System.ComponentModel.DataAnnotations;
using MedService.API.Database.Entities.Enums;

namespace MedService.API.Database.Entities.Data;

public class Client
{
	[Key]
	public int Id { get; set; }

	[Required]
	public string Name { get; set; }

	[Required]
	public SexType SexType { get; set; }
}
