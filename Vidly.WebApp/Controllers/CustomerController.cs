using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.WebApp.Models;
using Vidly.WebApp.ViewModel;

namespace Vidly.WebApp.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customer
        [HttpGet]
        public ActionResult Index()
        {
            var customer = _context.Customers.Include(c => c.MemberShipType).ToList();

            return View(customer);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {

            var customer = _context.Customers.Include(c => c.MemberShipType).SingleOrDefault(c => c.Id == id);

            return View(customer);
        }

        // GET: Customer/Create
        [HttpGet]
        public ActionResult New()
        {
            var memberShipTypes = _context.MemberShipTypes.ToList();

            var newCustomerViewModel = new CustomerFormViewModel()
            {
                MemberShipTypes = memberShipTypes
            };

            return View("CustomerForm", newCustomerViewModel);
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Save(CustomerFormViewModel model)
        {
            if (model.Customers.Id == 0)
            {
                _context.Customers.Add(model.Customers);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == model.Customers.Id);
                customerInDb.Name = model.Customers.Name;
                customerInDb.BirthDate = model.Customers.BirthDate;
                customerInDb.MemberShipTypeId = model.Customers.MemberShipTypeId;
                customerInDb.IsSubscribedToNewsletter = model.Customers.IsSubscribedToNewsletter;
            }

            _context.SaveChanges();


            return RedirectToAction("Index");
        }

        // GET: Customer/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            var newCustomerViewModel = new CustomerFormViewModel()
            {
                Customers = customer,
                MemberShipTypes = _context.MemberShipTypes
            };

            if (customer == null)
                return HttpNotFound();

            return View("CustomerForm", newCustomerViewModel);
        }

        // GET: Customer/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            return View(customer);
        }

        // POST: Customer/Delete/5
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
