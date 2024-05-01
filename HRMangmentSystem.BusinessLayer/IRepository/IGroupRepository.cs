using HRMangmentSystem.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMangmentSystem.BusinessLayer.IRepository
{
    public interface IGroupRepository
    {
        public Task<List<Group>> GetAllGroups();
        public Task<Group> GetGroupById(int id);
        public Task CreateGroup(Group group);
    }
}
