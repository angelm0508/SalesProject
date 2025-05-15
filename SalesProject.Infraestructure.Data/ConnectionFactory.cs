using SalesProject.Domain.Entity.Models;
using SalesProject.Transversal.Common;
using System.Data;

namespace SalesProject.Infraestructure.Data
{
    public class ConnectionFactory : IConnectionFactory
    {
        public IDbConnection GetConnection
        {
            get
            {
                var context = new ApiDbContext();
                return (IDbConnection)context;
            }
        }

    }
}