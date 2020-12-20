using IEzbolatov.SalaryProgram.Domain;
using IEzbolatov.SalaryProgram.Domain.Persons;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace IEzbolatov.SalaryProgram.Repository
{
    public class MemoryRepository : IRepository
    {
        #region Fake Data
        private List<TimeRecord> employees = new List<TimeRecord>()
        {
            new TimeRecord(DateTime.Now.Date.AddDays(-3), "Иванов",8,"test message 1"),
            new TimeRecord(DateTime.Now.Date.AddDays(-3), "Васильев",8,"test message 2"),
            new TimeRecord(DateTime.Now.Date.AddDays(-2), "Иванов",10,"test message 3"),
            new TimeRecord(DateTime.Now.Date.AddDays(-2), "Васильев",8,"test message 4")
        };

        private List<TimeRecord> freelancers = new List<TimeRecord>()
        {
            new TimeRecord(DateTime.Now.Date.AddDays(-3), "Смит",8,"test message 1"),
            new TimeRecord(DateTime.Now.Date.AddDays(-3), "Бонд",8,"test message 2"),
            new TimeRecord(DateTime.Now.Date.AddDays(-2), "Смит",10,"test message 3"),
            new TimeRecord(DateTime.Now.Date.AddDays(-2), "Бонд",8,"test message 4")
        };

        private List<TimeRecord> managers = new List<TimeRecord>()
        {
            new TimeRecord(DateTime.Now.Date.AddDays(-3), "Эзболатов",8,"test message 1"),
            new TimeRecord(DateTime.Now.Date.AddDays(-2), "Эзболатов",10,"test message 2")
        };

        private List<User> users = new List<User>()
            {
                new User("Иванов", UserRole.Employee),
                new User("Васильев", UserRole.Employee),
                new User("Смит", UserRole.Freelancer),
                new User("Бонд", UserRole.Freelancer),
                new User("Эзболатов", UserRole.Manager),
            }; 
        #endregion

        public List<TimeRecord> Employees()
        {
            return employees;
        }

        public List<TimeRecord> Freelancers()
        {
            return freelancers;
        }

        public List<TimeRecord> Managers()
        {
            return managers;
        }

        public List<TimeRecord> ReportGet(UserRole userRole, DateTime? from = null, DateTime? to = null)
        {
            var records = new List<TimeRecord>();
            switch (userRole)
            {
                case UserRole.Manager:
                    records = Managers();
                    break;
                case UserRole.Employee:
                    records = Employees();
                    break;
                case UserRole.Freelancer:
                    records = Freelancers();
                    break;
                default:
                    throw new NotImplementedException("Добавлена новая роль");
            }
            if (from == null)
            {
                from = DateTime.Now.AddYears(-100);
            }
            if (to == null)
            {
                to = DateTime.Now;
            }
            return records.Where(x => from.Value <= x.Date && x.Date <= to).ToList();
        }

        public List<TimeRecord> ReportGetByUser(string userName, UserRole userRole, DateTime? from = null, DateTime? to = null)
        {
            return ReportGet(userRole, from, to).Where(x=>x.Name == userName).ToList();
        }

        public void TimeRecordAdd(UserRole userRole, TimeRecord timeRecord)
        {
            switch (userRole)
            {
                case UserRole.Manager:
                    managers.Add(timeRecord);
                    break;
                case UserRole.Employee:
                    employees.Add(timeRecord);
                    break;
                case UserRole.Freelancer:
                    freelancers.Add(timeRecord);
                    break;
                default:
                    throw new NotImplementedException("Добавлена новая роль");
            }
        }

        public bool UserCreate(UserRole userRole, string name)
        {
            var newUser = new User(name, userRole);
            User existedUser = UserGet(name);
            if (existedUser == null)
            {
                users.Add(newUser);
                return true;
            }
            else
            {
                return false;
            }
        }

        public User UserGet(string name)
        {
            return Users().FirstOrDefault(x => x.Name == name);
        }

        public List<User> Users()
        {
            return users;
        }
    }
}
