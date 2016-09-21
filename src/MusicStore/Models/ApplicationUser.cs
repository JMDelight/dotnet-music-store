using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MusicStore.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
