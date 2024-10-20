using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DealerX.Contants;

namespace DealerX.Data.Entities
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        //              Y E A R 
        [Range(ConsVehicle.YearMin,int.MaxValue)]
        public int Year { get; set; }

        //              D  O O R
        [Range(ConsVehicle.DoorMin, int.MaxValue)]
        public int Doors { get; set; }


        public string Condition { get; set; } = ConsCondition.New;
        public string Type { get; set; } = ConsTypeVehicle.SEDAN;

        public int MaxWeigh { get; set; }

        public int Price { get; set; }
        public string Description { get; set; } = "Perfect for you";



        public Byte[][] Images { get; set; } = [];

        #region  Foreign Keys :: Model, Engine
        public int ModelId { get; set; }
        [ForeignKey(nameof(ModelId))]
        public virtual Model Model { get; set; } = null!;


        public int EngineId { get; set; }
        [ForeignKey(nameof(EngineId))]
        public virtual Engine Engine { get; set; } = null!;

        #endregion



    }
}
