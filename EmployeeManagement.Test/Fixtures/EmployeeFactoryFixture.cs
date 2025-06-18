using EmployeeManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Test.Fixtures
{
    public class EmployeeFactoryFixture : IDisposable
    {
        public EmployeeFactory EmployeeFactory { get; }

        public EmployeeFactoryFixture()
        {
            EmployeeFactory = new EmployeeFactory();
        }

        public void Dispose()
        {

        }
    }
}
