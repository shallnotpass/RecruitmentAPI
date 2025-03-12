using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Candidate
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }
        public DateTime WorkingStartDate { get; set; }
        public bool ProbationIsCompleted { get; set; }
        public bool TestIsNeeded { get; set; }
        public bool TestIsCompleted { get; set; }
    }
}
