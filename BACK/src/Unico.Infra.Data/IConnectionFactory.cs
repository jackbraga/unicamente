using System.Data;

namespace Unico.Infra.Data
{
    public interface IConnectionFactory
    {
         IDbConnection Connection();
    }
}