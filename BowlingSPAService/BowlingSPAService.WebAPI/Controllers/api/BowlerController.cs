using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BowlingSPAService.Model.EntityModels;
using BowlingSPAService.Repository.RepoTransactions;

namespace BowlingSPAService.WebAPI.Controllers.api
{
    [RoutePrefix("Bowler")]
    public class BowlerController : ApiController
    {

        private readonly IUnitOfWork unitOfWork;

        public BowlerController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [Route("")]
        public IEnumerable<Bowler> Get()
        {
            return this.unitOfWork.Repository.GetAll<Bowler>();
        }

        /// <summary>
        /// Returns a collection of bowler's that match the name value provided 
        /// </summary>        
        /// <param name="name" type="string"></param>
        /// <returns></returns>
        [Route("")]
        public IEnumerable<Bowler> Get(string name)
        {
            return this.unitOfWork.Repository.GetQuery<Bowler>(x => x.FirstName.Contains(name) || x.LastName.Contains(name))
                                                               .Where(y => y.Scores.Any(z => z.Team != null)).ToList();
        }

        /// <summary>
        /// Adds the bowler information to the database and returns the newly created entity with updated ID representing the added resource
        /// </summary>
        /// <param name="bowler" type="Bowler"></param>
        /// <returns>Bowler</returns>
        [Route("")]
        public HttpResponseMessage Post(Bowler bowler)
        {
            if (bowler == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not read bowler information from the request");
            }

            var result = this.unitOfWork.Repository.Add(bowler);
            this.unitOfWork.Save();
            if (result != null && result.Id != 0)
            {
                return Request.CreateResponse(HttpStatusCode.Created, result);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not save to the database.");
            }
                        
        }

    }
}