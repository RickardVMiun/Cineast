using Cineasterna.Models;
using Cineasterna.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Cineasterna.Controllers
{
    public class BrowseController : Controller
    {

        private IRepository repository;

        public BrowseController(IRepository repository)
        {
            this.repository = repository;
        }
    }
}
