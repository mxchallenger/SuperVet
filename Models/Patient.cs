using SuperVet.Models;

namespace SuperVet
{
	public class Patient : BaseEntity
	{
		public string? Name { get; set; }

		public string? Type { get; set; }

		public string? Sex { get; set; }

		public DateTime Birthdate { get; set; }

		public int Age
		{
			get
			{
				var today = DateTime.Today;
				var age = today.Year - Birthdate.Year;
				if (Birthdate > today.AddYears(-age))
				{
					age--;
				}
				return age;
			}
		}
		//TODO add weight to model
		//TODO get patient health issues list

		public string? Altered { get; set; }

		//TODO get patient owner information

		public string? MicrochipId { get; set; }

	}
}

