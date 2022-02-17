using Data.DataAccess.Interface.BlogModule;
using Data.Model.BlogModule;
using Data.Model.UserModule;
using Service.Interface.BlogModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implement.BlogModule
{
    public class VoteService : IVoteService
    {
        private readonly IVoteRepository voteRepository;
        public VoteService(IVoteRepository voteRepository)
        {
            this.voteRepository = voteRepository;
        }
        public Vote DownVote(Blog blog, User user)
        {
            return voteRepository.DownVote(blog, user);
        }

        public Vote UpVote(Blog blog, User user)
        {
            return voteRepository.UpVote(blog, user);
        }
    }
}
