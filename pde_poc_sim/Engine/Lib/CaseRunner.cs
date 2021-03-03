using System.Collections.Generic;
using System.Linq;

using pde_poc_rule;

namespace pde_poc_sim.Engine.Lib
{
    public class CaseRunner : IRunCases
    {
        private readonly IBuildRules _ruleBuilder;
        private readonly ISimulateMaternityBenefits _simulator;

        public CaseRunner(IBuildRules ruleBuilder, ISimulateMaternityBenefits simulator) {
            _ruleBuilder = ruleBuilder;
            _simulator = simulator;
        }

        public SimulationCaseResult Run(SimulationCase simulationCase, List<Person> persons) {
            var result = new SimulationCaseResult();
            var personDict = persons.ToDictionary(x => x.Id);

            var rule = _ruleBuilder.Build(simulationCase);
            
            var rulePersons = persons.Select(x => new pde_poc_rule.Person() {
                Id = x.Id,
                UnemploymentRegionId = x.UnemploymentRegion.Id,
                WeeklyIncome = x.WeeklyIncome.Select(y => new pde_poc_rule.WeeklyIncome() {
                    StartDate = y.StartDate,
                    Income = y.Income
                }).ToList()
            }).ToList();

            var simResult = _simulator.Simulate(rule, rulePersons);

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