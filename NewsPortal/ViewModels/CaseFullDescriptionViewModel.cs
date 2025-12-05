public class CaseFullDescriptionViewModel
{
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