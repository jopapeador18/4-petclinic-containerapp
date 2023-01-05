using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace petclinicFront.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public Dictionary<string,string> env;

        public void OnGet()
        {
            env = new Dictionary<string, string>();
            var vars = Environment.GetEnvironmentVariables();
            foreach (DictionaryEntry item in vars)
            {
                env.Add(item.Key.ToString(), item.Value.ToString());
            }
        }
    }
}
