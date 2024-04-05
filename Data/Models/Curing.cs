using SQLite;

namespace CuringCalculator.Data.Models
{
    [Table("Curings")]
    public class Curing
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("Id")]
        public int Id { get; set; }

        [Column("StartDate")]
        public DateTime StartDate { get; set; }

        [Column("EndDate")]
        public DateTime EndDate { get; set; }

        [Column("Comments")]
        public string Comments { get; set; }

        [Column("MeatAmount")]
        public decimal MeatAmount { get; set; }

        [Column("DaysIntervalId")]
        public int DaysIntervalId { get; set; }

        public Curing()
        { }
    }
}