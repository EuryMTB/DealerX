using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DealerX.Data.Entities
{
    public class Model
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public Byte[] Image { get; set; } = null!;

        public int BrandId { get; set; }

        [ForeignKey(nameof(BrandId))]
        public virtual Brand Brand { get; set; } = null!;


        public IEnumerable<Vehicle> Vehicles { get; set; } = new List<Vehicle>();


    }
}
