using IEzbolatov.SalaryProgram.Domain.Persons;
using System;
using System.Collections.Generic;
using System.Text;

namespace IEzbolatov.SalaryProgram.Domain
{
    public class Employee: Staff
    {
        public Employee(string name, List<TimeRecord> timeRecords) : base(name, 120000, timeRecords)
        {

        }
    }
}
