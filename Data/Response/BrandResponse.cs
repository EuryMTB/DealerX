using DealerX.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DealerX.Contants;
using DealerX.Data.Request;
using static System.Net.Mime.MediaTypeNames;

namespace DealerX.Data.Response;

public class BrandResponse
{
	public int Id { get; set; }
	public string Name { get; set; } = null!;
	public string Image { get; set; } = null!;
}
public class ModelResponse
{
	public int Id { get; set; }
	public string Name { get; set; } = null!;
	public string Image { get; set; } = null!;
    public int BrandId { get; set; }
    public Brand Brand { get; set; } = null!;


}
public class VehicleResponse
{
	public int Id { get; set; }
	//              Y E A R 
	[Range(ConsVehicle.YearMin, int.MaxValue)]
	public int Year { get; set; }

	//              D  O O R
	[Range(ConsVehicle.DoorMin, int.MaxValue)]
	public int Doors { get; set; }


	public string Condition { get; set; } = ConsCondition.New;
	public string Type { get; set; } = ConsTypeVehicle.SEDAN;

	public int MaxWeigh { get; set; }
	public bool Available { get; set; }

	public int Price { get; set; }
	public string Description { get; set; } = "Perfect for you";
	public List<string> Images { get; set; } = new ();
    public int ModelId { get; set; }
    //public ModelResponse Model { get; set; } = null!;
    public ModelResponse model { get; set; } = null!;
	public int EngineId { get; set; }

	public Engine Engine { get; set; } = null!;
    public string GetImage(string Image) => $"data:image/png;base64,{Image}";


    public VehicleRequest ToRequest()
	{
		return new()
		{
			Id = Id,
			Year = Year,
			Doors = Doors,
			Condition = Condition,
			Type = Type,
			MaxWeigh = MaxWeigh,
			Price = Price,
			Description = Description,
			Images = Images,
			ModelId = model.Id,
			EngineId = Engine.Id
		};
	}

}
