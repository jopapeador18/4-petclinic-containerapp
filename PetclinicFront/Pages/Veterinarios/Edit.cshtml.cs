using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using petclinicFront.Models;

namespace petclinicFront.Pages.Veterinarios
{
    public class EditModel : PageModel
    {
        private readonly petclinicFront.Models.azuresqlpetclinicContext _context;

        public EditModel()
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

            Veterinario = _context.GetVets(id).FirstOrDefault();

            if (Veterinario == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

           //Hacer el cambio
           _context.EditVet(Veterinario.VeterinarioId, Veterinario);

            return RedirectToPage("./Index");
        }

        private bool VetsExist(int id)
        {
            return _context.GetVets(0).Any(e => e.VeterinarioId == id);
        }
    }
}
