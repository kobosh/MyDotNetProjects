using MessageBoards.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MessageBoards.Controllers
{
    public class TopicsController : ApiController
    {
        public TopicsController(MessageBoards.Data.IMessageBoardRepository repo)
        {
            _repo = repo;
        }

      public  IEnumerable<Topic> Get(bool includeReplies=false )
        {
            IQueryable<Topic> results;
            if (includeReplies==true)
            { results = _repo.GetTopicsIncludingReplies(); }

            else
            { results = _repo.GetTopics(); }
                 results.OrderByDescending(i => i.Created)
                         .Take(50)
                         .ToList();
                
                

            return results ;

        }

      public HttpResponseMessage Post([FromBody] Topic newTopic)
      {
          if(newTopic.Created==default(DateTime))
          {
              newTopic.Created = DateTime.Now;
          }
          if(_repo.AddTopic(newTopic)&&_repo.Save())
          {

              return Request.CreateResponse(HttpStatusCode.Created, newTopic);
          }

          return Request.CreateResponse(HttpStatusCode.BadRequest);
      
      }

        public IMessageBoardRepository _repo { get; set; }
    }
}
