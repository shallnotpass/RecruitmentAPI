using DataAccess.Repositories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class CandidatesService : ICandidatesService
    {
        private readonly ICandidateRepository _candidateRepository;
        public CandidatesService(ICandidateRepository candidateRepository) 
        {
            _candidateRepository = candidateRepository;
        }
        public async Task<Candidate?> AddCandidate(Candidate candidateData)
        {
            return await _candidateRepository.AddCandidate(candidateData);
        }

        public Task<Candidate?> FailCandidate(string candidateId)
        {
            throw new NotImplementedException();
        }
    }
}
