﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Application.Querys.Candidate
{
    public class GetAllCandidatesRequest : IRequest<IEnumerable<GetAllCandidatesViewModel>>
    {
    }
}
