using PagedList;

namespace OMSWEB.ViewModels
{
    public class PagedListModel<T>
    {
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public string prevLink { get; set; }
        public string nextLink { get; set; }
        //public IPagedList<T> Result { get; set; }
    }
}
