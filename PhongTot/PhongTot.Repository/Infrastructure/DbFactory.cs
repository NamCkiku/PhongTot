using PhongTot.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongTot.Repository.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private RoomsEntity dbContext;

        public RoomsEntity Init()
        {
            return dbContext ?? (dbContext = new RoomsEntity());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
