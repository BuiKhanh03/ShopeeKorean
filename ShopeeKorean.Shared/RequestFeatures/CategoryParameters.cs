namespace ShopeeKorean.Shared.RequestFeatures
{
    public class CategoryParameters : RequestParameters
    {
        public CategoryParameters() => OrderBy = "Name";

        public string Name { get; set; } = string.Empty;

    }
}
