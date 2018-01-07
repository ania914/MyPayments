using SQLite;

namespace DataLayer
{
    [Table("UtilityBill")]
    public class UtilityBill : Entity
    {
        //[ForeignKey(typeof(Address))]
        public int IdAddress { get; set; }
       // [ManyToOne]
       // public Address Address { get; set; }
        public string Name { get; set; }
        public bool IsConstant { get; set; }
        public double? MonthlyCost { get; set; }
    }
}
