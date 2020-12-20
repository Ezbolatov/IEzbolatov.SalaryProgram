using IEzbolatov.SalaryProgram.Domain;
using NUnit.Framework;
using IEzbolatov.SalaryProgram.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using IEzbolatov.SalaryProgram.Domain.Persons;

namespace IEzbolatov.SalaryProgram.SalaryProgramTests
{
    public class RepositoryTests
    {
        IRepository memoryRepository = new MemoryRepository();
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void UserCreatedEmployee()
        {
            bool isCreated = memoryRepository.UserCreate(UserRole.Employee, "Тестов");
            var newUser = memoryRepository.Users().FirstOrDefault(x => x.Name == "Тестов");
            Assert.IsTrue(isCreated);
            Assert.IsTrue(newUser != null);
            Assert.IsTrue(newUser.UserRole == UserRole.Employee);
        }

        [Test]
        public void UserCreatedEmployeeExisted()
        {
            bool isCreated = memoryRepository.UserCreate(UserRole.Employee, "Иванов");
            var existedUser = memoryRepository.Users().FirstOrDefault(x => x.Name == "Иванов");
            Assert.IsTrue(!isCreated);
            Assert.IsTrue(existedUser != null);
            Assert.IsTrue(existedUser.UserRole == UserRole.Employee);
        }

        [Test]
        public void UserGetTest()
        {
            var existedUser = memoryRepository.UserGet("Иванов");
            var notExisteduser = memoryRepository.UserGet("Буков");
            Assert.IsTrue(existedUser != null);
            Assert.IsTrue(notExisteduser == null);
        }

        [Test]
        public void ReportGetByUserEmployeeTest()
        {
            var reportList = memoryRepository.ReportGetByUser("Васильев", UserRole.Employee, null, null);
            var sampleList = new List<TimeRecord>()
            {
                new TimeRecord(DateTime.Now.Date.AddDays(-3), "Васильев",8,"test message 2"),
                new TimeRecord(DateTime.Now.Date.AddDays(-2), "Васильев",8,"test message 4")
            };
            //var firstNotSecond = reportList.Except(sampleList).ToList();
            //var secondNotFirst = sampleList.Except(reportList).ToList();
            

            Assert.IsTrue(Enumerable.SequenceEqual(reportList, sampleList, new TimeRecordCompare()));
        }

        [Test]
        public void ReportGetByUserManagerTest()
        {
            var reportList = memoryRepository.ReportGetByUser("Эзболатов", UserRole.Manager, null, null);
            var sampleList = new List<TimeRecord>()
            {
                new TimeRecord(DateTime.Now.Date.AddDays(-3), "Эзболатов",8,"test message 1"),
                new TimeRecord(DateTime.Now.Date.AddDays(-2), "Эзболатов",10,"test message 2")
            };
            //var firstNotSecond = reportList.Except(sampleList).ToList();
            //var secondNotFirst = sampleList.Except(reportList).ToList();


            Assert.IsTrue(Enumerable.SequenceEqual(reportList, sampleList, new TimeRecordCompare()));
        }
    }
}