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
    public class BowlerControllerTest
    {

        private IList<Bowler> bowlers;

        [TestInitialize]
        public void Setup()
        {

            bowlers = new List<Bowler>()
            {
                new Bowler()
                {
                    Id = 1,
                    FirstName = "Allen",
                    LastName = "Conway",
                    Average = 205,
                    Handicap = 18                    
                },
                new Bowler()
                {
                    Id = 2,
                    FirstName = "Craig",
                    LastName = "Sunshine",
                    Average = 185,
                    Handicap = 38 
                }
            };

        }

        [TestMethod]
        public void BowlerController_Get_ReturnsAllBowlers()
        {
            //Arrange
            var repositoryMock = new Mock<IUnitOfWork>();
            //Setup mock to dictate behavior of repository and it will return a list of bowlers when called:
            repositoryMock.Setup(x => x.Repository.GetAll<Bowler>()).Returns(bowlers);
            //Create instance of bowler controller that will have mock repository injected; this is what will be used during the unit test
            var bowlerController = new BowlerController(repositoryMock.Object);

            //Act
            var result = bowlerController.Get();

            //Assert
            repositoryMock.Verify(x => x.Repository.GetAll<Bowler>(), Times.Once); // Ensure repository was called
            Assert.IsNotNull(result); // Test to make sure return is not null
            Assert.IsInstanceOfType(result, typeof(IList<Bowler>));  // Test type
            CollectionAssert.AreEqual(result.ToList(), bowlers.ToList()); // Test the return is identical to what we expected

        }

        [TestMethod]
        public void BowlerController_GetWithValidName_ReturnsSingleBowlers()
        {
            //Arrange
            const string bowlerName = "Allen";
            var repositoryMock = new Mock<IUnitOfWork>();
            var singleBowler = bowlers.Where(x => x.FirstName == bowlerName).AsQueryable();
            //Setup mock to dictate behavior of repository and it will return single bowler matching name used in test when called:
            repositoryMock.Setup(x => x.Repository.GetQuery<Bowler>(It.IsAny<Expression<Func<Bowler, bool>>>())).Returns(singleBowler);
            //Create instance of bowler controller that will have mock repository injected; this is what will be used during the unit test
            var bowlerController = new BowlerController(repositoryMock.Object);


            //Act
            var result = bowlerController.Get(bowlerName);

            //Assert
            repositoryMock.Verify(x => x.Repository.GetQuery<Bowler>(It.IsAny<Expression<Func<Bowler, bool>>>()), Times.Once); // Ensure repository was called
            Assert.IsNotNull(result); // Test to make sure return is not null
            Assert.IsInstanceOfType(result, typeof(IList<Bowler>));  // Test type
            CollectionAssert.AreEqual(result.ToList(), singleBowler.ToList()); // Test the return collection (with a single bowler) is identical to what we expected

        }
       
    }
}
