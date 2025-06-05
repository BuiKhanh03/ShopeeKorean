using System.Dynamic;

namespace ShopeeKorean.Service.Contracts
{
    public interface IDataShaper<T>
    {
        //A comma-separated string indicating which fields to include (e.g., "Id,Name").
        IEnumerable<ExpandoObject> ShapeData(IEnumerable<T> entities, string? fieldsString);
        ExpandoObject ShapeData(T entity, string? fieldsString);
    }
}
