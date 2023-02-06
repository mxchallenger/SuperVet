using System;
namespace SuperVet.DTOs
{
	public class PatientDTO
	{
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public string? Name { get; set; }

        public string? Type { get; set; }

        public string? Sex { get; set; }

        public DateTime Birthdate { get; set; }

        public int Age { get; }

        public string? Altered { get; set; }

        public string? MicrochipId { get; set; }
    }
}

