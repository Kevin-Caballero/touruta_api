using System;
using Touruta.Core.QueryFilters;

namespace Touruta.Infrastructure.Interfaces
{
    public interface IUriService
    {
        Uri GetTourPaginationUri(TourQueryFilter filter, string actionUrl);
    }
}