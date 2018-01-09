using SQLite;
using SQLiteNetExtensions.Attributes;
using System;

namespace DataLayer
{
    [Table("MeterReading")]
    public class MeterReading : Entity
    {
        [ForeignKey(typeof(UtilityBill))]
        public int IdUtilityBill { get; set; }
        [OneToOne]
        public UtilityBill UtilityBill { get; set; }
        public long MeterReadingValue { get; set; }
        public DateTime DateOfAddition { get; set; }
    }
}
