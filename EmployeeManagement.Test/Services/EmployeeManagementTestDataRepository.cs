using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Test.Services
{
    public class EmployeeManagementTestDataRepository : IEmployeeManagementRepository
    {
        public void AddInternalEmployee(InternalEmployee internalEmployee)
        {
            throw new NotImplementedException();
        }

        public Course? GetCourse(Guid courseId)
        {
            throw new NotImplementedException();
        }

        public Task<Course?> GetCourseAsync(Guid courseId)
        {
            throw new NotImplementedException();
        }

        public List<Course> GetCourses(params Guid[] courseIds)
        {
            throw new NotImplementedException();
        }

        public Task<List<Course>> GetCoursesAsync(params Guid[] courseIds)
        {
            throw new NotImplementedException();
        }

        public InternalEmployee? GetInternalEmployee(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<InternalEmployee?> GetInternalEmployeeAsync(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<InternalEmployee>> GetInternalEmployeesAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
