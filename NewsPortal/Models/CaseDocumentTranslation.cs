namespace NewsPortal.Models
{
    public class CaseDocumentTranslation
    {
        public int Id { get; set; }
        public int CaseDocumentId { get; set; }
        public string Language { get; set; } = "ru";
        public string Title { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; // PDF

        public CaseDocument CaseDocument { get; set; } = null!;
    }
}
