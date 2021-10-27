using Cineasterna.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cineasterna.Controllers
{
    public class MovieController : Controller
    {

        private IRepository repository;

        public MovieController(IRepository repository)
        {
            this.repository = repository;
        }
        public IActionResult Movie()
        {
            return View();
        }
    }
}
