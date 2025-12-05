namespace NewsPortal.Models
{
    public class CaseDocument
    {
        public int Id { get; set; }

        public List<CaseDocumentTranslation> Translations { get; set; } = new();
    }
}
