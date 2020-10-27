using System.Collections.Generic;

namespace Touruta.Core.Entities
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int IdRol { get; set; }
        public string Rol { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
