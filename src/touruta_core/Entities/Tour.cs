using System;
using System.Collections.Generic;

namespace Touruta.Core.Entities
{
    public partial class Tour
    {
        public Tour()
        {
            Comments = new HashSet<Comment>();
        }

        public int IdTour { get; set; }
        public int IdUser { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Audio { get; set; }

        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
