using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using petclinicFront.Models;

namespace petclinicFront.Pages.Veterinarios
{
    public class DeleteModel : PageModel
    {
        private readonly petclinicFront.Models.azuresqlpetclinicContext _context;

        public DeleteModel()
        {
            _context = new azuresqlpetclinicContext();
        }

        [BindProperty]
        public Veterinario Veterinario { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Veterinario = _context.GetVets(id).FirstOrDefault(m => m.VeterinarioId == id);

            if (Veterinario == null)
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

            Veterinario = _context.GetVets(0).Find(x=>x.VeterinarioId == id);

            if (Veterinario != null)
            {
                _context.DeleteVet(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
