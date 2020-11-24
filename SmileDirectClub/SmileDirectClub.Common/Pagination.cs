
namespace SmileDirectClub.Common
{
    public class Pagination : IPagination
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int ItemsCount { get; set; }
        public double PageCount 
        {
            get { return ItemsCount < PageSize ? 1 : (int)(((double)ItemsCount / PageSize)); }
            set { }
        }
    }
}
