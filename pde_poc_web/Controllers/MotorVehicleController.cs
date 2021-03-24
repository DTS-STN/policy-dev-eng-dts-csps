using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

using pde_poc_web.Models;
using pde_poc_sim.Engine.Lib;
using pde_poc_sim.Engine;

namespace pde_poc_web.Controllers
{
    public class MotorVehicleController : Controller
    {
        private readonly IHandleSimulationRequests<MotorVehicleSimulationCaseRequest> _requestHandler;
        private readonly IGetSimulations<MotorVehicleSimulationCase> _simulationGetter;
        private readonly IMemoryCache _cache;
        
        public MotorVehicleController(
            IHandleSimulationRequests<MotorVehicleSimulationCaseRequest> requestHandler,
            IGetSimulations<MotorVehicleSimulationCase> simulationGetter,
            IMemoryCache cache)
        {
            _requestHandler = requestHandler;
            _simulationGetter = simulationGetter;
            _cache = cache;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Form() {
            var vm = new MVSimulationViewModel();
            return View(vm);
        }

        public IActionResult Modify() {
            var vm = _cache.Get<MVSimulationViewModel>("MV_ViewModel");
            if (vm == null) {
                return RedirectToAction("Form");
            }
            return View("Form", vm);
        }

        [HttpPost]
        public IActionResult Form(MVSimulationViewModel formViewModel) {
            if (ModelState.IsValid) {
                // Store current form data in the cache
                _cache.Set<MVSimulationViewModel>("MV_ViewModel", formViewModel);

                // Store the person in the cache
                var person = BuildPerson(formViewModel);
                _cache.Set<MotorVehiclePerson>("MV_PERSON", person);

                // Run the simulation
                var simulationRequest = BuildRequest(formViewModel);
                var id = _requestHandler.Handle(simulationRequest);
                return RedirectToAction("Results", new { id });
            }
            return View("Form", formViewModel);
        }

        public IActionResult Results(Guid id) {
            var simResults = _simulationGetter.Get(id);
            var person = _cache.Get<MotorVehiclePerson>("MV_PERSON");
            var result = new MotorVehicleResultsViewModel(simResults, person);
            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private MotorVehiclePerson BuildPerson(MVSimulationViewModel vm) {
            var weeklySchedule = new MvoSchedule() {
                Hours = new List<HourSet>()
            };

            foreach (var vmHour in vm.Person.Hours) {
                weeklySchedule.Hours.Add(new HourSet(vmHour.HoursCmvo.Value, vmHour.HoursHmvo.Value, vmHour.HoursOther.Value, vmHour.IsHoliday));
            }

            var result = new MotorVehiclePerson() {
                Id = Guid.NewGuid(),
                WeeklySchedule =  weeklySchedule
            };

            return result;
        }

        private SimulationRequest<MotorVehicleSimulationCaseRequest> BuildRequest(MVSimulationViewModel vm) {
            return new SimulationRequest<MotorVehicleSimulationCaseRequest>() {
                BaseCaseRequest = new MotorVehicleSimulationCaseRequest() {
                    StandardCmvoDaily = vm.BaseCase.StandardCmvoDaily,
                    StandardCmvoWeekly = vm.BaseCase.StandardCmvoWeekly,
                    StandardOtherDaily = vm.BaseCase.StandardOtherDaily,
                    StandardOtherWeekly = vm.BaseCase.StandardOtherWeekly,
                    StandardHighwayWeekly = vm.BaseCase.StandardHighwayWeekly,
                    StandardHighwayReduction = vm.BaseCase.StandardHighwayReduction,
                    
                },
                VariantCaseRequest = new MotorVehicleSimulationCaseRequest() {
                    StandardCmvoDaily = vm.VariantCase.StandardCmvoDaily,
                    StandardCmvoWeekly = vm.VariantCase.StandardCmvoWeekly,
                    StandardOtherDaily = vm.VariantCase.StandardOtherDaily,
                    StandardOtherWeekly = vm.VariantCase.StandardOtherWeekly,
                    StandardHighwayWeekly = vm.VariantCase.StandardHighwayWeekly,
                    StandardHighwayReduction = vm.VariantCase.StandardHighwayReduction,
                },
            };
        }
    }
}
