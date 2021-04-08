using TheBakingCentre.Models;
using TheBakingCentre.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TheBakingCentre.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _pieRepository;
        public HomeController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {   PiesofTheWeek = _pieRepository.PiesOfTheWeek

             };
            return View(homeViewModel);
        }
    }
}
