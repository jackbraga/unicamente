using Microsoft.Data.SqlClient;
using System.Data;
namespace Unicamente.Repository
{
    public class DefaultSqlConnectionFactory : IConnectionFactory
    {
        public IDbConnection Connection()
        {
            //return new SqlConnection("Data Source=LOCALHOST\\SQLEXPRESS;Integrated Security=True;Initial Catalog=OSKEM;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            return new SqlConnection("Data Source=SQL5112.site4now.net;Initial Catalog=db_aa2da6_oskem;User Id=db_aa2da6_oskem_admin;Password=Osk3m@2023");

        }
    }

    public interface IConnectionFactory
    {
        IDbConnection Connection();
    }
}
