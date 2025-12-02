namespace NewsPortal.Models
{
    public class WhoWeArePage
    {
        public int Id { get; set; }
        public List<WhoWeArePageTranslation> Translations { get; set; } = new();
    }


}
