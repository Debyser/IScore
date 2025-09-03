using SQLite;

namespace IScore.Models;
public class Match
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    [NotNull]
    public int Match2Tournament { get; set; }
    public int? Match2Pool { get; set; }
    [NotNull]
    public int Match2Team1 { get; set; }
    [NotNull]
    public int Match2Team2 { get; set; }
    public int? Team1Score { get; set; }
    public int? Team2Score { get; set; }
    [NotNull]
    public string MatchDate { get; set; } = string.Empty;
}
