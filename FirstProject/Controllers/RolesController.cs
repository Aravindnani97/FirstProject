using FirstProject.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstProject.Controllers
{
    [Authorize(Roles ="IT_Admin")]
    public class RolesController : Controller
    {
        // GET: Roles
        private ApplicationDbContext dbContext = null;
        public RolesController()
        {
            dbContext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult Index()
        {
            var roles = dbContext.Roles.ToList();
            return View(roles);
        }
       // GET: Roles/Create
        public ActionResult Create()
        {
            var role = new IdentityRole();
            
            return View(role);
        }

        // POST: Roles/Create
        [HttpPost]
        public ActionResult Create(IdentityRole role)
        {
            dbContext.Roles.Add(role);
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Roles");
        } 
    }
}
