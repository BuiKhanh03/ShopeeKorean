using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeKorean.Entities.Models
{
    public class Roles : IdentityRole<Guid>
    {
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
