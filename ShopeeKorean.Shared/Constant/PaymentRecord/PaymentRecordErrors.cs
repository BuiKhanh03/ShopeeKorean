using ShopeeKorean.Shared.ErrorModel;

namespace ShopeeKorean.Shared.Constant.PaymentRecord
{
    public class PaymentRecordErrors
    {
        #region ErrorMessages
        public const string VnPayNotSuccess = "";
        public const string PaymentRecordNotFound = "Payment not found with order id {0}";
        #endregion

        #region Static Method
        public static ErrorsResult GetVnPayNotSuccess(string error) =>
            new() { Code = VnPayNotSuccess, Description= string.Format(VnPayNotSuccess, error) };
        public static ErrorsResult GetPaymentRecordByOrderNotFound(Guid orderId)
            => new () { Code = PaymentRecordNotFound, Description = string.Format(PaymentRecordNotFound, orderId) };
        #endregion
    }
}
