using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer
{
    [Table("MeterReading")]
    public class MeterReading : Entity
    {
        [ForeignKey("UtilityBill")]
        public int IdUtilityBill { get; set; }        
        public virtual UtilityBill UtilityBill { get; set; }
        public long MeterReadingValue { get; set; }
        public DateTime DateOfAddition { get; set; }
    }
}
