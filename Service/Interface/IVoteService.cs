using Data.Model.BlogModule;
using Data.Model.UserModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IVoteService
    {
        public Vote UpVote(Blog blog, User user);
        public Vote DownVote(Blog blog, User user);
    }
}
