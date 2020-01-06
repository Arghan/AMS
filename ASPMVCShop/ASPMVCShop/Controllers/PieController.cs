using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPMVCShop.Models;
using ASPMVCShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPMVCShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _pieRepository = pieRepository;
        }

        public ViewResult List(string category)
        {
            var cat = _categoryRepository.AllCategories.FirstOrDefault(c => 
                string.IsNullOrEmpty(category) || c.CategoryName == category);

            PiesListViewModel vm = new PiesListViewModel {
                Category = string.IsNullOrEmpty(category) ? "All categories" : cat.CategoryName, 
                Pies = _pieRepository.AllPies.Where(p => p.CategoryId == cat.CategoryId)
            };
        
            return View(vm);
        }

        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);

            if (pie == null)
                return NotFound();
            else
                return View(pie);
        }
    }
}
