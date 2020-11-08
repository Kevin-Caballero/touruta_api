using System;

namespace Touruta.Core.QueryFilters
{
    public class TourQueryFilter
    {
        public int? UserId { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
    }
}