﻿using DealerX.Data.Entities;
using DealerX.Data.EntitiesDataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DealerX.Data.Context
{
	public class dbContext : DbContext, IdbContext
	{
		private readonly IConfiguration config;

		public dbContext(IConfiguration config)
		{
			this.config = config;
		}


		public DbSet<Brand> Brands { get; set; }
		public DbSet<Model> Models { get; set; }
		public DbSet<Engine> Engines { get; set; }
		public DbSet<Vehicle> Vehicles { get; set; }

		public DbSet<Bill> Bills { get; set; }
		public DbSet<Client> Clients { get; set; }

		public DbSet<Payment> Payments { get; set; }

		public DbSet<VehicleTransaction> VehicleTransactions { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(config.GetConnectionString("MSSQL"));
		}
		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			return base.SaveChangesAsync(cancellationToken);
		}
	}
}
