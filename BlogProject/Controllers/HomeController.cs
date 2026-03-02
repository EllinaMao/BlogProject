using BlogProject.Interfaces;
using BlogProject.Models;
using BlogProject.Models.Pages;
using BlogProject.Repositories;
using BlogProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogProject.Controllers
{
    /*
     * наша задача для HomeController
изменить действие индекс и отобразить все посты. Добавить пагинацию, поиск, фильтрацию
     */
    public class HomeController : Controller
    {
        private readonly ICategory _categories;
        private readonly IPublication _publications;

        public HomeController(IPublication publication, ICategory categories)
        {
            _categories = categories;
            _publications = publication;
        }
        public async Task<IActionResult> Index(QueryOptions? options, string? categoryId)
        {
            var allCategories = await _categories.GetAllCategoriesAsync();
            var allPublications = await _publications.GetAllPublicationsByCategoryWithCategories(options, categoryId);

            return View(new IndexViewModel
            {
                Categories = allCategories.ToList(),
                Publications = allPublications
            });
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
