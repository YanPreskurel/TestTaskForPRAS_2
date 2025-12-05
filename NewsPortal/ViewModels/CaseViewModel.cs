using System.Collections.Generic;

namespace NewsPortal.ViewModels
{
    public class CaseViewModel
    {
        public int Id { get; set; }

        // Перевод для текущего языка
        public string Title { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Organization { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        // Флаг страны
        public string FlagImagePath { get; set; } = string.Empty;
        public string StatusColor { get; set; } = string.Empty;
    }
}
