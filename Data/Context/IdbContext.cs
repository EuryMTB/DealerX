using DealerX.Data.Entities;
using DealerX.Data.EntitiesDataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DealerX.Data.Context
{
    public interface IdbContext
    {
        DbSet<Brand> Brands { get; set; }
        DbSet<Engine> Engines { get; set; }
        DbSet<Model> Models { get; set; }
        DbSet<Vehicle> Vehicles { get; set; }
		DbSet<Bill> Bills { get; set; }
		DbSet<Client> Clients { get; set; }
		DbSet<Payment> Payments { get; set; }
		DbSet<VehicleTransaction> VehicleTransactions { get; set; }

		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}