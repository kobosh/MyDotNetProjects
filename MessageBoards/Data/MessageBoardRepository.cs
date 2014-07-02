using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessageBoards.Data
{
    public class MessageBoardRepository:IMessageBoardRepository
    {
        MessageBoardContext _ctx;
        public MessageBoardRepository(MessageBoardContext ctx)
        {
            _ctx = ctx;
        }
        public IQueryable<Topic> GetTopics()
        {
            return _ctx.Topics;
        }

        public IQueryable<Reply> GetRepliesByTopic(int topicId)
        {
            var replies= _ctx.Replies .Where(p => p.TopicId==topicId );
            return replies;
        }


        public bool Save()
        {
            try {  return _ctx.SaveChanges()>0; }
            catch { return false; }
        }

        public bool AddTopic(Topic topic)
        {
            try { _ctx.Topics.Add(topic);
            return true;
            }
            catch { return false; }
        }


        public IQueryable<Topic> GetTopicsIncludingReplies()
        {
            return _ctx.Topics.Include("Replies");
        }


        public bool AddReply(Reply newReply)
        {
            try
            {
                _ctx.Replies.Add(newReply);
                return true;
            }
            catch { return false; }
 
        }
    }
}