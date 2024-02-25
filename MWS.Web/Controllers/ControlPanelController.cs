using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MWS.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MWS.Web.Controllers
{
    [Authorize(Roles = "Administrator,Staff")]
    public class ControlPanelController : Controller
    {
        private readonly MWSWebDBContext _context;

        public ControlPanelController(MWSWebDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var controlPanelViewModel = new ControlPanelViewModel();
            controlPanelViewModel.Mrate = new Mrate();
            controlPanelViewModel.Mrates = await _context.Mrates.ToListAsync();
            controlPanelViewModel.Fee = await _context.Fees.FirstOrDefaultAsync();
            controlPanelViewModel.Fee.SeniorDiscount = controlPanelViewModel.Fee.SeniorDiscount * 100;
            return View(controlPanelViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Mrate mrate)
        {
            
            if (ModelState.IsValid)
            {
                _context.Mrates.Add(mrate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();

        }

        public async Task<IActionResult> Update(int? Id)
        {            
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var mrate = await _context.Mrates.Where(c => c.Metid == Id).FirstOrDefaultAsync();

            if (mrate == null)
            {
                return NotFound();
            }

            return View(mrate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Mrate mrate)
        {           
            if (ModelState.IsValid)
            {
                _context.Mrates.Update(mrate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateFee(Fee fee)
        {
            if (ModelState.IsValid)
            {
                fee.SeniorDiscount = fee.SeniorDiscount / 100;
                _context.Fees.Update(fee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var mrate = await _context.Mrates.Where(c => c.Metid == id).FirstOrDefaultAsync();

            _context.Mrates.Remove(mrate);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
