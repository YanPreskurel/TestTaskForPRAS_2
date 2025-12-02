namespace NewsPortal.Models
{
    public class Case
    {
        public int Id { get; set; }
        public string FlagImagePath { get; set; } = string.Empty;
        public string StatusColor { get; set; } = string.Empty;

        public List<CaseTranslation> Translations { get; set; } = new();
    }
}
