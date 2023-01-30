using System;
namespace SuperVet.Data
{
	public interface IDataContext
	{
		public DbSet<Patient> Patients { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}

