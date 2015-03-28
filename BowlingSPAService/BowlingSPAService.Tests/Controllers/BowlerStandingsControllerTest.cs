using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BowlingSPAService.Model.EntityModels;
using BowlingSPAService.Repository.RepoTransactions;
using BowlingSPAService.WebAPI.Controllers.api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BowlingSPAService.Tests.Controllers
{
    [TestClass]
    public class BowlerStandingsControllerTest
    {
        private IList<Bowler> bowlers;

        [TestInitialize]
        public void Setup()
        {

        }

        [TestMethod]
        public void BowlerStandingsController_GetWithNoResultsFromRepository_ReturnsEmptyBowlingStats()
        {

            //Arrange
            var repositoryMock = new Mock<IUnitOfWork>();
            //Setup mock to dictate behavior of repository and will return list of bowlers when called:
            repositoryMock.Setup(x => x.Repository.GetQuery<Score>(It.IsAny<Expression<Func<Score, bool>>>())).Returns(It.IsAny<IQueryable<Score>>());
            //Create instance of BowlerStandingsControllerTest that will have mock repository injected; this is what will be used during the unit test
            var bowlerStandingsController = new BowlerStandingsController(repositoryMock.Object);

            //Act
            var result = bowlerStandingsController.Get(1,1);

            //Assert
            Assert.IsNotNull(result); // Test if null
            Assert.IsInstanceOfType(result, typeof(Score)); // Test type
            Assert.AreEqual(bowlers, result); //Test the return is identical to what we expected

        }
    }
}
