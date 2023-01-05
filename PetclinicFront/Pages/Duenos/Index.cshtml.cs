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
    public class IndexModel : PageModel
    {
        private readonly petclinicFront.Models.azuresqlpetclinicContext _context;

        public IndexModel()
        {
            _context = new azuresqlpetclinicContext();
        }

        public IList<DuenosGrid> DuenosGrid { get;set; }

        public async Task OnGetAsync()
        {
            DuenosGrid = _context.GetDuenosGrid(0);
        }
    }
}
