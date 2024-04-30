using HRMangmentSystem.DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMangmentSystem.DataAccessLayer.Context
{
    public class HRMangmentCotext : IdentityDbContext<ApplicationUser>
    {
        public HRMangmentCotext()
        {

        }
        public HRMangmentCotext(DbContextOptions<HRMangmentCotext> options) : base(options)
        {
        }
    }

}
