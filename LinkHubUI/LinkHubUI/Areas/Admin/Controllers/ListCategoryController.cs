using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Admin.Controllers
{
    public class ListCategoryController : BaseAdminController
    {

        private double pageSize = 10.0;

        // GET: Admin/ListCategory
        public ActionResult Index(string sortOrder, string sortBy, string page)
        {
            ViewBag.SortOrder = sortOrder;
            ViewBag.SortBy = sortBy;
            var categories = objBs.categoryBs.GetAll();

            switch (sortBy)
            {
                case "CategoryName":
                    switch (sortOrder)
                    {
                        case "Asc":
                            categories = categories.OrderBy(x => x.CategoryName).ToList();
                            break;
                        case "Desc":
                            categories = categories.OrderByDescending(x => x.CategoryName).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                case "CategoryDesc":
                    switch (sortOrder)
                    {
                        case "Asc":
                            categories = categories.OrderBy(x => x.CategoryDesc).ToList();
                            break;
                        case "Desc":
                            categories = categories.OrderByDescending(x => x.CategoryDesc).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    categories = categories.OrderBy(x => x.CategoryName).ToList();
                    break;
            }

            ViewBag.TotalPages = Math.Ceiling(objBs.categoryBs.GetAll().Count() / pageSize);
            int pageNum = int.Parse(page == null ? "1" : page);
            ViewBag.Page = pageNum;

            categories = categories.Skip((pageNum - 1) * 10).Take(10).ToList();


            return View(categories);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                objBs.categoryBs.Delete(id);
                TempData["Msg"] = "Deleted Successfully";
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                TempData["Msg"] = "Delete Failed: " + e.Message;
                return RedirectToAction("Index");
            }
        }

        //public ActionResult Create(tbl_Category category)
        //{
        //    objBs.Insert(category)
        //}
    }
}


