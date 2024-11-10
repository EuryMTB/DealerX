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

	[Range(1,int.MaxValue, ErrorMessage = "It has to have an Available model")]
	public int ModelId { get; set; }
	[Range(1, int.MaxValue, ErrorMessage = "It has to have an Available Engine")]

	public int EngineId { get; set; }


}

public class EngineRequest()
{

	public int Id { get; set; }

	[Range(ConsEngine.CylinderMin, ConsEngine.CylinderMax)]
	public int CC { get; set; }


	[Range(ConsEngine.HPMin, ConsEngine.HPMax), Column(TypeName = "decimal(18,2)")]

	public decimal HorsePower { get; set; }


	[Range(ConsEngine.CylinderMin, ConsEngine.CylinderMax)]
	public int Cylinder { get; set; } = ConsEngine.CylinderMin;


	[Range(ConsEngine.Positive, double.MaxValue)]
	public int TopSpeed { get; set; }

	public bool Turbo { get; set; }

	[Range(ConsEngine.Positive, (double)decimal.MaxValue), Column(TypeName = "decimal(18,2)")]
	public decimal? AccelerationZeroTo100 { get; set; }

	[Range(ConsEngine.Positive, (double)decimal.MaxValue), Column(TypeName = "decimal(18,2)")]
	public decimal? AccelerationZeroTo200 { get; set; }


	[Range(ConsEngine.Positive, (double)decimal.MaxValue), Column(TypeName = "decimal(18,2)")]
	public decimal ConsumeUrban { get; set; }


	[Range(ConsEngine.Positive, (double)decimal.MaxValue), Column(TypeName = "decimal(18,2)")]
	public decimal ConsumeSubUrb { get; set; }

	public string FuelType { get; set; } = null!;
}