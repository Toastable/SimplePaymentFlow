using SimplePaymentFlowAPI.Models;
using SimplePaymentFlowAPI.Models.Domain;
using SimplePaymentFlowAPI.Services;

namespace SimplePaymentFlowAPI.Managers
{
    /* The SiteInformationManager acts as an isolation layer to ecapsulate any business or mapping logic in order to keep the Controllers lean so that they do not need to be tested (as much)
     * This manager however would be tested as it contains actual logic beyond simply returning values from other classes.     * 
     */
    public class SiteInformationManager : ISiteInformationManager
    {
        ISiteInformationService _siteInfoService;

        public SiteInformationManager(ISiteInformationService siteInfoService)
        {
            _siteInfoService = siteInfoService;
        }

        public async Task<ReceiptResponse> GenerateReceiptForPumpId(string pumpId)
        {
            Receipt result = await _siteInfoService.GenerateReceiptForPumpId(pumpId);

            return ToReceiptResponse(result);
        }

        public async Task<SiteDetailsResponse> GetDetailsForSite(SiteDetailsRequest request)
        {
            SiteDetails result = await _siteInfoService.GetSiteDetailsForSearchValue(request.SearchValue);
            return ToSiteDetailsResponse(result);
        }

        public async Task<bool> UnlockPumpForId(string pumpId)
        {
            return await _siteInfoService.UnlockPumpForId(pumpId);
        }

        /* Even though the SiteDetailsResponse and the SiteDetails Domain objects have the same fields it is never a good idea to tightly couple output models to internal ones.
         * The most important reason to not do this is in case somebody changes the Domain object (which is probably tied to a Database field) 
         * and accidentally reveals information that should not be made public outside of the system.
         */
        private SiteDetailsResponse ToSiteDetailsResponse(SiteDetails siteDetails)
        {
            return new SiteDetailsResponse()
            {
                Name = siteDetails.Name,
                Address = siteDetails.Address,
                OpeningTimes = siteDetails.OpeningTimes,
                NextAvailablePumpId = siteDetails.NextAvailablePumpId
            };
        }

        private ReceiptResponse ToReceiptResponse(Receipt receipt)
        {
            return new ReceiptResponse()
            {
                Amount = receipt.Amount,
                Date = receipt.Date
            };
        }
    }
}
