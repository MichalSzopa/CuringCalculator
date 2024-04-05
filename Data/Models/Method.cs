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

    public Method(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public Method()
    { }
}