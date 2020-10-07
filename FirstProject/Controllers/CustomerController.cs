using FirstProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using FirstProject.ViewModel;

namespace FirstProject.Controllers
{
    [RoutePrefix("Customer")]
    public class CustomerController : Controller
    {
        private ApplicationDbContext dbContext = null;

        public CustomerController()
        {
            dbContext = new ApplicationDbContext();
        }
        // GET: Customer
        [AllowAnonymous]
       // [HttpGet]
        public ActionResult Index()
        {
            //var customer = new Customer
            //{
            //    id = 1,
            //    Name ="Aravind",
            //    DateofBirth = DateTime.Today
            //};
            //return View(customer);
            List<Customer> customers = GetCustomers();
            return View(customers);
        }
      
        //public ActionResult FindAge(DateTime DOB)
        //{
        //    DateTime birthDate = Convert.ToDateTime("06/16/1997");
        //    DateTime TodayDate = DateTime.Today;
        //    int age = TodayDate.Year - birthDate.Year;
        //    if (birthDate > TodayDate.AddYears(-age)) 
        //    age--;
        //    return Content($"Age of Person is:{age}");
        //}
        [Authorize(Users ="admin@moviestore.com,emp@moviestore.com")]
        [HttpGet]
        [HandleError(ExceptionType =typeof(ArgumentNullException),View ="ArgumentNull")]
        public ActionResult Create()
        {
            var viewModel = new CustomerViewModel
            {
                Customer = new Customer(),
                GetMemberships = dbContext.Memberships.ToList(),
                Gender = GetGender()
            };
          
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerViewModel
                {
                    Customer = new Customer(),
                    GetMemberships = dbContext.Memberships.ToList(),
                    Gender=GetGender(),
                };
                
                return View(viewModel);
            }
            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }

        [HttpGet]

        public ActionResult Edit(int id)
        {
            var customer = dbContext.Customers.SingleOrDefault(x => x.id == id);
            if (customer != null)
            {
                var viewModel = new CustomerViewModel
                {
                    Customer = customer,
                    GetMemberships = dbContext.Memberships.ToList(),
                    Gender=GetGender()
                };
                return View(viewModel);
            }
            return HttpNotFound("Customer Id Does Not Exist");
        }
        [HttpPost]
        public ActionResult Edit(int id, Customer customer )
        {
            var CustomDb = dbContext.Customers.SingleOrDefault(x => x.id == id);
            if (CustomDb != null)
            {
                CustomDb.Name = customer.Name;
               CustomDb.DateofBirth = customer.DateofBirth;
                CustomDb.Address = customer.Address;
                CustomDb.MembershipId = customer.MembershipId;
                CustomDb.Gender = customer.Gender;
                dbContext.SaveChanges();
                return RedirectToAction("Index", "Customer");
            }
            return HttpNotFound();
        }

        [HttpPost]

        public ActionResult Delete(int id)
        {
            var customer = dbContext.Customers.SingleOrDefault(m => m.id == id);
            if (customer != null)
            {
                dbContext.Customers.Remove(customer);
                dbContext.SaveChanges();
                return RedirectToAction("Index", "Customer");
            }
            return HttpNotFound();
        }

        [Authorize(Users = "admin@moviestore.com,emp@moviestore.com")]

        [HandleError(ExceptionType =typeof(NullReferenceException),View ="NullRef")]
        public ActionResult Details(int id)
        {
            var customer = dbContext.Customers.Include(m => m.Membership).FirstOrDefault(x => x.id == id);
            return View(customer);
        }
        [NonAction]
        public List<Customer> GetCustomers()
        {
            //return View();
            return dbContext.Customers.ToList();
        }
        [NonAction]
        public IEnumerable<SelectListItem> GetMembershipType()
        {
            var members = dbContext.Memberships.AsEnumerable().Select(x => new SelectListItem
            {
                Text = x.MembershipType,
                Value = x.Id.ToString()
            });
            return members;
        }

        [NonAction]
        public List<SelectListItem> GetGender()
        {
            return new List<SelectListItem>
          {
              new SelectListItem{Text="Select your Gender"},
              new SelectListItem{Text="Male",Value="Male"},
               new SelectListItem{Text="Female",Value="Female"},
                new SelectListItem{Text="Others",Value="Others"}
          };
        }
    }
}