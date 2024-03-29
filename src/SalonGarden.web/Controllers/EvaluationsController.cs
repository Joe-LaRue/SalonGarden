﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalonGarden.Core.Entities;
using SalonGarden.Web.Models;
using SalonGarden.Web.Data.SalonGarden;
using Microsoft.AspNetCore.Authorization;

namespace SalonGarden.Web.Controllers
{
    [Authorize(Roles = Data.Constants.Roles.EDUCATOR)]
    public class EvaluationsController : Controller
    {
        private readonly SalonGardenContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public EvaluationsController(SalonGardenContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            this._userManager = userManager;
        }

        // GET: Evaluations
        public async Task<IActionResult> Index()
        {
            var userList = _userManager.Users.ToList();

            var viewModel = new EvaluationListViewModel();
            
            var evaluations = await _context.Evaluations
                .Include(e => e.EvaluationDetailItems)
                .Include(e => e.EvaluationStatus)
                .Include(e => e.EvaluationType)
                .Include(e => e.Technique)
                .Where(e => e.EvaluationStatusId == (int)EvaluationStatuses.Open)
                .ToListAsync();

            foreach (var evaluation in evaluations )
            {
                var dto = new EvaluationDto(evaluation);
                dto.StudentName = userList.First(x => x.Id == evaluation.StudentId).UserName;
                dto.EducatorName = userList.First(x => x.Id == evaluation.EducatorId).UserName;
                viewModel.EvaluationDtos.Add(dto);
            }


            return View(viewModel);
        }

        public async Task<IActionResult> History()
        {
            var userList = _userManager.Users.ToList();

            var viewModel = new EvaluationListViewModel();

            var evaluations = await _context.Evaluations
                .Include(e => e.EvaluationDetailItems)
                .Include(e => e.EvaluationStatus)
                .Include(e => e.EvaluationType)
                .Include(e => e.Technique)
                .Where(e => e.EvaluationStatusId == (int)EvaluationStatuses.Closed)
                .ToListAsync();

            foreach (var evaluation in evaluations)
            {
                var dto = new EvaluationDto(evaluation);
                dto.StudentName = userList.First(x => x.Id == evaluation.StudentId).UserName;
                dto.EducatorName = userList.First(x => x.Id == evaluation.EducatorId).UserName;
                viewModel.EvaluationDtos.Add(dto);
            }


            return View(viewModel);
        }

        // GET: Evaluations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = new EvaluationDetailVIewModel();

            viewModel.CriteriaGroups = await _context.EvaluationCriteriaGroups.Include(x => x.EvaluationCriteria).ToListAsync();

            var evaluation = await _context.Evaluations
                .Include(e => e.EvaluationStatus)
                .Include(e => e.EvaluationType)
                .Include(e => e.Technique)
                .Include(e => e.EvaluationDetailItems)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (evaluation == null)
            {
                return NotFound();
            }

            viewModel.Evaluation = evaluation;

            var student = await _userManager.FindByIdAsync(evaluation.StudentId);
            var educator = await _userManager.FindByIdAsync(evaluation.EducatorId);

            viewModel.Student = student;
            viewModel.Educator = educator;

            return View(viewModel);
        }

        // GET: Evaluations/Create
        public IActionResult Create()
        {

            var users = _userManager.GetUsersInRoleAsync("Student").Result;

            var viewModel = new CreateEvaluationViewModel()
            {
                TechniqueSelectList = new SelectList(_context.Techniques.OrderBy(x => x.Description).ToList(), "Id", "Description"),
                EvaluationTypesSelectList = new SelectList(_context.EvaluationTypes.OrderBy(x => x.Description).ToList(), "Id", "Description"),
                UsersSelectList = new SelectList(users.OrderBy(x => x.UserName), "Id", "UserName")
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEvaluationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var currentUser = _userManager.FindByEmailAsync(User.Identity.Name).Result;
                var evaluation = new Evaluation(viewModel.SelectedEvaluationTypeId, viewModel.SelectedTechniqueId, currentUser.Id, viewModel.SelectedStudentId);

                _context.Add(evaluation);
                await _context.SaveChangesAsync();

                var evaluationCriteria = _context.EvaluationCriterias.ToList();

                evaluation.InitializeEvaluationStepEntries(evaluationCriteria);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Edit), new { id = evaluation.Id });
            }

            
            var users = _userManager.GetUsersInRoleAsync("Student").Result;

            viewModel.TechniqueSelectList = new SelectList(_context.Techniques.OrderBy(x => x.Description).ToList(), "Id", "Description");
            viewModel.EvaluationTypesSelectList = new SelectList(_context.EvaluationTypes.OrderBy(x => x.Description).ToList(), "Id", "Description");
            viewModel.UsersSelectList = new SelectList(users.OrderBy(x => x.UserName), "Id", "UserName");

            return View(viewModel);
        }

       
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluation = await _context.Evaluations
               .Include(e => e.EvaluationStatus)
               .Include(e => e.EvaluationType)
               .Include(e => e.EvaluationDetailItems)
               .Include(e => e.Technique)
               .FirstOrDefaultAsync(m => m.Id == id);

            if (evaluation == null)
            {
                return NotFound();
            }

            if (evaluation.EvaluationStatusId != (int)EvaluationStatuses.Open)
            {
                return RedirectToAction(nameof(Details), new { id = id });
            }


            var viewModel = new EditEvaluationViewModel();

            viewModel.CriteriaGroups = await _context.EvaluationCriteriaGroups.Include(x => x.EvaluationCriteria).ToListAsync();

           

            viewModel.Evaluation = evaluation;

            var student = await _userManager.FindByIdAsync(evaluation.StudentId);
            var educator = await _userManager.FindByIdAsync(evaluation.EducatorId);

            viewModel.Student = student;
            viewModel.Educator = educator;
            return View(viewModel);
        }

        
        // POST: Evaluations/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEvaluation(int evaluationId)
        {
            var evaluation = _context.Evaluations.FirstOrDefault(x => x.Id == evaluationId);

            if (evaluation != null)
            {
                _context.Remove(evaluation);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return BadRequest();
        }

        public IActionResult UpdateScore(int detailItemId, int score)
        {
            var detailItem = _context.EvaluationDetailItems.FirstOrDefault(x => x.Id == detailItemId);
            if (detailItem != null)
            {
                detailItem.AllocatedPoints = score;
                _context.SaveChanges();
                return Ok();
            }

            return BadRequest();
        }

        public IActionResult CompleteEvaluation(int evaluationId)
        {
            var evaluation = _context.Evaluations.FirstOrDefault(x => x.Id == evaluationId);

            if (evaluation != null)
            {
                evaluation.EvaluationStatusId = (int)EvaluationStatuses.Closed;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return BadRequest();
        }
    }
}
