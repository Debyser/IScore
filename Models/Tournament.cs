using SQLite;

namespace IScore.Models;
public class Tournament
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    [MaxLength(50), NotNull]
    public string Name { get; set; }
    [MaxLength(20), NotNull]
    public string SportType { get; set; }
    [NotNull]
    public string StartDate { get; set; }
    [MaxLength(20), NotNull]
    public string Format { get; set; }
}
