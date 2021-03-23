using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Filters;

using pde_poc_web.Models;
using pde_poc_sim.Engine.Lib;
using pde_poc_sim.Engine;


namespace pde_poc_web.Controllers
{
    
    public class MaternityBenefitController : Controller
    {
        private readonly IHandleSimulationRequests<MaternityBenefitSimulationCaseRequest> _requestHandler;
        private readonly ISimulationLib<MaternityBenefitSimulationCase> _simulationLib;
        private readonly IGetSimulations<MaternityBenefitSimulationCase> _simulationGetter;

        public MaternityBenefitController(
            IHandleSimulationRequests<MaternityBenefitSimulationCaseRequest> requestHandler,
            ISimulationLib<MaternityBenefitSimulationCase> simulationLib,
            IGetSimulations<MaternityBenefitSimulationCase> simulationGetter)
        {
            _simulationLib = simulationLib;
            _requestHandler = requestHandler;
            _simulationGetter = simulationGetter;
        }

        public IActionResult Index(string admin)
        {
            var simulations = _simulationLib.GetAll();
            ViewBag.IsAdmin = (admin == "admin");
            return View(simulations);
        }

        public IActionResult Delete(Guid id) {
            _simulationLib.DeleteSimulation(id);
            return RedirectToAction("Index");
        }

        public IActionResult Form()
        {
            var baseCase = _simulationLib.GetBaseCase();
            var formVm = new FormViewModel(baseCase);
            return View(formVm);
        }

        [HttpPost]
        public IActionResult RunSim(FormViewModel formViewModel) {
            if (ModelState.IsValid) {
                var simulationRequest = BuildRequest(formViewModel);
                var id = _requestHandler.Handle(simulationRequest);
                return RedirectToAction("Results", new { id });
            }
            return View("Form");
        }

        public IActionResult Results(Guid id) {
            var simResults = _simulationGetter.Get(id);
            return View(simResults);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private SimulationRequest<MaternityBenefitSimulationCaseRequest> BuildRequest(FormViewModel vm) {
            return new SimulationRequest<MaternityBenefitSimulationCaseRequest>() {
                SimulationName = vm.SimulationName,
                BaseCaseRequest = new MaternityBenefitSimulationCaseRequest() {
                    MaxWeeklyAmount = vm.BaseCase.MaxWeeklyAmount,
                    Percentage = vm.BaseCase.Percentage,
                    NumWeeks = vm.BaseCase.NumWeeks
                },
                VariantCaseRequest = new MaternityBenefitSimulationCaseRequest() {
                    MaxWeeklyAmount = vm.VariantCase.MaxWeeklyAmount,
                    Percentage = vm.VariantCase.Percentage,
                    NumWeeks = vm.VariantCase.NumWeeks
                },
            };
        }
    }

}
