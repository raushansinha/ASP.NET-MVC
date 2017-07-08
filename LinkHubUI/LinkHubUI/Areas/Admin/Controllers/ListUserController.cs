using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Admin.Controllers
{
    public class ListUserController : BaseAdminController
    {
        private double pageSize = 10.0;

     
        // GET: Admin/ListUser
        public ActionResult Index(string sortOrder, string sortBy, string page)
        {
            ViewBag.SortOrder = sortOrder;
            ViewBag.SortBy = sortBy;
            var users = objBs.userBs.GetAll();

            switch (sortBy)
            {
                case "UserEmail":
                    switch (sortOrder)
                    {
                        case "Asc":
                            users = users.OrderBy(x => x.UserEmail).ToList();
                            break;
                        case "Desc":
                            users = users.OrderByDescending(x => x.Role).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                case "Role":
                    switch (sortOrder)
                    {
                        case "Asc":
                            users = users.OrderBy(x => x.Role).ToList();
                            break;
                        case "Desc":
                            users = users.OrderByDescending(x => x.Role).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    users = users.OrderBy(x => x.UserEmail).ToList();
                    break;
            }

            ViewBag.TotalPages = Math.Ceiling(objBs.userBs.GetAll().Count() / pageSize);
            int pageNum = int.Parse(page == null ? "1" : page);
            ViewBag.Page = pageNum;

            users = users.Skip((pageNum - 1) * 10).Take(10).ToList();
            return View(users);
        }
    }
}


