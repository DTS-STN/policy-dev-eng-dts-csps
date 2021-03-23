// using System;
// using System.Collections.Generic;
// using Xunit;
// using FakeItEasy;

// using pde_poc_rule;

// namespace pde_poc.Tests
// {
//     public class MaternityBenefitSimulatorTest
//     {
//         [Fact]
//         public void ShouldWorkNormally()
//         {
//             // Arrange
//             var rule = A.Fake<IRule>();
//             A.CallTo(() => rule.Calculate(A<Person>._)).Returns(5m);
//             var sut = new MaternityBenefitSimulator();

//             // Act
//             var persons = GeneratePersons(10);
//             var result = sut.Simulate(rule, persons);

//             // Assert
//             Assert.Equal(10, result.Count);
//             Assert.Equal(5m, result[persons[0].Id]);
//         }


//         private List<Person> GeneratePersons(int amount) {
//             var result = new List<Person>();

//             for (int i = 0; i < amount; i++) {
//                 var person = A.Fake<Person>();
//                 person.Id = Guid.NewGuid();
//                 result.Add(person);
//             }

//             return result;
//         }
//     }
// }
