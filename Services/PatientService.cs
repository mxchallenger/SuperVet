using SuperVet.Data;
using SuperVet.Data.Filters;

namespace SuperVet.Services
{
	public class PatientService : IPatientService
	{
		private readonly VetContext _ctx;

		public PatientService(VetContext ctx)
		{
            _ctx = ctx;
		}

		public async Task<IEnumerable<Patient>> GetPatients()
		{
			return await _ctx.Patients
                .AsNoTracking()
                .OrderBy(p => p.Id)
                .ToListAsync();
		}

        public async Task<Patient> GetPatientByIdAsync(int patientId)
        {
            return await _ctx.Patients
                   .AsNoTracking()
                   .WherePatientIdEquals(patientId)
                   //.Include(patient => patient.Encounters) includes the encounters collection
                   .SingleOrDefaultAsync();
        }

        public async Task<Patient> CreatePatientAsync(Patient patient)
        {
            _ctx.Patients.Add(patient);
            await _ctx.SaveChangesAsync();

            return patient;
        }
    }
}

