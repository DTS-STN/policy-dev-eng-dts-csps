using System;
using System.Collections.Generic;
using System.Linq;

using pde_poc_sim.Engine;
using pde_poc_sim.Engine.Interfaces;

using pde_poc_sim.OpenFisca.DailyRequest;
using pde_poc_sim.OpenFisca.AggregateRequest;

using pde_poc_sim.OpenFisca;

namespace pde_poc_sim.Engine.Lib
{
    public class MotorVehicleRuleExecutor : IExecuteRules<MotorVehicleSimulationCase, MotorVehiclePerson>
    {
        private readonly IOpenFisca _openFiscaLib;
        private readonly IBuildDailyRequests _dailyRequestBuilder;
        private readonly IBuildAggregateRequests _aggregateRequestBuilder;

        public MotorVehicleRuleExecutor(
            IOpenFisca openFiscaLib,
            IBuildDailyRequests dailyRequestBuilder,
            IBuildAggregateRequests aggregateRequestBuilder
            ) {
            _openFiscaLib = openFiscaLib;
            _dailyRequestBuilder = dailyRequestBuilder;
            _aggregateRequestBuilder = aggregateRequestBuilder;
        }

        public decimal Execute(MotorVehicleSimulationCase rule, MotorVehiclePerson person) {
            
            // REQUEST 1 : DAILIES
            var dailyRequest = _dailyRequestBuilder.Build(rule, person);
            var dailyResponse = _openFiscaLib.Calculate(dailyRequest);
            var dailyResult = ExtractDailyResult(dailyResponse);

            // REQUEST 2: WEEKLY/AGGREGATION
            var aggregateRequest = _aggregateRequestBuilder.Build(rule, person, dailyResult);
            var aggregateResponse = _openFiscaLib.Calculate(aggregateRequest);
            var aggregateResult = ExtractAggregateResult(aggregateResponse);

            return aggregateResult;
        }       

        // Could move the extractors into interfaces as well...

        private decimal ExtractDailyResult(OpenFiscaResponse response) {
            decimal totalDailyHours = 0m;
            foreach (var day in response.persons) {
                var dayResult = day.Value;
                var valueDict = dayResult["calculate_overtime_daily__overtime_worked_hours"];
                var fullValue = Convert.ToDecimal(valueDict.Values.First());
                totalDailyHours += fullValue;
            }
            return totalDailyHours;
        } 

        private decimal ExtractAggregateResult(OpenFiscaResponse response) {
            // decimal totalDailyHours = 0m;
            // foreach (var day in response.persons) {
            //     var dayResult = day.Value;
            //     var valueDict = dayResult["calculate_overtime_daily__overtime_worked_hours"];
            //     var fullValue = Convert.ToDecimal(valueDict.Values.First());
            //     totalDailyHours += fullValue;
            // }
            // return totalDailyHours;
            return 0;
        } 

    }
}