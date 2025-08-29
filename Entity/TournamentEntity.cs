using SQLite;

namespace IScore.Entity;
public class TournamentEntity
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public required string Name { get; set; }
    public required string SportType { get; set; } // Pétanque, Mini-foot
    public required string StartDate { get; set; } // Format ISO, ex. "2025-08-29"
    public required string Format { get; set; } // Poule, Elimination, Championnat
}
