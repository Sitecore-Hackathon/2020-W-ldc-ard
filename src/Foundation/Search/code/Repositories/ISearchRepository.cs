using Sitecore.XA.Foundation.RenderingVariants.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hackathon.Boilerplate.Foundation.Search.Models;

namespace Hackathon.Boilerplate.Feature.Account.Repositories
{
   public interface ISearchRepository 
   {
       SearchResultResponse GetAccounts(SearchFilter filter);
   }
}
