using SimplePaymentFlowAPI.Models;

namespace SimplePaymentFlowAPI.Managers
{
    public interface ISiteInformationManager
    {
        Task<SiteDetailsResponse> GetDetailsForSite(SiteDetailsRequest request);

        Task<bool> UnlockPumpForId(string pumpId);

        Task<ReceiptResponse> GenerateReceiptForPumpId(string pumpId);
    }
}
