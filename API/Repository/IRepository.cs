using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiffinManagementService.API.Repository
{
    public interface IRepository
    {
        IEnumerable<TElement> ExecuteSql<TElement>(string commandText, params object[] parameters);
    }
}