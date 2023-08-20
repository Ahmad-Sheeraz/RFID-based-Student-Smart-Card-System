using FYP.SSCard.WEB.UI.Models;
using StudentSmartCard.Student;
using StudentSmartCard.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYP.SSCard.WEB.UI.Controllers
{
    public class UsersController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.Ctl = Request.QueryString["ctl"];
            ViewBag.Act = Request.QueryString["act"];
            HttpCookie cookie = Request.Cookies[WebUtil.MY_COOKIE];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Today.AddDays(3);
                Response.SetCookie(cookie);
                string[] loginData = cookie.Value.Split(',');
                User currentUser = new UsersHandler().GetUser(loginData[0], loginData[1]);
                // adding into session based on user ROLE

                Session.Add(WebUtil.CURRENT_USER, currentUser);
                if (currentUser.Role.Id == (int)Roles.Admin)
                {
                    string ctl = Request.QueryString["ctl"];
                    string act = Request.QueryString["act"];
                    if (!string.IsNullOrWhiteSpace(ctl) && !string.IsNullOrWhiteSpace(act))
                    {
                        return RedirectToAction(act, ctl);
                    }
                    return RedirectToAction("manage", "students");
                }
                else
                {
                    return RedirectToAction("homepage", "home");
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            User currentUser = new UsersHandler().GetUser(model.LoginId, model.Password);
            if (currentUser != null)
            {
                if (model.RememberMe)
                {
                    HttpCookie c = new HttpCookie(WebUtil.MY_COOKIE);
                    c.Expires = DateTime.Today.AddDays(3);
                    c.Value = $"{model.LoginId},{model.Password}";
                    Response.SetCookie(c);
                }


                Session.Add(WebUtil.CURRENT_USER, currentUser);
                if (currentUser.Role.Id == (int)Roles.Admin)
                {
                    string ctl = Request.QueryString["ctl"];
                    string act = Request.QueryString["act"];
                    if (!string.IsNullOrWhiteSpace(ctl) && !string.IsNullOrWhiteSpace(act))
                    {
                        return RedirectToAction(act, ctl);
                    }
                    return RedirectToAction("manage", "students");
                }

                else if (currentUser.Role.Id == (int)Roles.Student)
                {
                    var studentDetail = new StudentHandler().GetStudentDetailByEmail(currentUser.Email);
                    return RedirectToAction("details", "students", new { id = studentDetail.Id });
                }
                else if (currentUser.Role.Id == (int)Roles.Library)
                {
                    return RedirectToAction("DeductAmount", "Librarian");
                }
                else if (currentUser.Role.Id == (int)Roles.Cafeteria)
                {
                    return RedirectToAction("DeductAmount", "Cafeteria");
                }
                else
                    return RedirectToAction("about", "home");
            }
            return View();
        }


        [HttpGet]
        public ActionResult Signup()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Abandon();
            HttpCookie temp = Request.Cookies[WebUtil.MY_COOKIE];
            if (temp != null)
            {
                temp.Expires = DateTime.Now;
                Response.SetCookie(temp);
            }

            return RedirectToAction("login");
        }

    }
}