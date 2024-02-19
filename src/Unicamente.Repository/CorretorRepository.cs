using Dapper;
using Unicamente.Domain.Entities;
using Unicamente.Domain.Interfaces;

namespace Unicamente.Repository
{
    public class CorretorRepository : ICorretorRepository
    {
        private readonly IConnectionFactory _connection;
        public CorretorRepository(IConnectionFactory connectionFactory)
        {
            _connection = connectionFactory;
        }
        public int Add(Corretor classe)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Corretor> GetAll()
        {
            var sql = @"SELECT ID, Nome, Email, CPF, Contato,SituacaoCadastro
	                    FROM tbCorretor";

            using (var connection = _connection.Connection())
            {
                connection.Open();
                var listaCorretor = connection.Query<Corretor>(sql);

                return listaCorretor;
            }
        }

        public Corretor GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Corretor> GetByName(string texto)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            var sql = "DELETE FROM tbCorretor WHERE ID=@id";
            using (var connection = _connection.Connection())
            {
                connection.Open();
                connection.Execute(sql, new
                {
                    id
                });
            }
        }

        public void Update(Corretor classe)
        {
            throw new NotImplementedException();
        }
    }
}
