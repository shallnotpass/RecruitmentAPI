using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface ICandidateRepository
    {
        Task<Candidate> AddCandidate(Candidate email);
        Task<Candidate?> FindCandidate(string CandidateId);
        Task<Candidate> UpdateCandidate(Candidate Candidate);
    }
}
