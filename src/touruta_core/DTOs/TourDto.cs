using System;

namespace Touruta.Core.DTOs
{
    public class TourDto
    {
        public int IdTour { get; set; }
        public int IdUser { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Audio { get; set; }
    }
}
