using PhongTot.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongTot.Repository.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        RoomsEntity Init();
    }
}
