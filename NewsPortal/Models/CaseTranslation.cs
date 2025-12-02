namespace NewsPortal.Models
{
    public class CaseTranslation
    {
        public int Id { get; set; }
        public int CaseId { get; set; }
        public string Language { get; set; } = "ru";
        public string Title { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string FullDescription { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Organization { get; set; } = string.Empty;

        public Case Case { get; set; } = null!;
    }
}
