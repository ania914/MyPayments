using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer
{
    [Table("Payment")]
    public class Payment : Entity
    {
        [ForeignKey("MeterReading")]
        public int MeterReadingId { get; set; }
        public virtual MeterReading MeterReading { get; set; }
        public double Cost { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
