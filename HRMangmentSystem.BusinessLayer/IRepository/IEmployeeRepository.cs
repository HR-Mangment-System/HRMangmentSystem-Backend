using HRManagementSystem.DataAccessLayer.Models;

namespace HRMangmentSystem.BusinessLayer.IRepository
{
    public interface IEmployeeRepository : IGenericRepositoryAsync<Employee>
    {
        public Task<Employee> GetEmployeeByNationalId(string nationalId);
        public List<Employee> GetEmployeeByDepartmentId(int departmentId);

    }
}
