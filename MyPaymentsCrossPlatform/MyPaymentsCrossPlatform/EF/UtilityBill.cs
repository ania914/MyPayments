using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer
{
    [Table("UtilityBill")]
    public class UtilityBill : Entity
    {
        [ForeignKey("Address")]
        public int IdAddress { get; set; }
        public virtual Address Address { get; set; }
        public string Name { get; set; }
        public bool IsConstant { get; set; }
        public double? MonthlyCost { get; set; }
        public virtual ICollection<MeterReading> MeterReadings { get; set; }
    }
}
