using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using pde_poc_web.Models;
using pde_poc_sim.Storage.Mocks;

namespace pde_poc_web.Controllers
{
    public class MockController : Controller
    {
        private readonly MockCreator _mock;

        public MockController(MockCreator mock)
        {
            _mock = mock;
        }

        public IActionResult Index()
        {
            _mock.TearDown();
            _mock.Generate();
            return View();
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
