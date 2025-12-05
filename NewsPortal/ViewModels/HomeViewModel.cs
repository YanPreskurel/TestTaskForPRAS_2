using System.Collections.Generic;
using NewsPortal.Models;

namespace NewsPortal.ViewModels
{
    public class HomeViewModel
    {
        public WhoWeArePage WhoWeAre { get; set; } = null!;
        public CallToActionBlockTranslation CTA { get; set; } = null!;
        public List<CaseViewModel> Cases { get; set; } = new();
        public string CurrentLanguage { get; set; } = "ru";
    }
}
