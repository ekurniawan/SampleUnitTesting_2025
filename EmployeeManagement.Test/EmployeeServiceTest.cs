using EmployeeManagement.Business;
using EmployeeManagement.Business.EventArguments;
using EmployeeManagement.Business.Exceptions;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.Test.Fixtures;
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
        private readonly EmployeeServiceFixture _employeeServiceFixture;

        public EmployeeServiceTest()
        {
            _employeeServiceFixture = new EmployeeServiceFixture();
        }

        [Fact]
        public void CreateInternalEmployee_InternalEmployeeCreated_MustHaveAttendedFirstObligatoryCourse_WithObject()
        {
            //arrange

            var obligatoryCourse = _employeeServiceFixture.EmployeManagementTestDataRepository.
                GetCourse(Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"));

            //act
            var internalEmployee = _employeeServiceFixture.EmployeeService
                .CreateInternalEmployee("Scott", "Guthrie");

            //assert
            Assert.Contains(obligatoryCourse, internalEmployee.AttendedCourses);
        }

        [Fact]
        public void CreateInternalEmployee_InternalEmployeeCreated_MustHaveAttendedFirstObligatoryCourse_WithPredicate()
        {


            var internalEmployee = _employeeServiceFixture.EmployeeService
                .CreateInternalEmployee("Scott", "Guthrie");

            //assert
            Assert.Contains(internalEmployee.AttendedCourses,
                c => c.Id == Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"));
        }

        [Fact]
        public void CreateInternalEmployee_InternalEmployeeCreated_AttendedCourseMustMatchObligatoryCourses()
        {

            var obligatoryCourses = _employeeServiceFixture.EmployeManagementTestDataRepository.
                GetCourses(
                    Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"),
                    Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"));

            var internalEmployee = _employeeServiceFixture.EmployeeService.CreateInternalEmployee("Scott", "Guthrie");

            //assert
            Assert.Equal(obligatoryCourses, internalEmployee.AttendedCourses);
        }

        [Fact]
        public async Task CreateInternalEmployee_InternalEmployeeCreated_AttendedCourseMustMatchObligatoryCourses_Async()
        {
            //arrange

            var obligatoryCourses = await _employeeServiceFixture.EmployeManagementTestDataRepository.
                GetCoursesAsync(
                    Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"),
                    Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"));

            var internalEmployee = await _employeeServiceFixture.EmployeeService.CreateInternalEmployeeAsync("Scott", "Guthrie");


            //assert
            Assert.Equal(obligatoryCourses, internalEmployee.AttendedCourses);
        }

        [Fact]
        public async Task GiveRaise_RaiseBelowMinimumGiven_EmployeeInvalidRaiseExceptionMustBeThrown()
        {
            //arrange
            var internalEmployee = new InternalEmployee("Scott", "Guthrie", 2, 3000, false, 2);

            await Assert.ThrowsAsync<EmployeeInvalidRaiseException>(
                async () => await _employeeServiceFixture.EmployeeService.GiveRaiseAsync(internalEmployee, 50));
        }

        [Fact]
        public void NotifyOfAbsence_EmployeeIsAbsent_OnEmployeeIsAbsentEventMustBeRaised()
        {
            //arrange

            var internalEmployee = new InternalEmployee("Scott", "Guthrie", 2, 3000, false, 2);

            Assert.Raises<EmployeeIsAbsentEventArgs>(
                handler => _employeeServiceFixture.EmployeeService.EmployeeIsAbsent += handler,
                handler => _employeeServiceFixture.EmployeeService.EmployeeIsAbsent -= handler,
                () => _employeeServiceFixture.EmployeeService.NotifyOfAbsence(internalEmployee));
        }
    }
}
