namespace ShopeeKorean.Shared.DataTransferObjects.VnPay
{
    public class VnPayDto
    {
        public bool IsSuccess { get; set; }
        public string OrderId { get; set; }
        public Guid PaymentIdR {  get; set; }
        public string PaymentMethod { get; set; } = "VnPay";
        public string OrderType { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string OrderDescription { get; set; } = string.Empty;
        public string PaymentId { get; set; } = string.Empty;
        public string TransactionId { get; set; } = string.Empty;
        public string PaidAt {  get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public string VnPayResponseCode { get; set; } = string.Empty;
    }
}

