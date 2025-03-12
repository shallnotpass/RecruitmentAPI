using Domain.Models;

namespace DataAccess.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly DbAccess _dbAccess;
        public CandidateRepository(DbAccess dbAccess) 
        {
            _dbAccess = dbAccess;
        }
        public async Task<Candidate> AddCandidate(Candidate candidate)
        {

            candidate.Id = Guid.NewGuid().ToString();

            // Добавление нового пользователя
            await _dbAccess.Candidates.AddAsync(candidate);
            await _dbAccess.SaveChangesAsync();
            return candidate;
        }

        public async Task<Candidate> UpdateCandidate(Candidate candidate)
        {
            _dbAccess.Update(candidate);
            _dbAccess.SaveChanges();
            return candidate;
        }

        public async Task<Candidate?> FindCandidate(string candidateId)
        {
            return _dbAccess.Candidates.FirstOrDefault(x => x.Id == candidateId);
        }
    }
}
