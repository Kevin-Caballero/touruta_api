using System.Collections.Generic;

namespace Touruta.Core.Entities
{
    public partial class Role : BaseEntity
    {
        public Role()
        {
            Users = new HashSet<User>();
        }
        
        public string Rol { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
