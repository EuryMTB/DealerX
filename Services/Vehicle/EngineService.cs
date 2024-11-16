﻿using DealerX.Data.Context;
using DealerX.Data.Response;
using DealerX.Shared;

namespace DealerX.Services.Vehicle;

public interface IEngineService
{
	 Task<ResultList<EngineResponse>> Get(string filter = "");
}

public class EngineService(IdbContext context) : IEngineService
{
	public async Task<ResultList<EngineResponse>> Get(string filter = "")
	{
		try
		{
			var r = context.Engines.Select(
			x => new EngineResponse()
			{
				Id = x.Id,
				CC = x.CC,
				Description = $"HP: {x.HorsePower} Cylinder: {x.Cylinder} FuelType : {x.FuelType}",
				HorsePower = x.HorsePower,
				Cylinder = x.Cylinder,
				TopSpeed = x.TopSpeed,
				Turbo = x.Turbo,
				AccelerationZeroTo100 = x.AccelerationZeroTo100,
				AccelerationZeroTo200 = x.AccelerationZeroTo200,
				ConsumeUrban = x.ConsumeUrban,
				ConsumeSubUrb = x.ConsumeSubUrb,
				FuelType = x.FuelType

			}).ToList();
			if (r is not null && r.Count > 0)
			{
				return ResultList<EngineResponse>.Success(r);
			}
			return ResultList<EngineResponse>.Failure("No Engines founded");

		}
		catch (Exception ex)
		{
			return ResultList<EngineResponse>.Failure($"Error loading Engines: ${ex.Message}");

		}
	}
}
