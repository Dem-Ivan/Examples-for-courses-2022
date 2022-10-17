using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Db.Models;

[Table("orders")]
public class Order
{
    [Column("id")]
    public Guid Id { get; set; }
    [Column("order_date")]
    public DateTime OrderDate { get; set; }
    [Column("price")]
    public double Price { get; set; }
    [Column("customer_id")]
    public Guid CustomerId { get; set; }

    public Customer Customer { get; set; }
}