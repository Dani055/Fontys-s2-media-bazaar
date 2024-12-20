﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using MBazaarClassLibrary.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MediaBazaarWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly INotyfService _notyf;
        public IndexModel(ILogger<IndexModel> logger, INotyfService notyf)
        {
            _logger = logger;
            _notyf = notyf;
        }

        public void OnGet()
        {
            
        }
    }
}
