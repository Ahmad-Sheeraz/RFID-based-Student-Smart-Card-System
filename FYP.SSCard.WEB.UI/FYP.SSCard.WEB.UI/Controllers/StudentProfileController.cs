using FYP.SSCard.WEB.UI.Filters;
using FYP.SSCard.WEB.UI.Models;
using FYP.SSCard.WEB.UI.Models.Documents;
using FYP.SSCard.WEB.UI.Models.Students;
using StudentSmartCard;
using StudentSmartCard.Student;
using StudentSmartCard.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYP.SSCard.WEB.UI.Controllers
{
    //[AdminSessionValidation]
    public class StudentProfileController : Controller
    {
        [HttpGet]
        [AdminSessionValidation]
        public ActionResult SearchStudent(int? id)
        {
            User user = (User)Session[WebUtil.CURRENT_USER];
           
            SmartCardDB dB = new SmartCardDB();
            return View();
        }
        [AdminSessionValidation]
        public ActionResult StudentDetails(int id)
        {
            User user = (User)Session[WebUtil.CURRENT_USER];
            

            StudentsModel model_A = new StudentHandler().GetStudentDetail(id).ToStuModel();
            List<DocumentsModel> model_B = new StudentHandler().GetDocuments().ToDocumentsModel();
            DetailsModel model = new DetailsModel();
            model.students = model_A;
            model.documents = model_B;
            // DocumentsModel modal = new StudentHandler().GetDocument(id).ToDocModel();
            // ViewBag.Title = $"Student : - {model.FirstName}";
            //  StudentProfileModel profileModel = new StudentProfileModel();
            // profileModel.StudentsModel = StudentHandler().GetStudent(id).ToStuModel();
            // profileModel.DocumentsModels = StudentHandler().GetDocument(id).ToDocModel();
            // return View(profileModel);
            return View(model);
        }
    }
}