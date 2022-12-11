using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeanSceneApp.Data;
using BeanSceneApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace BeanSceneApp.Controllers
{
    [Authorize(Roles = "Manager")]
    public class TableController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TableController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Table
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Table.Include(s => s.Area);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Table/Create
        public IActionResult Create()
        {
            ViewData["AreaId"] = new SelectList(_context.Area, "AreaId", "Name");
            return View();
        }

        // POST: Table/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Area, AreaId,TableNum,Note")] Table table)
        {
            table.Area = _context.Area.Find(table.AreaId); 

            if (ModelState.IsValid)
            {
                if (TableExists(table.AreaId, table.TableNum))
                {
                    ModelState.AddModelError("","This table already exists");
                    ViewData["AreaId"] = new SelectList(_context.Area, "AreaId", "Name", table.AreaId);
                    return View(table);
                }
                _context.Add(table);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("", "Something went wrong. Please try again later.");
                ViewData["AreaId"] = new SelectList(_context.Area, "AreaId", "Name", table.AreaId);
                return View(table);
            }
           
        }

        // GET: Table/Edit/5
        [Route("Table/Edit/{AreaId}/{TableNum}")]
        public async Task<IActionResult> Edit(char? areaId, int? tableNum)
        {
            if (areaId == null || tableNum < 0 || _context.Table == null)
            {
                return NotFound();
            }

            var table = await _context.Table.FindAsync(areaId, tableNum);
            if (table == null)
            {
                return NotFound();
            }
            return View(table);
        }

        // POST: Table/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Table/Edit/{AreaId}/{TableNum}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(char?areaId, int? tableNum, [Bind("AreaId,TableNum,Note")] Table table)
        {
            if (areaId != table.AreaId || tableNum != table.TableNum)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    _context.Update(table);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TableExists(table.AreaId, table.TableNum))
                    {
                        return NotFound();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Something went wrong.");
                    }
                }
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Table/Delete/M/5
        [Route("Table/Delete/{AreaId}/{TableNum}")]
        public async Task<IActionResult> Delete(char? areaId, int? tableNum)
        {
            if (areaId == null || tableNum == 0 || _context.Table == null)
            {
                return NotFound();
            }
            
            var table = await _context.Table
                .FirstOrDefaultAsync(m => m.AreaId == areaId);
            if (table == null)
            {
                return NotFound();
            }

            return View(table);
        }

        // POST: Table/Delete/5
        [HttpPost, ActionName("Delete")]
        [Route("Table/Delete/{AreaId}/{TableNum}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(char areaId, int tableNum)
        {
            if (_context.Table == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Table'  is null.");
            }
            var table = await _context.Table.FindAsync(areaId,tableNum);
            if (table != null)
            {
                _context.Table.Remove(table);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TableExists(char areaId, int tableNum)
        {
            var table = _context.Table.Find(areaId, tableNum);
            if (table != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
