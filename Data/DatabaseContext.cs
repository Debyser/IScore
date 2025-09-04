using IScore.Models;
using SQLite;
using System.Linq.Expressions;

namespace IScore.Data
{
    public class DatabaseContext : IAsyncDisposable
    {
        private const string DbName = "IScore";
        private static readonly string _dbPath = Path.Combine("C:\\Users\\jdebyser\\Documents\\Database\\sqlite\\", DbName);
        //private static readonly string _dbPath = Path.Combine(FileSystem.AppDataDirectory, DbName);

        private SQLiteAsyncConnection _connection;
        public SQLiteAsyncConnection Database =>
            _connection ??= new SQLiteAsyncConnection(_dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);

        public async Task InitializeAsync()
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
        }
        public async Task<IEnumerable<TTable>> GetAllAsync<TTable>() where TTable : class, new()
        {
            var table = await GetTableAsync<TTable>();
            return await table.ToListAsync();
        }

        public async Task<IEnumerable<TTable>> GetFilteredAsync<TTable>(Expression<Func<TTable, bool>> predicate) where TTable : class, new()
        {
            var table = await GetTableAsync<TTable>();
            return await table.Where(predicate).ToListAsync();
        }

        public async Task<TTable> GetItemByKeyAsync<TTable>(object primaryKey) where TTable : class, new()
            => await Execute<TTable, TTable>(async () => await Database.GetAsync<TTable>(primaryKey));

        public async Task<bool> AddItemAsync<TTable>(TTable item) where TTable : class, new()
            => await Execute<TTable, bool>(async () => await Database.InsertAsync(item) > 0);

        public async Task<bool> UpdateItemAsync<TTable>(TTable item) where TTable : class, new()
            => await Execute<TTable, bool>(async () => await Database.UpdateAsync(item) > 0);

        public async Task<bool> DeleteItemAsync<TTable>(TTable item) where TTable : class, new()
            => await Execute<TTable, bool>(async () => await Database.DeleteAsync(item) > 0);

        public async Task<bool> DeleteItemByKeyAsync<TTable>(object primaryKey) where TTable : class, new()
            => await Execute<TTable, bool>(async () => await Database.DeleteAsync<TTable>(primaryKey) > 0);

        public async ValueTask DisposeAsync() => await _connection?.CloseAsync();

        #region privates methods

        private async Task<TResult> Execute<TTable, TResult>(Func<Task<TResult>> action) where TTable : class, new()
        {
            //await CreateTableIfNotExistAsync<TTable>();
            return await action();
        }

        // private async Task CreateTableIfNotExistAsync<TTable>() where TTable : class, new() => await Database.CreateTableAsync<TTable>();

        private async Task<AsyncTableQuery<TTable>> GetTableAsync<TTable>() where TTable : class, new()
        {
            //await CreateTableIfNotExistAsync<TTable>();
            return Database.Table<TTable>();
        }
        #endregion
    }
}
