using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace TiffinManagementService.API.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<TElement> ExecuteSql<TElement>(string commandText, params object[] parameters);

        void Insert(T entity);
    }
}