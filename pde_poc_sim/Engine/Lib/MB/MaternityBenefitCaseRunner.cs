using System.Collections.Generic;
using System.Linq;

using pde_poc_sim.Engine.Interfaces;

namespace pde_poc_sim.Engine.Lib
{
    public class MaternityBenefitCaseRunner : IRunCases<MaternityBenefitSimulationCase, MaternityBenefitPerson>
    {
        private readonly IExecuteRules<MaternityBenefitSimulationCase, MaternityBenefitPerson> _executor;

        public MaternityBenefitCaseRunner(
            IExecuteRules<MaternityBenefitSimulationCase, MaternityBenefitPerson> executor
        ) {
            _executor = executor;
        }

        public SimulationCaseResult Run(MaternityBenefitSimulationCase simulationCase, IEnumerable<MaternityBenefitPerson> persons) {
            var result = new SimulationCaseResult();
            var personDict = persons.ToDictionary(x => x.Id);

            foreach (var person in persons) {
                var amount = _executor.Execute(simulationCase, person);
                var nextResult = new PersonCaseResult() {
                    Person = personDict[person.Id],
                    Amount = amount
                };
                result.ResultSet.Add(person.Id, nextResult);
            }

            return result;
        }
    }
}