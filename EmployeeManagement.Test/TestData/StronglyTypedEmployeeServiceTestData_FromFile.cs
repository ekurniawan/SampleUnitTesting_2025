using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Test.TestData
{
    public class StronglyTypedEmployeeServiceTestData_FromFile : TheoryData<int, bool>
    {
        public StronglyTypedEmployeeServiceTestData_FromFile()
        {
            var testDataLine = File.ReadAllLines("TestData/EmployeeServiceTestData.csv");
            foreach (var line in testDataLine)
            {
                var splitString = line.Split(',');
                if (int.TryParse(splitString[0], out int raiseGiven) &&
                   bool.TryParse(splitString[1], out bool expectedValueForMinimumRaiseGiven))
                {
                    Add(raiseGiven, expectedValueForMinimumRaiseGiven);
                }
                else
                {
                    throw new FormatException("Invalid data format in test data file.");
                }
            }
        }
    }
}
