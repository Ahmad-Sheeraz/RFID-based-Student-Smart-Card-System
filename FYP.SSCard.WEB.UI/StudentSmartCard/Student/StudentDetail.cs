using StudentSmartCard.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSmartCard.Student
{
    public class StudentDetail
    {
       
        public int Id { get; set; }
        public string StudentRollNo { get; set; }
        public string ImageUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public DateTime DateofBirth { get; set; }
        public string CNIC { get; set; }
        public string Guardian { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string CellNo { get; set; }
        public string MobileNo { get; set; }
    }
}
