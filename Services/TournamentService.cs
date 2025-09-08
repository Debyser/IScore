using IScore.Data;
using IScore.Models;

namespace IScore.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly DatabaseContext _context;
        public TournamentService(DatabaseContext context)
        {
            _context = context;
        }
        public Task<bool> CreateAsync(Tournament model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(Tournament model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemByKeyAsync(object primaryKey)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Tournament>> GetFilteredListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Tournament>> GetListAsync()
        {
            return _context.GetAllAsync<Tournament>();
        }

        public Task<bool> ModifyAsync(int id, Tournament model)
        {
            throw new NotImplementedException();
        }
    }
}
