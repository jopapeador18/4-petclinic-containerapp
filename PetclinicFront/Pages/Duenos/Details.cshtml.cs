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
    public class DetailsModel : PageModel
    {
        private readonly petclinicFront.Models.azuresqlpetclinicContext _context;

        public DetailsModel()
        {
            _context = new azuresqlpetclinicContext();
        }

        public DuenosGrid DuenosGrid { get; set; }
        public List<Mascota> Mascotas { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DuenosGrid = _context.GetDuenosGrid(id).FirstOrDefault();

            if (DuenosGrid == null)
            {
                return NotFound();
            }

            Mascotas = new List<Mascota>();
            Mascotas = _context.GetMascotasPorDueno(DuenosGrid.DuenoId);


            return Page();
        }
    }
}
