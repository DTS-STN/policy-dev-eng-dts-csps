using pde_poc_sim.Engine.Interfaces;
using pde_poc_sim.OpenFisca;

namespace pde_poc_sim.Engine.Lib
{
    public class MotorVehicleRuleExecutor : IExecuteRules<MotorVehicleSimulationCase, MotorVehiclePerson>
    {
        private readonly IOpenFisca _openFiscaLib;
        private readonly IBuildDailyRequests _dailyRequestBuilder;
        private readonly IBuildAggregateRequests _aggregateRequestBuilder;
        private readonly IExtractDailyResults _dailyResultExtractor;
        private readonly IExtractAggregateResults _aggregateResultExtractor;

        public MotorVehicleRuleExecutor(
            IOpenFisca openFiscaLib,
            IBuildDailyRequests dailyRequestBuilder,
            IBuildAggregateRequests aggregateRequestBuilder,
            IExtractDailyResults dailyResultExtractor,
            IExtractAggregateResults aggregateResultExtractor
            ) {
            _openFiscaLib = openFiscaLib;
            _dailyRequestBuilder = dailyRequestBuilder;
            _aggregateRequestBuilder = aggregateRequestBuilder;
            _dailyResultExtractor = dailyResultExtractor;
            _aggregateResultExtractor = aggregateResultExtractor;
        }

        public decimal Execute(MotorVehicleSimulationCase rule, MotorVehiclePerson person) {
            
            // REQUEST 1 : DAILIES
            var dailyRequest = _dailyRequestBuilder.Build(rule, person);
            var dailyResponse = _openFiscaLib.Calculate(dailyRequest);
            var dailyResult = _dailyResultExtractor.Extract(dailyResponse);

            // REQUEST 2: WEEKLY/AGGREGATION
            var aggregateRequest = _aggregateRequestBuilder.Build(rule, person, dailyResult);
            var aggregateResponse = _openFiscaLib.Calculate(aggregateRequest);
            var aggregateResult = _aggregateResultExtractor.Extract(aggregateResponse);

            return aggregateResult;
        }       

    }
}