using FYP.SSCard.WEB.UI.Filters;
using StudentSmartCard.ScannedCardInfo;
using StudentSmartCard.Student;
using StudentSmartCard.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYP.SSCard.WEB.UI.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        [AdminSessionValidation]
        public ActionResult CardRecharge()
        {

            return View();
        }

        [HttpPost]
        [AdminSessionValidation]
        public ActionResult CardRecharge(int amount, int studentId, string cardId)
        {
            User user = (User)Session[WebUtil.CURRENT_USER];

            new StudentHandler().CardRecharge(cardId, user.Id, studentId, amount);

            return View();
        }

        public string FetchCardInformation()
        {
            ScannedCardInformation scannedCardInformation = new CardsHandler().GetScannedCardInformation();

            if (scannedCardInformation != null)
            {
                new CardsHandler().UpdateCardInformation(scannedCardInformation.Id);
                return scannedCardInformation.CardId.ToString();
            }

            else
                return "No Card Found";

        }

        public List<SelectListItem> SelectStudentList()
        {
            List<StudentDetail> studentDetails = new StudentHandler().GetStudentDetails();
            List<SelectListItem> dropDownItems = new List<SelectListItem>();
            dropDownItems.Add(new SelectListItem { Text = "--Select--", Value = "" });
            foreach (var studentDetail in studentDetails)
            {
                dropDownItems.Add(new SelectListItem { Text = studentDetail.FirstName + " " + studentDetail.LastName, Value = studentDetail.Id.ToString(), Selected = false });
            }
            return dropDownItems;
        }

        
    }
}