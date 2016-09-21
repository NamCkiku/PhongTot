using PhongTot.Entities.Models;
using PhongTot.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongTot.Repository.Repositories
{
    public interface IOtherInfoRepository : IRepository<OtherInfo>
    {
    }

    public class OtherInfoRepository : RepositoryBase<OtherInfo>, IOtherInfoRepository
    {
        public OtherInfoRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
