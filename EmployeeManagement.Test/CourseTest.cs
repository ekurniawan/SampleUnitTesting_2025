using EmployeeManagement.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Test
{
    public class CourseTest
    {
        [Fact]
        public void CourseConstructor_ConstructCourse_IsNewMustBeTrue()
        {
            //act
            var course = new Course("Automated Testing");

            //Assert
            Assert.True(course.IsNew);
        }
    }
}
