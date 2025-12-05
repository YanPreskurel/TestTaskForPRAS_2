using NewsPortal.Models;

public interface ICallToActionRepository
{
    Task<CallToActionBlockTranslation?> GetFirstWithTranslationAsync(string lang);
}