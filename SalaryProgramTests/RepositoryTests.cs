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
            bool isCreated = memoryRepository.UserCreate(UserRole.Employee, "������");
            var newUser = memoryRepository.Users().FirstOrDefault(x => x.Name == "������");
            Assert.IsTrue(isCreated);
            Assert.IsTrue(newUser != null);
            Assert.IsTrue(newUser.UserRole == UserRole.Employee);
        }

        [Test]
        public void UserCreatedEmployeeExisted()
        {
            bool isCreated = memoryRepository.UserCreate(UserRole.Employee, "������");
            var existedUser = memoryRepository.Users().FirstOrDefault(x => x.Name == "������");
            Assert.IsTrue(!isCreated);
            Assert.IsTrue(existedUser != null);
            Assert.IsTrue(existedUser.UserRole == UserRole.Employee);
        }

        [Test]
        public void UserGetTest()
        {
            var existedUser = memoryRepository.UserGet("������");
            var notExisteduser = memoryRepository.UserGet("�����");
            Assert.IsTrue(existedUser != null);
            Assert.IsTrue(notExisteduser == null);
        }

        [Test]
        public void ReportGetByUserEmployeeTest()
        {
            var reportList = memoryRepository.ReportGetByUser("��������", UserRole.Employee, null, null);
            var sampleList = new List<TimeRecord>()
            {
                new TimeRecord(DateTime.Now.Date.AddDays(-3), "��������",8,"test message 2"),
                new TimeRecord(DateTime.Now.Date.AddDays(-2), "��������",8,"test message 4")
            };
            //var firstNotSecond = reportList.Except(sampleList).ToList();
            //var secondNotFirst = sampleList.Except(reportList).ToList();
            

            Assert.IsTrue(Enumerable.SequenceEqual(reportList, sampleList, new TimeRecordCompare()));
        }

        [Test]
        public void ReportGetByUserManagerTest()
        {
            var reportList = memoryRepository.ReportGetByUser("���������", UserRole.Manager, null, null);
            var sampleList = new List<TimeRecord>()
            {
                new TimeRecord(DateTime.Now.Date.AddDays(-3), "���������",8,"test message 1"),
                new TimeRecord(DateTime.Now.Date.AddDays(-2), "���������",10,"test message 2")
            };
            //var firstNotSecond = reportList.Except(sampleList).ToList();
            //var secondNotFirst = sampleList.Except(reportList).ToList();


            Assert.IsTrue(Enumerable.SequenceEqual(reportList, sampleList, new TimeRecordCompare()));
        }
    }
}