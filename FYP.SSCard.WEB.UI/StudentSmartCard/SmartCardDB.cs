using StudentSmartCard.Location;
using StudentSmartCard.ScannedCardInfo;
using StudentSmartCard.Student;
using StudentSmartCard.UserManagement;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSmartCard
{
    public class SmartCardDB:DbContext
    {
        public SmartCardDB() : base("StudentCard")
        {

        }
        protected override void OnModelCreating(DbModelBuilder dbModel)
        {
            base.OnModelCreating(dbModel);

        }

        public DbSet<StudentDetail> StudentDetails { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<QualCategory> QualificationCategories { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Religions> Religions { get; set; }
        public DbSet<Document> Document { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ScannedCardInformation> ScannedCardInfo { get; set; }
        public DbSet<StudentCard> StudentCard { get; set; }
    }
}
