using SQLite;

namespace IScore.Models
{
    [Table("team_role")]
    public class TeamRole
    {
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public int Id { get; set; }
        [NotNull]
        [Column("team_role2tournament")]
        public int TournamentId { get; set; }
        [NotNull]
        [Column("team_role2team")]
        public int TeamId { get; set; }
        [MaxLength(50)]
        [Column("pool_name")]
        public string PoolName { get; set; } // Ex. "Poule A", peut être null pour certains formats
        [Column("date")]
        public string Date { get; set; } // Format "yyyy-MM-dd", peut être null
    }
}
