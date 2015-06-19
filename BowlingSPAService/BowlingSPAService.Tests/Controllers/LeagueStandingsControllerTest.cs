using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BowlingSPAService.Model.DomainModels;
using BowlingSPAService.Model.EntityModels;
using BowlingSPAService.Repository.RepoTransactions;
using BowlingSPAService.WebAPI.Controllers.api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BowlingSPAService.Tests.Controllers
{
    [TestClass]
    public class LeagueStandingsControllerTest
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
                    LeagueId = 1,
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
                    LeagueId = 1,
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
        public void LeagueStandingsController_Get_ReturnsValidLeagueStats()
        {
            //Arrange
            const int leagueId = 1;
            var repositoryMock = new Mock<IUnitOfWork>();            
            //Setup mock to dictate behavior of repository and it will return a list of teams when called:
            repositoryMock.Setup(x => x.Repository.GetQuery<Team>(It.IsAny<Expression<Func<Team, bool>>>())).Returns(teams.AsQueryable());
            //Create instance of leagues standings controller that will have mock repository injected; this is what will be used during the unit test
            var leaguesStandingsController = new LeagueStandingsController(repositoryMock.Object);


            //Act
            var result = leaguesStandingsController.Get(leagueId);

            //Assert
            repositoryMock.Verify(x => x.Repository.GetQuery<Team>(It.IsAny<Expression<Func<Team, bool>>>()), Times.Once); // Ensure repository was called
            Assert.IsNotNull(result); // Test to make sure return is not null
            Assert.IsInstanceOfType(result, typeof(IEnumerable<LeagueStats>));  // Test type           
            Assert.AreNotEqual(result.FirstOrDefault().Position, 0);  //Ensure the stats were actually calculated and the 'Position' property has a non-zero value
        }

    }
}
