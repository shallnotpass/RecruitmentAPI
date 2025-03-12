using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface ICandidatesService
    {
        public Task<Candidate?> AddCandidate(Candidate candidateData);
        public Task<Candidate?> FindCandidate(string candidateId);
        public Task<Candidate?> FailCandidate(string candidateId);
    }
}
