using Data.DataAccess.Interface.BlogModule;
using Data.Database;
using Data.Model.BlogModule;
using Data.Model.UserModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataAccess.Implement.BlogModule
{
    public class VoteRepository : IVoteRepository
    {
        private readonly Context context;
        public VoteRepository(Context context)
        {
            this.context = context;
        }
        public Vote DownVote(Blog blog, User user)
        {
            var downVote = context.Votes.FirstOrDefault(x => x.UserId == user.Id && x.BlogId == blog.Id);
            if (downVote == null)
            {
                downVote = new Vote
                {
                    Id = Guid.NewGuid().ToString(),
                    UserId = user.Id,
                    User = user,
                    BlogId = blog.Id,
                    Blog = blog,
                    VoteType = VoteType.DOWNVOTE
                };
                context.Votes.Add(downVote);
                blog.Vote -= 1;
            }
            else if (downVote != null)
            {
                if (downVote.VoteType == VoteType.DOWNVOTE)
                {
                    context.Votes.Remove(downVote);
                    blog.Vote += 1;
                }
                else if (downVote.VoteType == VoteType.UPVOTE)
                {
                    downVote.VoteType = VoteType.DOWNVOTE;
                    blog.Vote -= 2;
                }
            }
            context.SaveChanges();
            return downVote;
        }

        public Vote UpVote(Blog blog, User user)
        {
            var upVote = context.Votes.FirstOrDefault(x => x.UserId == user.Id && x.BlogId == blog.Id);
            if (upVote == null)
            {
                upVote = new Vote
                {
                    Id = Guid.NewGuid().ToString(),
                    UserId = user.Id,
                    User = user,
                    BlogId = blog.Id,
                    Blog = blog,
                    VoteType = VoteType.UPVOTE
                };
                context.Votes.Add(upVote);
                blog.Vote += 1;
            }
            else if (upVote != null)
            {
                if (upVote.VoteType == VoteType.UPVOTE)
                {
                    context.Votes.Remove(upVote);
                    blog.Vote -= 1;
                }
                else if (upVote.VoteType == VoteType.DOWNVOTE)
                {
                    upVote.VoteType = VoteType.UPVOTE;
                    blog.Vote += 2;
                }
            }
            context.SaveChanges();
            return upVote;
        }
    }
}
