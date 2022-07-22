using CandidateManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Domain.Interfaces
{
    public interface ICandidateManagementRepository : IRepository<Candidate>
    {
        Candidate Get(Guid id);

        IEnumerable<Candidate> GetAll();

    }
}
