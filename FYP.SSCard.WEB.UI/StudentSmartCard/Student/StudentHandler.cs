using StudentSmartCard.Location;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSmartCard.Student
{
    public class StudentHandler
    {
        #region Category
        public Category GetCategory(int id)
        {
            using (SmartCardDB contex = new SmartCardDB())
            {
                return (from d in contex.Categories
                        where d.Id == id
                        select d).First();
            }
        }
        public List<Category> GetCategories()
        {
            using (SmartCardDB contex = new SmartCardDB())
            {
                return (from d in contex.Categories
                        select d).ToList();
            }
        }

        public void DeductAmount(string cardId, int id, int studentId, int amount,int processedBy)
        {
            using (SmartCardDB context = new SmartCardDB())
            {
                StudentCard studentCard = context.StudentCard.FirstOrDefault(x => x.CardId == cardId);
                if (studentCard != null)
                {
                    studentCard.Amount = studentCard.Amount - amount;
                    studentCard.ProcessedBy = processedBy;
                    studentCard.StudentId = studentId;
                    context.SaveChanges();
                }

            }
        }

        #endregion

        #region SubCategories
        public List<SubCategory> GetSubCategories()
        {
            using (SmartCardDB contex = new SmartCardDB())
            {
                return (from d in contex.SubCategories
                        .Include(d => d.Category)
                        select d).ToList();
            }
        }
        public List<SubCategory> GetSubCategories(Category cat)
        {
            using (SmartCardDB contex = new SmartCardDB())
            {
                return (from d in contex.SubCategories
                        .Include(d => d.Category)
                        where d.Category.Id == cat.Id
                        select d).ToList();
            }
        }
        public SubCategory GetSubCategory(int id)
        {
            using (SmartCardDB context = new SmartCardDB())
            {
                SubCategory found = (from c in context.SubCategories
                                   .Include(c => c.Category)
                                     where c.Id == id
                                     select c).FirstOrDefault();
                return found;
            }
        }
        #endregion

        #region QualificationCategory
        public QualCategory GetQualiCategories(int id)
        {
            using (SmartCardDB contex = new SmartCardDB())
            {
                return (from d in contex.QualificationCategories select d).First();
            }
        }
        public List<QualCategory> GetQualiCategories()
        {
            using (SmartCardDB contex = new SmartCardDB())
            {
                return (from d in contex.QualificationCategories
                        select d).ToList();
            }
        }
        #endregion

        #region Gender
        public Gender GetGender(int id)
        {
            using (SmartCardDB contex = new SmartCardDB())
            {
                return (from d in contex.Genders select d).First();
            }
        }
        public List<Gender> GetGenders()
        {
            using (SmartCardDB contex = new SmartCardDB())
            {
                return (from d in contex.Genders
                        select d).ToList();
            }
        }

        public StudentDetail GetStudentDetailByEmail(string email)
        {
            using (SmartCardDB contex = new SmartCardDB())
            {
                return contex.StudentDetails.FirstOrDefault(x => x.Email == email);
            }
        }
        #endregion

        #region Religions
        public Religions GetReligion(int id)
        {
            using (SmartCardDB contex = new SmartCardDB())
            {
                return (from d in contex.Religions select d).First();
            }
        }
        public List<Religions> GetReligions()
        {
            using (SmartCardDB contex = new SmartCardDB())
            {
                return (from d in contex.Religions
                        select d).ToList();
            }
        }
        #endregion

        #region Country
        public Country GetCountries(int id)
        {
            using (SmartCardDB context = new SmartCardDB())
            {
                return (from c in context.Countries select c).First();
            }
        }
        public List<Country> GetCountries()
        {
            using (SmartCardDB context = new SmartCardDB())
            {
                return (from c in context.Countries select c).ToList();
            }
        }
        public void AddCountry(Country country)
        {
            using (SmartCardDB context = new SmartCardDB())
            {
                context.Countries.Add(country);
                context.SaveChanges();
            }
        }

        public void UpdateCountry(int idToSearch, Country country)
        {
            using (SmartCardDB context = new SmartCardDB())
            {
                Country found = context.Countries.Find(idToSearch);
                found.Name = country.Name;
            }
        }

        public void DeleteCountry(int idToSearch)
        {
            using (SmartCardDB context = new SmartCardDB())
            {
                Country found = context.Countries.Find(idToSearch);
                context.Countries.Remove(found);
                context.SaveChanges();
            }
        }
        #endregion

        #region Province
        public List<Province> GetProvinces(Country cat)
        {
            using (SmartCardDB context = new SmartCardDB())
            {
                return (from p in context.Provinces
                       .Include(p => p.Country)
                        where p.Country.Id == cat.Id
                        select p).ToList();
            }
        }

        public void UpdateStudentDetail(int id, StudentDetail entity)
        {
            throw new NotImplementedException();
        }

        public List<Province> GetProvinces()
        {
            using (SmartCardDB context = new SmartCardDB())
            {
                return (from p in context.Provinces
                       .Include(p => p.Country)
                        select p).ToList();
            }
        }
        public Province GetProvince(int id)
        {
            using (SmartCardDB context = new SmartCardDB())
            {
                Province found = (from p in context.Provinces
                                  .Include(p => p.Country)
                                  where p.Id == id
                                  select p).FirstOrDefault();
                return found;
            }
        }
        public City GetCities(int id)
        {
            using (SmartCardDB context = new SmartCardDB())
            {
                return (from c in context.Cities
                        .Include(c => c.Province.Country)
                        select c).First();
            }

        }
        public List<City> GetCities()
        {
            using (SmartCardDB context = new SmartCardDB())
            {
                return (from c in context.Cities
                        .Include(c => c.Province.Country)
                        select c).ToList();
            }

        }
        public List<City> GetCities(Province province)
        {
            using (SmartCardDB context = new SmartCardDB())
            {
                return (from c in context.Cities
                        .Include(c => c.Province.Country)
                        where c.Province.Id == province.Id
                        select c).ToList();
            }

        }
        #endregion

        #region Documents
        public List<Document> GetDocuments()
        {
            using (SmartCardDB context = new SmartCardDB())
            {
                return (from s in context.Document
                        .Include(s => s.QualCategory)
                        select s).ToList();
            }
        }
        public Document GetDocument(int id)
        {
            using (SmartCardDB context = new SmartCardDB())
            {
                return (from s in context.Document
                        .Include(s => s.QualCategory)
                        where s.Id == id
                        select s).FirstOrDefault();
            }
        }
        public void AddDocuments(Document doc)
        {
            using (SmartCardDB context = new SmartCardDB())
            {
                //context.Entry(doc.QualCategory).State = EntityState.Unchanged;
                context.Document.Add(doc);
                context.SaveChanges();
            }
        }
        public void UpdateDocuments(int idToSearch, Document doc)
        {
            using (SmartCardDB context = new SmartCardDB())
            {
                Document found = (from d in context.Document
                                  where d.Id == idToSearch
                                  select d).First();
                found.StuRollNo = doc.StuRollNo;
                found.Board = doc.Board;
                found.Subjects = doc.Subjects;
                if (!string.IsNullOrWhiteSpace(doc.Imageupload))
                {
                    found.Imageupload = doc.Imageupload;

                }
                found.PassingYear = doc.PassingYear;
                found.TotalMarks = doc.TotalMarks;
                found.ObtainMarks = doc.ObtainMarks;
                found.QualCategory = doc.QualCategory;
                context.SaveChanges();
            }
        }
        public void DeleteDocuments(int idToSearch)
        {
            using (SmartCardDB context = new SmartCardDB())
            {
                Document found = (from d in context.Document
                                  where d.Id == idToSearch
                                  select d).First();
                context.Document.Remove(found);
                context.SaveChanges();
            }
        }
        #endregion

        #region StudentDetails

        public List<StudentDetail> GetStudentDetailsBySearchQuery(string searchQuery, bool isSearchByRollNumberOnly)
        {
            using (SmartCardDB context = new SmartCardDB())
            {
                List<StudentDetail> studentDetails = new List<StudentDetail>();
                if (isSearchByRollNumberOnly)
                {
                    studentDetails = context.StudentDetails.Where(x => x.StudentRollNo == searchQuery).ToList();
                }
                else
                {
                    studentDetails = context.StudentDetails.Where(x => x.FatherName.Contains(searchQuery) || x.FirstName.Contains(searchQuery) || x.LastName.Contains(searchQuery)).ToList();
                }


                return studentDetails;
            }
        }

        public List<StudentDetail> GetStudentDetails()
        {
            using (SmartCardDB context = new SmartCardDB())
            {
                return (from s in context.StudentDetails
                            //.Include(s => s.SubCategories.Category)
                            //.Include(s => s.Cities.Province.Country)
                        select s).ToList();
            }
        }
        public List<StudentDetail> GetStudentDetails(Category category, Country country)
        {
            using (SmartCardDB context = new SmartCardDB())
            {
                return (from p in context.StudentDetails
                            //.Include(p => p.SubCategories.Category)
                            //.Include(p => p.Cities.Province.Country)
                            // where p.SubCategories.Category.Id == category.Id
                            // where p.Cities.Province.Country.Id==country.Id
                        select p).ToList();
            }
        }

        public StudentDetail GetStudentDetail(int id)
        {
            using (SmartCardDB context = new SmartCardDB())
            {
                return (from p in context.StudentDetails
                            // .Include(p => p.Cities.Province.Country)
                            // .Include(p => p.SubCategories.Category)
                        where p.Id == id
                        select p).FirstOrDefault();
            }
        }
        public StudentDetail GetStudentDetail(string studentrollno)
        {
            using (SmartCardDB context = new SmartCardDB())
            {
                return (from p in context.StudentDetails
                            // .Include(p => p.Cities.Province.Country)
                            // .Include(p => p.SubCategories.Category)
                        where p.StudentRollNo == studentrollno
                        select p).FirstOrDefault();
            }
        }
        public void AddStudentDetails(StudentDetail Std)
        {
            using (SmartCardDB context = new SmartCardDB())
            {
                // context.Entry(Std.SubCategories).State = EntityState.Unchanged;
                // context.Entry(Std.Cities).State = EntityState.Unchanged;
                context.StudentDetails.Add(Std);
                context.SaveChanges();
            }
        }
        public void UpdateStudentDetail(StudentDetail Std, int idtoSearch)
        {
            using (SmartCardDB context = new SmartCardDB())
            {
                StudentDetail entity = (from d in context.StudentDetails
                                        where d.Id == idtoSearch
                                        select d).First();
                entity.StudentRollNo = Std.StudentRollNo;
                if (!string.IsNullOrWhiteSpace(Std.ImageUrl))
                {
                    entity.ImageUrl = Std.ImageUrl;
                }
                entity.FirstName = Std.FirstName;
                entity.LastName = Std.LastName;
                entity.FatherName = Std.FatherName;
                entity.Guardian = Std.Guardian;
                entity.DateofBirth = Std.DateofBirth;
                //entity.Cities = Std.Cities;
                // entity.SubCategories = entity.SubCategories;
                entity.Email = Std.Email;
                entity.Address = Std.Address;
                entity.CNIC = Std.CNIC;
                entity.CellNo = Std.CellNo;
                Std.MobileNo = Std.MobileNo;
                context.SaveChanges();
            }

        }
        public void DeleteStudentDetail(int idTooSearch)
        {
            using (SmartCardDB context = new SmartCardDB())
            {
                StudentDetail detail = (from e in context.StudentDetails
                                        where e.Id == idTooSearch
                                        select e).First();
                context.StudentDetails.Remove(detail);
                context.SaveChanges();
            }
        }
        #endregion

        #region Student Card

        public StudentCard CardRecharge(string cardId, int processedBy, int studentId, int amount)
        {
            using (SmartCardDB context = new SmartCardDB())
            {

                StudentCard studentCard = context.StudentCard.FirstOrDefault(x => x.CardId == cardId);
                if (studentCard == null)
                {
                    studentCard = new StudentCard();
                    studentCard.Amount =  amount;
                    studentCard.CardId = cardId;
                    studentCard.ProcessedBy = processedBy;
                    studentCard.StudentId = studentId;

                    context.StudentCard.Add(studentCard);
                    context.SaveChanges();
                }
                else
                {
                    studentCard.Amount = studentCard.Amount + amount;
                    studentCard.ProcessedBy = processedBy;
                    studentCard.StudentId = studentId;
                    context.SaveChanges();
                }

                return studentCard;
            }

            return null;
        }
        #endregion
    }
}
