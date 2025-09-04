using SQLite;

namespace IScore.Models;

[Table("team")]
public class Team
{
    [PrimaryKey]
    [AutoIncrement]
    [Column("id")]
    public int Id { get; set; }
    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;
}
//https://github.com/dotnet/maui-samples/blob/main/10.0/Data/TodoSQLite/TodoSQLite/Data/TodoItemDatabase.cs