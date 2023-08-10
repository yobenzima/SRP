using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Domain
{
    /// <summary>
    /// Paged list interface
    /// </summary>
    public interface IPagedList<T> : IList<T>
    {
        /// <summary>
        /// Index of the page
        /// </summary>
        int PageIndex { get; }
        /// <summary>
        /// Size of the page
        /// </summary>
        int PageSize { get; }
        /// <summary>
        /// 
        /// </summary>
        int TotalCount { get; }
        /// <summary>
        /// Total pages
        /// </summary>
        int TotalPages { get; }
        /// <summary>
        /// Has previous page
        /// </summary>
        bool HasPreviousPage { get; }
        /// <summary>
        /// Has next page
        /// </summary>
        bool HasNextPage { get; }
    }
}
