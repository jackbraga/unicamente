using System.Data;
using System.Data.SqlClient;

namespace Unico.Infra.Data
{
    public class DefaultSqlConnectionFactory : IConnectionFactory
    {
        public IDbConnection Connection()
        {
            return new SqlConnection("Data Source=.\\Sqlexpress;Initial Catalog=UNICO;User Id=sa; Password=lanchonete");
        }
    }
}