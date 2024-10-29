using System.ComponentModel.DataAnnotations.Schema;

namespace DealerX.Data.EntitiesDataAnnotations;

[Table("Clients")]
public class Client
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

}

