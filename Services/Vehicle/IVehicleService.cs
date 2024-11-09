using DealerX.Data.Request;
using DealerX.Data.Response;
using DealerX.Shared;

namespace DealerX.Services.Vehicle
{
	public interface IVehicleService
	{
        Task<Result> Create(VehicleRequest request);
        Task<ResultList<VehicleResponse>> Get(string filter = "", bool All = false);
    
	}
}