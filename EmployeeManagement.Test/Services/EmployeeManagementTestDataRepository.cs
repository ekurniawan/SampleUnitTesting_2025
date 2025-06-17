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
        private List<InternalEmployee> _internalEmployees;
        private List<Course> _courses;
        private List<ExternalEmployee> _externalEmployees;

        public EmployeeManagementTestDataRepository()
        {
            Thread.Sleep(3000); // Simulate delay for test data setup
            var obligatoryCourse1 = new Course("Integration Testing")
            {
                Id = Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"),
                IsNew = false
            };

            var obligatoryCourse2 = new Course("Unit Testing with TDD")
            {
                Id = Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"),
                IsNew = false
            };

            var obligatoryCourse3 = new Course("Advanced Unit Testing")
            {
                Id = Guid.Parse("2fd115cf-f44c-4982-86bc-a8fe2e4ff83e"),
                IsNew = false
            };

            var obligatoryCourse4 = new Course("Mocking Frameworks")
            {
                Id = Guid.Parse("3fd115cf-f44c-4982-86bc-a8fe2e4ff83e"),
                IsNew = false
            };

            var obligatoryCourse5 = new Course("Test-Driven Development")
            {
                Id = Guid.Parse("4fd115cf-f44c-4982-86bc-a8fe2e4ff83e"),
                IsNew = false
            };

            _courses = new List<Course>
            {
                obligatoryCourse1,
                obligatoryCourse2,
                obligatoryCourse3,
                obligatoryCourse4,
                obligatoryCourse5
            };

            _internalEmployees = new()
            {
                new InternalEmployee("Scott", "Guthrie", 2, 3000, false, 2)
                {
                    Id = Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"),
                    AttendedCourses = new List<Course> { obligatoryCourse1, obligatoryCourse2 }
                },
                new InternalEmployee("Jon", "Skeet", 5, 5000, false, 5)
                {
                    Id = Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"),
                    AttendedCourses = new List<Course> { obligatoryCourse1, obligatoryCourse2, obligatoryCourse3 }
                },
            };

            _externalEmployees = new()
            {
                new ExternalEmployee("Jane", "Doe","Software Testing")
                {
                    Id = Guid.Parse("2fd115cf-f44c-4982-86bc-a8fe2e4ff83e")
                },
            };
        }

        public void AddInternalEmployee(InternalEmployee internalEmployee)
        {
            throw new NotImplementedException();
        }

        public Course? GetCourse(Guid courseId)
        {
            return _courses.FirstOrDefault(c => c.Id == courseId);
        }

        public Task<Course?> GetCourseAsync(Guid courseId)
        {
            return Task.FromResult(GetCourse(courseId));
        }

        public List<Course> GetCourses(params Guid[] courseIds)
        {
            List<Course> coursesToReturn = new();
            foreach (var courseId in courseIds)
            {
                var course = GetCourse(courseId);
                if (course != null)
                {
                    coursesToReturn.Add(course);
                }
            }
            return coursesToReturn;
        }

        public Task<List<Course>> GetCoursesAsync(params Guid[] courseIds)
        {
            return Task.FromResult(GetCourses(courseIds));
        }

        public InternalEmployee? GetInternalEmployee(Guid employeeId)
        {
            return _internalEmployees
                .FirstOrDefault(e => e.Id == employeeId);
        }

        public Task<InternalEmployee?> GetInternalEmployeeAsync(Guid employeeId)
        {
            return Task.FromResult(GetInternalEmployee(employeeId));
        }

        public Task<IEnumerable<InternalEmployee>> GetInternalEmployeesAsync()
        {
            return Task.FromResult(_internalEmployees.AsEnumerable());
        }

        public Task SaveChangesAsync()
        {
            return Task.CompletedTask;
        }
    }
}
