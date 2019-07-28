using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalonGarden.Core.Entities;
using SalonGarden.Infrastructure.Data;
using SalonGarden.Web.Models;

namespace SalonGarden.Web.Controllers
{
    public class EvaluationsController : Controller
    {
        private readonly SalonGardenContext _context;

        public EvaluationsController(SalonGardenContext context)
        {
            _context = context;
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
            ViewData["TechniqueId"] = new SelectList(_context.Set<Technique>(), "Id", "Description");
            ViewData["EvaluationTypeId"] = new SelectList(_context.Set<EvaluationType>(), "Id", "Description");
            return View();
        }

        // POST: Evaluations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EvaluationTypeId,EvaluationStatusId,TechniqueId,Description,EducatorId,StudentId,CreationDate")] Evaluation evaluation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(evaluation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EvaluationStatusId"] = new SelectList(_context.Set<EvaluationStatus>(), "Id", "Id", evaluation.EvaluationStatusId);
            ViewData["EvaluationTypeId"] = new SelectList(_context.Set<EvaluationType>(), "Id", "Id", evaluation.EvaluationTypeId);
            return View(evaluation);
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
