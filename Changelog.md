## Changelog

### Feb 26, 2021
- Added aggregation functionality by region and showing it in the Results View
- Refactored some library code along Test-Driven design principles
- More library tests

### Feb 24, 2021
- Added a test project (pde_poc.Tests)
- Added some preliminary tests around the pde_poc_rule project and the pde_poc_sim project
- Minor refactoring on pde_poc_sim to make it more testable


### Feb 23, 2021
- Separated code into separate projects within a solution file
    - Web project (pde_poc_web) contains the front-end MVC code
    - Simulation Engine project (pde_poc_sim) contains the simulation logic and data access
    - Rule Engine project (pde_poc_rule) contains the rule calculation. The idea is that this could be swapped out with a generic rules engine, such as OpenFisca
    - Rules test project (pde_poc_rule_test) contains tests for the rules project. Will add much more to this and will create a separate project for the simulation engine tests 


### Feb 22, 2021
- Cleaner separation of code and addition of more interfaces
- User can now name a simulation
- User can now view all past simulations
- User can now alter both the base and variant parameters for the rule
- More varied mock data


### Feb 16, 2021
- Initial commit
- Basic maternity benefit calculation
- Form allowing a user to create a variant rule for the calculation
- Mock data from a Postgres database to create a simulated population
- Simulation engine that runs the population through both sets of rules
- Page that shows basic aggregated results and individual results
