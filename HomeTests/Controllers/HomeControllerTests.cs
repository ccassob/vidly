using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vidly.WebApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Vidly.WebApp.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            Assert.IsNotNull(new CustomerController().Edit(54) as ViewResult);
        }
    }
}