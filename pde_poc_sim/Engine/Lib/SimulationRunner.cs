using System.Collections.Generic;

namespace pde_poc_sim.Engine.Lib
{
    public class SimulationRunner : IRunSimulations
    {
        private readonly IRunCases _caseRunner;
        private readonly IJoinResults _joiner;

        public SimulationRunner(
            IRunCases caseRunner,
            IJoinResults joiner
        ) {
            _caseRunner = caseRunner;
            _joiner = joiner;
        }

        public SimulationResult Run(Simulation simulation, List<Person> persons) {
            // Run base case
            var baseResult = _caseRunner.Run(simulation.BaseCase, persons);

            // Run variant case
            var variantResult = _caseRunner.Run(simulation.VariantCase, persons);

            // Join Results
            var personResults = _joiner.Join(baseResult, variantResult);

            return new SimulationResult() {
                PersonResults = personResults
            };
        }
    }
}