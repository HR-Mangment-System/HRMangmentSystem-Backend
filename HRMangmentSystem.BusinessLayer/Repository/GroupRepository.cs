using HRMangmentSystem.BusinessLayer.IRepository;
using HRMangmentSystem.DataAccessLayer.Context;
using HRMangmentSystem.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMangmentSystem.BusinessLayer.Repository
{
    public class GroupRepository : IGroupRepository
    {
        private readonly HRMangmentCotext _db;
        public GroupRepository(HRMangmentCotext db)
        {
            _db = db;

        }

        public Task CreateGroup(Group group)
        {
            _db.Groups.Add(group);
            return _db.SaveChangesAsync();
        }

        public async Task<List<Group>> GetAllGroups()
        {
            return await _db.Groups.ToListAsync();
        }

        public async Task<Group> GetGroupById(int id)
        {
            return await _db.Groups.Include(group => group.Permissions).FirstOrDefaultAsync(group => group.Id == id);
        }

    }
}
