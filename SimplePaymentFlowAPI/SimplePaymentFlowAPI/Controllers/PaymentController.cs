using Microsoft.AspNetCore.Mvc;
using SimplePaymentFlowAPI.Managers;
using SimplePaymentFlowAPI.Models;

namespace SimplePaymentFlowAPI.Controllers
{
    /* Realistically these endpoinds would be better served by being in their own RESTful endpoints however to keep things simple I have implemented them here as non-restful endpoints on the Payments route.
     * This doesn't make the most semantic sense but then again this is a common failing of non-restful APIs. */
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        ISiteInformationManager _siteInformationManager;

        public PaymentController(ISiteInformationManager siteInformationManager)
        {
            _siteInformationManager = siteInformationManager;
        }

        [HttpPost("FindASite")]
        public async Task<IActionResult> FindASite([FromBody]SiteDetailsRequest request)
        {
            SiteDetailsResponse siteDetails = await _siteInformationManager.GetDetailsForSite(request);
            return new JsonResult(siteDetails);
        }

        [HttpPost("UnlockPump")]
        public async Task<IActionResult> UnlockPump([FromBody] string pumpId)
        {
            bool pumpUnlocked = await _siteInformationManager.UnlockPumpForId(pumpId);
            return new JsonResult(pumpUnlocked);
        }

        [HttpPost("Receipt")]
        public async Task<IActionResult> Receipt([FromBody] string pumpId)
        {
            ReceiptResponse receiptResponse = await _siteInformationManager.GenerateReceiptForPumpId(pumpId);
            return new JsonResult(receiptResponse);
        }
    }
}
