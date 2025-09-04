using SQLite;

namespace IScore.Models;
public class Tournament
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    [MaxLength(50), NotNull]
    public string Name { get; set; } = string.Empty;
    [MaxLength(20), NotNull]
    public string SportType { get; set; } = string.Empty;
    [NotNull]
    public string StartDate { get; set; } = string.Empty;
    [MaxLength(20), NotNull]
    public string Format { get; set; } = string.Empty;

    public Tournament Clone() => (Tournament)MemberwiseClone();
}
