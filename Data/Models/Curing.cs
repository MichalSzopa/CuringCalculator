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

        [Column("SugarAmount")]
        public decimal SugarAmount { get; set; }

        [Column("SaltAmount")]
        public decimal SaltAmount { get; set; }

        [Column("Days")]
        public int Days { get; set; }

        [Column("MethodId")]
        public int MethodId { get; set; }

        public Curing()
        { }
    }
}