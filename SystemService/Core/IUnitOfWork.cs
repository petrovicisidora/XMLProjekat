using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemService.Core
{
    interface IUnitOfWork : IDisposable
    {
        int Complete();
        void Dispose();
    }
}
