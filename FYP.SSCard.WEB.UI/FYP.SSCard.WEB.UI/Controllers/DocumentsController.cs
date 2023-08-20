using FYP.SSCard.WEB.UI.Filters;
using FYP.SSCard.WEB.UI.Models;
using FYP.SSCard.WEB.UI.Models.Documents;
using StudentSmartCard.Student;
using StudentSmartCard.UserManagement;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYP.SSCard.WEB.UI.Controllers
{
    [AdminSessionValidation]
    public class DocumentsController : Controller
    {
        [HttpGet]
        public ActionResult Details(int id)
        {
            User user = (User)Session[WebUtil.CURRENT_USER];
           
            DocumentsModel models = new StudentHandler().GetDocument(id).ToDocModel();
            return View(models);

        }
        [HttpGet]
        public ActionResult Manage()
        {
            User user = (User)Session[WebUtil.CURRENT_USER];
           
            List<DocumentsModel> models = new StudentHandler().GetDocuments().ToDocumentsModel();
            return View(models);

        }
        [HttpGet]
        public ActionResult Create()
        {
            User user = (User)Session[WebUtil.CURRENT_USER];
           
           ViewBag.Qualification = new StudentHandler().GetQualiCategories().ToselectListItems();
            return PartialView("~/Views/Documents/_Create.cshtml");
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection data)
        {
            User user = (User)Session[WebUtil.CURRENT_USER];
            
            try
            {
                Document entity = new Document();
               // entity.QualCategory = new QualCategory { Id = Convert.ToInt32(data["QualCategory"]) };
                entity.StuRollNo = data["StudentRollno"];
                HttpPostedFileBase file = Request.Files["photo"];
                if (!string.IsNullOrEmpty(file.FileName))
                {
                    string url = $"~/Images/{DateTime.Now.Ticks}{file.FileName.Substring(file.FileName.LastIndexOf("."))}";
                    file.SaveAs(Server.MapPath(url));
                    entity.Imageupload = url;
                }
                entity.Board = data["Board"];
                entity.Subjects = data["Subjects"];
                entity.PassingYear = Convert.ToInt32(data["Passing Year"]);
                entity.ObtainMarks = Convert.ToInt32(data["Obtain Marks"]);
                entity.TotalMarks = Convert.ToInt32(data["Total Marks"]);
                new StudentHandler().AddDocuments(entity);
                TempData.Add("AlertMessage", new AlertModel($"New Document added successfully", AlertModel.AlertType.Success));
            }
            catch (Exception ex)
            {
                TempData.Add("AlertMessage", new AlertModel($"Failed to add the Documents", AlertModel.AlertType.Error));
                Trace.WriteLine("******************************************");
                Trace.WriteLine($"{DateTime.Now.ToString("F")}: {ex.Message}");
                Trace.WriteLine(ex.StackTrace);
                Trace.Flush();
            }

            return RedirectToAction("manage");
        }
        [HttpGet]
        [AdminSessionValidation]
        public ActionResult Edit(int id)
        {
            User user = (User)Session[WebUtil.CURRENT_USER];
          
            DocumentsModel model = new StudentHandler().GetDocument(id).ToDocModel();
            return PartialView("~/Views/Documents/_Edit.cshtml", model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection data)
        {
            User user = (User)Session[WebUtil.CURRENT_USER];
           
            try
            {
                Document entity = new Document();
                entity.Id = Convert.ToInt32(data["Id"]);
                entity.StuRollNo = data["StudentRollNo"];
                HttpPostedFileBase file = Request.Files["photo"];
                if (!string.IsNullOrEmpty(file.FileName))
                {
                    string url = $"~/Images/{DateTime.Now.Ticks}{file.FileName.Substring(file.FileName.LastIndexOf("."))}";
                    file.SaveAs(Server.MapPath(url));
                    entity.Imageupload = url;
                }
                entity.Board = data["Board"];
                entity.Subjects = data["Subjects"];
                entity.PassingYear = Convert.ToInt32(data["Passing Year"]);
                entity.ObtainMarks = Convert.ToInt32(data["Obtain Marks"]);
                entity.TotalMarks = Convert.ToInt32(data["Total Marks"]);
                new StudentHandler().UpdateDocuments(entity.Id, entity);
                TempData.Add("AlertMessage", new AlertModel($"Document updated successfully", AlertModel.AlertType.Success));
            }
            catch (Exception ex)
            {
                TempData.Add("AlertMessage", new AlertModel($"Failed to update Document", AlertModel.AlertType.Error));
                Trace.WriteLine("******************************************");
                Trace.WriteLine($"{DateTime.Now.ToString("F")}: {ex.Message}");
                Trace.WriteLine(ex.StackTrace);
                Trace.Flush();
            }

            return RedirectToAction("manage");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            User user = (User)Session[WebUtil.CURRENT_USER];
           
            DocumentsModel model = new StudentHandler().GetDocument(id).ToDocModel();
            return PartialView("~/Views/Documents/_Delete.cshtml", model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete(FormCollection data)
        {
            User user = (User)Session[WebUtil.CURRENT_USER];
           
            try
            {
                new StudentHandler().DeleteDocuments(Convert.ToInt32(data["Id"]));
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
    }
}