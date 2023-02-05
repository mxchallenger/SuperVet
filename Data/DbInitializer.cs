using System;
using SuperVet.Data;

namespace SuperVet.Data
{
	public class DbInitializer
	{
		public static VetContext? _context;

		public DbInitializer(VetContext context)
		{
			_context = context;
		}

		public void Run()
		{
			_context.Database.EnsureDeleted();
			_context.Database.EnsureCreated();
		}

	}
}
