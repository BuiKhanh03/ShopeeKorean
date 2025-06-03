using ShopeeKorean.Shared.ResultModel;

namespace ShopeeKorean.Shared.Extension
{
    public static class ResultExtension
    {
        public static TResultType GetValue<TResultType>(this Result result) => (result as Result<TResultType>)!.Value!;
    }
}
