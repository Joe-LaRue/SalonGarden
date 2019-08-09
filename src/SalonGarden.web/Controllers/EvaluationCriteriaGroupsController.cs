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
    public class EvaluationCriteriaGroupsController : Controller
    {
        private readonly SalonGardenContext _context;

        public EvaluationCriteriaGroupsController(SalonGardenContext context)
        {
            _context = context;
        }

        // GET: EvaluationCriteriaGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.EvaluationCriteriaGroups.ToListAsync());
        }

        // GET: EvaluationCriteriaGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluationCriteriaGroup = await _context.EvaluationCriteriaGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evaluationCriteriaGroup == null)
            {
                return NotFound();
            }

            return View(evaluationCriteriaGroup);
        }

        // GET: EvaluationCriteriaGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EvaluationCriteriaGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,SequenceNumber")] EvaluationCriteriaGroup evaluationCriteriaGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(evaluationCriteriaGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(evaluationCriteriaGroup);
        }

        // GET: EvaluationCriteriaGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluationCriteriaGroup = await _context.EvaluationCriteriaGroups.FindAsync(id);
            if (evaluationCriteriaGroup == null)
            {
                return NotFound();
            }
            return View(evaluationCriteriaGroup);
        }

        // POST: EvaluationCriteriaGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,SequenceNumber")] EvaluationCriteriaGroup evaluationCriteriaGroup)
        {
            if (id != evaluationCriteriaGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evaluationCriteriaGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvaluationCriteriaGroupExists(evaluationCriteriaGroup.Id))
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
            return View(evaluationCriteriaGroup);
        }

        // GET: EvaluationCriteriaGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluationCriteriaGroup = await _context.EvaluationCriteriaGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evaluationCriteriaGroup == null)
            {
                return NotFound();
            }

            return View(evaluationCriteriaGroup);
        }

        // POST: EvaluationCriteriaGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evaluationCriteriaGroup = await _context.EvaluationCriteriaGroups.FindAsync(id);
            _context.EvaluationCriteriaGroups.Remove(evaluationCriteriaGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvaluationCriteriaGroupExists(int id)
        {
            return _context.EvaluationCriteriaGroups.Any(e => e.Id == id);
        }
    }
}
