using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BowlingSPAService.Model.EntityModels;
using BowlingSPAService.Repository.RepoTransactions;

namespace BowlingSPAService.WebAPI.Controllers.api
{
    public class BowlerController : ApiController
    {

        private readonly IUnitOfWork unitOfWork;

        public BowlerController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [Route("Bowler")]
        public IEnumerable<Bowler> Get()
        {
            return this.unitOfWork.Repository.GetAll<Bowler>();
        }

        /// <summary>
        /// Returns a collection of bowler's that match the name value provided 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Bowler/{name}")]
        public IEnumerable<Bowler> Get(string name)
        {
            return this.unitOfWork.Repository.GetQuery<Bowler>(x => x.FirstName.Contains(name) || x.LastName.Contains(name)).ToList();
        }

    }
}