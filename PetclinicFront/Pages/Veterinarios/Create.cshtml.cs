using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using petclinicFront.Models;

namespace petclinicFront.Pages.Veterinarios
{
    public class CreateModel : PageModel
    {
        private readonly petclinicFront.Models.azuresqlpetclinicContext _context;

        public CreateModel()
        {
            _context = new azuresqlpetclinicContext();
        }

        public IActionResult OnGet(int? duenoId)
        {
            return Page();
        }

        [BindProperty]
        public Veterinario Veterinario { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? duenoId)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AddVet(Veterinario);

            return Redirect("~/Veterinarios/Index");
        }
    }
}
