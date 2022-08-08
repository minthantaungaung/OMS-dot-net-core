using System.Collections.Generic;

namespace OMSAPI.ViewModels
{
    public class PagingModel<T>
    {
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public string prevLink { get; set; }
        public string nextLink { get; set; }
        public IEnumerable<T>Result { get; set; }
    }
}
