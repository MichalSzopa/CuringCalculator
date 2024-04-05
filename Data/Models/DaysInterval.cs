using SQLite;

namespace CuringCalculator.Data.Models;

[Table("DaysIntervals")]
public class DaysInterval
{
    [PrimaryKey]
    [AutoIncrement]
    [Column("Id")]
    public int Id { get; set; }

    [Column("MinDay")]
    public int MinDay { get; set; }

    [Column("MaxDay")]
    public int MaxDay { get; set; }

    [Column("MinSalt")]
    public int MinSalt { get; set; }

    [Column("MaxSalt")]
    public int MaxSalt { get; set; }

    [Column("Massaging")]
    public bool Massaging { get; set; }

    [Column("SingleInjection")]
    public int SingleInjection { get; set; }

    [Column("MethodId")]
    public int MethodId { get; set; }

    public string DisplayedValue { get => MinDay == MaxDay ? MinDay.ToString() : string.Format("{0}-{1}", MinDay, MaxDay); }

    public DaysInterval(int id, int minDay, int maxDay, int minSalt, int maxSalt, bool massaging, int singleInjection, int methodId)
    {
        Id = id;
        MinDay = minDay;
        MaxDay = maxDay;
        MinSalt = minSalt;
        MaxSalt = maxSalt;
        Massaging = massaging;
        SingleInjection = singleInjection;
        MethodId = methodId;
    }

    public DaysInterval()
    { }
}