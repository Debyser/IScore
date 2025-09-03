using SQLite;

namespace IScore.Models;

public class Pool
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    [NotNull]
    public string Name { get; set; } = string.Empty;
    public int Pool2Tournament { get; set; }
}
