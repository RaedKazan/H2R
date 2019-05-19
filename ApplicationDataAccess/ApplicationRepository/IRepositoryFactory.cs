using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDataAccess.ApplicationRepository
{
    public interface IRepositoryFactory
    {
        IRepository<T> GetRepository<T>() where T : class;
    }
}
