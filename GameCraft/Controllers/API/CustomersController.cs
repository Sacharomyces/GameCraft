using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using GameCraft.Dtos;
using GameCraft.Models;

namespace GameCraft.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
           _context = new ApplicationDbContext();
        }
    
        //GET /api/customers
        public IHttpActionResult  GetCustomers()
        {
            var customersDTos = _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);

            return Ok (customersDTos);
        }

        // GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id==id);

            if (customer == null)
                return NotFound();

            var customerDTo = Mapper.Map<Customer, CustomerDto>(customer);

            return Ok(customerDTo);
        }

        //POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var newCustomer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(newCustomer);
            _context.SaveChanges();

            customerDto.Id = newCustomer.Id;

            return Created(new Uri(Request.RequestUri + "/" + newCustomer.Id), customerDto);
        }

        //PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto cutomerDto)
        {
            if (!ModelState.IsValid)
               return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
               return NotFound();

            Mapper.Map(cutomerDto,customerInDb);

            _context.SaveChanges();

            return Ok();

        }

        //DELETE /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
