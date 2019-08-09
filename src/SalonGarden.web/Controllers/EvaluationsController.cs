
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalonGarden.Core.Entities;
using SalonGarden.Web.Data.SalonGarden;
using SalonGarden.Web.Models;

namespace SalonGarden.Web.Controllers
{
    public class EvaluationsController : Controller
    {
        private readonly SalonGardenContext _context;
        private readonly UserManager<IdentityUser> userManager;

        public EvaluationsController(SalonGardenContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }

        // GET: Evaluations
        public async Task<IActionResult> Index()
        {
            var viewModel = new EvaluationListViewModel();
            
            viewModel.Evaluations = await _context.Evaluations
                .Include(e => e.EvaluationStatus)
                .Include(e => e.EvaluationType)
                .Include(e => e.Technique)
                .ToListAsync();

            return View(viewModel);
        }

        // GET: Evaluations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluation = await _context.Evaluations
                .Include(e => e.EvaluationStatus)
                .Include(e => e.EvaluationType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evaluation == null)
            {
                return NotFound();
            }

            return View(evaluation);
        }

        // GET: Evaluations/Create
        public IActionResult Create()
        {

            var users = userManager.GetUsersInRoleAsync("Student").Result;

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
        public async Task<IActionResult> Create(CreateEvaluationViewModel createEvaluationViewModel)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(evaluation);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }


            return View(createEvaluationViewModel);
        }

        // GET: Evaluations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluation = await _context.Evaluations.FindAsync(id);
            if (evaluation == null)
            {
                return NotFound();
            }
            ViewData["EvaluationStatusId"] = new SelectList(_context.Set<EvaluationStatus>(), "Id", "Id", evaluation.EvaluationStatusId);
            ViewData["EvaluationTypeId"] = new SelectList(_context.Set<EvaluationType>(), "Id", "Id", evaluation.EvaluationTypeId);
            return View(evaluation);
        }

        // POST: Evaluations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EvaluationTypeId,EvaluationStatusId,TechniqueId,Description,EducatorId,StudentId,CreationDate")] Evaluation evaluation)
        {
            if (id != evaluation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evaluation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvaluationExists(evaluation.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EvaluationStatusId"] = new SelectList(_context.Set<EvaluationStatus>(), "Id", "Id", evaluation.EvaluationStatusId);
            ViewData["EvaluationTypeId"] = new SelectList(_context.Set<EvaluationType>(), "Id", "Id", evaluation.EvaluationTypeId);
            return View(evaluation);
        }

        // GET: Evaluations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluation = await _context.Evaluations
                .Include(e => e.EvaluationStatus)
                .Include(e => e.EvaluationType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evaluation == null)
            {
                return NotFound();
            }

            return View(evaluation);
        }

        // POST: Evaluations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evaluation = await _context.Evaluations.FindAsync(id);
            _context.Evaluations.Remove(evaluation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvaluationExists(int id)
        {
            return _context.Evaluations.Any(e => e.Id == id);
        }
    }
}
