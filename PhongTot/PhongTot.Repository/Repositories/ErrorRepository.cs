﻿using PhongTot.Entities.Models;
using PhongTot.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongTot.Repository.Repositories
{
    public interface IErrorRepository : IRepository<Error>
    {

    }
    class ErrorRepository : RepositoryBase<Error>, IErrorRepository
    {
        public ErrorRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
