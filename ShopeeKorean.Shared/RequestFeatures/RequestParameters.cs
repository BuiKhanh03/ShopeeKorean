namespace ShopeeKorean.Shared.RequestFeatures
{
    public abstract class RequestParameters
    {
        private int _pageNumber = 1;
        private int _pageSize = 10; 
        public int PageNumber
        {
            get { return _pageNumber; }
            set
            {
                if (value > 0) _pageNumber = value; 
            }
        }

        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                _pageSize = value;
            }
        }

        public string? OrderBy { get; set; }

        public string? Field { get; set; }

    }
}
