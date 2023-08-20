using FYP.SSCard.WEB.UI.Filters;
using FYP.SSCard.WEB.UI.Models;
using FYP.SSCard.WEB.UI.Models.Documents;
using FYP.SSCard.WEB.UI.Models.Students;
using StudentSmartCard;
using StudentSmartCard.Student;
using StudentSmartCard.UserManagement;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace FYP.SSCard.WEB.UI.Controllers
{
    //[AdminSessionValidation]
    public class StudentsController : Controller
    {
        SmartCardDB cardDB = new SmartCardDB();

        [HttpGet]
        public ActionResult Details(int id)
        {
            User user = (User)Session[WebUtil.CURRENT_USER];
            var model_C = new StudentHandler().GetStudentDetail(id);
            StudentsModel model_A = new StudentHandler().GetStudentDetail(id).ToStuModel();
            List<DocumentsModel> model_B = new StudentHandler().GetDocuments().ToDocumentsModel();
            DetailsModel model = new DetailsModel();
            model.students = model_A;
            model.documents = model_B;
            var studentcardinfo = new CardsHandler().GetStudentCardInfo(id);
            ViewBag.AvailableBalance = studentcardinfo != null ? studentcardinfo.Amount : 0;
            return View(model);
        }
        [HttpGet]
        public ActionResult Manage(string searchQuery = null, bool isSearchByRollNumberOnly = false)
        {
            User user = (User)Session[WebUtil.CURRENT_USER];

            List<StudentsModel> models = new List<StudentsModel>();
            if (string.IsNullOrEmpty(searchQuery))
            {
                models = new StudentHandler().GetStudentDetails().ToStudentModel();
            }
            else
            {
                models = new StudentHandler().GetStudentDetailsBySearchQuery(searchQuery, isSearchByRollNumberOnly).ToStudentModel();
            }


            return View(models);

        }
        [HttpGet]
        [AdminSessionValidation]
        public ActionResult Create()
        {
            User user = (User)Session[WebUtil.CURRENT_USER];

            return PartialView("~/Views/Students/_Create.cshtml");
        }
        [HttpPost, ValidateAntiForgeryToken]
        [AdminSessionValidation]
        public ActionResult Create(FormCollection data)
        {
            User user = (User)Session[WebUtil.CURRENT_USER];

            try
            {
                StudentDetail entity = new StudentDetail();
                entity.Id = Convert.ToInt32(data["Id"]);
                entity.StudentRollNo = data["StudentRollno"];
                HttpPostedFileBase file = Request.Files["photo"];
                if (!string.IsNullOrEmpty(file.FileName))
                {
                    string url = $"~/images/{DateTime.Now.Ticks}{file.FileName.Substring(file.FileName.LastIndexOf("."))}";
                    file.SaveAs(Server.MapPath(url));
                    entity.ImageUrl = url;
                }
                entity.FirstName = data["FirstName"];
                entity.LastName = data["LastName"];
                entity.FatherName = data["FatherName"];
                entity.Email = data["Email"];
                entity.Password = data["Password"];
                entity.Guardian = data["Guardian"];
                entity.CNIC = data["CNIC"];
                entity.Address = data["Address"];
                entity.DateofBirth = Convert.ToDateTime(data["DateOfBirth"]);
                entity.MobileNo = data["MobileNo"];
                entity.CellNo = data["CellNo"];
                new StudentHandler().AddStudentDetails(entity);
                CreateStudentLogin(entity);
                SendEmail(entity.Email, entity.FirstName + " " + entity.LastName, entity.Password);
                TempData.Add("AlertMessage", new AlertModel($"New Student added successfully", AlertModel.AlertType.Success));
            }
            catch (Exception ex)
            {
                TempData.Add("AlertMessage", new AlertModel($"Failed to add the Students", AlertModel.AlertType.Error));
                Trace.WriteLine("******************************************");
                Trace.WriteLine($"{DateTime.Now.ToString("F")}: {ex.Message}");
                Trace.WriteLine(ex.StackTrace);
                Trace.Flush();
            }

            return RedirectToAction("manage");
        }

        private void CreateStudentLogin(StudentDetail entity)
        {

            User studentUser = new User();
            studentUser.Name = entity.FirstName + " " + entity.LastName;
            studentUser.ImageUrl = entity.ImageUrl;
            studentUser.IsActive = true;
            studentUser.BirthDate = entity.DateofBirth;
            studentUser.ContactNumber = entity.CellNo;
            studentUser.Email = entity.Email;
            studentUser.LoginId = entity.FirstName;
            studentUser.Password = entity.Password;
            studentUser.SecurityQuestion = entity.FirstName;
            studentUser.SecurityAnswer = entity.Guardian;
            new UsersHandler().AddStudentAsWebsiteUser(studentUser);
        }

        [HttpGet]
        [AdminSessionValidation]
        public ActionResult Edit(int id)
        {
            User user = (User)Session[WebUtil.CURRENT_USER];

            StudentsModel modelin = new StudentHandler().GetStudentDetail(id).ToStuModel();
            return PartialView("~/Views/Students/_Edit.cshtml", modelin);
        }
        [HttpPost, ValidateAntiForgeryToken]
        [AdminSessionValidation]
        public ActionResult Edit(FormCollection data)
        {
            User user = (User)Session[WebUtil.CURRENT_USER];

            try
            {
                StudentDetail entity = new StudentDetail();
                entity.Id = Convert.ToInt32(data["Id"]);
                entity.StudentRollNo = data["StudentRollno"];
                HttpPostedFileBase file = Request.Files["photo"];
                if (!string.IsNullOrEmpty(file.FileName))
                {
                    string url = $"~/images/{DateTime.Now.Ticks}{file.FileName.Substring(file.FileName.LastIndexOf("."))}";
                    file.SaveAs(Server.MapPath(url));
                    entity.ImageUrl = url;
                }
                entity.FirstName = data["FirstName"];
                entity.LastName = data["LastName"];
                entity.FatherName = data["FatherName"];
                entity.Email = data["Email"];
                entity.Password = data["Password"];
                entity.Guardian = data["Guardian"];
                entity.CNIC = data["CNIC"];
                entity.Address = data["Address"];
                entity.DateofBirth = Convert.ToDateTime(data["DateOfBirth"]);
                entity.MobileNo = data["MobileNo"];
                entity.CellNo = data["CellNo"];
                new StudentHandler().UpdateStudentDetail(entity.Id, entity);
                TempData.Add("AlertMessage", new AlertModel($"Student Profile updated successfully", AlertModel.AlertType.Success));
            }
            catch (Exception ex)
            {
                TempData.Add("AlertMessage", new AlertModel($"Failed to update Student Profile", AlertModel.AlertType.Error));
                Trace.WriteLine("******************************************");
                Trace.WriteLine($"{DateTime.Now.ToString("F")}: {ex.Message}");
                Trace.WriteLine(ex.StackTrace);
                Trace.Flush();
            }

            return RedirectToAction("manage");
        }
        [HttpGet]
        [AdminSessionValidation]
        public ActionResult Delete(int id)
        {
            User user = (User)Session[WebUtil.CURRENT_USER];
            // Delete user from Login
            // very importan
            // otherwise user will be able login, even deleted from admin
            StudentsModel modelin = new StudentHandler().GetStudentDetail(id).ToStuModel();
            return PartialView("~/Views/Students/_Delete.cshtml", modelin);
        }
        [HttpPost, ValidateAntiForgeryToken]
        [AdminSessionValidation]
        public ActionResult Delete(FormCollection data)
        {
            User user = (User)Session[WebUtil.CURRENT_USER];

            try
            {
                new StudentHandler().DeleteStudentDetail(Convert.ToInt32(data["Id"]));
                TempData.Add("AlertMessage", new AlertModel($"Document deleted successfully", AlertModel.AlertType.Success));
            }
            catch (Exception ex)
            {
                TempData.Add("AlertMessage", new AlertModel($"Failed to delete Document", AlertModel.AlertType.Error));
                Trace.WriteLine("******************************************");
                Trace.WriteLine($"{DateTime.Now.ToString("F")}: {ex.Message}");
                Trace.WriteLine(ex.StackTrace);
                Trace.Flush();
            }

            return RedirectToAction("manage");
        }


        public bool SendEmail(string receiverEmailAddress, string receiverName, string receiverPassword)
        {
            try
            {
                var senderEmail = new MailAddress("leadsunifaculity@gmail.com", "Lahore Leads University - Smart Card Portal");
                var receiverEmail = new MailAddress(receiverEmailAddress, "Receiver");

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(senderEmail.Address, "Lahoreleads1")
                };
                using (var message = new MailMessage(senderEmail, receiverEmail)
                {
                    Subject = "Smart Card Portal - Registration Completed (" + receiverName + ")",
                    Body = GetEmailBody(receiverName, receiverEmailAddress, receiverPassword),
                    IsBodyHtml = true
                })
                {
                    smtp.Send(message);
                }
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }

        }

        public string GetEmailBody(string receiverName, string emailAddress, string password)
        {
            string emailContent = @"<!DOCTYPE html>
                                    <html>
                                    <body>
                                    
                                    <p>Dear $$Name$$</p>
                                    
                                    <p>You have successfully registered on Lahore Leads Smart Card Portal. Following are your credentials</p>
                                    
                                    <p>Email: $$Email$$</p>
                                    <p>Password: $$Password$$</p>
                                    
                                    
                                    <p>Regards</p>
                                    <p>Lahore Leads - Smart Card Portal Team</p>
                                    
                                    </body>
                                    </html>
                                    ";

            emailContent = emailContent.Replace("$$Name$$", receiverName);
            emailContent = emailContent.Replace("$$Email$$", emailAddress);
            emailContent = emailContent.Replace("$$Password$$", password);

            return emailContent;
        }
    }
}