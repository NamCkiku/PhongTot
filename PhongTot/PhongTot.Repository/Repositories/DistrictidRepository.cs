using PhongTot.Entities.Models;
using PhongTot.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongTot.Repository.Repositories
{
    public interface IDistrictidRepository: IRepository<Districtid>
    {

    }
    public class DistrictidRepository : RepositoryBase<Districtid>, IDistrictidRepository
    {
        public DistrictidRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
