Policy Difference Engine - Proof of Concept

## Description

This project is the first of two phases for a policy difference engine prototype. 

It is a tool that will allow you to simulate changes to the maternity benefits formula using a simulated population generated from various anonymized data sources.

This first phase is a proof of concept that will demonstrate the concept and design, and will use randomized mock data. During development of phase 1, we will be researching and planning a more integrated technology architecture, which will be used for the development of phase 2. 


## Rules as Code

In addition to building a valuable simulation tool, the goal of this project is to build momentum on the idea of 'Rules as Code'. The rules are coded into a system, and any application that requires these rules can make use of it. This may be other simulation engines, eligibility engines, service desk tools, end-user facing tools, etc. The idea is that the rule is written in one place, a 'Rules Engine', so that there is no duplication of work on interpreting and implementing a written rule into code, promoting policy agility.


## Development

Deploy the web project (pde_poc_web) to the azure web app.

To publish:
- `cd pde_poc_web`
- `dotnet publish -c Release -o ./publish`
- Publish to the appropriate web app

There is a test project that contains tests for the Simulation engine and the Rules engine

To run tests, navigate to the test project folder (`cd pde_poc.Tests`) and run `dotnet test`

For code coverage, run `dotnet test --collect:"XPlat Code Coverage"`

This will generate a folder in the TestResults folder with a guid for a name. Copy that guid, and insert it into the following command, then run it:

`reportgenerator "-reports:TestResults\{INSERT-GUID-HERE}\coverage.cobertura.xml" "-targetdir:coveragereport" -reporttypes:Html`

This will generate a set of html files that will display code coverage in the browser. The test coverage files are not checked into source control, but a future goal is to integrate automated testing and coverage into the deployment pipeline.


## Upcoming Features

### Product Features
- Additional demographics data (will still be randomized)
- Aggregation by demographics (region, age, etc)
- Integration with an aggregation/visualization engine
- Ability to toggle the Employment/Best weeks values for the simulation


### Engineering Features
- Dev ops pipeline, with automated testing, code coverage, and automated deployment
- Further separation of code in the data layer for increased flexibility
- Integrating the Maternity Benefit Rule into a system such as OpenFisca and removing it from this project
