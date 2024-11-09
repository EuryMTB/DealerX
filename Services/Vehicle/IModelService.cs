using DealerX.Data.Response;
using DealerX.Shared;

namespace DealerX.Services.Vehicle
{
	public interface IModelService
	{
		Result<ModelResponse> GetById(int id);
	}
}