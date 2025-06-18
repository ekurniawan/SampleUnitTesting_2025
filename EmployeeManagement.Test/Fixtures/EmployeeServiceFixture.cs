using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.Services;
using EmployeeManagement.Test.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Test.Fixtures
{
    public class EmployeeServiceFixture : IDisposable
    {
        public IEmployeeManagementRepository EmployeManagementTestDataRepository { get; }
        public EmployeeService EmployeeService { get; }

        public EmployeeServiceFixture()
        {
            EmployeManagementTestDataRepository = new EmployeeManagementTestDataRepository();
            EmployeeService = new EmployeeService(EmployeManagementTestDataRepository,
                new EmployeeFactory());
        }


        public void Dispose()
        {

        }
    }
}
