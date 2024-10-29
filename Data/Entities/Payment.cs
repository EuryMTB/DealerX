using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DealerX.Data.Entities;

[Table("Payments")]

public class Payment
{
	[Key]
	public int Id { get; set; }

	public DateTime Date { get; set; }
	public decimal Amount { get; set; }
	public int VehicleTransactionID { get; set; }
	public string Method { get; set; } = null!;

	#region Foreign Keys
	[ForeignKey(nameof(VehicleTransactionID))]
	public virtual VehicleTransaction VehicleTransaction { get; set; } = null!;
	#endregion
}
