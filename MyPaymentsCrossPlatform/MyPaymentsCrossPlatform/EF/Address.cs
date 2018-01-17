using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer
{
    [Table("Address")]
    public class Address : Entity
    {
        public string FullAddress { get; set; }
        public virtual ICollection<UtilityBill> Bills { get; set; }
    }
}
