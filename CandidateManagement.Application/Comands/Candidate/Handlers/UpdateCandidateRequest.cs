using CandidateManagement.Application.Comands.Candidate.Requests;
using CandidateManagement.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CandidateManagement.Application.Comands.Candidate.Handlers
{
    public class UpdateCandidateHandler : IRequestHandler<UpdateCandidateRequest, bool>
    {
        private readonly ICandidateManagementRepository _candidateRepository;

        public UpdateCandidateHandler(ICandidateManagementRepository candidateRepository)
        {
            this._candidateRepository = candidateRepository;
        }
        public Task<bool> Handle(UpdateCandidateRequest request, CancellationToken cancellationToken)
        {

            var candidate = _candidateRepository.Get(request.Id);

            if (candidate == null)
                return Task.FromResult(false);

            var candidateUpdated = new Domain.Entities.Candidate(request.Id,
                                            request.Name,
                                            request.Surname,
                                            request.Birthdate,
                                            candidate.InsertDate,
                                            request.Email);


            _candidateRepository.Update(candidateUpdated);


            return Task.FromResult(true);
        }

    }
}
