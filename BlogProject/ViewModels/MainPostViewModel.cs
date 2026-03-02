namespace BlogProject.ViewModels
{
    public class MainPostViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public string? Image { get; set; }

        public DateTime CreatedAt { get; set; }
        public long TotalViews { get; set; }
        public IEnumerable<string> CategoryNames { get; set; }
    }
}
