using PhongTot.Entities.Models;
using PhongTot.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongTot.Repository.Repositories
{
    public interface IWardidRepository : IRepository<Wardid>
    {
    }

    public class WardidRepository : RepositoryBase<Wardid>, IWardidRepository
    {
        public WardidRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
