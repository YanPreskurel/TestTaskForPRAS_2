using NewsPortal.Models;

public interface ICallToActionRepository
{
    Task<CallToActionBlockTranslation?> GetFirstWithTranslationAsync(string lang);
    Task UpdateTranslationAsync(int id, string lang, CallToActionBlockTranslation model);
}