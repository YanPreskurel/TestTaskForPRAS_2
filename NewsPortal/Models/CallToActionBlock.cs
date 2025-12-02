namespace NewsPortal.Models
{
    public class CallToActionBlock
    {
        public int Id { get; set; }
        public List<CallToActionBlockTranslation> Translations { get; set; } = new();
    }
}
