﻿using System;
using System.Collections.Generic;


namespace Touruta.Core.Entities
{
    public partial class User :  BaseEntity
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            Tours = new HashSet<Tour>();
        }
        
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public int IdRol { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public bool Active { get; set; }

        public virtual Role IdRolNavigation { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Tour> Tours { get; set; }
    }
}
