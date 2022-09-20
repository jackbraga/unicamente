using Dapper;
using Unico.Domain.Entidades;
using Unico.Domain.Interfaces;

namespace Unico.Infra.Data.Repositories
{
    public class MaririRepository : IMaririRepository
    {
        private readonly IConnectionFactory _connection;

        public MaririRepository(IConnectionFactory connection)
        {
            _connection = connection;
        }
        public Mariri Add(Mariri objeto)
        {
            string sql = "INSERT INTO tbMariri(Descricao,Observacao,Imagem) VALUES(@descricao,@observacao,@imagem) ";
 
            using (var connection = _connection.Connection())
            {
                connection.Open();
                connection.Query<Mariri>(sql, new
                {
                    descricao = objeto.Descricao,
                    observacao = objeto.Observacao,
                    imagem = objeto.Imagem
                });
                return objeto;
            }

        }


        public Mariri Update(Mariri objeto)
        {
            string sql = "UPDATE tbMariri SET Descricao=@descricao,Observacao=@observacao,Imagem=@imagem " +
             " WHERE ID=@id";
            using (var connection = _connection.Connection())
            {
                connection.Open();
                connection.Query<Mariri>(sql, new
                {
                    descricao = objeto.Descricao,
                    observacao = objeto.Observacao,
                    imagem = objeto.Imagem,
                    id = objeto.Id
                });
                return objeto;
            }
        }

        public IEnumerable<Mariri> GetAll()
        {
            string sql = "SELECT A.ID, A.Descricao, A.Observacao, A.Imagem " +
           "FROM tbMariri AS A " +
           "ORDER BY 1; ";

            using (var connection = _connection.Connection())
            {
                connection.Open();
                return connection.Query<Mariri>(sql);
            }
        }


        public Task<IEnumerable<Mariri>> GetAllAsync()
        {
            string sql = "SELECT A.ID, A.Descricao " +
        "FROM tbMariri AS A " +
        "ORDER BY 1; ";

            using (var connection = _connection.Connection())
            {
                connection.Open();
                return connection.QueryAsync<Mariri>(sql);
            }
        }

        public Mariri GetById(int? id)
        {
            string sql = "SELECT A.ID, A.Descricao, A.Imagem, A.Observacao " +
                            "FROM tbMariri AS A " +
                            "WHERE ID=@id; ";

            using (var connection = _connection.Connection())
            {
                connection.Open();
                return connection.QuerySingle<Mariri>(sql, new
                {
                    id = id
                }) ;
            }
        }

        public IEnumerable<Mariri> GetByName(string texto)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            string sql = "DELETE FROM tbMariri WHERE ID=@id";
            using (var connection = _connection.Connection())
            {
                connection.Open();
                connection.Query<Mariri>(sql, new
                {
                    id = id
                });
            }
        }



    }
}