using PhongTot.Entities.Models;
using PhongTot.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongTot.Repository.Repositories
{
    public interface ICategoryOtherInfoRepository : IRepository<CategoryOtherInfo>
    {
    }

    public class CategoryOtherInfoRepository : RepositoryBase<CategoryOtherInfo>, ICategoryOtherInfoRepository
    {
        public CategoryOtherInfoRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
