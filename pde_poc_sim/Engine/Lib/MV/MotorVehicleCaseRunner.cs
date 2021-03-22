using System;
using System.Collections.Generic;
using System.Linq;

using pde_poc_sim.Engine.Interfaces;

namespace pde_poc_sim.Engine.Lib
{
    public class MotorVehicleCaseRunner : IRunCases<MotorVehicleSimulationCase, MotorVehiclePerson>
    {
        private readonly IExecuteRules<MotorVehicleSimulationCase, MotorVehiclePerson> _executor;

        public MotorVehicleCaseRunner(
            IExecuteRules<MotorVehicleSimulationCase, MotorVehiclePerson> executor
        ) {
            _executor = executor;
        }

        public SimulationCaseResult Run(MotorVehicleSimulationCase simulationCase, IEnumerable<MotorVehiclePerson> persons) {
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