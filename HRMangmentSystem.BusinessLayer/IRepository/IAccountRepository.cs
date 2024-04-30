using HRMangmentSystem.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMangmentSystem.BusinessLayer.IRepository
{
    public interface IAccountRepository
    {
        public Task CreateAdminAsync(ApplicationUser user, bool isSuperAdmin);
    }
}
