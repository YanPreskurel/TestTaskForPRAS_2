namespace NewsPortal.Models
{
    public class LawyerTranslation
    {
        public int Id { get; set; }
        public int LawyerId { get; set; }
        public string Language { get; set; } = "ru";
        public string Name { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string PhotoImagePath { get; set; } = string.Empty;

        public Lawyer Lawyer { get; set; } = null!;
    }
}
