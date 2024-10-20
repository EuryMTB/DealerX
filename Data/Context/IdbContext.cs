using DealerX.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DealerX.Data.Context
{
    public interface IdbContext
    {
        DbSet<Brand> Brands { get; set; }
        DbSet<Engine> Engines { get; set; }
        DbSet<Model> Models { get; set; }
        DbSet<Vehicle> Vehicles { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}