using EMovieFinder.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EMovieFinder.Web.Controllers
{
    public class MovieCartController : Controller
    {
        private readonly IMovieCartService _movieCartService;

        public MovieCartController(IMovieCartService movieCartService)
        {
            _movieCartService = movieCartService;
        }

        public IActionResult Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return View(this._movieCartService.getMovieCartInfo(userId));
        }

        public IActionResult DeleteMovieFromMovieCart(Guid id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = this._movieCartService.deleteMovieFromMovieCart(userId, id);

            if (result)
            {
                return RedirectToAction("Index", "MovieCart");
            }
            else
            {
                return RedirectToAction("Index", "MovieCart");
            }
        }

        public IActionResult DownloadNow()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = this._movieCartService.downloadNow(userId);

            if (result)
            {
                return RedirectToAction("Index", "MovieCart");
            }
            else
            {
                return RedirectToAction("Index", "MovieCart");
            }
        }
    }
}
