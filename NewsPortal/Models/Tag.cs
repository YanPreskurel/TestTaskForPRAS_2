namespace NewsPortal.Models
{
    public class Tag
    {
        public int Id { get; set; }

        public string Color { get; set; } = string.Empty;

        public List<TagTranslation> Translations { get; set; } = new();
    }

}
