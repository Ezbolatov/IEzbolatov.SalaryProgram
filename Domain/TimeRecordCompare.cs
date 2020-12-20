using System;
using System.Collections.Generic;
using System.Text;

namespace IEzbolatov.SalaryProgram.Domain
{
    public class TimeRecordCompare : IEqualityComparer<TimeRecord>
    {
        public bool Equals(TimeRecord x, TimeRecord y)
        {
            if (x == null && y == null)
            {
                return true;
            }
            else if (x == null || y == null)
            {
                return false;
            }
            else if (x.Date == y.Date && x.Hours == y.Hours && x.Message == y.Message && x.Name == y.Name)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetHashCode(TimeRecord obj)
        {
            int hCode = obj.Date.Day ^ obj.Hours ^ obj.Message.Length ^ obj.Name.Length;
            return hCode.GetHashCode();
        }
    }
}
