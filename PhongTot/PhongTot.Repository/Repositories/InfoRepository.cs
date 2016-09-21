using PhongTot.Entities.Models;
using PhongTot.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongTot.Repository.Repositories
{
    public interface IInfoRepository : IRepository<Info>
    {

    }
    public class InfoRepository : RepositoryBase<Info>, IInfoRepository
    {
        public InfoRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
