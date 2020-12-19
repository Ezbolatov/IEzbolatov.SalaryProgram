using System;
using System.Collections.Generic;
using System.Text;

namespace IEzbolatov.SalaryProgram.Domain.Persons
{
    public class User
    { 
        public string Name { get; }
        public UserRole UserRole { get; }
        public User(string name, UserRole userRole)
        {
            Name = name;
            UserRole = userRole;
        }
    }
}
