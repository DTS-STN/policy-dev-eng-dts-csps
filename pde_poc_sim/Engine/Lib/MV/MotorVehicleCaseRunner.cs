using System.Collections.Generic;
using System.Linq;

using pde_poc_rule;
using pde_poc_sim.Engine.Interfaces;

namespace pde_poc_sim.Engine.Lib
{
    public class MotorVehicleCaseRunner : IRunCases<MotorVehicleSimulationCase, MotorVehiclePerson>
    {
        private readonly IBuildRules<MotorVehicleSimulationCase,  pde_poc_rule.MotorVehiclePerson> _ruleBuilder;
        
        private readonly IExecuteRules<pde_poc_rule.MotorVehiclePerson> _executor;

        public MotorVehicleCaseRunner(
            IBuildRules<MotorVehicleSimulationCase, pde_poc_rule.MotorVehiclePerson> ruleBuilder, 
            IExecuteRules<pde_poc_rule.MotorVehiclePerson> executor
        ) {
            _ruleBuilder = ruleBuilder;
            _executor = executor;
        }

        public SimulationCaseResult Run(MotorVehicleSimulationCase simulationCase, IEnumerable<MotorVehiclePerson> persons) {
            var result = new SimulationCaseResult();
            var personDict = persons.ToDictionary(x => x.Id);

            var rule = _ruleBuilder.Build(simulationCase);
            
            var rulePersons = persons.Select(x => {
                var hours = x.WeeklySchedule.Hours;

                var ruleHours = new List<pde_poc_rule.HourSet>();
                foreach (var h in x.WeeklySchedule.Hours) {
                    ruleHours.Add(
                        new pde_poc_rule.HourSet(h.HoursCmvo, h.HoursHmvo, h.HoursOther, h.IsHoliday)
                    );
                }

                return new pde_poc_rule.MotorVehiclePerson() {
                    Id = x.Id,
                    WeeklySchedule = new pde_poc_rule.MvoSchedule() {
                        Hours = ruleHours
                    },
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