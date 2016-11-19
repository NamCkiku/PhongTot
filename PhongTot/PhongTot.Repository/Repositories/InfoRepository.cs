using PhongTot.Entities.Models;
using PhongTot.Entities.ModelView;
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
        IEnumerable<InfoViewModel> GetAllListInfoJoin();
    }
    public class InfoRepository : RepositoryBase<Info>, IInfoRepository
    {
        public InfoRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public IEnumerable<InfoViewModel> GetAllListInfoJoin()
        {
            var query = (from p in DbContext.Infoes
                         join s in DbContext.CategoryInfoes on p.CategoryID equals s.ID
                         join to in DbContext.Provinces on p.Provinceid equals to.provinceid
                         select new InfoViewModel
                         {
                             ID=p.ID,
                             Name = p.Name,
                             Price = p.Price,
                             Acreage = p.Acreage,
                             CategoryName = s.Name,
                             ProvinceName = to.name,
                             CreateDate = p.CreateDate,
                             Image = p.Image,
                         }).ToList();
            return query;
        }
    }
}
