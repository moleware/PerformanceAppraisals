using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGS_Enterprise.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        DGS_EnterpriseEntities Init();
    }
}
