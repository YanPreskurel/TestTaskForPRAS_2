namespace NewsPortal.Models
{
    public class CaseNoteTranslation
    {
        public int Id { get; set; }
        public int CaseNoteId { get; set; }
        public string Language { get; set; } = "ru";
        public string Title { get; set; } = "Пояснение";
        public string Text { get; set; } = string.Empty;

        public CaseNote CaseNote { get; set; } = null!;
    }
}
