using System.Text;
using System.Reflection;

namespace ShopeeKorean.Repository.Extensions.Utility
{
    public static class QueryBuilder
    {
        //orderByQueryString: Chuỗi đầu vào (ví dụ: "Name asc, Age desc")
        public static string CreateOrderQuery<T>(string orderByQueryString, PropertyInfo[] propertyInfos)
        {
            //Chuỗi "Name asc, Age desc" → Mảng ["Name asc", "Age desc"]
            // var orderParams = orderByQueryString.Trim().Split(',');
            // var orderQueryBuilder = new StringBuilder();
            var orderParams = orderByQueryString.Trim().Split(',');
            var orderQueryBuilder = new StringBuilder();
           /* foreach (var param in orderParams) 
            { 
                if(string.IsNullOrEmpty(param)) continue;
                //"Name asc" → ["Name", "asc"]
                var propertyFromQueryName = param.Split(" ")[0];
                //
                var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.OrdinalIgnoreCase));
                if (objectProperty is null) continue;
                var direction = param.EndsWith(" desc") ? "descending" : "ascending";
                orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction},");
            }
            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
            return orderQuery;*/
           

            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;

                var propertyFromQueryName = param.Split(' ')[0];
                var objectProperty = propertyInfos.FirstOrDefault(pi =>
                    pi.Name.Equals(propertyFromQueryName, StringComparison.CurrentCultureIgnoreCase));

                if (objectProperty is null) continue;

                var direction = param.EndsWith(" desc") ? "descending" : "ascending";

                orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction},");
            }
            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

            return orderQuery;
        }
    }
}