using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameCraft.Models;
using System.Data.Entity;
using System.Web.UI.WebControls;
using AutoMapper;
using GameCraft.ViewModels;

namespace GameCraft.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }
       
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            
            if (customer == null)
                return HttpNotFound("Klient o podanym Id nie został zarejestrowany.");

            return View(customer);

        }
        public ActionResult New()
        {
            var customerViewModel = new CustomerFormViewModel()
            {
                MembershipType = _context.MembershipTypes.ToList(),
                Customer = new Customer()
            }; 

            return View ("CustomerForm",customerViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MembershipType = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm",viewModel);
            }

            if (customer.Id ==0)
               
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                
                /*
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.MembershipTypeId = customer.MembershipTypeId; */

                Mapper.Map(customer, customerInDb);


            }
            _context.SaveChanges();

            return RedirectToAction("Index","Customer");
        }
        
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customer ==null)
                return HttpNotFound("Użytkownik nie jest zarejestrowany");

            var customerFormViewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipType = _context.MembershipTypes.ToList()

            };

            return View("CustomerForm",customerFormViewModel);
        }
    }
}