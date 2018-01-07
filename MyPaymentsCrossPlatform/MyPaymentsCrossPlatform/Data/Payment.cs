using SQLite;
using System;

namespace DataLayer
{
    [Table("Payment")]
    public class Payment : Entity
    {
       // [ForeignKey(typeof(MeterReading))]
        public int MeterReadingId { get; set; }
       // [OneToOne]
      //  public MeterReading MeterReading { get; set; }
        public double Cost { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
