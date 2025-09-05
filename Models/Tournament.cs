using SQLite;

namespace IScore.Models;

[Table("tournament")]
public class Tournament
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }
    [MaxLength(50), NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;
    [MaxLength(20), NotNull]
    [Column("sport_type")]
    public string SportType { get; set; } = string.Empty;
    [NotNull]
    [Column("start_date")]
    public string StartDate { get; set; } = string.Empty;
    [MaxLength(20), NotNull]
    [Column("format")]
    public string Format { get; set; } = string.Empty;

    public Tournament Clone() => (Tournament)MemberwiseClone();
}
