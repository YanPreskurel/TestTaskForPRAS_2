namespace NewsPortal.Models
{
    public class WhoWeArePageTranslation
    {
        public int Id { get; set; }
        public int WhoWeArePageId { get; set; }
        public string Language { get; set; } = "ru";

        public string Title { get; set; } = string.Empty;

        public string Description1 { get; set; } = string.Empty;
        public string Description2 { get; set; } = string.Empty;

        public string SectionTitle { get; set; } = string.Empty;

        public string SectionText1 { get; set; } = string.Empty;
        public string SectionText2 { get; set; } = string.Empty;

        public WhoWeArePage WhoWeArePage { get; set; } = null!;
    }
}
