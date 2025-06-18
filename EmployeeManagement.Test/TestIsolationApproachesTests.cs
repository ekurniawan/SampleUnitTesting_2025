﻿using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.DbContexts;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.DataAccess.Services;
using EmployeeManagement.Test.HttpMessageHandlers;
using EmployeeManagement.Test.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Test
{
    public class TestIsolationApproachesTests
    {
        [Fact]
        public async Task AttendedCourseAsync_CourseAttended_SuggestedBonusMustCorrectlyBeRecalculate()
        {
            var connection = new SqliteConnection("Data Source=:memory:");
            connection.Open();

            var optionsBuilder = new DbContextOptionsBuilder<EmployeeDbContext>().UseSqlite(connection);
            var dbContext = new EmployeeDbContext(optionsBuilder.Options);
            dbContext.Database.Migrate();

            var employeeManagementDataRepository = new EmployeeManagementRepository(dbContext);
            var employeeService = new EmployeeService(employeeManagementDataRepository, new EmployeeFactory());

            var courseToAttend = await employeeManagementDataRepository.GetCourseAsync(Guid.Parse("844e14ce-c055-49e9-9610-855669c9859b"));
            var internalEmployee = await employeeManagementDataRepository.GetInternalEmployeeAsync(Guid.Parse("72f2f5fe-e50c-4966-8420-d50258aefdcb"));

            if (courseToAttend == null || internalEmployee == null)
            {
                throw new InvalidOperationException("Course or employee not found in the database.");
            }

            var expectedSuggestedBonus = internalEmployee.YearsInService * (internalEmployee.AttendedCourses.Count + 1) * 100;
            await employeeService.AttendCourseAsync(internalEmployee, courseToAttend);

            // Assert
            Assert.Equal(expectedSuggestedBonus, internalEmployee.SuggestedBonus);
        }

        [Fact]
        public async Task PromoteInternalEmployeeAsync_IsEligible_JobLevekMustBeIncreased()
        {
            var httpClient = new HttpClient(new TestablePromotionEligibilityHandler(true));
            var internalEmployee = new InternalEmployee("John", "Doe", 5, 3000, false, 1);

            var promotionService = new PromotionService(httpClient, new EmployeeManagementTestDataRepository());

            await promotionService.PromoteInternalEmployeeAsync(internalEmployee);

            Assert.Equal(2, internalEmployee.JobLevel);
        }
    }


}
