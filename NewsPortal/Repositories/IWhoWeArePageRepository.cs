using NewsPortal.Models;

public interface IWhoWeArePageRepository
{
    Task<WhoWeArePageTranslation?> GetPageWithTranslationAsync(string lang);
}