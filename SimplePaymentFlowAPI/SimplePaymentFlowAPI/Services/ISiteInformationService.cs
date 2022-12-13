using SimplePaymentFlowAPI.Models.Domain;

namespace SimplePaymentFlowAPI.Services
{
    public interface ISiteInformationService
    {
        Task<SiteDetails> GetSiteDetailsForSearchValue(string searchValue);

        Task<bool> UnlockPumpForId(string pumpId);

        Task<Receipt> GenerateReceiptForPumpId(string pumpId);
    }
}
