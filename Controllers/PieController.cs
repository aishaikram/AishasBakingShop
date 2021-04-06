using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AishasBakingShop.Models;
using AishasBakingShop.ViewModels;

namespace AishasBakingShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;
        // the category and pie repositories are automatically injected whereever they are required by the ASP.net MVC framework after they are registered in Startup class for DI
        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }
        //public ViewResult List()
        //{/*
        //    //ViewBag.CurrentCategory = "cheese bag";
        //    //builtin method from asp.net core
        //    return View(_pieRepository.AllPies);
        //    */

        //    //added following cide replacing above code 
        //    PieListViewModel pieListViewModel = new PieListViewModel();
        //    pieListViewModel.Pies = _pieRepository.AllPies;
        //    pieListViewModel.CurrentCategory = "Fruit Pies";
        //    return View(pieListViewModel);
        //}

        public ViewResult List(string category)
        {
            IEnumerable<Pie> pies;
            string currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                pies = _pieRepository.AllPies.OrderBy(p => p.PieId);
                currentCategory = "All Cakes and Pies";
            }
            else
            {
                pies = _pieRepository.AllPies.Where(p => p.Category.CategoryName == category)
                    .OrderBy(p => p.PieId);
                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }

            return View(new PieListViewModel
            {
                Pies = pies,
                CurrentCategory = currentCategory
            });
        }
        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie==null)
                  return NotFound(); //sends 404 Not found to client
            return View(pie);
        }

    }
}
