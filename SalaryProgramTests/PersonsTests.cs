using IEzbolatov.SalaryProgram.Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace IEzbolatov.SalaryProgram.SalaryProgramTests
{
    public class PersonsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ManagerTotalPay()
        {
            //10000+11000+8750=29750
            Manager manager = new Manager("test", new List<TimeRecord>() {
                new TimeRecord(DateTime.Now.AddDays(-3),"test",8,"test"),
                new TimeRecord(DateTime.Now.AddDays(-2),"test",9,"test"),
                new TimeRecord(DateTime.Now.AddDays(-1),"test",7,"test"),
            });

            Assert.IsTrue(manager.TotalPay == 29750);
        }

        [Test]
        public void ManagerTotalPay2()
        {
            //10000
            Manager manager = new Manager("test", new List<TimeRecord>() {
                new TimeRecord(DateTime.Now.AddDays(-3),"test",8,"test"),
            });

            Assert.IsTrue(manager.TotalPay == 10000);
        }
    }
}