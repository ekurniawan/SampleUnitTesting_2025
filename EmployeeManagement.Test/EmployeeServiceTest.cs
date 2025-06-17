using EmployeeManagement.Business;
using EmployeeManagement.Test.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Test
{
    public class EmployeeServiceTest
    {
        [Fact]
        public void CreateInternalEmployee_InternalEmployeeCreated_MustHaveAttendedFirstObligatoryCourse_WithObject()
        {
            //arrange
            var employeManagementTestDataRepository = new EmployeeManagementTestDataRepository();
            var employeeService = new EmployeeService(employeManagementTestDataRepository,
                new EmployeeFactory());
            var obligatoryCourse = employeManagementTestDataRepository.
                GetCourse(Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"));

            //act
            var internalEmployee = employeeService
                .CreateInternalEmployee("Scott", "Guthrie");

            //assert
            Assert.Contains(obligatoryCourse, internalEmployee.AttendedCourses);
        }

        [Fact]
        public void CreateInternalEmployee_InternalEmployeeCreated_MustHaveAttendedFirstObligatoryCourse_WithPredicate()
        {
            var employeManagementTestDataRepository = new EmployeeManagementTestDataRepository();
            var employeeService = new EmployeeService(employeManagementTestDataRepository,
                new EmployeeFactory());

            var internalEmployee = employeeService
                .CreateInternalEmployee("Scott", "Guthrie");

            //assert
            Assert.Contains(internalEmployee.AttendedCourses,
                c => c.Id == Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"));
        }

        [Fact]
        public void CreateInternalEmployee_InternalEmployeeCreated_AttendedCourseMustMatchObligatoryCourses()
        {
            var employeManagementTestDataRepository = new EmployeeManagementTestDataRepository();
            var employeeService = new EmployeeService(employeManagementTestDataRepository,
                new EmployeeFactory());
            var obligatoryCourses = employeManagementTestDataRepository.
                GetCourses(
                    Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"),
                    Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"));

            var internalEmployee = employeeService.CreateInternalEmployee("Scott", "Guthrie");

            //assert
            Assert.Equal(obligatoryCourses, internalEmployee.AttendedCourses);
        }
    }
}
