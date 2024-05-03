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
    public class AnnualHolidaysRepository:GenericRepositoryAsync<AnnualHolidays>,IAnnualHolidaysRepository
    {
        private readonly DbSet<AnnualHolidays> _settings;
        public AnnualHolidaysRepository(HRMangmentCotext dbContext) : base(dbContext)
        {
            _settings = dbContext.Set<AnnualHolidays>();
        }
    }
}
