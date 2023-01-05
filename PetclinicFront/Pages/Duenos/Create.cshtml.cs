using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using petclinicFront.Models;

namespace petclinicFront.Pages.Duenos
{
    public class CreateModel : PageModel
    {
        private readonly petclinicFront.Models.azuresqlpetclinicContext _context;

        public CreateModel()
        {
            _context = new azuresqlpetclinicContext();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Dueno Dueno { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AddDueno(Dueno);

            return RedirectToPage("./Index");
        }
    }
}
