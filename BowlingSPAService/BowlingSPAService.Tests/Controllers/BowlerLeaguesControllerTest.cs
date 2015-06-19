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
    public class BowlerLeaguesControllerTest
    {

        private IList<Team> teams;

        [TestInitialize]
        public void Setup()
        {

            teams = new List<Team>()
            {
                new Team()
                {
                    Id = 1,
                    Name = "Split Happens",
                    Scores = new List<Score>
                    {
                        new Score()
                        {
                            BowlerId = 1,
                            Pins = 300
                        }
                    }
                },
                new Team()
                {
                    Id = 2,
                    Name = "The 1st Place Team",
                    Scores = new List<Score>
                    {
                        new Score()
                        {
                            BowlerId = 1,
                            Pins = 250
                        }
                    }
                }
            };

        }


        [TestMethod]
        public void BowlerLeaguesController_GetWithValidBowlerId_ReturnsSingleBowlers()
        {
            //Arrange
            const int bowlerId = 1;
            var repositoryMock = new Mock<IUnitOfWork>();
            //Setup mock to dictate behavior of repository and it will return a list of teams when called:
            repositoryMock.Setup(x => x.Repository.GetQuery<Team>(It.IsAny<Expression<Func<Team, bool>>>())).Returns(teams.AsQueryable());
            //Create instance of bowler leagues controller that will have mock repository injected; this is what will be used during the unit test
            var bowlerLeaguesController = new BowlerLeaguesController(repositoryMock.Object);


            //Act
            var result = bowlerLeaguesController.Get(bowlerId);

            //Assert
            repositoryMock.Verify(x => x.Repository.GetQuery<Team>(It.IsAny<Expression<Func<Team, bool>>>()), Times.Once); // Ensure repository was called
            Assert.IsNotNull(result); // Test to make sure return is not null
            Assert.IsInstanceOfType(result, typeof(IList<Team>));  // Test type
            CollectionAssert.AreEqual(result.ToList(), teams.ToList()); // Test the return collection is identical to what we expected

        }
    }
}
