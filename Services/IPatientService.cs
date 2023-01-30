using System;

namespace SuperVet.Services
{
	public interface IPatientService
	{
        Task<IEnumerable<Patient>> GetPatients();
    }
}

