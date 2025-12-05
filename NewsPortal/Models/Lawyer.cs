namespace NewsPortal.Models
{
    public class Lawyer
    {
        public int Id { get; set; }

        public List<LawyerTranslation> Translations { get; set; } = new();
    }
}
