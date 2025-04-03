using SQLite;

namespace MyShift.Models;

[Table("notes")]
public class Note
{
    [PrimaryKey]
    public DateTime Date { get; set; }
    public string? TextNote { get; set; }
}
