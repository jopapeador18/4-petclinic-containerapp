using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using petclinicFront.Models;

namespace petclinicFront.Pages.Duenos
{
    public class EditModel : PageModel
    {
        private readonly petclinicFront.Models.azuresqlpetclinicContext _context;

        public EditModel()
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

            DuenosGrid = _context.GetDuenosGrid(id).FirstOrDefault();

            if (DuenosGrid == null)
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
           _context.EditDueno(DuenosGrid.DuenoId,new Dueno()
           {
               DuenoId = DuenosGrid.DuenoId,
               Nombre = DuenosGrid.Nombre,
               Apellido = DuenosGrid.Apellido,
               Ciudad = DuenosGrid.Ciudad,
               Direccion = DuenosGrid.Direccion,
               Telefono = DuenosGrid.Direccion
           });

            return RedirectToPage("./Index");
        }

        private bool DuenosGridExists(int id)
        {
            return _context.GetDuenosGrid(0).Any(e => e.DuenoId == id);
        }
    }
}
