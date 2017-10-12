using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.WebApp.Models;
using Vidly.WebApp.ViewModel;

namespace Vidly.WebApp.Controllers
{
    [Authorize]
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
            return View();
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
                MemberShipTypes = memberShipTypes,
            };

            return View("CustomerForm", newCustomerViewModel);
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer model)
        {
            if (!ModelState.IsValid)
            {
                var memberShipTypes = _context.MemberShipTypes.ToList();
                var customerformviewmodel = new CustomerFormViewModel()
                {
                    MemberShipTypes = memberShipTypes
                };

                return View("CustomerForm", memberShipTypes);
            }

            if (model.Id == 0)
            {
                _context.Customers.Add(model);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == model.Id);
                customerInDb.Name = model.Name;
                customerInDb.BirthDate = model.BirthDate;
                customerInDb.MemberShipTypeId = model.MemberShipTypeId;
                customerInDb.IsSubscribedToNewsletter = model.IsSubscribedToNewsletter;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Customer/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            var newCustomerViewModel = new CustomerFormViewModel(customer)
            {
                MemberShipTypes = _context.MemberShipTypes
            };

            if (customer == null)
                return HttpNotFound();

            return View("CustomerForm", newCustomerViewModel);
        }
    }
}