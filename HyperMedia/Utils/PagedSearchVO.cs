using System;
using System.Collections.Generic;
using RESTApi.HyperMedia.Abstract;

namespace RESTApi.HyperMedia.Utils
{
    public class PagedSearchVO<T> where T : ISupportHyperMedia
    {
        public PagedSearchVO()
        {
        }

        public PagedSearchVO(int currentPage, int pageSize, string sortFields, string sortDirections)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
            SortFields = sortFields;
            SortDirections = sortDirections;
        }

        public PagedSearchVO(int currentPage, int pageSize, string sortFields, string sortDirections, Dictionary<string, object> filters)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
            SortFields = sortFields;
            SortDirections = sortDirections;
            Filters = filters;
        }

        public PagedSearchVO(int currentPage, string sortFields, string sortDirections)
            : this(currentPage, 10, sortFields, sortDirections) { }



        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalResult { get; set; }
        public string SortFields{ get; set; }
        public string SortDirections { get; set; }
        public Dictionary<string, Object> Filters { get; set; }
        public List<T> List { get; set; }

        public int GetCurrentPage()
        {
            return CurrentPage == 0 ? 2 : CurrentPage;
        }

        public int GetPageSize()
        {
            return PageSize == 0 ? 10 : PageSize;
        }
    }
}