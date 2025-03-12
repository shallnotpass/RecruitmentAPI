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
            candidateData.Id = Guid.NewGuid().ToString();
            candidateData.WorkingStartDate = null;
            return await _candidateRepository.AddCandidate(candidateData);
        }

        public async Task<Candidate?> FailCandidate(string candidateId)
        {
            var candidate = await _candidateRepository.FindCandidate(candidateId);
            if (candidate.Failed == false) 
            {
                candidate.Failed = true;
                await _candidateRepository.UpdateCandidate(candidate);
            }
            return candidate;
        }

        public Task<Candidate?> FindCandidate(string candidateId)
        {
            return _candidateRepository.FindCandidate(candidateId);
        }
    }
}
