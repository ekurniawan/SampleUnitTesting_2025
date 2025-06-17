using EmployeeManagement.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Test
{
    public class EmployeeTests
    {
        [Fact]
        public void EmployeeFullNamePropertyGetter_InputFirstNameAndLastName_FullNameIsConcatenation()
        {
            //arrange
            var employee = new InternalEmployee("John", "Doe", 0, 2500, false, 1);

            //act
            employee.FirstName = "Jane";
            employee.LastName = "SMITH";

            //assert
            Assert.Equal("Jane Smith", employee.FullName, ignoreCase: true);

        }

        [Fact]
        public void EmployeeFullNamePropertyGetter_InputFirstNameAndLastName_FullNameStartWithFirstName()
        {
            //arrange
            var employee = new InternalEmployee("John", "Doe", 0, 2500, false, 1);

            //act
            employee.FirstName = "Jane";
            employee.LastName = "Smith";

            //assert
            Assert.StartsWith(employee.FirstName, employee.FullName);
        }

        [Fact]
        public void EmployeeFullNamePropertyGetter_InputFirstNameAndLastName_FullNameEndsWithLastName()
        {
            //arrange
            var employee = new InternalEmployee("John", "Doe", 0, 2500, false, 1);
            //act
            employee.FirstName = "Jane";
            employee.LastName = "Smith";
            //assert
            Assert.EndsWith(employee.LastName, employee.FullName);
        }

        [Fact]
        public void EmployeeFullNamePropertyGetter_InputFirstNameAndLastName_FullNameContainsPartOfConcatenation()
        {
            //arrange
            var employee = new InternalEmployee("John", "Doe", 0, 2500, false, 1);

            //act
            employee.FirstName = "Jane";
            employee.LastName = "Smith";


            //assert
            Assert.Contains("Jane", employee.FullName, StringComparison.OrdinalIgnoreCase);
        }
    }
}
