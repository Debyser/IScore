using IScore.Models;

namespace IScore.Services
{
    public class TeamService
    {
        public async Task<List<Team>> GetListAsync()
        {
            var db = await DatabaseService.GetDatabaseAsync();
            return await db.Table<Team>().ToListAsync();
        }

        public async Task AddAsync(Team team)
        {
            var db = await DatabaseService.GetDatabaseAsync();
            await db.InsertAsync(team);
        }
    }
}
