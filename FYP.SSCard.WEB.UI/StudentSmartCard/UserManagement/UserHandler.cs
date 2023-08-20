using StudentSmartCard;
using StudentSmartCard.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSmartCard.UserManagement
{
    public class UsersHandler
    {
        public List<User> GetUsers()
        {
            SmartCardDB context = new SmartCardDB();
            using (context)
            {
                return (from u in context.Users
                        .Include("Role")
                        //.Include("Address.City.Province.Country")
                        select u).ToList();
            }
        }

        public User GetUser(string loginid, string password)
        {
            using (SmartCardDB context = new SmartCardDB())
           {
                return (from u in context.Users
                        .Include("Role")
                        //.Include("Address.City.Province.Country")
                        where u.LoginId.Equals(loginid) && u.Password.Equals(password)
                        select u).FirstOrDefault();
            }
        }


        public List<Role> GetRoles()
        {
            SmartCardDB context = new SmartCardDB();
            using (context)
            {
                return (from u in context.Roles
                        select u).ToList();
            }
        }

        public bool AddStudentAsWebsiteUser(User studentUser)
        {
            try
            {
                using (SmartCardDB context = new SmartCardDB())
                {
                    //studen-Role
                    studentUser.Role = context.Roles.FirstOrDefault(x => x.Id == 8);
                    context.Users.Add(studentUser);
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
            
        }
    }
}
