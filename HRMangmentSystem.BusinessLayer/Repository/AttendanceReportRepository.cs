using HRManagementSystem.DataAccessLayer.Models;
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
    public class AttendanceReportRepository : GenericRepositoryAsync<AttendanceRecord>, IAttendanceReportRepository
    {
        private readonly DbSet<AttendanceRecord> _attendance;
        public AttendanceReportRepository(HRMangmentCotext dbContext) : base(dbContext)
        {
            _attendance = dbContext.Set<AttendanceRecord>();
        }
        public override List<AttendanceRecord> GetTableAsTracking()
        {
            return _attendance.Include(emp => emp.Employee).
                ThenInclude(dept => dept.Department).ToList();
        }

    }
}
