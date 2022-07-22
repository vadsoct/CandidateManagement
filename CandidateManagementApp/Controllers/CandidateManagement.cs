﻿
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CandidateManagement.Application.Querys.Candidate;
using System;
using CandidateManagement.Application.Querys;
using AutoMapper;
using CandidateManagement.Domain.Entities;
using CandidateManagement.Application.Comands.Requests;
using CandidateManagement.Application.Comands.Candidate.Requests;

namespace CandidateManagementApp.Controllers
{
    public class CandidateManagementController : Controller
    {
        private readonly ILogger<CandidateManagementController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CandidateManagementController(IMediator mediator, ILogger<CandidateManagementController> logger, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var query = new GetAllCandidatesRequest();

            var candidatesViewModel = _mediator.Send(query).Result;

            return View(candidatesViewModel);
        }

        [HttpGet]
        public IActionResult Details(Guid id)
        {
            var query = new GetCandidateRequest() { Id = id };

            var candidateViewModel = _mediator.Send(query).Result;

            return View(candidateViewModel);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] CreateCandidateRequest request)
        {
            if (!ModelState.IsValid) return View(request);

            _mediator.Send(request);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var query = new GetCandidateRequest() { Id = id };

            var candidateViewModel = _mediator.Send(query).Result;

            return View(candidateViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind] UpdateCandidateRequest request)
        {
            if (!ModelState.IsValid) return View(request);

            _mediator.Send(request);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var query = new GetCandidateRequest() { Id = id };

            var candidateViewModel = _mediator.Send(query).Result;

            return View(candidateViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(DeleteCandidateRequest request)
        {
            if (!ModelState.IsValid) return View(request);

            _mediator.Send(request);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult CreateExperience(Guid id)
        {
            var request = new CreateCandidateExperienceRequest(id);
            return View(request);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateExperience([Bind] CreateCandidateExperienceRequest request)
        {
            if (!ModelState.IsValid) return View(request);

            _mediator.Send(request);

            return RedirectToAction("Details", new { id = request.CandidateId });
        }

        [HttpGet]
        public IActionResult EditCandidateExperience(CandidateExperience candidateExperience)
        {
            GetCandidateExperienceViewModel candidateExperienceViewModel = _mapper.Map<GetCandidateExperienceViewModel>(candidateExperience);
            return View(candidateExperienceViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCandidateExperience([Bind] UpdateCandidateExperienceRequest request)
        {
            if (!ModelState.IsValid) return View(request);

            _mediator.Send(request);

            return RedirectToAction("Details", new { id = request.CandidateId });
        }
    }
}
