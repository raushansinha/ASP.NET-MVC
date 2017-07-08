using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Common.Controllers
{
    public class BrowseURLController : BaseCommonController
    {
        private double pageSize = 10.0;

        // GET: Common/Browse
        public ActionResult Index(string sortOrder, string sortBy, string page)
        {
            ViewBag.SortOrder = sortOrder;
            ViewBag.SortBy = sortBy;
            var urls = objBs.urlBs.GetAll().Where(x => x.IsApproved == "A").ToList();

            switch(sortBy)
            {
                case "Title":
                    switch (sortOrder)
                    {
                        case "Asc":
                            urls = urls.OrderBy(x => x.UrlTitle).ToList();
                            break;
                        case "Desc":
                            urls = urls.OrderByDescending(x => x.UrlTitle).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                case "Url":
                    switch (sortOrder)
                    {
                        case "Asc":
                            urls = urls.OrderBy(x => x.Url).ToList();
                            break;
                        case "Desc":
                            urls = urls.OrderByDescending(x => x.Url).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                case "UrlDesc":
                    switch (sortOrder)
                    {
                        case "Asc":
                            urls = urls.OrderBy(x => x.UrlDesc).ToList();
                            break;
                        case "Desc":
                            urls = urls.OrderByDescending(x => x.UrlDesc).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                case "CategoryName":
                    switch (sortOrder)
                    {
                        case "Asc":
                            urls = urls.OrderBy(x => x.CategoryId).ToList();
                            break;
                        case "Desc":
                            urls = urls.OrderByDescending(x => x.CategoryId).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    urls = urls.OrderBy(x => x.UrlTitle).ToList();
                    break;
            }

            ViewBag.TotalPages = Math.Ceiling(objBs.urlBs.GetAll().Where(x => x.IsApproved == "A").Count() / pageSize);
            int pageNum = int.Parse(page == null ? "1": page);
            ViewBag.Page = pageNum;

            urls = urls.Skip((pageNum - 1) * 10).Take(10).ToList();

            return View(urls);
        }
    }
}