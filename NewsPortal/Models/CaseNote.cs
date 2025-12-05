namespace NewsPortal.Models
{
    public class CaseNote
    {
        public int Id { get; set; }

        public List<CaseNoteTranslation> Translations { get; set; } = new();
    }
}
