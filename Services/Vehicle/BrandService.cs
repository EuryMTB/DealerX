﻿using DealerX.Data.Context;
using DealerX.Data.Response;
using DealerX.Shared;

namespace DealerX.Services.Vehicle;

public interface IBrandService
{
	Task<ResultList<BrandResponse>> Get(string filter = "");
}


public class BrandService(IdbContext context) : IBrandService
{
	public async Task<ResultList<BrandResponse>> Get(string filter = "")
	{
		try
		{
			var r = context.Brands.Where(x => x.Name.ToLower().Contains(filter)).Select(x => new BrandResponse() { Id = x.Id, Name = x.Name, Image = x.Image }).ToList();
			if (r is not null && r.Count > 0)
			{
				return ResultList<BrandResponse>.Success(r);
			}
			return ResultList<BrandResponse>.Failure("No brands founded");

		}
		catch (Exception ex)
		{
			return ResultList<BrandResponse>.Failure($"Error: Getting the brands : {ex.Message}");
		}
	}
}
