using DealerX.Data.Context;
using DealerX.Data.Request;
using DealerX.Data.Response;
using DealerX.Shared;
using DealerX.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DealerX.Services.Vehicle;

public class VehicleService : IVehicleService
{
	private readonly IdbContext context;

	public VehicleService(IdbContext context)
	{
		this.context = context;
	}
	public async Task<ResultList<VehicleResponse>> Get(string filter = "", bool All = false)
	{
		try
		{
			var vehicles = await context.Vehicles.Select(x => new VehicleResponse()
			{
				Id = x.Id,
				Year = x.Year,
				Doors = x.Doors,
				Condition = x.Condition,
				Type = x.Type,
				MaxWeigh = x.MaxWeigh,
				Price = x.Price,
				Description = x.Description,
				Images = new List<string>(),
				ModelId = x.ModelId,
				model = new ModelResponse()
				{
					Id = x.Model.Id,
					Name = x.Model.Name,
					Image = "NO",
					BrandId = x.Model.BrandId,
					Brand = x.Model.Brand

				},
				Engine = x.Engine,
				EngineId = x.EngineId,
				Available = x.Available
			}).ToListAsync();
			var rr = context.Vehicles.ToList();
			foreach (var x in vehicles)
			{
				Console.WriteLine($"Data::: {x.model.Name}");
			}
			if (!All)
			{
				vehicles = vehicles.Where(x => x.Available).ToList();
			}

			return ResultList<VehicleResponse>.Success(vehicles);
		}
		catch (Exception Ex)
		{
			return ResultList<VehicleResponse>.Failure($"Error : {Ex}");
		}
	}

	
	public async Task<Result> Create(VehicleRequest request)
	{
		try
		{
			var vehicle = Data.Entities.Vehicle.Create(request);
			context.Vehicles.Add(vehicle);
			await context.SaveChangesAsync();

			return Result.Success("Vehicle was added");
		}
		catch (Exception e)
		{
			return Result.Failure($"Error: {e.Message}");
		}
	}
}


public class ModelService(IdbContext context) : IModelService
{

	public Result<ModelResponse> GetById(int id)
	{
		try
		{
			var model = context.Models.FirstOrDefault(x => x.Id == id);
			if (model is not null)
			{
				return Result<ModelResponse>.Success(new ModelResponse()
				{
					BrandId = model.BrandId,
					Name = model.Name,
					Id = model.Id,
					Image = model.Image,
				});
			}
			else
			{
				return Result<ModelResponse>.Failure($"Model hasn't found");
			}
		}
		catch (Exception e)
		{
			return Result<ModelResponse>.Failure($"Error: {e.Message}");
		}
	}
}