namespace NewsPortal.Models
{
    public class CallToActionBlockTranslation
    {
        public int Id { get; set; }
        public int CallToActionBlockId { get; set; }
        public string Language { get; set; } = "ru";
        public string Title { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public string ButtonText { get; set; } = string.Empty;
        public CallToActionBlock CallToActionBlock { get; set; } = null!;
    }
}
