using SQLite;

namespace CuringCalculator.Data.Models;

[Table("Methods")]
public class Method
{
    [PrimaryKey]
    [AutoIncrement]
    [Column("Id")]
    public int Id { get; set; }

    [Column("Name")]
    public string Name { get; set; }

    public virtual IEnumerable<DaysInterval>? DaysIntervals { get; set; }

    public virtual IEnumerable<Curing>? Curings { get; set; }

    public Method(int id, string name, IEnumerable<DaysInterval> daysIntervals)
    {
        Id = id;
        Name = name;
        DaysIntervals = daysIntervals;
    }

    public Method(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public Method() { }
}
