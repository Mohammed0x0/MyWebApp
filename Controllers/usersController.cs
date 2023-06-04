using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WarehouseManagement.Controllers;
using WarehouseManagement.Models;

namespace MyWebApp.Controllers
{

    public class usersController : Controller
    {
        public static readonly Users usr = Users.us;

        // GET: users
        public ActionResult Index(int? page)
        {
             int pagesize = 3;
             int pageNum ;
            if (page == null)
            {
                pageNum = (page ?? 1);
            }
            else
            {
                pageNum = (int)page;
            }
            var usrs = new List<users>();
            usrs = usr.GetAllUsers();

            return View(usrs.OrderBy(x => x.id).ToPagedList(pageNum, pagesize));

        }


        public ActionResult selector()
        {
            var usrs = new List<users>();
            usrs = usr.GetAllUsers();
            
            return View(usrs);

        }

        // GET: users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: users/Create
        [HttpPost]
        public ActionResult Create(users user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = new users()
                    {
                        name = user.name,
                        phone = user.phone
                    };
                    if (usr.AddUser(model))
                    {
                        Redirect("users");
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }


        }

        // GET: users/Edit/5
        public ActionResult Edit(int id)
        {
            var usered = new List<users>();
            usered = usr.GetUser(id);
            var model = new users();
            
            return View(model);
        }

        // POST: users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, users editusr)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = new users()
                    {
                        name = editusr.name,
                        phone = editusr.phone
                    };
                    if (usr.EditUser(id , model))
                    {
                        Redirect("users");
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
