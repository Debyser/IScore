using IScore.Models;
using SQLite;

namespace IScore.Services;
public class DatabaseService
{
    private static SQLiteAsyncConnection _database;
    private const string DbName = "iscore.db3";


    public static async Task<SQLiteAsyncConnection> GetDatabaseAsync()
    {
        if (_database == null)
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, DbName);
            _database = new SQLiteAsyncConnection(dbPath);
            // Créez les tables si nécessaire
            await _database.CreateTableAsync<Team>();
            await _database.CreateTableAsync<Tournament>();
            await _database.CreateTableAsync<Pool>();
            await _database.CreateTableAsync<Match>();
            // Créer l'index unique sur Tournament.name
            var indexScript = @"
                        CREATE UNIQUE INDEX Tournament_name_IDX ON tournament (name);
                        CREATE INDEX match_match2tournament_IDX ON ""match"" (match2tournament);
                        CREATE INDEX match_match2pool_IDX ON ""match"" (match2pool);
                        CREATE INDEX match_match2team1_IDX ON ""match"" (match2team1);
                        CREATE INDEX match_match2team2_IDX ON ""match"" (match2team2);";
            await _database.ExecuteAsync(indexScript);
        }
        return _database;
    }
    /*public async Task InitializeAsync()
    {
        try
        {
            await _connection.CreateTableAsync<Team>();
            await _connection.CreateTableAsync<Tournament>();
            await _connection.CreateTableAsync<Pool>();
            await _connection.CreateTableAsync<Match>();
            // Créer l'index unique sur Tournament.name
            var indexScript = @"
                        CREATE UNIQUE INDEX Tournament_name_IDX ON tournament (name);
                        CREATE INDEX match_match2tournament_IDX ON ""match"" (match2tournament);
                        CREATE INDEX match_match2pool_IDX ON ""match"" (match2pool);
                        CREATE INDEX match_match2team1_IDX ON ""match"" (match2team1);
                        CREATE INDEX match_match2team2_IDX ON ""match"" (match2team2);";
            await _connection.ExecuteAsync(indexScript);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors de l'initialisation de la base de données : {ex.Message}");
        }
        // Créer les tables si elles n'existent pas déjà


    }*/

    /*public async Task InitializeAsync()
    {
        // Exécuter le script SQL pour créer les tables avec contraintes
        var script = @"
                CREATE TABLE IF NOT EXISTS Team (
                    id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                    name TEXT NOT NULL
                );
                CREATE TABLE IF NOT EXISTS Tournament (
                    id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                    name TEXT(50) NOT NULL,
                    sport_type TEXT(20) NOT NULL,
                    start_date TEXT NOT NULL,
                    format TEXT(20) NOT NULL
                );
                CREATE TABLE IF NOT EXISTS Pool (
                    id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                    name TEXT NOT NULL,
                    pool2tournament INTEGER,
                    CONSTRAINT pool_pool2tournament_fkey FOREIGN KEY (pool2tournament) REFERENCES Tournament(id) ON DELETE CASCADE
                );
                CREATE TABLE IF NOT EXISTS ""match"" (
                    id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                    match2tournament INTEGER NOT NULL,
                    match2pool INTEGER,
                    match2team1 INTEGER NOT NULL,
                    match2team2 INTEGER NOT NULL,
                    team1_score INTEGER,
                    team2_score INTEGER,
                    match_date TEXT NOT NULL,
                    CONSTRAINT match_match2pool_fkey FOREIGN KEY (match2pool) REFERENCES Pool(id) ON DELETE SET NULL,
                    CONSTRAINT match_match2team1_fkey FOREIGN KEY (match2team1) REFERENCES Team(id) ON DELETE CASCADE,
                    CONSTRAINT match_match2tournament_fkey FOREIGN KEY (match2tournament) REFERENCES Tournament(id) ON DELETE CASCADE,
                    CONSTRAINT match_match2team2_fkey FOREIGN KEY (match2team2) REFERENCES Team(id) ON DELETE CASCADE
                );";

        await _connection.ExecuteAsync(script);
    }*/

}
