using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.Test.Fixtures;
using EmployeeManagement.Test.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Test
{

    public class DataDrivenEmployeeServiceTests
    {
        private readonly EmployeeServiceFixture _employeeServiceFixture;

        public DataDrivenEmployeeServiceTests()
        {
            _employeeServiceFixture = new EmployeeServiceFixture();
        }

        [Theory]
        [InlineData("37e03ca7-c730-4351-834c-b66f280cdb01")]
        [InlineData("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e")]
        public void CreateInternalEmployee_InternalEmployeeCreated_MustHaveAttendedSecondObligatoryCourse(Guid courseId)
        {
            var internalEmployee = _employeeServiceFixture.EmployeeService
                .CreateInternalEmployee("Scott", "Guthrie");

            //assert
            Assert.Contains(internalEmployee.AttendedCourses,
                c => c.Id == courseId);
        }


        [Theory]
        //[ClassData(typeof(StronglyTypedEmployeeServiceTestData))]
        [ClassData(typeof(StronglyTypedEmployeeServiceTestData_FromFile))]
        public async Task GiveRaise_RaiseGiven_EmployeeMinimumRaiseGivenMatchValue(int raiseGiven,
            bool expectedValueForMinimumRaiseGiven)
        {
            var internalEmployee = new InternalEmployee("Scott", "Guthrie", 5, 3000, false, 1);

            await _employeeServiceFixture.EmployeeService.GiveRaiseAsync(internalEmployee, raiseGiven);

            //assert
            Assert.Equal(expectedValueForMinimumRaiseGiven,
                internalEmployee.MinimumRaiseGiven);
        }
    }
}
