using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RobotalentLessons.Models;

namespace RobotalentLessons.Controllers
{
    public class LessonsController : Controller
    {
        private readonly robotalentLessonsContext _context;

        public LessonsController(robotalentLessonsContext context)
        {
            _context = context;
        }

        // GET: Lessons
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lessons.ToListAsync());
        }

        // GET: Lessons/Details/5
        public async Task<IActionResult> Details(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lessons = await _context.Lessons
                .SingleOrDefaultAsync(m => m.Id == id);
            if (lessons == null)
            {
                return NotFound();
            }

            return View(lessons);
        }

        // GET: Lessons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lessons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LessonType,Name,LessonNumbers,Description,CurrentLessonNumber,Status,BeginDate,EndDate")] Lessons lessons)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lessons);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lessons);
        }

        // GET: Lessons/Edit/5
        public async Task<IActionResult> Edit(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lessons = await _context.Lessons.SingleOrDefaultAsync(m => m.Id == id);
            if (lessons == null)
            {
                return NotFound();
            }
            return View(lessons);
        }

        // POST: Lessons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(uint id, [Bind("Id,LessonType,Name,LessonNumbers,Description,CurrentLessonNumber,Status,BeginDate,EndDate")] Lessons lessons)
        {
            if (id != lessons.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lessons);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LessonsExists(lessons.Id))
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
            return View(lessons);
        }

        // GET: Lessons/Delete/5
        public async Task<IActionResult> Delete(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lessons = await _context.Lessons
                .SingleOrDefaultAsync(m => m.Id == id);
            if (lessons == null)
            {
                return NotFound();
            }

            return View(lessons);
        }

        // POST: Lessons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(uint id)
        {
            var lessons = await _context.Lessons.SingleOrDefaultAsync(m => m.Id == id);
            _context.Lessons.Remove(lessons);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LessonsExists(uint id)
        {
            return _context.Lessons.Any(e => e.Id == id);
        }
    }
}
