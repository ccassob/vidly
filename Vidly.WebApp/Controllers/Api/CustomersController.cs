using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly.WebApp.Models;

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
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        //POST Api/Customers/1
        [HttpGet]
        public Customer GetCustomer(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return customer;
        }

        //POST Api/Customers
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (customer == null || !ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        //PUT Api/Customers/1
        [HttpPut]
        public Customer UpdateCustomer(int Id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            customerInDb.Name = customer.Name;
            customerInDb.MemberShipTypeId = customer.MemberShipTypeId;
            customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            customerInDb.BirthDate = customer.BirthDate;

            _context.SaveChanges();

            return customer;
        }

        //DELETE Api/Customers/1
        [HttpDelete]
        public Customer DeleteCustomer(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return customer;
        }
    }
}