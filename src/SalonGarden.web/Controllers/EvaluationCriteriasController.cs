using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalonGarden.Core.Entities;
using SalonGarden.Web.Data.SalonGarden;

namespace SalonGarden.Web.Controllers
{
    public class EvaluationCriteriasController : Controller
    {
        private readonly SalonGardenContext _context;

        public EvaluationCriteriasController(SalonGardenContext context)
        {
            _context = context;
        }

        // GET: EvaluationCriterias
        public async Task<IActionResult> Index()
        {
            return View(await _context.EvaluationCriterias.ToListAsync());
        }

        // GET: EvaluationCriterias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluationCriteria = await _context.EvaluationCriterias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evaluationCriteria == null)
            {
                return NotFound();
            }

            return View(evaluationCriteria);
        }

        // GET: EvaluationCriterias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EvaluationCriterias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,SequenceNumber,EvaluationCriteriaGroupId,TotalPoints")] EvaluationCriteria evaluationCriteria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(evaluationCriteria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(evaluationCriteria);
        }

        // GET: EvaluationCriterias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluationCriteria = await _context.EvaluationCriterias.FindAsync(id);
            if (evaluationCriteria == null)
            {
                return NotFound();
            }
            return View(evaluationCriteria);
        }

        // POST: EvaluationCriterias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,SequenceNumber,EvaluationCriteriaGroupId,TotalPoints")] EvaluationCriteria evaluationCriteria)
        {
            if (id != evaluationCriteria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evaluationCriteria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvaluationCriteriaExists(evaluationCriteria.Id))
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
            return View(evaluationCriteria);
        }

        // GET: EvaluationCriterias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluationCriteria = await _context.EvaluationCriterias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evaluationCriteria == null)
            {
                return NotFound();
            }

            return View(evaluationCriteria);
        }

        // POST: EvaluationCriterias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evaluationCriteria = await _context.EvaluationCriterias.FindAsync(id);
            _context.EvaluationCriterias.Remove(evaluationCriteria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvaluationCriteriaExists(int id)
        {
            return _context.EvaluationCriterias.Any(e => e.Id == id);
        }
    }
}
