using System.Collections.Generic;

namespace NewsPortal.ViewModels
{
    public class CaseViewModel
    {
        public int Id { get; set; }

        // Язык текущего перевода
        public string Language { get; set; } = "ru";

        // Переведённые поля
        public string Title { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;

        // Поля без перевода
        public string Country { get; set; } = string.Empty;
        public string Organization { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string FlagImagePath { get; set; } = string.Empty;
        public string StatusColor { get; set; } = string.Empty;

        // ===== Связанные данные с переводами =====
        public List<CaseDocumentViewModel> Documents { get; set; } = new();
        public List<TagViewModel> Tags { get; set; } = new();
        public List<LawyerViewModel> Lawyers { get; set; } = new();
        public List<CaseNoteViewModel> Notes { get; set; } = new();

        public CaseTranslationViewModel RU { get; set; } = new CaseTranslationViewModel();
        public CaseTranslationViewModel EN { get; set; } = new CaseTranslationViewModel();
    }

    public class CaseDocumentViewModel
    {
        public int Id { get; set; }
        public string Language { get; set; } = "ru";
        public string Title { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
    }

    public class TagViewModel
    {
        public int Id { get; set; }
        public string Language { get; set; } = "ru";
        public string Name { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
    }

    public class LawyerViewModel
    {
        public int Id { get; set; }
        public string Language { get; set; } = "ru";
        public string Name { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string PhotoImagePath { get; set; } = string.Empty;
    }

    public class CaseNoteViewModel
    {
        public int Id { get; set; }
        public string Language { get; set; } = "ru";
        public string Title { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
    }

    public class CaseTranslationViewModel
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Country { get; set; }
        public string Organization { get; set; }
        public string Status { get; set; }
        public CaseFullDescriptionViewModel FullDescription { get; set; } = new CaseFullDescriptionViewModel();
    }
}
