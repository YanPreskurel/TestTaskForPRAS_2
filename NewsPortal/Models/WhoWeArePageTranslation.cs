namespace NewsPortal.Models
{
    public class WhoWeArePageTranslation
    {
        public int Id { get; set; }
        public int WhoWeArePageId { get; set; }
        public string Language { get; set; } = "ru";
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public WhoWeArePage WhoWeArePage { get; set; } = null!;
    }
}
