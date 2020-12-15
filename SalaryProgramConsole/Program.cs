using IEzbolatov.SalaryProgram.Domain;
using IEzbolatov.SalaryProgram.Repository;
using IEzbolatov.SalaryProgram.Domain.Persons;
using System;
using System.Collections.Generic;

namespace IEzbolatov.SalaryProgram.SalaryProgramConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager("test", new List<TimeRecord>() {
                new TimeRecord(DateTime.Now.AddDays(-3),"test",8,"test"),
                new TimeRecord(DateTime.Now.AddDays(-2),"test",9,"test"),
                new TimeRecord(DateTime.Now.AddDays(-1),"test",7,"test"),
            });

            Console.WriteLine(manager.TotalPay);//29750
            Console.ReadLine();
        }
    }
}
