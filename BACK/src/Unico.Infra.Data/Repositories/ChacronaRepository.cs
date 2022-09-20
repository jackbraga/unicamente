using Dapper;
using Unico.Domain.Entidades;
using Unico.Domain.Interfaces;

namespace Unico.Infra.Data.Repositories
{
    public class ChacronaRepository : IChacronaRepository
    {
        private readonly IConnectionFactory _connection;

        public ChacronaRepository(IConnectionFactory connection)
        {
            _connection = connection;
        }
        public Chacrona Add(Chacrona objeto)
        {
            string sql = "INSERT INTO tbChacrona(Descricao,Observacao,Imagem) VALUES(@descricao,@observacao,@imagem) ";

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


        public Chacrona Update(Chacrona objeto)
        {
            string sql = "UPDATE tbChacrona SET Descricao=@descricao,Observacao=@observacao,Imagem=@imagem " +
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

        public IEnumerable<Chacrona> GetAll()
        {
            string sql = "SELECT A.ID, A.Descricao, A.Observacao, A.Imagem " +
           "FROM tbChacrona AS A " +
           "ORDER BY 1; ";

            using (var connection = _connection.Connection())
            {
                connection.Open();
                return connection.Query<Chacrona>(sql);
            }
        }


        public Task<IEnumerable<Chacrona>> GetAllAsync()
        {
            string sql = "SELECT A.ID, A.Descricao " +
        "FROM tbChacrona AS A " +
        "ORDER BY 1; ";

            using (var connection = _connection.Connection())
            {
                connection.Open();
                return connection.QueryAsync<Chacrona>(sql);
            }
        }

        public Chacrona GetById(int? id)
        {
            string sql = "SELECT A.ID, A.Descricao, A.Imagem, A.Observacao " +
                            "FROM tbChacrona AS A " +
                            "WHERE ID=@id; ";

            using (var connection = _connection.Connection())
            {
                connection.Open();
                return connection.QuerySingle<Chacrona>(sql, new
                {
                    id = id
                });
            }
        }

        public IEnumerable<Chacrona> GetByName(string texto)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            string sql = "DELETE FROM tbChacrona WHERE ID=@id";
            using (var connection = _connection.Connection())
            {
                connection.Open();
                connection.Query<Chacrona>(sql, new
                {
                    id = id
                });
            }
        }



    }
}