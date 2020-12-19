using System;
using System.Collections.Generic;
using System.Text;

namespace IEzbolatov.SalaryProgram.Domain
{
    public class Freelancer: Person
    {
        public decimal TotalPayFreelancer { get; }

       
        public Freelancer(string name, List<TimeRecord> timeRecords) : base(name, timeRecords)
        {
            decimal payPerHour = 1000;
            decimal totalPayFreelancer = 0;

            foreach (var timeRecord in TimeRecords)
            {
                totalPayFreelancer += timeRecord.Hours * payPerHour;
            }

            TotalPayFreelancer = totalPayFreelancer;

        }
    }
}
