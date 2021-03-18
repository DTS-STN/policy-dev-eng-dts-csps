using System.Collections.Generic;
using System.Linq;

using pde_poc_rule;
using pde_poc_sim.Engine.Interfaces;

namespace pde_poc_sim.Engine.Lib
{
    public class MaternityBenefitCaseRunner : IRunCases<MaternityBenefitSimulationCase, MaternityBenefitPerson>
    {
        private readonly IBuildRules<MaternityBenefitSimulationCase, pde_poc_rule.MaternityBenefitPerson> _ruleBuilder;
        
        private readonly IExecuteRules<pde_poc_rule.MaternityBenefitPerson> _executor;

        public MaternityBenefitCaseRunner(
            IBuildRules<MaternityBenefitSimulationCase, pde_poc_rule.MaternityBenefitPerson> ruleBuilder, 
            IExecuteRules<pde_poc_rule.MaternityBenefitPerson> executor
        ) {
            _ruleBuilder = ruleBuilder;
            _executor = executor;
        }

        public SimulationCaseResult Run(MaternityBenefitSimulationCase simulationCase, IEnumerable<MaternityBenefitPerson> persons) {
            var result = new SimulationCaseResult();
            var personDict = persons.ToDictionary(x => x.Id);

            var rule = _ruleBuilder.Build(simulationCase);
            
            var rulePersons = persons.Select(x => {
                return new pde_poc_rule.MaternityBenefitPerson() {
                    Id = x.Id,
                    UnemploymentRegionId = x.UnemploymentRegion.Id,
                    WeeklyIncome = x.WeeklyIncome.Select(y => new pde_poc_rule.WeeklyIncome() {
                        StartDate = y.StartDate,
                        Income = y.Income
                    }).ToList()
                };
            }).ToList();

            var simResult = _executor.Execute(rule, rulePersons);

            foreach (var entry in simResult) {
                var nextResult = new PersonCaseResult() {
                    Person = personDict[entry.Key],
                    Amount = entry.Value
                };
                result.ResultSet.Add(entry.Key, nextResult);
            }

            return result;
        }
    }
}