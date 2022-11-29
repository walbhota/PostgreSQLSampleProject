using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviePostgreSql.Domain;
using MoviePostgreSql.Models;
using MoviePostgreSql.ViewModels;
using System.Diagnostics;

namespace MoviePostgreSql.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieDataContext _context;

        public HomeController(MovieDataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Actors).Select(m => new MovieViewModel
            {
                Title = m.Title,
                Year = m.Year.ToString(),
                Summary = m.Summary,
                Actors = string.Join(',', m.Actors.Select(a => a.FullName))

            });
            return View(movies);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}