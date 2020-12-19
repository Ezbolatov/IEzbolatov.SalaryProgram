using IEzbolatov.SalaryProgram.Domain.Persons;
using System;
using System.Collections.Generic;
using System.Text;

namespace IEzbolatov.SalaryProgram.Domain
{
    public class Employee : Staff
    {
        public decimal TotalPayEmployee { get; }

        public Employee(string name, List<TimeRecord> timeRecords) : base(name, 120000, timeRecords)
        {
            decimal payPerHour = MonthSalary / Settings.WorkHoursInMonth;
            decimal totalPayEmployee = 0;
            decimal doublePay = (MonthSalary / Settings.WorkHoursInMonth) * 2;

            foreach (var timeRecord in timeRecords)
            {
                if (timeRecord.Hours <= Settings.WorkHourInDay)
                {
                    totalPayEmployee += timeRecord.Hours * payPerHour;
                }
                else // Двойная оплата
                {
                    totalPayEmployee += (timeRecord.Hours * payPerHour) + doublePay;
                }
            }

            TotalPayEmployee = totalPayEmployee;
        }
    }
}
