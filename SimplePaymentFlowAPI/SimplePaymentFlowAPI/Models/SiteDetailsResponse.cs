namespace SimplePaymentFlowAPI.Models
{
    public class SiteDetailsResponse
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string OpeningTimes { get; set; }
        public string NextAvailablePumpId { get; set; }
    }
}
