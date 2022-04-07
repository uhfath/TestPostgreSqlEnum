using MedService.API.Database.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPostgreSqlEnum
{
	public class TempModel
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public TempEnumType TempEnum { get; set; }
	}
}
