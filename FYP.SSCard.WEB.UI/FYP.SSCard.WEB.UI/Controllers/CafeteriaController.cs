using FYP.SSCard.WEB.UI.Filters;
using StudentSmartCard.Student;
using StudentSmartCard.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYP.SSCard.WEB.UI.Controllers
{
    public class CafeteriaController : Controller
    {
        // GET: Cafeteria
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [CanteenSessionValidation]
        public ActionResult DeductAmount()
        {

            return View();
        }

        [HttpPost]
        [CanteenSessionValidation]
        public ActionResult DeductAmount(int amount, int studentId, string cardId)
        {
            User user = (User)Session[WebUtil.CURRENT_USER];

            new StudentHandler().DeductAmount(cardId, user.Id, studentId, amount, user.Id);

            return View();
        }
    }
}