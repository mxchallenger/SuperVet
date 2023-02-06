using System;
namespace SuperVet.Models
{
	public class Owner : BaseEntity
	{
		public string? OwnerFirstName { get; set; }
        public string? OwnerLastName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int? Postal { get; set; }

        public ICollection<Patient> Patients { get; set; }

        public Owner()
        {
            Patients = new List<Patient>();
        }
    }
}

