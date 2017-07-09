﻿using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Admin.Controllers
{
    [Authorize(Roles ="A")]
    public class CategoryController : BaseAdminController
    {
       
        // GET: Admin/Category
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create (tbl_Category category)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    objBs.categoryBs.Insert(category);
                    TempData["Msg"] = "Created Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Index");
                }
            }
            catch (Exception e)
            {
                TempData["Msg"] = "Create Failed: " + e.Message;
                return RedirectToAction("Index");
            }
        }
    }
}