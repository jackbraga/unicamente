using Microsoft.Data.SqlClient;
using System.Data;
namespace Unicamente.Repository
{
    public class DefaultSqlConnectionFactory : IConnectionFactory
    {
        public IDbConnection Connection()
        {
            //return new SqlConnection("Data Source=LOCALHOST\\SQLEXPRESS;Integrated Security=True;Initial Catalog=OSKEM;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            return new SqlConnection("Data Source=LOCALHOST\\SQLEXPRESS;Integrated Security=True;Initial Catalog=Unicamente;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        }
    }

    public interface IConnectionFactory
    {
        IDbConnection Connection();
    }
}
