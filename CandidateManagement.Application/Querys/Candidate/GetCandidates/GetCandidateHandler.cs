using AutoMapper;
using CandidateManagement.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CandidateManagement.Application.Querys.Candidate
{
    public class GetCandidateHandler : IRequestHandler<GetCandidateRequest, GetCandidateViewModel>
    {
        private readonly ICandidateManagementRepository candidateRepository;
        private readonly IMapper mapper;

        public GetCandidateHandler(ICandidateManagementRepository candidateRepository, IMapper mapper)
        {
            this.candidateRepository = candidateRepository;
            this.mapper = mapper;
        }

        public Task<GetCandidateViewModel> Handle(GetCandidateRequest request, CancellationToken cancellationToken)
        {
            var candidate = candidateRepository.Get(request.Id);
            var candidateViewModel = mapper.Map<GetCandidateViewModel>(candidate);

            return Task.FromResult(candidateViewModel);
        }
    }
}
