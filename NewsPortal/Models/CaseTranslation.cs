namespace NewsPortal.Models
{
    public class CaseTranslation
    {
        public int Id { get; set; }

        public int CaseId { get; set; }
        public string Language { get; set; } = "ru";

        public string Title { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Organization { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        public CaseFullDescription CaseFullDescription { get; set; } = new();

        public Case Case { get; set; } = null!;
    }



    public class CaseFullDescription
    {
        public int Id { get; set; }

        // Внешний ключ на CaseTranslation
        public int CaseTranslationId { get; set; }
        public CaseTranslation CaseTranslation { get; set; } = null!;


        // ------------------------------------------------------------
        // ОБЩИЙ БЛОК
        // ------------------------------------------------------------
        public string MessageNumber { get; set; } = string.Empty;
        public string StatusText { get; set; } = string.Empty;
        public string CaseType { get; set; } = string.Empty;

        // ------------------------------------------------------------
        // ТЕКСТ
        // ------------------------------------------------------------
        public string Paragraph1 { get; set; } = string.Empty;

        public string Section1Title { get; set; } = string.Empty;
        public string Section1Text { get; set; } = string.Empty;
        public string Quote { get; set; } = string.Empty;
        public string Paragraph2 { get; set; } = string.Empty;

        public string Note1 { get; set; } = string.Empty;

        public string Section2Title { get; set; } = string.Empty;
        public string Section2Text { get; set; } = string.Empty;

        public string ListTitle { get; set; } = string.Empty;
        public string ListItems { get; set; } = string.Empty;

        public string Paragraph3 { get; set; } = string.Empty;

        public string Note2 { get; set; } = string.Empty;
        public string Note3 { get; set; } = string.Empty;

        public string DecisionTitle { get; set; } = string.Empty;
        public string DecisionText { get; set; } = string.Empty;
        public string DecisionLink { get; set; } = string.Empty;
    }
}
