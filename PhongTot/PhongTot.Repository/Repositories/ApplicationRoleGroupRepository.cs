using PhongTot.Entities.Models;
using PhongTot.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongTot.Repository.Repositories
{
    public interface IApplicationRoleGroupRepository : IRepository<ApplicationRoleGroup>
    {

    }
    public class ApplicationRoleGroupRepository : RepositoryBase<ApplicationRoleGroup>, IApplicationRoleGroupRepository
    {
        public ApplicationRoleGroupRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
