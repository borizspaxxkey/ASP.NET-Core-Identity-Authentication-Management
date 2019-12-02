using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth22.Data
{
    public class ApplicationUser : IdentityUser
    {
        public virtual string FullName { get; set; }
        public virtual int Age { get; set; }
    }
}
