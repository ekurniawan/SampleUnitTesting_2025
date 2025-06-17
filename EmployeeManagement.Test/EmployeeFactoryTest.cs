using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Test
{
    public class EmployeeFactoryTest
    {
        [Fact]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBe2500()
        {
            //arrange
            var employeeFactory = new EmployeeFactory();

            //act
            var employee = (InternalEmployee)employeeFactory.CreateEmployee("John", "Doe");

            //assert
            Assert.Equal(2500, employee.Salary);
        }

        [Fact]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBeBetween2500And3500()
        {
            //arrange
            var employeeFactory = new EmployeeFactory();

            //act
            var employee = (InternalEmployee)employeeFactory.CreateEmployee("John", "Doe");

            //assert
            //Assert.True(employee.Salary >= 2500 && employee.Salary <= 3500,
            //    "Salary should be between 2500 and 3500.");
            Assert.InRange(employee.Salary, 2500, 3500);

        }

        [Fact]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBe2500_PrecisionExample()
        {
            //arrange
            var employeeFactory = new EmployeeFactory();

            //act
            var employee = (InternalEmployee)employeeFactory.CreateEmployee("John", "Doe");
            employee.Salary = 2500.1234m; // setting a value with more precision

            //asert
            Assert.Equal(2500, employee.Salary, 0);
        }
    }
}
