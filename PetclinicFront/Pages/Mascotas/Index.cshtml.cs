using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using petclinicFront.Models;

namespace petclinicFront.Pages.Mascotas
{
    public class IndexModel : PageModel
    {
        private readonly petclinicFront.Models.azuresqlpetclinicContext _context;

        public IndexModel()
        {
            _context = new azuresqlpetclinicContext();
        }

        public IList<Mascota> Mascotas { get;set; }

        public async Task OnGetAsync()
        {
            Mascotas = _context.GetMascotas(0);
            foreach (var mascota in Mascotas)
            {
                mascota.Dueno.Nombre = mascota.Dueno.Nombre + " " + mascota.Dueno.Apellido;
            }
        }
    }
}
