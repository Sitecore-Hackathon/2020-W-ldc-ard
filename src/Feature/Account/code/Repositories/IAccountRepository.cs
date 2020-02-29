using Sitecore.XA.Foundation.RenderingVariants.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hackathon.Boilerplate.Feature.Account.Models;
using Hackathon.Boilerplate.Foundation.Search.Models;

namespace Hackathon.Boilerplate.Feature.Account.Repositories
{
   public interface IAccountRepository : IVariantsRepository
    {
        SearchResultResponse GetAccounts(AccountListType type, AccountContext context, ISearchRepository repository);
    }
}
