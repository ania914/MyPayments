using SQLite;

namespace DataLayer
{
    [Table("Address")]
    public class Address : Entity
    {
        public string FullAddress { get; set; }
       // [OneToMany]
       // public IEnumerable<UtilityBill> Bills { get; set; }
    }
}
