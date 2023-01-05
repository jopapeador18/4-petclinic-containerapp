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
    public class DetailsModel : PageModel
    {
        private readonly petclinicFront.Models.azuresqlpetclinicContext _context;

        public DetailsModel()
        {
            _context = new azuresqlpetclinicContext();
        }

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
    }
}
