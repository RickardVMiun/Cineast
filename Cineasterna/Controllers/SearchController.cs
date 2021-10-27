using Cineasterna.Models;
using Cineasterna.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cineasterna.Controllers
{
    public class SearchController : Controller
    {
        private IRepository repository;

        public SearchController(IRepository repository)
        {
            this.repository = repository;
        }

        
    }
}
