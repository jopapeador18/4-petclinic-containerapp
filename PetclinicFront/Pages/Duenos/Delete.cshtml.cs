using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using petclinicFront.Models;

namespace petclinicFront.Pages.Duenos
{
    public class DeleteModel : PageModel
    {
        private readonly petclinicFront.Models.azuresqlpetclinicContext _context;

        public DeleteModel()
        {
            _context = new azuresqlpetclinicContext();
        }

        [BindProperty]
        public DuenosGrid DuenosGrid { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DuenosGrid = _context.GetDuenosGrid(id).FirstOrDefault(m => m.DuenoId == id);

            if (DuenosGrid == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DuenosGrid = _context.GetDuenosGrid(0).Find(x=>x.DuenoId == id);

            if (DuenosGrid != null)
            {
                _context.DeleteDueno(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
