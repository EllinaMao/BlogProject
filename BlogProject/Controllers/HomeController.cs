using BlogProject.Interfaces;
using BlogProject.Models;
using BlogProject.Models.Pages;
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
        private readonly IPublication _publication;

        public HomeController(IPublication publication)
        {
            _publication = publication;
        }
        public async Task<IActionResult> Index(QueryOptions options, Guid? categoryId)
        {
            var publications = await _publication.GetAllPublicationsWithCategoriesAsync();
            if (categoryId.HasValue)
            {
                publications = publications.Where(p => p.Categories.Any(c => c.Id == categoryId.Value)).ToList();
            }

            var viewModel = publications.Select(p => new MainPostViewModel
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description,
                Image = p.Image,
                CreatedAt = p.CreatedAt,
                TotalViews = p.TotalViews,
                CategoryNames = p.Categories.Select(c => c.Name)
            }).ToList();


            //var pagedList = new PagedList<MainPostViewModel>(viewModel, options)
            //{
            //    CategoryId = categoryId
            //};


            return View();
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
