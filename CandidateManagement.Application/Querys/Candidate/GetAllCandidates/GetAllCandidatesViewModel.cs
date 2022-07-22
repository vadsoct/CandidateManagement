﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Application.Querys.Candidate
{
    public class GetAllCandidatesViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime Birthdate { get; set; }

        public string Email { get; set; }
        public List<Domain.Entities.CandidateExperience> CandidateExperiences { get; set; }
    }
}
