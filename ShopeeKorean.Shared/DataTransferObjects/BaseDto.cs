
using System.Reflection;
using System.Text.Json.Serialization;

namespace ShopeeKorean.Shared.DataTransferObjects
{

    //static constructor, nó chỉ được gọi một lần khi BaseDto<T> được sử dụng lần đầu tiên
    public abstract record BaseDto<T>
    {
        public static PropertyInfo[] PropertiesInfo;

        static BaseDto()
        {
            //ypeof(T).GetProperties(...): lấy tất cả các property instance công khai trong kiểu T.
            //BindingFlags.Instance | BindingFlags.Public: chỉ lấy các property thuộc instance (không phải static) và có quyền truy cập public.
            //.GetCustomAttribute<JsonPropertyOrderAttribute>()?.Order: nếu property có đánh dấu [JsonPropertyOrder(Order = ...)] thì lấy giá trị Order.
            //Nếu không có thì mặc định sắp xếp về cuối (int.MaxValue).
            PropertiesInfo = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public).OrderBy(p => p.GetCustomAttribute<JsonPropertyOrderAttribute>()?.Order ?? int.MaxValue).ToArray();
        }
    }
}
