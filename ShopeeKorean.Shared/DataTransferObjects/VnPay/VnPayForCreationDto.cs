namespace ShopeeKorean.Shared.DataTransferObjects.VnPay
{
    public class VnPayForCreationDto
    {
        public string OrderType { get; set; }
        public double Amount { get; set; }
        public string OrderDescription { get; set; }
        public Guid PaymentIdR { get; set; }
    }
}
