namespace NewsPortal.Models
{
    public class TagTranslation
    {
        public int Id { get; set; }
        public int TagId { get; set; }
        public string Language { get; set; } = "ru";
        public string Name { get; set; } = string.Empty;

        public Tag Tag { get; set; } = null!;
    }

}
