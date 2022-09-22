
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Db.Models;

[Table("customers")]
public class Customer
{
    [Column("id")]
    public Guid Id { get; set; }
    
    [Column("name")]
    public string Name { get; set; }
    
    [Column("address")]
    public string Address { get; set; }
    [Column("city")]
    public string City { get; set; }
    [Column("country")]
    public string Country { get; set; }

    public ICollection<Order> Orders { get; set; }
}