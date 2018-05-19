using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;

namespace TiffinManagementService.API.Repository
{
    public class Repository : IRepository
    {
        private readonly DbContext _ctx;
        private readonly string _cs;

        public Repository()
        {
            _cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            _ctx = new DbContext(_cs);
        }

        public IEnumerable<TElement> ExecuteSql<TElement>(string commandText, params object[] parameters)
        {
            if (parameters == null && parameters.Length <= 0)
                return _ctx.Database.SqlQuery<TElement>(commandText, parameters);

            var count = 0;
            foreach (var param in parameters)
            {
                var p = param as DbParameter;

                if (p == null)
                    throw new Exception("Invalid parameter");

                commandText += count == 0 ? " " : ",";

                commandText += '@' + p.ParameterName;

                count++;
            }

            return _ctx.Database.SqlQuery<TElement>(commandText, parameters);
        }
    }

}