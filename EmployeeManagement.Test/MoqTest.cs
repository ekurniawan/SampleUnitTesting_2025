using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.Test.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Test
{
    public class MoqTest
    {
        [Fact]
        public void FetchInternalEmployee_EmployeeFetched_SuggestedBonusMustBeCalculated()
        {
            var employeeManagementTestDataRepository = new EmployeeManagementTestDataRepository();
            //var employeeFactory = new EmployeeFactory();
            var employeeFactoryMock = new Mock<EmployeeFactory>();

            var employeeService = new EmployeeService(employeeManagementTestDataRepository,
                employeeFactoryMock.Object);

            var employee = employeeService.FetchInternalEmployee(Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"));

            Assert.Equal(400, employee.SuggestedBonus);
        }

        [Fact]
        public void CreateInternalEmployee_InternalEmployeeCreated_SuggestedBonusMustBeCalculated()
        {
            var employeeManagementTestDataRepository = new EmployeeManagementTestDataRepository();
            var employeeFactoryMock = new Mock<EmployeeFactory>();
            employeeFactoryMock
                .Setup(x => x.CreateEmployee("John", It.IsAny<string>(), null, false))
                .Returns(new InternalEmployee("John", "Doe", 5, 2500, false, 1));
            employeeFactoryMock
                .Setup(x => x.CreateEmployee("Jane", It.IsAny<string>(), null, false))
                .Returns(new InternalEmployee("Jane", "Doe", 0, 3000, false, 1));

            employeeFactoryMock
                .Setup(x => x.CreateEmployee(It.IsAny<string>(), It.IsAny<string>(), null, true))
                .Returns(new InternalEmployee("Jane", "Doe", 0, 2500, false, 1));

            employeeFactoryMock
                .Setup(x => x.CreateEmployee(It.IsAny<string>(), It.IsAny<string>(), null, false))
                .Returns(new InternalEmployee("Scott", "Guthrie", 5, 2500, false, 1));

            employeeFactoryMock
                .Setup(x => x.CreateEmployee(It.IsAny<string>(), It.IsAny<string>(), null, true))
                .Returns(new InternalEmployee("Scott", "Ha", 5, 2500, false, 1));


            var employeeService = new EmployeeService(employeeManagementTestDataRepository, employeeFactoryMock.Object);

            decimal suggestedBonus = 1000;

            Assert.Equal(suggestedBonus, employeeService.CreateInternalEmployee("Scott", "Guthrie").SuggestedBonus);
        }
    }
}
