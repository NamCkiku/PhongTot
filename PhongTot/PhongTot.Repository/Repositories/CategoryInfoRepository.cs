using PhongTot.Entities.Models;
using PhongTot.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongTot.Repository.Repositories
{
    public interface ICategoryInfoRepository : IRepository<CategoryInfo>
    {
    }

    public class CategoryInfoRepository : RepositoryBase<CategoryInfo>, ICategoryInfoRepository
    {
        public CategoryInfoRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
