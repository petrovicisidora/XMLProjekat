using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccommodationService.Core
{
    public interface IUnitOfWork : IDisposable
    {
        void Dispose();

    }
}
