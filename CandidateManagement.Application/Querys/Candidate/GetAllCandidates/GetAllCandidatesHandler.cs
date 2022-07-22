using AutoMapper;
using CandidateManagement.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CandidateManagement.Application.Querys.Candidate.GetAllCandidates
{
    public class GetAllCandidatesHandler : IRequestHandler<GetAllCandidatesRequest, IEnumerable<GetAllCandidatesViewModel>>
    {
        private readonly ICandidateManagementRepository candidateManagementRepository;
        private readonly IMapper mapper;

        public GetAllCandidatesHandler(ICandidateManagementRepository CandidateManagementRepository, IMapper mapper)
        {
            this.candidateManagementRepository = CandidateManagementRepository;
            this.mapper = mapper;
        }

        public Task<IEnumerable<GetAllCandidatesViewModel>> Handle(GetAllCandidatesRequest request, CancellationToken cancellationToken)
        {
            var candidate = candidateManagementRepository.GetAll();
            var candidateViewModel = mapper.Map<IEnumerable<GetAllCandidatesViewModel>>(candidate);

            return Task.FromResult(candidateViewModel);
        }
    }
}
