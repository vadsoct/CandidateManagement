using AutoMapper;
using CandidateManagement.Application.Querys;
using CandidateManagement.Application.Querys.Candidate;
using CandidateManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Candidate, GetCandidateViewModel>();

            CreateMap<Candidate, GetAllCandidatesViewModel>();
            CreateMap<CandidateExperience, GetCandidateExperienceViewModel>();
        }
    }
}
