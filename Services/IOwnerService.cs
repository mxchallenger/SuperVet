using System;

namespace SuperVet.Services
{
	public interface IPatientService
	{
        Task<IEnumerable<Patient>> GetPatients();

        Task<Patient>GetPatientByIdAsync(int id);

        Task<Patient>CreatePatientAsync(Patient newPatient);

        Task<Patient> UpdatePatientByIdAsync(Patient patient, int patientId);

        Task DeletePatientByIdAsync(int id);
    }
}

