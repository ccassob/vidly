using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly.WebApp.Models;
using Vidly.WebApp.Models.Dtos;

namespace Vidly.WebApp.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET Api/Customers
        public IHttpActionResult GetCustomers()
        {
            var customers = _context.Customers.ToList().Select(customer => Mapper.Map<Customer, CustomerDto>(customer));

            return Ok(customers);
        }

        //POST Api/Customers/1
        [HttpGet]
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = Mapper.Map<Customer, CustomerDto>(_context.Customers.SingleOrDefault(c => c.Id == id));

            if (customer == null)
                NotFound();

            return Ok(customer);
        }

        //POST Api/Customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerdto)
        {
            if (customerdto == null || !ModelState.IsValid)
                BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerdto);

            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerdto.Id = customer.Id;

            return Created( new Uri(Request.RequestUri + "/" + customer.Id), customerdto);
        }

        //PUT Api/Customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerdto)
        {
            if (!ModelState.IsValid)
                BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                NotFound();

            Mapper.Map<CustomerDto, Customer>(customerdto, customerInDb);
            _context.SaveChanges();


            return Ok();
        }

        //DELETE Api/Customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                NotFound();

            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return Ok();
        }
    }
}