using System;
using System.Collections.Generic;

namespace Touruta.Core.Data
{
    public partial class Comment
    {
        public int IdComment { get; set; }
        public int IdTour { get; set; }
        public int IdUser { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool Active { get; set; }

        public virtual Tour IdTourNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
