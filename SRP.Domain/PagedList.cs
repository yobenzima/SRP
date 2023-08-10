using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Domain
{
    public partial class PagedList<T> : List<T>, IPagedList<T> where T : class
    {

        private void Initialize(IEnumerable<T> source, int pageIndex, int pageSize, int? totalCount = null)
        {
            if(source == null)
                throw new ArgumentNullException(nameof(source));
            if(pageIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(pageIndex), pageIndex, "PageIndex cannot be below 0.");
            if(pageSize <= 0)
                pageSize = 1;

            TotalCount = totalCount ?? source.Count();
            if(pageSize > 0)
            {
                TotalPages = (int)Math.Ceiling(TotalCount / (double)pageSize);
                if(TotalCount % pageSize > 0)
                    TotalPages++;
            }

            PageIndex = pageIndex;
            PageSize = pageSize;
            AddRange(source);
        }
        private Task InitializeAsync(IEnumerable<T> source, int pageIndex, int pageSize, int? totalCount = null)
        {
            if(source == null)
                throw new ArgumentNullException(nameof(source));
            if(pageIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(pageIndex), pageIndex, "PageIndex cannot be below 0.");
            if(pageSize <= 0)
                pageSize = 1;

            TotalCount = totalCount ?? source.Count();
            if(pageSize > 0)
            {
                TotalPages = (int)Math.Ceiling(TotalCount / (double)pageSize);
                if(TotalCount % pageSize > 0)
                    TotalPages++;
            }

            PageIndex = pageIndex;
            PageSize = pageSize;
            AddRange(source);
            return Task.CompletedTask;
        }

        public PagedList()
        {
        }

        public PagedList(IEnumerable<T> source, int pageIndex, int pageSize)
        {
            Initialize(source, pageIndex, pageSize);
        }

        public PagedList(IEnumerable<T> source, int pageIndex, int pageSize, int totalCount)
        {
            Initialize(source, pageIndex, pageSize, totalCount);
        }

        public PagedList(IEnumerable<T> source, int pageIndex, int pageSize, int? totalCount)
        {
            Initialize(source, pageIndex, pageSize, totalCount);
        }

        public static Task<PagedList<T>> CreateAsync(IEnumerable<T> source, int pageIndex, int pageSize)
        {
            var tPagedList = new PagedList<T>();
            return tPagedList.InitializeAsync(source, pageIndex, pageSize).ContinueWith(t => tPagedList);
        }

        public static async Task<PagedList<T>> Create(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var tPagedList = new PagedList<T>();
            await tPagedList.InitializeAsync(source, pageIndex, pageSize);
            return tPagedList;
        }

        public int PageIndex { get; protected set; }
        public int PageSize { get; protected set; }
        public int TotalCount { get; protected set; }
        public int TotalPages { get; protected set; }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 0);
            }
        }
        public bool HasNextPage
        {
            get
            {
                return (PageIndex + 1 < TotalPages);
            }
        }

    }
}
