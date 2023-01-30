using SuperVet.Data;

namespace SuperVet.Services
{
	public class PatientService : IPatientService
	{
		private readonly IDataContext _ctx;

		public PatientService(IDataContext ctx)
		{
            _ctx = ctx;
		}

		public async Task<IEnumerable<Patient>> GetPatients()
		{
			return await _ctx.Patients.OrderBy(p => p.Id).ToListAsync();
		}

	}
}

