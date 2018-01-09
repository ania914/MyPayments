using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace DataLayer
{
    [Table("Address")]
    public class Address : Entity
    {
        public string FullAddress { get; set; }
        [OneToMany]
        public List<UtilityBill> Bills { get; set; }
    }
}
