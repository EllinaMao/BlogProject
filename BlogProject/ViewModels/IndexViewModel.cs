using BlogProject.Models;

namespace BlogProject.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Publication> Publications { get; set; }
        public List<Category> Categories { get; set; }
    }
}
