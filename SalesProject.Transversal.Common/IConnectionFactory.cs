using System.Data;

namespace SalesProject.Transversal.Common
{
    public  interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
       
    }
}
