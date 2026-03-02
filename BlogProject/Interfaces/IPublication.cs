using BlogProject.Models;
using BlogProject.Models.Pages;

namespace BlogProject.Interfaces
{
    public interface IPublication
    {
        Task<IEnumerable<Publication>> GetAllPublicationsAsync();
        Task<IEnumerable<Publication>> GetAllPublicationsWithCategoriesAsync();
        Task<Publication> GetPublicationAsync(string id);
        Task<Publication> GetPublicationWithCategoriesAsync(string id);

        Task UpdateViewsAsync(string id);

        Task AddPublicationAsync(Publication publication);
        Task UpdatePublicationAsync(Publication publication);
        Task DeletePublicationAsync(Publication publication);


        IQueryable<Publication> GetPublicationsQuery();
        IQueryable<Publication> GetPublicationsWithCategoriesQuery();

        Task<PagedList<Publication>> GetAllPublicationsByCategoryWithCategories(QueryOptions options, string id);
    }

}
