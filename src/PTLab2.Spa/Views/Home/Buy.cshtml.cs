using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace PTLab2.Spa.Views.Home
{
    public class Buy : PageModel
    {
        private readonly ILogger<Buy> _logger;

        public Buy(ILogger<Buy> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}