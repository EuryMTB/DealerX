using DealerX.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DealerX.Contants;

namespace DealerX.Data.Request;

public class BrandRequest
{
	public int Id { get; set; }
	public string Name { get; set; } = null!;
	public string Image { get; set; } = null!;
}
public class ModelRequest
{
	public int Id { get; set; }
	public string Name { get; set; } = null!;
	public string Image { get; set; } = null!;
	public int BrandId { get; set; }

}
public class VehicleRequest
{
	public int Id { get; set; }
	//              Y E A R 
	[Range(ConsVehicle.YearMin, int.MaxValue)]
	[MaxYearCar(ErrorMessage = "Invalid Year Value")]
	public int Year { get; set; }

	//              D  O O R
	[Range(ConsVehicle.DoorMin, 6, ErrorMessage = "Doors has to be between 1 and 6")]
	public int Doors { get; set; }


	public string Condition { get; set; } = ConsCondition.New;
	public string Type { get; set; } = ConsTypeVehicle.SEDAN;

	[Range(1, int.MaxValue, ErrorMessage = "Max Weigh needs to be at least 1")]
	public int MaxWeigh { get; set; }

	[Range(1, int.MaxValue, ErrorMessage = "Price needs to be at least 1")]
	public int Price { get; set; }

	public bool Available { get; set; }

	[Required(ErrorMessage = "The Description is required.")]
	public string Description { get; set; } = "Perfect for you";
	
	[AtLeastOneItemListString(ErrorMessage = "At least one image has to be provided.")]
	public List<string> Images { get; set; } = new List<string>();
	public int ModelId { get; set; }
	public int EngineId { get; set; }


}
