using System;
namespace SuperVet.Data.Filters
{
	public static class Filters
	{
		public static IQueryable<Patient> WherePatientIdEquals(this IQueryable<Patient> patients, int patientId)
		{
			return patients.Where(p => p.Id == patientId).AsQueryable();
		}

    }
}

