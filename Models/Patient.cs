using SuperVet.Models;

namespace SuperVet
{
	public class Patient : BaseEntity
	{
		public string? Name { get; set; }

		public string? Type { get; set; }

		public string? Sex { get; set; }

		public string? Birthdate { get; set; }

		//TODO get birthdate, calculate age, set age
		public byte Age { get; set; }

		//TODO get patient health issues list

		public string? Altered { get; set; }

		//TODO get patient owner information

		public string? MicrochipId { get; set; }

	}
}

