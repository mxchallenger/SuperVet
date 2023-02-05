using System;
using Microsoft.EntityFrameworkCore;

namespace SuperVet.Data
{
	public static class Extensions
	{
		public static void SeedData(this ModelBuilder modelBuilder)
		{
			var patientFactory = new PatientFactory();
			modelBuilder.Entity<Patient>().HasData(patientFactory.GetPatients(25));
		}

		/* public static void SeedData(this ModelBuilder modelBuilder)
		{
			var patientFactory = new PatientFactory();
			var patients = patientFactory.GenerateRandomPatients(25);
			modelBuilder.Entity<Patient>().HasData();
		}  ALTERNATE OF ABOVE REFACTORING
		*/
	}
};
