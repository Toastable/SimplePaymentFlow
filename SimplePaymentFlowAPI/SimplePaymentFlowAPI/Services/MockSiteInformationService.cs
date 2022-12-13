using SimplePaymentFlowAPI.Models.Domain;

namespace SimplePaymentFlowAPI.Services
{
    /* This would likely be split out into a separate project for deployment purposes however to keep things simple I have just left in a folder here.  */
    public class MockSiteInformationService : ISiteInformationService
    {
        public async Task<SiteDetails> GetSiteDetailsForSearchValue(string searchValue)
        {
            /* For the sake of simplicity this is just a mock implementation, in reality a query would be ran against some sort of data persistence mechanism or a request sent off to another system.
             * For the purposes of this testing mock however this implementation just returns a hardcoded instance of SiteDetails. 
             */

            return new SiteDetails()
            {
                Name = "TestSite",
                Address = "1 Test Street, TestTown, NE1 9AL",
                OpeningTimes = "Mon-Sun 7am-9pm",
                NextAvailablePumpId = "CB7029A9-7D3A-48EB-8984-66F5D796268F"
            };
        }

        public async Task<Receipt> GenerateReceiptForPumpId(string pumpId)
        {
            /* Same as above as far as implementation is concerned. I have assumed throughout that there is a separate mechanism for determining the cost of the purchase and that the client cannot be trusted in this architecture.
             * Therefore the Receipt data such as price, transcation id etc would be supplied by a call to an external or separate system or mechanism and that this API just collates and returns that information.
             */

            return new Receipt
            {
                Amount = "60.36",
                Date = DateTime.UtcNow.ToShortDateString()
            };
        }

        public async Task<bool> UnlockPumpForId(string pumpId)
        {
            /* Same as above as far as implementation is concerned, in reality this would refer to some mechanism elsewhere in this application or some other system or a database to determine
             * whether or not the pump should be unlocked. For testing purposes this implementation just assumes all is well and returns true.
             * 
             */

            return true;
        }
    }
}
