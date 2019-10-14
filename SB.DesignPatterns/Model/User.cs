using System;
using System.Collections.Generic;
using System.Text;

namespace SB.DesignPatterns.Model
{
    public class User
    {
        public int Id { get; set; }
        public string LoginName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
