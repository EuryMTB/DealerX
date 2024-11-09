using System.ComponentModel.DataAnnotations;

namespace DealerX.Data.Entities
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Image { get; set; } = null!;
        public virtual ICollection<Model> Models { get; set; } = [];

    }
}
