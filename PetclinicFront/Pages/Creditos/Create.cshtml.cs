using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using petclinicFront.Models;

namespace petclinicFront.Pages.Creditos
{
    public class CreateModel : PageModel
    {
        private readonly petclinicFront.Models.azuresqlpetclinicContext _context;

        public CreateModel()
        {
            _context = new azuresqlpetclinicContext();
            LookUpPlazos = new List<SelectListItem>();
            LookUpPlazos.Add(new SelectListItem() { Text = "6 Meses", Value = "180" });
            LookUpPlazos.Add(new SelectListItem() { Text = "12 Meses", Value = "360" });
            LookUpPlazos.Add(new SelectListItem() { Text = "16 Meses", Value = "480" });

            LookUpArea = new List<SelectListItem>();
            LookUpArea.Add(new SelectListItem() { Text = "Urbana", Value = "Urbana" });
            LookUpArea.Add(new SelectListItem() { Text = "Semiurbana", Value = "Semiurbana" });
            LookUpArea.Add(new SelectListItem() { Text = "Rural", Value = "Rural" });
        }

        public IActionResult OnGet(int? duenoId)
        {
            return Page();
        }

        

        [BindProperty]
        public PreaprobacionRequest SolicitudCredito { get; set; }
        public List<SelectListItem> LookUpPlazos;
        public List<SelectListItem> LookUpArea;
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var prediction = _context.GetCreditPrediction(SolicitudCredito);

            ViewData["Score"] = prediction;
            ViewData["Preautorizado"] = prediction >= 0.8 ? "1" : "0";

            return Page();
        }
    }
}
