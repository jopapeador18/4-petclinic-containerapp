using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using petclinicFront.Models;

namespace petclinicFront.Pages.Mascotas
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
            List<Tipo> tipos = new List<Tipo>();
            LookUpTipo = new List<SelectListItem>();
            LookUpDueno = new List<SelectListItem>();

            tipos = _context.GetTipos(0);

            foreach (var tipo in tipos)
            {
                LookUpTipo.Add(new SelectListItem() { Text = tipo.Tipo1, Value = tipo.TipoId.ToString() });
            }

            List<DuenosGrid> duenos = new List<DuenosGrid>();
            duenos = _context.GetDuenosGrid(0);
            
            foreach (var dueno in duenos)
            {
                LookUpDueno.Add(new SelectListItem() { Text = dueno.Nombre + " " + dueno.Apellido, Value = dueno.DuenoId.ToString(),Selected = duenoId == dueno.DuenoId});
            }

            return Page();
        }

        [BindProperty]
        public Mascota Mascota { get; set; }

        public List<SelectListItem> LookUpTipo { get; set; }
        public List<SelectListItem> LookUpDueno { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? duenoId)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AddMascota(Mascota);
            if (duenoId != null && duenoId > 0)
                return Redirect("~/Duenos/Details?id=" + Mascota.DuenoId);
            return Redirect("~/Duenos/Index");
        }
    }
}
